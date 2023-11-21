using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class NatureLesionInitializer
    {
        public static void Initialize(AccidentContext context)
        {
            context.Database.EnsureCreated();

            if (context.NatureLesions.Any())
            {
                return;
            }

            using (var transaction = context.Database.BeginTransaction())
            {
                var natureLesion = new NatureLesion[]
                {
                    new NatureLesion { Label="Nature de la blessure inconnue ou non précisée"},
                    new NatureLesion { Label="Plaies et blessures superficielles"},
                    new NatureLesion { Label="Fractures osseuses"},
                    new NatureLesion { Label="Luxations, entorses et foulures"},
                    new NatureLesion { Label="Amputations traumatiques (perte de parties du corps)"},
                    new NatureLesion { Label="Commotions et traumatismes internes"},
                    new NatureLesion { Label="Brûlures, brûlures par exposition à un liquide bouillant et gelures"},
                    new NatureLesion { Label="Empoisonnements et infections"},
                    new NatureLesion { Label="Noyade et asphyxie"},
                    new NatureLesion { Label="Effets du bruit, des vibrations et de la pression"},
                    new NatureLesion { Label="Effets des extrêmes de température, de la lumière et des radiations"},
                    new NatureLesion { Label="Choc"},
                    new NatureLesion { Label="Blessures multiples"},
                    new NatureLesion { Label="Autres blessures déterminées non classées sous d'autres rubriques"},
                };

                foreach (NatureLesion n in natureLesion)
                {
                    context.NatureLesions.Add(n);
                }

                context.SaveChanges();

                transaction.Commit();
            }
        }
    }
}
