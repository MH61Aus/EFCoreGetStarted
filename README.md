# EFCoreGetStarted
This is a demo app created as a demonstration of https://github.com/dotnet/efcore/issues/30877

It uses a table per hierarchy to map a blog to two derived types: RssBlog and SpecialBlog. Blog itself is abstract, as every blog must be a derived type.

Each Blog has an owner. An owner can own multiple Rss Blogs, and only one Special Blog.

I have forced the Blog<->Owner FK to be in the Blog table (i.e. Blog.OwnerID). But the migrations generator duplicates the FK and Index generation, possibly because of the TPH implementation.



