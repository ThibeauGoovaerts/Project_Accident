using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class ProtectionInitializer
    {
        public static void Initialize(AccidentContext context)
        {
            context.Database.EnsureCreated();

            if (context.Protections.Any())
            {
                return;
            }

            using (var transaction = context.Database.BeginTransaction())
            {
                var protections = new Protection[]
                {
                    new Protection { Label="Casque"},
                    new Protection { Label="Gant"},
                    new Protection { Label="Lunettes de sécurité"},
                    new Protection { Label="Ecran facial"},
                    new Protection { Label="Veste de protection"},
                    new Protection { Label="Protection de l’ouïe"},
                    new Protection { Label="Chaussures de sécurité"},
                    new Protection { Label="Masque respiratoire"},
                    new Protection { Label="Masque antiseptique"},
                    new Protection { Label="Protection contre les chutes"},
                };

                foreach (Protection p in protections)
                {
                    context.Protections.Add(p);
                }

                context.SaveChanges();

                transaction.Commit();
            }
        }
    }
}
