using System;
using Plugin.Geolocator;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using BigCat.Model;
using Xamarin.Forms;

namespace BigCat
{
    public partial class CustomVision : ContentPage
    {
        public CustomVision()
        {
            InitializeComponent();
        }

        private async void loadCamera(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                PhotoSize = PhotoSize.Medium,
                Directory = "Sample",
                Name = $"{DateTime.UtcNow}.jpg"
            });

            if (file == null)
                return;

            image.Source = ImageSource.FromStream(() =>
            {
                return file.GetStream();
            });
		await postLocationAsync();

			await MakePredictionRequest(file);
		}

	async Task postLocationAsync()
	{

			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;

			var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10)); 

			BigCatorNotModel model = new BigCatorNotModel()
			{
				TigerHeight = (float)position.Longitude,
				LionHeight = (float)position.Latitude

			};

			await AzureManager.AzureManagerInstance.PostBigCatorNot(model);
		}
           

       


        static byte[] GetImageAsByteArray(MediaFile file)
        {
            var stream = file.GetStream();
            BinaryReader binaryReader = new BinaryReader(stream);
            return binaryReader.ReadBytes((int)stream.Length);
        }

        async Task MakePredictionRequest(MediaFile file)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Prediction-Key", "4609999dc6134d9d8faa66f6d90b66ce");

            string url = "https://southcentralus.api.cognitive.microsoft.com/customvision/v1.0/Prediction/204bc4e4-a878-4f13-a349-17986d43538c/image";

            HttpResponseMessage response;

            byte[] byteData = GetImageAsByteArray(file);

            using (var content = new ByteArrayContent(byteData))
            {

                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(url, content);


                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    EvaluationModel responseModel = JsonConvert.DeserializeObject<EvaluationModel>(responseString);

                    double max = responseModel.Predictions.Max(m => m.Probability);

                    TagLabel.Text = (max >= 0.5) ? "BigCat" : "Not BigCat";
                }

               
                file.Dispose();
            }
        }
    }
}