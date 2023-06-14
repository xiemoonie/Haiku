using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Build Pattern
namespace RandomHaikuGenerator
{
    public class BlogPostSettings
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public IList<string> Categories { get; set; }
        public IList<string> Tags { get; set; }
        public string MetaDescription { get; set; }
        public string MetadataTitle { get; set; }
    }

    public interface IBlog
    {
        void AddTitle(string t);
        void AddContent(string c);
        void AddAuthor(string a);
        void AddDate(DateTime dt);
        void AddCategories(IEnumerable<string> tags);
        void AddTags(IEnumerable<string> tags);
        void AddMetaDescription(string d);
        void AddMetadataTitle(string d);

        BlogPostSettings Build();
    }
    public class BlogPostBuilder : IBlog
    {

        BlogPostSettings _blogPostSettings = new BlogPostSettings();

        public BlogPostBuilder()
        {
            _blogPostSettings.Categories = new List<string>();
            _blogPostSettings.Tags = new List<string>();
        }
        public void AddAuthor(string a)
        {
            _blogPostSettings.Author = a;
        }

        public void AddContent(string c)
        {
            _blogPostSettings.Content = c;
        }

        public void AddDate(DateTime dt)
        {
            _blogPostSettings.Date = dt;
        }

        public void AddMetadataTitle(string t)
        {
            _blogPostSettings.MetadataTitle = t;
        }

        public void AddTags(IEnumerable<string> tags)
        {
            _blogPostSettings.Tags = tags.ToList();
        }

        public void AddMetaDescription(string d)
        {
            _blogPostSettings.MetaDescription = d;
        }

        public void AddTitle(string t)
        {
            _blogPostSettings.Title = t;
        }
        public void AddCategories(IEnumerable<string> cat)
        {
            _blogPostSettings.Categories = cat.ToList();
        }

        public BlogPostSettings Build()
        {
            return _blogPostSettings;
        }
    }
    public class BlogPost
    {

        public BlogPost()
        {
            IEnumerable<string> e_tags = new List<string> { "first item", "second item" };
            IEnumerable<string> c_category = new List<string> { "first item", "second item" };

            BlogPostBuilder blog = new BlogPostBuilder();
            blog.AddTitle("My First Blog Post");
            blog.AddContent("This is my first blog post");
            blog.AddAuthor("John Doe");
            blog.AddMetadataTitle("Some Cool Metadata to please your eyes with");
            blog.AddMetaDescription("Describing things is also important do not you think?");
            blog.AddDate(DateTime.Now);
            blog.AddCategories(e_tags);
            blog.AddTags(c_category);

            var blogPostSettings = blog.Build();

           //Console.WriteLine($"{blogPostSettings.Author},{blogPostSettings.Date},{blogPostSettings.Title},{blogPostSettings.Content},{blogPostSettings.MetadataTitle}");
        }
    }
}
