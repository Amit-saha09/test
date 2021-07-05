using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Repository
{
    public class BlogPostRepository : Repository<BlogPost>
    {
        public List<BlogPost> GetUserPosts(int Id)
        {
            return this.contex.BlogPosts.Where(x => x.DoctorId == Id).ToList();
        }

        
    }
}