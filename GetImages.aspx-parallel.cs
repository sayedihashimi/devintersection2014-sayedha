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

namespace three {
    public partial class GetImages : System.Web.UI.Page {
        protected void btnGetImg_Click(object sender, EventArgs e) {
            string[] urls = textUrls.Text.Split(
                new string[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries);
            GetImagesSync(urls);
        }

        private void GetImagesSync(string[] urls) {
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
            string[] urls = textUrlsAsync.Text.Split(
                new string[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries);
            await GetImagesAsync(urls);
        }

        private async Task GetImagesAsync(string[] urls) {
            List<Task> tasks = new List<Task>();
            foreach (var url in urls) {
                tasks.Add(GetImageAsync(url));
            }

            await Task.WhenAll(tasks);
        }

        private async Task GetImageAsync(string url) {
            string imagesdir = Server.MapPath(@"~/images/");
            string filename = new Uri(url).Segments.Last();
            string localfile = Path.Combine(imagesdir, filename);

            using (var client = new HttpClient()) {
                var result = await client.GetAsync(url);
                result.EnsureSuccessStatusCode();

                await result.Content.LoadIntoBufferAsync();
                await result.Content.ReadAsFileAsync(localfile, true);
            }
        }
    }

    public static class HttpContentExtensions {
        public static async Task ReadAsFileAsync(this HttpContent content, string filename, bool overwrite) {
            string pathname = Path.GetFullPath(filename);
            if (!overwrite && File.Exists(filename)) {
                throw new InvalidOperationException(string.Format("File {0} already exists.", pathname));
            }

            using (var fileStream = new FileStream(pathname, FileMode.Create, FileAccess.Write, FileShare.None)) {
                await content.CopyToAsync(fileStream);
                fileStream.Close();
            }
        }
    }
}
/*
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
*/


