using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class DeviationDetailInitializer
    {
        private static int searchIDDeviation(string s, AccidentContext context)
        {
            int id = context.Deviations.First(d => d.Label == s).ID;
            return id;
        }

        private static void saveDeviationDetails(DeviationDetail[] deviationDetails, AccidentContext context)
        {
            foreach (DeviationDetail deviationDetail in deviationDetails)
            {
                context.DeviationDetails.Add(deviationDetail);
            }

            context.SaveChanges();
        }

        public static void Initialize(AccidentContext context)
        {
            context.Database.EnsureCreated();

            if (context.DeviationDetails.Any())
            {
                return;
            }

            using (var transaction = context.Database.BeginTransaction())
            {

                int deviationID = searchIDDeviation("Déviation par problème électrique, explosion, feu", context);

                var deviationDetails = new DeviationDetail[]
                {
                    new DeviationDetail{ DeviationID=deviationID, Code= 10, Label="Déviation par problème électrique, explosion, feu – Non précisé"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 11, Label="Problème électrique par défaillance dans l’installation – entraînant un contact indirect"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 12, Label="Problème électrique – entraînant un contact direct"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 13, Label="Explosion"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 14, Label="Incendie, embrasement"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 19, Label="Autre déviation connue du groupe 10 mais non listée ci-dessus"},
                };

                saveDeviationDetails(deviationDetails, context);

                deviationID = searchIDDeviation("Déviation par débordement, renversement, fuite, écoulement, vaporisation, dégagement", context);

                deviationDetails = new DeviationDetail[]
                {
                    new DeviationDetail{ DeviationID=deviationID, Code = 20, Label="Déviation par débordement, renversement, fuite, écoulement, vaporisation, dégagement – Non précisé"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 21, Label="A l’état solide - débordement, renversement"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 22, Label="A l’état liquide - fuite, suintement, écoulement, éclaboussure, aspersion"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 23, Label="A l’état gazeux - vaporisation, formation d’aérosol, formation de gaz"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 24, Label="Pulvérulent - génération de fumée, émission de poussière, particules"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 29, Label="Autre déviation connue du groupe 20 mais non listée ci-dessus"},
                };
                //new DeviationDetail{ DeviationID=deviationID, Label=""},
                saveDeviationDetails(deviationDetails, context);

                deviationID = searchIDDeviation("Rupture, bris, éclatement, glissade, chute, effondrement d’Agent matériel", context);

                deviationDetails = new DeviationDetail[]
                {
                    new DeviationDetail{ DeviationID=deviationID, Code = 30, Label="Rupture, bris, éclatement, glissade, chute, effondrement d’Agent matériel – Non précisé"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 31, Label="Rupture de matériel, aux joints, aux connexions"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 32, Label="Rupture, éclatement, causant des éclats (bois, verre, métal, pierre, plastique, autres)"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 33, Label="Glissade, chute, effondrement d’agent matériel – supérieur (tombant sur la victime)"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 34, Label="Glissade, chute, effondrement d’agent matériel – inférieur (entraînant la victime)"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 35, Label="Glissade, chute, effondrement d’agent matériel – de plain pied"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 39, Label="Autre déviation connue du groupe 30 mais non listée ci-dessus"},
                };

                saveDeviationDetails(deviationDetails, context);

                deviationID = searchIDDeviation("Perte, totale ou partielle, de contrôle de machine, moyen de transport, équipement de manutention, outil à main, objet, animal", context);

                deviationDetails = new DeviationDetail[]
                {
                    new DeviationDetail{ DeviationID=deviationID, Code = 40, Label="Perte, totale ou partielle, de contrôle de machine, moyen de transport - équipement de manutention, outil à main, objet, animal –Non précisé"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 41, Label="Perte, totale ou partielle, de contrôle - de machine, ainsi que de la matière travaillée par la machine"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 42, Label="Perte, totale ou partielle, de contrôle de moyen de transport - d’équipement de manutention (motorisé ou non)"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 43, Label="Perte, totale ou partielle, de contrôle d’outil à main (motorisé ou non) ainsi que de la matière travaillée par l’outil"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 44, Label="Perte, totale ou partielle, de contrôle d’objet (porté, déplacé, manipulé, etc.) "},
                    new DeviationDetail{ DeviationID=deviationID, Code = 45, Label="Perte, totale ou partielle, de contrôle d’animal"},
                    new DeviationDetail{ DeviationID=deviationID, Code = 49, Label="Autre déviation connue du groupe 40 mais non listée ci-dessus"},
                };

                saveDeviationDetails(deviationDetails, context);

                deviationID = searchIDDeviation("Glissade ou trébuchement avec chute, chute de personne", context);

                deviationDetails = new DeviationDetail[]
                {
                    new DeviationDetail{ DeviationID=deviationID, Code= 50,Label="Glissade ou trébuchement avec chute, chute de personne – Non précisé"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 51,Label="Chute de personne – de hauteur"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 52,Label="Glissade ou trébuchement avec chute, chute de personne – de plain-pied"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 59,Label="Autre déviation connue du groupe 50 mais non listée ci-dessus"},
                };

                saveDeviationDetails(deviationDetails, context);

                deviationID = searchIDDeviation("Mouvement du corps sans contrainte physique (Conduisant généralement à une blessure externe)", context);

                deviationDetails = new DeviationDetail[]
                {
                    new DeviationDetail{ DeviationID=deviationID, Code=60, Label="Mouvement du corps sans contrainte physique (Conduisant généralement à une blessure externe) – Non précisé"},
                    new DeviationDetail{ DeviationID=deviationID, Code=61, Label="En marchant sur un objet coupant"},
                    new DeviationDetail{ DeviationID=deviationID, Code=62, Label="En s’agenouillant, s’asseyant, s’appuyant contre"},
                    new DeviationDetail{ DeviationID=deviationID, Code=63, Label="En étant attrapé, entraîné, par quelque chose ou par son élan"},
                    new DeviationDetail{ DeviationID=deviationID, Code=64, Label="Mouvement non coordonnés, gestes intempestifs, inopportuns"},
                    new DeviationDetail{ DeviationID=deviationID, Code=69, Label="Autre déviation connue du groupe 60 mais non listée ci-dessus"},
                };

                saveDeviationDetails(deviationDetails, context);

                deviationID = searchIDDeviation("Mouvement du corps sous ou avec contrainte physique (Conduisant généralement à une blessure interne)", context);

                deviationDetails = new DeviationDetail[]
                {
                    new DeviationDetail{ DeviationID=deviationID, Code= 70, Label="Mouvement du corps sous ou avec contrainte physique (Conduisant généralement à une blessure interne) – Non précisé"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 71, Label="En soulevant, en portant, en se soulevant"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 72, Label="En poussant, en tractant"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 73, Label="En déposant, en se baissant"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 74, Label="En torsion, en rotation, en se tournant"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 75, Label="En marchant lourdement, faux pas, glissade – sans chute"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 79, Label="Autre déviation connue du groupe 70 mais non listée ci-dessus"},
                };

                saveDeviationDetails(deviationDetails, context);

                deviationID = searchIDDeviation("Surprise, frayeur, violence, agression, menace, présence", context);

                deviationDetails = new DeviationDetail[]
                {
                    new DeviationDetail{ DeviationID=deviationID, Code= 80, Label="Surprise, frayeur, violence, agression, menace, présence – Non précisé"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 81, Label="Surprise, frayeur"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 82, Label="Violence, agression, menace entre membres de l’entreprise soumis à l’autorité de l’employeur"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 83, Label="Violence, agression, menace – provenant de personnes externes à l’entreprise envers les victimes dans le cadre de leur formation"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 84, Label="Agression, bousculade – par animal"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 85, Label="Présence de la victime ou d’un tiers créant en soi un danger pour elle/lui-même et le cas échéant pour autrui"},
                    new DeviationDetail{ DeviationID=deviationID, Code= 89, Label="Autre déviation connue du groupe 80 mais non listée ci-dessus"},
                };

                saveDeviationDetails(deviationDetails, context);

                transaction.Commit();
            }
        }
    }
}
