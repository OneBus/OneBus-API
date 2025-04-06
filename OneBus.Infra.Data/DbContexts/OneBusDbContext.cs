using Microsoft.EntityFrameworkCore;

namespace OneBus.Infra.Data.DbContexts
{
    public class OneBusDbContext : DbContext
    {
        public OneBusDbContext(DbContextOptions<OneBusDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OneBusDbContext).Assembly);

            //Garantindo que todas as FKs tenham comportamento de 'Restrict' e garantindo consistência e segurança dos dados
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(c => c.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }        

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            //Todo campo de Texto não é Unicode
            configurationBuilder.Properties<string>().AreUnicode(false);
            configurationBuilder.Properties<string?>().AreUnicode(false);            

            //Todo campo de Dinheiro tem Precisão fixa 
            configurationBuilder.Properties<decimal>().HavePrecision(19, 4);
        }
    }
}
