using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelDatabase.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelDatabase
{
    public class ApplicationDbContext : IdentityDbContext<UserAccount>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.Property(e => e.FullName)
                .HasColumnName("FullName")
                .HasColumnType("nvarchar(24)");
                entity.Property(e => e.Image)
                .HasColumnName("Image")
                .HasColumnType("nvarchar(MAX)");
            });
            modelBuilder.Entity<Article>(entity =>
            {
                //Article Id
                entity.HasKey(e => e.AriticleId);
                // Title
                entity.Property(e => e.Title)
                .HasColumnName("Title")
                .HasColumnType("nvarchar(250)");
                //Content
                entity.Property(e => e.Content)
                .HasColumnName("Content")
                .HasColumnType("nvarchar(MAX)");
                //Date
                entity.Property(e => e.Date)
                .HasColumnName("Date")
                .HasColumnType("datetime");
                //Like
                entity.Property(e => e.Like)
                .HasColumnName("Like")
                .HasColumnType("int")
                .HasDefaultValue(0);
                //Foren key ArticleUserId -> UserAccount
                entity.HasOne(e => e.UserAccount)
                .WithMany(user => user.ArticlesList)
                .HasForeignKey("ArticleUserId")
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Article_UserAccount")
                .IsRequired(true);
                // Avatar
                entity.Property(e => e.Avatar)
                .HasColumnName("Avatar")
                .HasColumnType("nvarchar(MAX)");
                //Status
                entity.Property(e => e.Status)
                .HasColumnName("Status")
                .HasColumnType("bit")
                .HasDefaultValue(false);
                //ArticleArticleTypeId
                entity.HasOne(e => e.ArticleType)
                .WithMany(type => type.ArticlesList)
                .HasForeignKey("ArticleArticleTypeId")
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Article_ArticleType");
            });
            modelBuilder.Entity<ArticleType>(entity =>
            {
                entity.HasKey(e => e.ArticleTypeId);
                entity.Property(e => e.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(50)")
                .IsRequired(true);
                entity.Property(e => e.image)
                .HasColumnName("Image")
                .HasColumnType("nvarchar(MAX)");
            });
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.CommentId);
                entity.Property(e => e.Date)
                .HasColumnName("Date")
                .HasColumnType("datetime");
                entity.Property(e => e.Content)
                .HasColumnName("Content")
                .HasColumnType("nvarchar(MAX)");
                entity.HasOne(e => e.Article)
                .WithMany(ar => ar.CommentsList)
                .HasForeignKey("CommentArticleId")
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Comment_Article");
                entity.HasOne(e => e.UserAccount)
                .WithMany(user => user.commentsList)
                .HasForeignKey("CommentUserAccountId")
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Comment_UserAccount");
            });
            base.OnModelCreating(modelBuilder);
        }
       public DbSet<Article> Article { set; get; }
       public DbSet<ArticleType> ArticleType { set; get; }
       public DbSet<Comment> Comment { set; get; }
    }
}
