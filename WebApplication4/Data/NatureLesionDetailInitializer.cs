using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class NatureLesionDetailInitializer
    {
        private static int searchIDNature(string s, AccidentContext context)
        {
            int id = context.NatureLesions.First(d => d.Label == s).ID;
            return id;
        }

        private static void saveNatureDetails(NatureLesionDetail[] NatureLesionDetails, AccidentContext context)
        {
            foreach (NatureLesionDetail n in NatureLesionDetails)
            {
                context.NatureLesionDetails.Add(n);
            }
            context.SaveChanges();
        }

        public static void Initialize(AccidentContext context)
        {
            context.Database.EnsureCreated();

            if (context.NatureLesionDetails.Any())
            {
                return;
            }

            using (var transaction = context.Database.BeginTransaction())
            {

                int natureID = searchIDNature("Nature de la blessure inconnue ou non précisée", context);

                var natureDetails = new NatureLesionDetail[]
                {
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=00, Label="Blessure inconnue ou non précisée"},
                };

                saveNatureDetails(natureDetails, context);

                natureID = searchIDNature("Plaies et blessures superficielles", context);

                natureDetails = new NatureLesionDetail[]
                {
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=11, Label="Blessures superficielles"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=12, Label="Plaies ouvertes"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=13, Label="Plaies avec pertes de substances"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=19, Label="Autres types de plaies et de blessures superficielles"},
                };

                saveNatureDetails(natureDetails, context);

                natureID = searchIDNature("Fractures osseuses", context);

                natureDetails = new NatureLesionDetail[]
                {
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=21, Label="Fractures fermées"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=22, Label="Fractures ouvertes"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=29, Label="Autres types de fractures osseuses"},
                };

                saveNatureDetails(natureDetails, context);

                natureID = searchIDNature("Luxations, entorses et foulures", context);

                natureDetails = new NatureLesionDetail[]
                {
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=31, Label="Luxations et sub-luxations"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=32, Label="Entorses et foulures"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=39, Label="Autres types de luxations, d'entorses et de foulures"},
                };

                saveNatureDetails(natureDetails, context);

                natureID = searchIDNature("Amputations traumatiques (perte de parties du corps)", context);

                natureDetails = new NatureLesionDetail[]
                {
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=41, Label="Amputations"},
                };

                saveNatureDetails(natureDetails, context);

                natureID = searchIDNature("Commotions et traumatismes internes", context);

                natureDetails = new NatureLesionDetail[]
                {
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=51, Label="Commotions et traumatismes internes"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=52, Label="Traumatismes internes"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=53, Label="Commotions et traumatismes internes qui, en l'absence de traitement, peuvent mettre la survie en cause"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=54, Label="Effets nocifs de l'électricité"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=59, Label="Autres types de commotions et de traumatismes internes"},
                };

                saveNatureDetails(natureDetails, context);

                natureID = searchIDNature("Brûlures, brûlures par exposition à un liquide bouillant et gelures", context);

                natureDetails = new NatureLesionDetail[]
                {
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=61, Label="Brûlures et brûlures par exposition à un liquide bouillant (thermiques)"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=62, Label="Brûlures chimiques (corrosions)"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=63, Label="Gelures"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=69, Label="Autres types de brûlures, de brûlures par exposition à un liquide bouillant et de gelures"},
                };

                saveNatureDetails(natureDetails, context);

                natureID = searchIDNature("Empoisonnements et infections", context);

                natureDetails = new NatureLesionDetail[]
                {
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=71, Label="Empoisonnements aigus"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=72, Label="Infections aiguës"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=79, Label="Autres types d'empoisonnements et d'infections"},
                };

                saveNatureDetails(natureDetails, context);

                natureID = searchIDNature("Noyade et asphyxie", context);

                natureDetails = new NatureLesionDetail[]
                {
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=81, Label="Asphyxies"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=82, Label="Noyades et submersions non mortelles"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=89, Label="Autres types de noyades et d'asphyxies"},
                };

                saveNatureDetails(natureDetails, context);

                natureID = searchIDNature("Effets du bruit, des vibrations et de la pression", context);

                natureDetails = new NatureLesionDetail[]
                {
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=91, Label="Perte auditive aiguë"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=92, Label="Effets de la pression (barotrauma)"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=99, Label="Autres effets du bruit, des vibrations et de la pression"},
                };

                saveNatureDetails(natureDetails, context);

                natureID = searchIDNature("Effets des extrêmes de température, de la lumière et des radiations", context);

                natureDetails = new NatureLesionDetail[]
                {
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=101, Label="Chaleur et coups de soleil"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=102, Label="Effets des radiations (non thermiques)"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=103, Label="Effets du froid"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=109, Label="Autres effets des extrêmes de température, de la lumière et des radiations"},
                };

                saveNatureDetails(natureDetails, context);

                natureID = searchIDNature("Choc", context);

                natureDetails = new NatureLesionDetail[]
                {
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=111, Label="Chocs consécutifs à des agressions et menaces"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=112, Label="Chocs traumatiques"},
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=119, Label="Autres types de chocs"},
                };

                saveNatureDetails(natureDetails, context);

                natureID = searchIDNature("Blessures multiples", context);

                natureDetails = new NatureLesionDetail[]
                {
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=120, Label="Blessures multiples"},
                };

                saveNatureDetails(natureDetails, context);

                natureID = searchIDNature("Autres blessures déterminées non classées sous d'autres rubriques", context);

                natureDetails = new NatureLesionDetail[]
                {
                    new NatureLesionDetail{ NatureLesionID=natureID, Code=999, Label="Autres blessures déterminées non classées sous d'autres rubriques"},
                };

                saveNatureDetails(natureDetails, context);

                transaction.Commit();
            }
        }
    }
}
