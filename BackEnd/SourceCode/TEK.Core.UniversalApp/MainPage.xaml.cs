using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

using Windows.UI.Xaml;
using Windows.Web.Http;
using Windows.UI.Xaml.Controls;

namespace TEK.Core.UniversalApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void BtnLoadClick(object sender, RoutedEventArgs e)
        {
            this.TbSatatus.Text = string.Empty;
            this.ListCompanies.ItemsSource = null;

            var stopWatch = Stopwatch.StartNew();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    this.TbSatatus.Text += "Request...";

                    var response = await httpClient.GetAsync(
                        new Uri(this.TbUri.Text),
                        HttpCompletionOption.ResponseHeadersRead);

                    response.EnsureSuccessStatusCode();

                    using (var content = response.Content)
                    {
                        this.TbSatatus.Text += "Response...";
                        var result = await content.ReadAsStringAsync();

                        this.TbSatatus.Text += $"({stopWatch.ElapsedMilliseconds} miliSec). Rendering...";

                        this.ListCompanies.ItemsSource =
                            await Task.Run(() => JsonConvert.DeserializeObject<List<Company>>(result));
                        
                        stopWatch.Stop();
                        this.TbSatatus.Text += $"Done. Total time: ({stopWatch.ElapsedMilliseconds/1000} sec)";
                    }
                }
            }
            catch (Exception ex)
            {
                this.TbSatatus.Text = ex.Message;
            }
        }
    }
}