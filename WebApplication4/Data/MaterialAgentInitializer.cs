using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class MaterialAgentInitializer
    {
        public static void Initialize(AccidentContext context)
        {
            context.Database.EnsureCreated();

            if (context.MaterialAgents.Any())
            {
                return;
            }

            using (var transaction = context.Database.BeginTransaction())
            {
                var materialAgents = new MaterialAgent[]
                {
                    new MaterialAgent { Label="Bâtiments, constructions, surface – à niveau - (intérieur ou extérieur, fixe ou mobile, temporaires ou non)" },
                    new MaterialAgent { Label="Bâtiments, constructions, surface – en hauteur - (intérieur ou extérieur)" },
                    new MaterialAgent { Label="Bâtiments, constructions, surface – en profondeur (intérieur ou extérieur)" },
                    new MaterialAgent { Label="Dispositif de distribution de matière, d’alimentation, canalisation" },
                    new MaterialAgent { Label="Moteurs, dispositifs de transmission et de stockage d’énergie" },
                    new MaterialAgent { Label="Outils à main, non motorisés" },
                    new MaterialAgent { Label="Outils tenus ou guidés à la main, mécaniques" },
                    new MaterialAgent { Label="Outils à main – sans précision sur la motorisation" },
                    new MaterialAgent { Label="Machine et équipement – portables ou mobiles" },
                    new MaterialAgent { Label="Machines et équipements – fixes" },
                    new MaterialAgent { Label="Dispositif de convoyage, de transport et de stockage" },
                    new MaterialAgent { Label="Véhicule terrestres" },
                    new MaterialAgent { Label="Autres véhicules de transports" },
                    new MaterialAgent { Label="Matériaux, objets, produits, éléments constitutifs de machines, bris, poussières" },
                    new MaterialAgent { Label="Substances chimiques, explosives, radioactives, biologiques" },
                    new MaterialAgent { Label="Dispositif et équipement de sécurité" },
                    new MaterialAgent { Label="Equipements de bureau et personnels, matériel de sport, armes, appareillage domestique" },
                    new MaterialAgent { Label="Organismes vivants et êtres humains" },
                    new MaterialAgent { Label="Déchets en vrac" },
                    new MaterialAgent { Label="Phénomène physique et éléments naturels" },
                    new MaterialAgent { Label="Autres agents matériels non listés dans cette classification" },
                };

                foreach (MaterialAgent m in materialAgents)
                {
                    context.MaterialAgents.Add(m);
                }

                context.SaveChanges();

                transaction.Commit();
            }
        }
    }
}
