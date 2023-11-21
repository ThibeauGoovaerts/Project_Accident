using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class DeviationInitializer
    {
        public static void Initialize(AccidentContext context)
        {
            context.Database.EnsureCreated();

            if (context.Deviations.Any())
            {
                return;
            }

            using (var transaction = context.Database.BeginTransaction())
            {
                var deviations = new Deviation[]
                {
                    new Deviation { Label="Déviation par problème électrique, explosion, feu"},
                    new Deviation { Label="Déviation par débordement, renversement, fuite, écoulement, vaporisation, dégagement"},
                    new Deviation { Label="Rupture, bris, éclatement, glissade, chute, effondrement d’Agent matériel"},
                    new Deviation { Label="Perte, totale ou partielle, de contrôle de machine, moyen de transport, équipement de manutention, outil à main, objet, animal"},
                    new Deviation { Label="Glissade ou trébuchement avec chute, chute de personne"},
                    new Deviation { Label="Mouvement du corps sans contrainte physique (Conduisant généralement à une blessure externe)"},
                    new Deviation { Label="Mouvement du corps sous ou avec contrainte physique (Conduisant généralement à une blessure interne)"},
                    new Deviation { Label="Surprise, frayeur, violence, agression, menace, présence"},
                };

                foreach (Deviation d in deviations)
                {
                    context.Deviations.Add(d);
                }

                context.SaveChanges();

                transaction.Commit();
            }
        }
    }
}
