using System.Data.Entity;

namespace Kengic.Was.Domain.Model.SntonInterface
{
    public class SntonMesInterface : DbContext
    {
        static SntonMesInterface()
        {
            Database.SetInitializer<SntonMesInterface>(null);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
    }
}