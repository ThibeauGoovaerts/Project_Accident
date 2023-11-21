using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class LocationInitializer
    {
        public static void Initialize(AccidentContext context)
        {
            context.Database.EnsureCreated();

            if (context.Locations.Any())
            {
                return;
            }

            using (var transaction = context.Database.BeginTransaction())
            {
                var locations = new Location[]
                {
                    new Location{ Label="Ligne 1"},
                    new Location{ Label="Ligne 2"},
                    new Location{ Label="Ligne 3"},
                    new Location{ Label="Ligne 4"},
                    new Location{ Label="Hall"},
                    new Location{ Label="Atelier"},
                    new Location{ Label="Cantine"},
                    new Location{ Label="Bureau"},
                    new Location{ Label="Parking"},
                };

                foreach (Location l in locations)
                {
                    context.Locations.Add(l);
                }

                context.SaveChanges();

                transaction.Commit();
            }
        }
    }
}
