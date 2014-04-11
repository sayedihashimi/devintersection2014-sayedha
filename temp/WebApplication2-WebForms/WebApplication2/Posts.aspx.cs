using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Models;

namespace WebApplication2 {
    public partial class Posts : System.Web.UI.Page {
        private static List<Post> _posts;
        protected void Page_Load(object sender, EventArgs e) {
            if (_posts == null) {
                _posts = new List<Post> {
                    new Post{PostId=1,Title="title 1",Content="content 1"},
                    new Post{PostId=2,Title="title 2",Content="content 2"},
                    new Post{PostId=3,Title="title 3",Content="content 3"},
                };
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Post> GetPosts() {
            return _posts.AsQueryable<Post>();
        }

        public void UpdatePost(Post post) {
            if (post == null) { return; }

            var postToUpdate = (from p in _posts
                                where p.PostId == post.PostId
                                select p).Single();

            postToUpdate.Title = post.Title;
            postToUpdate.Content = post.Content;
        }
    }
}