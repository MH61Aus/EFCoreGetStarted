// See https://aka.ms/new-console-template for more information
using EFCoreGetStarted;

using var db = new BloggingContext();

db.Owners.Add(new Owner
{
    YearsSubscribed = 20,
    RssBlogs = new List<RssBlog> {
        new RssBlog {
            Url = "http://rss.blog.com",
            RssUrl = "rss.url",
        },
        new RssBlog {
            Url = "http://rss2.blog.com",
            RssUrl = "rss2.url",
        }
    },
    SpecialBlog = new SpecialBlog
    {
        Url = "http://special.blog.com",
        SpecialField = 999,
    }
});
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
var blog = db.SpecialBlogs
    .OrderBy(b => b.BlogId)
    .First();

Console.WriteLine(blog.Url);