using Microcharts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weather.Helpers;
using weather.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;

namespace weather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        private District district;

        public WeatherPage(District district)
        {
            InitializeComponent();
            this.district = district;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ = LoadWeatherData();
        }

        private async Task LoadWeatherData()
        {
            var response = await RestConnector.GetObjectAsync(
                "https://api.ipma.pt/open-data/forecast/meteorology/cities/daily/" + district.globalIdLocal + ".json");
            var weather = JsonConvert.DeserializeObject<Weather5Days>(response);

            localName.Text = district.local;
            updatedAt.Text = weather.dataUpdate.ToShortTimeString();
            todayBoard.BindingContext = weather.data.FirstOrDefault();

            var precipitationEntries = new List<Entry>();
            foreach (var item in weather.data)
            {
                precipitationEntries.Add(new Entry(float.Parse(item.precipitaProb)) { ValueLabel = item.precipitaProb, Label = item.forecastDate });
            }

            chartView.Chart = new PointChart() { Entries = precipitationEntries };
            listView.ItemsSource = weather.data;
        }
    }
}