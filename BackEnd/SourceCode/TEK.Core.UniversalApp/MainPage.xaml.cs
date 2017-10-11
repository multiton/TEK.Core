using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using Windows.UI.Xaml;
using Windows.Web.Http;
using Windows.UI.Xaml.Controls;

namespace TEK.Core.UniversalApp
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public sealed partial class MainPage : Page
    {       
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void BtnLoadClick(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("http://192.168.1.254:51404/api/asynch/1000000");

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var task = await httpClient.GetAsync(uri);
                    task.EnsureSuccessStatusCode();

                    var result = await task.Content.ReadAsStringAsync();
                    this.ListCompanies.ItemsSource = JsonConvert.DeserializeObject<List<Company>>(result);

                    this.TbSatatus.Text = "Done";
                }
            }
            catch (Exception ex)
            {
                this.TbSatatus.Text = ex.Message;
            }
        }
    }
}