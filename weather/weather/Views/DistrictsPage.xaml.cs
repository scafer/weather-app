using Newtonsoft.Json;
using System.Threading.Tasks;
using weather.Helpers;
using weather.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace weather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DistrictsPage : ContentPage
    {
        public DistrictsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ = LoadDistrictsFromApi();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as District;
            Navigation.PushAsync(new WeatherPage(item));
        }

        private async Task LoadDistrictsFromApi()
        {
            var response = await RestConnector.GetObjectAsync("https://api.ipma.pt/open-data/distrits-islands.json");
            DistrictIslands districts = JsonConvert.DeserializeObject<DistrictIslands>(response);
            listView.ItemsSource = districts.data;
        }
    }
}