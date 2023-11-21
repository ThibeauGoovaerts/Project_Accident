using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class DirectMesureInitializer
    {
        public static void Initialize(AccidentContext context)
        {
            context.Database.EnsureCreated();

            if (context.DirectMesures.Any())
            {
                return;
            }

            using (var transaction = context.Database.BeginTransaction())
            {
                var mesures = new DirectMesure[]
                {
                    new DirectMesure { Label="Balisage de la zone", IsDefault=true},
                    new DirectMesure { Label="Information", IsDefault=true},
                    new DirectMesure { Label="Appel maintenance", IsDefault=true},
                };

                foreach (DirectMesure m in mesures)
                {
                    context.DirectMesures.Add(m);
                }

                context.SaveChanges();

                transaction.Commit();
            }
        }
    }
}
