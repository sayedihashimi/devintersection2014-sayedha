using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2;

namespace WebApplication2 {
    public partial class DownloadImage : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected async Task CopyImage(string url) {
            using (var client = new HttpClient()) {

                var image = await client.GetAsync(url);
                image.EnsureSuccessStatusCode();
                await image.Content.LoadIntoBufferAsync();
                

                string imagesDir = Server.MapPath(@"~/images/");
                if (!Directory.Exists(imagesDir)) {
                    Directory.CreateDirectory(imagesDir);
                }

                await image.Content.ReadAsFileAsync(
                    Path.Combine(imagesDir, GetFileName(new Uri(url))), true);
            }
        }
        protected async void CopyImages(IEnumerable<string> urls) {
            List<Task> tasks = new List<Task>();
            foreach (var url in urls) {
                tasks.Add(CopyImage(url));
            }

            await Task.WhenAll(tasks);
        }
        protected void btnDownload_Click(object sender, EventArgs e) {
            string imageString = this.textUrl.Text;
            string[] urls = imageString.Split(new []{"\r\n"},StringSplitOptions.RemoveEmptyEntries);
            CopyImages(urls);
        }

        protected string GetFileName(Uri uri) {
            return uri.Segments[uri.Segments.Length - 1];
        }
    }
}