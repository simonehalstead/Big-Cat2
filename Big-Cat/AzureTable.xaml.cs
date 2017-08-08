using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Xamarin.Forms.Maps;


namespace BigCat
{
    public partial class AzureTable : ContentPage
    {
            

        public AzureTable()
        {
            InitializeComponent();


                }
                async void Handle_ClickedAsync(object sender, System.EventArgs e)
                {
                    List<BigCatorNotModel> BigCatorNot = await AzureManager.AzureManagerInstance.GetBigCatorNot();

                    BigCatList.ItemsSource = BigCatorNot;
                }
    }
}
