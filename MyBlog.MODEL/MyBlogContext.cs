using System;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.MODEL
{
    public class MyBlogContext:DbContext
    {
        public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
        {

        }

        public DbSet<Articles> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategory { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<ArticleComment> ArticleComment { get; set; }
        public DbSet<LeaveMessage> LeaveMessage { get; set; }
        public DbSet<PictureWall> PictureWall { get; set; }
        public DbSet<ReplyMessage>ReplyMessage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ArticleCategory>().Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(36).HasColumnType("char(36)");

            modelBuilder.Entity<Articles>().Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(36).HasColumnType("char(36)");

            modelBuilder.Entity<PictureWall>().Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(36).HasColumnType("char(36)");
            modelBuilder.Entity<ArticleComment>().Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(36).HasColumnType("char(36)");

            modelBuilder.Entity<Admin>().Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(36).HasColumnType("char(36)");

            modelBuilder.Entity<LeaveMessage>().Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(36).HasColumnType("char(36)");

            modelBuilder.Entity<Articles>().Property(x => x.ArticleCategoryId)
                .IsRequired()
                .HasMaxLength(36).HasColumnType("char(36)");

            modelBuilder.Entity<ArticleComment>().Property(x => x.ArticleId)
                .IsRequired()
                .HasMaxLength(36).HasColumnType("char(36)");

            modelBuilder.Entity<ReplyMessage>().Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(36).HasColumnType("char(36)");

            modelBuilder.Entity<ReplyMessage>().Property(x => x.CommentId)
                .IsRequired()
                .HasMaxLength(36).HasColumnType("char(36)");

            modelBuilder.Entity<Admin>().HasData(
                new Admin()
                {
                    Id = Guid.Parse("bbdee09c-089b-4d30-bece-44df5923716c"),
                    Name = "stackOverflow",
                    Password = "throwNewException",
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now,
                    IsRemove = false
                }
            );

        }


    }
    }