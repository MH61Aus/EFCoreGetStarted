using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreGetStarted;
public class BloggingContext : DbContext
{
    public DbSet<RssBlog> RssBlogs { get; set; }
    public DbSet<SpecialBlog> SpecialBlogs { get; set; }
    public DbSet<Owner> Owners { get; set; }


    public BloggingContext() { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasDiscriminator<int>("blog_type")
            .HasValue<RssBlog>((int)BlogTypeEnum.Rss)
            .HasValue<SpecialBlog>((int)BlogTypeEnum.Special);

        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer($"Server=.;Database=BloggingDB;Integrated Security=True;Encrypt=False;");
}

public abstract class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }
    public Owner Owner { get; set; }
    public int OwnerId { get; set; } // FK is required here so it knows how to generate one to one relationship
    
    public List<Post> Posts { get; } = new();
}

public class RssBlog : Blog
{
    public string RssUrl { get; set; }
}

public class SpecialBlog : Blog
{
    public int SpecialField { get; set; }
}

public class Owner
{
    public int OwnerId { get; set; }
    public int YearsSubscribed { get; set; }

    //An owner can own as many RssBlogs as they wish
    public List<RssBlog> RssBlogs { get; set; }

    //An owner can only own one special blog
    public SpecialBlog SpecialBlog { get; set; }
    
}

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Blog Blog { get; set; }
}

public enum BlogTypeEnum
{
    Rss = 1,
    Special = 2
}