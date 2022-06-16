using System.ComponentModel.DataAnnotations;

namespace Blog.Shared
{
    public class BlogPost
    {
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }

        public string?Image { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Content { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Author { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public bool IsPublished { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

    }
}
