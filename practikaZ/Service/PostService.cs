using practikaZ.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practikaZ.Service
{
    internal class PostService
    {
        public static List<Post> GetPosts()
        {
            using (var context = new MyDbContext())
            {
                return context.Posts.ToList();
            }
        }
    }
}

