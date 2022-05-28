using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {


                optionsBuilder.UseSqlServer("Data Source=10.101.17.4;initial catalog=DevTest;" +
                              "persist security info=True;user id=DevTeam;password=Ds#8587!;MultipleActiveResultSets=True;App=EntityFramework");

            }
        }

        public DbSet<Apply> Applies { get; set; }
        public DbSet<AuthorityTool> AuthorityTools { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<EmailConfirmed> EmailConfirmeds { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageType> ImageTypes { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Posting> Postings { get; set; }
        public DbSet<PostingType> PostingTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SavedPosting> SavedPostings { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<University> University { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInterestedPosting> UserInterestedPostings { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserTool> UserTools { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<UserInterestedPosting>(eb =>
            {
                eb.HasNoKey();
            });
            modelBuilder.Entity<Apply>(entity =>
            {
                entity.HasOne(x => x.CV)
                .WithMany(y => y.Apply)
                .HasForeignKey(z => z.CvId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.User)
                .WithMany(y => y.Applies)
                .HasForeignKey(z => z.UserId)
                .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne(x => x.Posting)
                .WithMany(y => y.Applies)
                .HasForeignKey(z => z.PostingId)
                .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<CV>(entity =>
            {
                entity.HasOne(x => x.User)
                .WithMany(y => y.CVs)
                .HasForeignKey(z => z.UserId);

            });
            modelBuilder.Entity<EmailConfirmed>(entity =>
            {

                entity.HasOne(x => x.User)
                .WithMany(y => y.EmailConfirmeds)
                .HasForeignKey(z => z.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            });
            modelBuilder.Entity<Event>(entity =>
            {

                entity.HasOne(x => x.User)
                .WithMany(y => y.Events)
                .HasForeignKey(z => z.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasOne(x => x.ImageType)
                .WithMany(y => y.Images)
                .HasForeignKey(z => z.ImageTypeId);

                entity.HasOne(x => x.Posting)
                .WithMany(y => y.Images)
                .HasForeignKey(z => z.PostingId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Event)
                .WithMany(y => y.Image)
                .HasForeignKey(z => z.EventId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.User)
                .WithMany(y => y.Image)
                .HasForeignKey(z => z.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PhoneNumber>(entity =>
            {
                entity.HasOne(x => x.User)
                .WithMany(y => y.PhoneNumber)
                .HasForeignKey(z => z.UserId);
            });

            modelBuilder.Entity<Posting>(entity =>
            {
                entity.HasOne(x => x.User)
                .WithMany(y => y.Postings)
                .HasForeignKey(z => z.UserId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Discipline)
                .WithMany(y => y.Postings)
                .HasForeignKey(z => z.DisciplineId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Title)
                .WithMany(y => y.Postings)
                .HasForeignKey(z => z.TitleId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.PostingType)
                .WithMany(y => y.Postings)
                .HasForeignKey(z => z.PostingTypeId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.University)
                .WithMany(y => y.Posting)
                .HasForeignKey(z => z.UniversityId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<SavedPosting>(entity =>
            {
                entity.HasOne(x => x.User)
                .WithMany(y => y.SavedPosting)
                .HasForeignKey(z => z.UserId)
                .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne(x => x.Posting)
                .WithMany(y => y.SavedPosting)
                .HasForeignKey(z => z.PostingId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserTool>(entity =>
            {

                entity.HasOne(x => x.User)
                .WithMany(y => y.UserTool)
                .HasForeignKey(z => z.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.Tool)
                .WithMany(y => y.UsersTool)
                .HasForeignKey(z => z.ToolId)
                .OnDelete(DeleteBehavior.Cascade);

            });
            modelBuilder.Entity<UserRole>(entity =>
            {

                entity.HasOne(x => x.User)
                .WithMany(y => y.UserRole)
                .HasForeignKey(z => z.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.Role)
                .WithMany(y => y.UsersRole)
                .HasForeignKey(z => z.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            });
            //modelBuilder.Entity<University>(entity =>
            //{

            //    entity.HasOne(x => x.Country)
            //    .WithMany(y => y.University)
            //    .HasForeignKey(z => z.CountryId)
            //    .OnDelete(DeleteBehavior.Cascade);
            //});
            //});
            modelBuilder.Entity<User>(entity =>
            {

               

                entity.HasOne(x => x.Country)
                    .WithMany(y => y.Users)
                    .HasForeignKey(z => z.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.City)
                .WithMany(y => y.Users)
                .HasForeignKey(z => z.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Individual>(entity =>
            {

                entity.HasOne(x => x.University)
                    .WithMany(y => y.Individuals)
                    .HasForeignKey(z => z.UniversityId)
                    .OnDelete(DeleteBehavior.Restrict);


                entity.HasOne(x => x.Title)
                    .WithMany(y => y.Individuals)
                    .HasForeignKey(z => z.TitleId)
                    .OnDelete(DeleteBehavior.Restrict);


                entity.HasOne(x => x.Discipline)
                    .WithMany(y => y.Individuals)
                    .HasForeignKey(z => z.DisciplineId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<City>(entity =>
            {

                entity.HasOne(x => x.Country)
                    .WithMany(y => y.Cities)
                    .HasForeignKey(z => z.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);



            });



        }
    }
}
