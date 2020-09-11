using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegeFood.Models.SQLModel;

namespace VegeFood.Services.SQLService
{
    public class BlogService: SQLBaseService
    {
        public BlogService(IConfiguration configuration): base(configuration) { }

        public Blog GetBlogById(int blogId)
        {
            Blog blog = SqlData.Blogs.Find(blogId);
            return blog;
        }

        public async Task<Blog> GetBlogByIdAsync(int blogId)
        {
            Blog blog = await SqlData.Blogs.FindAsync(blogId);
            return blog;
        }

        public List<Blog> GetListBlogs()
        {
            List<Blog> blogList = SqlData.Blogs.ToList();
            return blogList;
        }

        public async Task<List<Blog>> GetListBlogsAsync()
        {
            List<Blog> blogList = await SqlData.Blogs.ToListAsync();
            return blogList;
        }
    }
}
