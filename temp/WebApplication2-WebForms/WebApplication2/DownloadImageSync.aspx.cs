using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2 {
    public partial class DownloadImageSync : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        public void DownloadImage(string url) {
            using (var client = new WebClient()) {
                string imagesfolder = Server.MapPath(@"~/images/");
                string filename = GetFileNameFor(new Uri(url));
                client.DownloadFile(url, Path.Combine(imagesfolder, filename));
            }
        }

        private string GetFileNameFor(Uri uri) {
            return uri.Segments.Last();
        }

        public void DownloadImages(IEnumerable<string> urls) {
            foreach (string url in urls) {
                DownloadImage(url);
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e) {
            string[] urls = textUrl.Text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            DownloadImages(urls);
        }
    }
}