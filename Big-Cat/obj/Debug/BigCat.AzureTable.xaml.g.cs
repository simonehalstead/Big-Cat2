// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace BigCat {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("/Users/simonehalstead/Desktop/Big-Cat/Big-Cat/AzureTable.xaml")]
    public partial class AzureTable : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.ListView BigCatList;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.ActivityIndicator loading;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(AzureTable));
            BigCatList = global::Xamarin.Forms.NameScopeExtensions.FindByName <global::Xamarin.Forms.ListView>(this, "BigCatList");
            loading = global::Xamarin.Forms.NameScopeExtensions.FindByName <global::Xamarin.Forms.ActivityIndicator>(this, "loading");
        }
    }
}
