using System;
using System.Linq;
using DAL.Base.EF;
using Domain.App;
using Domain.App.Identity;
using Domain.Base;
using Domain.Base.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext : BaseDbContext<
        AppUser, 
        AppRole, 
        IdentityUserClaim<Guid>, 
        BaseAppUserRole<Guid, AppUser, AppRole>, 
        IdentityUserLogin<Guid>, 
        IdentityRoleClaim<Guid>, 
        IdentityUserToken<Guid>>
    {

        public DbSet<ContactType> ContactType { get; set; } = default!;
        public DbSet<Contact> Contact { get; set; } = default!;
        public DbSet<PersonType> PersonType { get; set; } = default!;
        public DbSet<Person> Person { get; set; } = default!;
        public DbSet<BloodGroup> BloodGroup { get; set; } = default!;
        public DbSet<BloodDonate> BloodDonate { get; set; } = default!;
        public DbSet<BloodTest> BloodTest { get; set; } = default!;
        public DbSet<TransferableBlood> TransferableBlood { get; set; } = default!;
        public DbSet<BloodTransfusion> BloodTransfusion { get; set; } = default!;
        public DbSet<LangString> LangStrings { get; set; } = default!;
        public DbSet<Translation> Translations { get; set; } = default!;
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Translation>().HasKey(k => new { k.Culture, k.LangStringId});
            
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // modelBuilder.Entity<Translation>()
            //     .HasOne<LangString>(x => x)
            //     
            // modelBuilder.Entity<LangString>()
            //     .HasOne<Contact>(x => x.)
            //
            // modelBuilder.Entity<LangString>()
            //     .HasMany<Translation>(x => x.Translations)
            //
            
            // modelBuilder.Entity<Contact>()
            //     .HasOne(x => x.ContactValue)
            //     .WithOne(x => x.Contact)
            //     .OnDelete(DeleteBehavior.Cascade);
            //
            // modelBuilder.Entity<LangString>()
            //     .HasMany(x => x.Translations)
            //     .WithOne(x => x.LangString!)
            //     .OnDelete(DeleteBehavior.Cascade);

        }
        
    }
}