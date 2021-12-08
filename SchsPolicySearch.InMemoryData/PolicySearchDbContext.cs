using Microsoft.EntityFrameworkCore;
using SchsPolicySearch.Domain.Entities;
using SchsPolicySearch.Domain.ValueObjects;

namespace SchsPolicySearch.InMemoryData
{
    public class PolicySearchDbContext : DbContext
    {
        public DbSet<Member> Members => Set<Member>();

        public PolicySearchDbContext(DbContextOptions<PolicySearchDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("PolicySearch");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.FirstName);
                x.Property(x => x.LastName);
                x.Property(x => x.DateOfBirth);
                x.Property(x => x.MemberCardNumber).HasConversion(p => p.Value, p => NumericalIdentifier.Create(p).Value);
                x.Property(x => x.PolicyNumber).HasConversion(p => p.Value, p => NumericalIdentifier.Create(p).Value);
                x.HasData(
                    new Member(1, "Winne", "Aslie", DateTime.Parse("26-07-1995"), NumericalIdentifier.Create("0473128446").Value, NumericalIdentifier.Create("6494400124").Value),
                    new Member(2, "Ransom", "Schops", DateTime.Parse("04-09-2012"), NumericalIdentifier.Create("8047727435").Value, NumericalIdentifier.Create("3279218470").Value),
                    new Member(3, "Estelle", "Lodin", DateTime.Parse("05-10-1997"), NumericalIdentifier.Create("9908842684").Value, NumericalIdentifier.Create("7649404129").Value),
                    new Member(4, "Jorry", "McAloren", DateTime.Parse("19-04-2016"), NumericalIdentifier.Create("3622460377").Value, NumericalIdentifier.Create("3412713163").Value),
                    new Member(5, "Allys", "Mordacai", DateTime.Parse("29-05-2021"), NumericalIdentifier.Create("7434867337").Value, NumericalIdentifier.Create("1406622567").Value),
                    new Member(6, "Rik", "Brookz", DateTime.Parse("15-02-2009"), NumericalIdentifier.Create("8207363673").Value, NumericalIdentifier.Create("1108841600").Value),
                    new Member(7, "Artair", "Priel", DateTime.Parse("14-09-2003"), NumericalIdentifier.Create("2807656978").Value, NumericalIdentifier.Create("2962112838").Value),
                    new Member(8, "Goldie", "Johnstone", DateTime.Parse("10-04-2005"), NumericalIdentifier.Create("5765227600").Value, NumericalIdentifier.Create("0628889739").Value),
                    new Member(9, "Chandra", "Shegog", DateTime.Parse("12-01-2010"), NumericalIdentifier.Create("6601157341").Value, NumericalIdentifier.Create("1793425884").Value),
                    new Member(10, "Appolonia", "Bullingham", DateTime.Parse("22-04-2010"), NumericalIdentifier.Create("9743324267").Value, NumericalIdentifier.Create("5202421605").Value)
                    );
            });
                
                
        }
    }
}