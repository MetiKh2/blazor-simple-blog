using Blog.Shared;
using System.Net;
using System.Net.Http.Json;

namespace Blog.Client.Services
{
    public interface IBlogService
    {
       Task<List<BlogPost>> GetBlogPosts();
        Task<BlogPost> GetBlogPostByUrl(string url);
        Task<BlogPost> CreateBlogPost(BlogPost post);
    }
    public class BlogService : IBlogService
    {
        private readonly HttpClient _httpClient;

        public BlogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BlogPost> CreateBlogPost(BlogPost post)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<BlogPost>($"api/Blog",post);
                if (response.IsSuccessStatusCode)
                {
                    //if (response.StatusCode == HttpStatusCode.NotFound)
                    //    return default(BlogPost);
                    return await response.Content.ReadFromJsonAsync<BlogPost>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<BlogPost> GetBlogPostByUrl(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Blog/"+url);
                if (response.IsSuccessStatusCode)
                {
                    //if (response.StatusCode == HttpStatusCode.NotFound)
                    //    return default(BlogPost);
                    return await response.Content.ReadFromJsonAsync<BlogPost>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Blog");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                        return Enumerable.Empty<BlogPost>().ToList();
                    return await response.Content.ReadFromJsonAsync<List<BlogPost>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
