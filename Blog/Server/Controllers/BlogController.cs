using Blog.Server.Data;
using Blog.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public List<BlogPost> Posts;
        private readonly DataContext _context;
        public BlogController(DataContext context)
        {
            Posts = new List<BlogPost>
            {
                new BlogPost{ Title="Title1",Content="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Praesent semper feugiat nibh sed pulvinar proin gravida hendrerit lectus. Purus in mollis nunc sed. Cras ornare arcu dui vivamus arcu felis bibendum ut. Facilisis volutpat est velit egestas dui id. Phasellus faucibus scelerisque eleifend donec pretium vulputate sapien nec sagittis. Nec sagittis aliquam malesuada bibendum arcu vitae. Duis tristique sollicitudin nibh sit amet. Ipsum dolor sit amet consectetur adipiscing elit duis tristique sollicitudin. Scelerisque fermentum dui faucibus in ornare quam viverra orci.",Url="Url1"},
                new BlogPost{ Title="Title2",Content="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Praesent semper feugiat nibh sed pulvinar proin gravida hendrerit lectus. Purus in mollis nunc sed. Cras ornare arcu dui vivamus arcu felis bibendum ut. Facilisis volutpat est velit egestas dui id. Phasellus faucibus scelerisque eleifend donec pretium vulputate sapien nec sagittis. Nec sagittis aliquam malesuada bibendum arcu vitae. Duis tristique sollicitudin nibh sit amet. Ipsum dolor sit amet consectetur adipiscing elit duis tristique sollicitudin. Scelerisque fermentum dui faucibus in ornare quam viverra orci.",Url="Url2"},
                new BlogPost{ Title="Title3",Content="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Praesent semper feugiat nibh sed pulvinar proin gravida hendrerit lectus. Purus in mollis nunc sed. Cras ornare arcu dui vivamus arcu felis bibendum ut. Facilisis volutpat est velit egestas dui id. Phasellus faucibus scelerisque eleifend donec pretium vulputate sapien nec sagittis. Nec sagittis aliquam malesuada bibendum arcu vitae. Duis tristique sollicitudin nibh sit amet. Ipsum dolor sit amet consectetur adipiscing elit duis tristique sollicitudin. Scelerisque fermentum dui faucibus in ornare quam viverra orci.",Url="Url3"},
                new BlogPost{ Title="Title4",Content="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Praesent semper feugiat nibh sed pulvinar proin gravida hendrerit lectus. Purus in mollis nunc sed. Cras ornare arcu dui vivamus arcu felis bibendum ut. Facilisis volutpat est velit egestas dui id. Phasellus faucibus scelerisque eleifend donec pretium vulputate sapien nec sagittis. Nec sagittis aliquam malesuada bibendum arcu vitae. Duis tristique sollicitudin nibh sit amet. Ipsum dolor sit amet consectetur adipiscing elit duis tristique sollicitudin. Scelerisque fermentum dui faucibus in ornare quam viverra orci.",Url="Url4"},
            };
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.BlogPosts.OrderByDescending(p=>p.DateCreated).ToList());
        }
        [HttpGet("{url}")]
        public IActionResult GetAll(string url)
        {
            var post = _context.BlogPosts.FirstOrDefault(p => p.Url.ToLower() == url.ToLower());
            if (post == null) return NotFound();
            return Ok(post);
        }
        [HttpPost]
        public async Task<BlogPost> Create(BlogPost post)
        {
            Console.WriteLine(post.Id);
            await _context.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }
    }
}
