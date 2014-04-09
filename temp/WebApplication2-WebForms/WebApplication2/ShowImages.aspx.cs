using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2 {
    public partial class ShowImages : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            // read the files from the images folder and return the list
        }

        public IEnumerable<string> GetImageUrls() {
            string localImagesDir = Server.MapPath(@"~/images/");
            IEnumerable<string> files = Directory.EnumerateFiles(localImagesDir, "*.jpg");
            return from f in files
                   select string.Format("http://localhost:62773/images/{0}",
                   new FileInfo(f).Name);
        }
    }
}