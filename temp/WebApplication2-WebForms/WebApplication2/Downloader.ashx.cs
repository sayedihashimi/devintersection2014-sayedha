using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebApplication2 {
    /// <summary>
    /// Summary description for Downloader
    /// </summary>
    public class Downloader : HttpTaskAsyncHandler {
        public override async System.Threading.Tasks.Task ProcessRequestAsync(HttpContext context) {
            using (var client = new HttpClient()) {
                var twitter = await client.GetStringAsync(@"http://twitter.com");                

                context.Response.Write(twitter);

                var bing = await client.GetStringAsync(@"http://bing.com");
                context.Response.Write(bing);
                context.Response.Flush();
            }
        }
    }
}