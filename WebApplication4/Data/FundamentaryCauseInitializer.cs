using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class FundamentaryCauseInitializer
    {
        public static void Initialize(AccidentContext context)
        {
            context.Database.EnsureCreated();

            if (context.FundamentaryCauses.Any())
            {
                return;
            }

            using (var transaction = context.Database.BeginTransaction())
            {
                var organisations = new FundamentaryCause[]
                {
                    new FundamentaryCause { Label="Respect des lois et tests réglementaires", IsDefault=true},
                    new FundamentaryCause { Label="Procédures de travail inadaptées", IsDefault=true},
                    new FundamentaryCause { Label="Règles de sécurité inadaptées", IsDefault=true},
                    new FundamentaryCause { Label="Training", IsDefault=true},
                    new FundamentaryCause { Label="Autorisation habilitation et permis requis", IsDefault=true},
                    new FundamentaryCause { Label="Équipement de protection individuel et collectif", IsDefault=true},
                    new FundamentaryCause { Label="Inspections, vérifications et contrôles requis", IsDefault=true},
                    new FundamentaryCause { Label="Équipements inadaptés", IsDefault=true},
                };

                foreach (FundamentaryCause o in organisations)
                {
                    context.FundamentaryCauses.Add(o);
                }

                context.SaveChanges();

                transaction.Commit();
            }
        }
    }
}
