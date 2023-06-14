using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomHaikuGenerator
{
    internal class BlogFluent
    {
        private readonly BlogPostSettings _blogPostSettings = new BlogPostSettings();

        public BlogFluent()
        {
            _blogPostSettings.Categories = new List<string>();
            _blogPostSettings.Tags = new List<string>();
        }
        public BlogFluent WithTitle(string t)
        {
            _blogPostSettings.Title = t;
            return this;
        }
        public BlogFluent WithAuthor(string t)
        {
            _blogPostSettings.Author = t;
            return this;
        }
        public BlogFluent WithDate(DateTime t)
        {
            _blogPostSettings.Date = t;
            return this;
        }
        public BlogFluent WithContent(string t)
        {
            _blogPostSettings.Content = t;
            return this;
        }
        public BlogFluent WithMetaDescription(string t)
        {
            _blogPostSettings.MetaDescription = t;
            return this;
        }
        public BlogFluent WithMetaTitle (string t)
        {
            _blogPostSettings.MetadataTitle = t;
            return this;
        }
        public BlogFluent WithTags(IEnumerable<string> tags)
        {
            _blogPostSettings.Tags= tags.ToList();
            return this;
        }

        public BlogFluent WithCategories(IEnumerable<string> cat)
        {
            _blogPostSettings.Categories = cat.ToList();
            return this;
        }

        public BlogPostSettings Build()
        {
            return _blogPostSettings;
        }



    }
}
