using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RssReaderModel.RssFeed;

namespace RssReaderModel.Migrations
{
    [DbContext(typeof(RssFeedContext))]
    [Migration("20170402001132_CreateDbAndRss")]
    partial class CreateDbAndRss
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RssReaderModel.RssFeed.RssArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BodyHtml");

                    b.Property<int?>("RssFeedId");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("RssFeedId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("RssReaderModel.RssFeed.RssFeed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("RssReaderModel.RssFeed.RssArticle", b =>
                {
                    b.HasOne("RssReaderModel.RssFeed.RssFeed")
                        .WithMany("Articles")
                        .HasForeignKey("RssFeedId");
                });
        }
    }
}
