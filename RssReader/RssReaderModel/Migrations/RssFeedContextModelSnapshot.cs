using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RssReaderModel.RssFeed;

namespace RssReaderModel.Migrations
{
    [DbContext(typeof(RssFeedContext))]
    partial class RssFeedContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("RssReaderModel.RssFeed.RssFeed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Feeds");
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
