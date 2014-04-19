using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2 {
    public partial class GetImages : System.Web.UI.Page {
        protected void btnGetImg_Click(object sender, EventArgs e) {
            string[] urls = textUrls.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            GetImagesSync(urls);
        }

        private void GetImagesSync(IEnumerable<string> urls) {
            foreach (var url in urls) {
                GetImageSync(url);
            }
        }

        private void GetImageSync(string url) {
            string imagesdir = Server.MapPath(@"~/images/");
            string filename = new Uri(url).Segments.Last();
            string localfile = Path.Combine(imagesdir, filename);
            using (var client = new WebClient()) {
                client.DownloadFile(url, localfile);
            }
        }

        protected async void btnGetImgAsync_Click(object sender, EventArgs e) {
            IEnumerable<string> urls = textUrlsAsync.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            await GetImagesAsync(urls);
        }
        private async Task GetImageAsnc(string url) {
            string imagesdir = Server.MapPath(@"~/images/");
            string filename = new Uri(url).Segments.Last();

            using (var client = new HttpClient()) {
                var result = await client.GetAsync(url);
                result.EnsureSuccessStatusCode();
                await result.Content.LoadIntoBufferAsync();

                await result.Content.ReadAsFileAsync(
                    Path.Combine(imagesdir, filename), true);
            }
        }
        private async Task GetImagesAsync(IEnumerable<string> urls) {
            var taskList = new List<Task>();
            foreach (var url in urls) {
                taskList.Add(GetImageAsnc(url));
            }

            await Task.WhenAll(taskList);
        }
    }
}