using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using exhibitions.Context.Entities;
using exhibitions.Context.Entities.User;

namespace exhibitions.Context
{
    public class MainDbContext :  IdentityDbContext<User, UserRole, Guid>
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().HasMany(x => x.Exhibitions).WithMany(x => x.Subscribed_Users).UsingEntity(t => t.ToTable("exhibition_users"));
            modelBuilder.Entity<UserRole>().ToTable("user_roles");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("user_role_owners");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("user_role_claims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");


            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Comment>().Property(x => x.Message).IsRequired();
            modelBuilder.Entity<Comment>().Property(x => x.Message).HasMaxLength(100);
            modelBuilder.Entity<Comment>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Comment>().HasOne(x => x.Exhibition).WithMany(x => x.Comments).HasForeignKey(x => x.ExhibitionId);
            modelBuilder.Entity<Comment>().HasOne(x => x.Author).WithMany(x => x.Comments).HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<Photo>().ToTable("photos");
            modelBuilder.Entity<Photo>().HasOne(x => x.Exhibition).WithMany(x => x.Photos).HasForeignKey(x=>x.ExhibitionId);

            modelBuilder.Entity<Exhibition>().ToTable("exhibitions");
            modelBuilder.Entity<Exhibition>().Property(x => x.Place).IsRequired();
            modelBuilder.Entity<Exhibition>().Property(x => x.Name).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<Exhibition>().Property(x => x.Date).IsRequired();

            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(x => x.Name).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Category>().HasMany(x => x.Exhibitions).WithMany(x => x.Categories).UsingEntity(t => t.ToTable("exhibition_categories"));

        }
    }
}
