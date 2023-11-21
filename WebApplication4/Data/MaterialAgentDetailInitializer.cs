using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class MaterialAgentDetailInitializer
    {

        private static int searchIDAgent(string s, AccidentContext context)
        {
            int id = context.MaterialAgents.First(a => a.Label == s).ID;
            return id;
        }

        private static void saveAgentDetails(MaterialAgentDetail[] materialAgents, AccidentContext context)
        {
            foreach (MaterialAgentDetail agent in materialAgents)
            {
                context.MaterialAgentDetails.Add(agent);
            }

            context.SaveChanges();
        }

        public static void Initialize(AccidentContext context)
        {
            context.Database.EnsureCreated();

            if (context.MaterialAgentDetails.Any())
            {
                return;
            }

            using (var transaction = context.Database.BeginTransaction())
            {
                int agentID = searchIDAgent("Bâtiments, constructions, surface – à niveau - (intérieur ou extérieur, fixe ou mobile, temporaires ou non)", context);

                var agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0100, Label = "Bâtiments, construction -à niveau (intérieur ou extérieur, fixes ou mobiles, temporaires ou non) – Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0101, Label = "Eléments de bâtiments, de construction – Portes, murs, cloisons,…et ostacles par destination (fenêtre, baies vitrées,…)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0102, Label = "Surface ou circulation à niveau – sols (intérieur ou extérieur, terrains agricoles, terrains de sport, sols glissants, sols encombrés, plancher,…)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0103, Label = "Surface à niveau – flottantes" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0199, Label = "Autre bâtiments, constructions, surfaces à niveau – connus du groupe 01 mais non listé ci-dessus" },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Bâtiments, constructions, surface – en hauteur - (intérieur ou extérieur)", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0200, Label = "Bâtiments, construction, surfaces – en hauteur (intérieur ou extérieur) – Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0201, Label = "Partie de bâtiment en hauteur – fixes (toitures, terrasses, ouvertures, escaliers, quais)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0202, Label = "Construction, surface en hauteur – fixes (comprend les passerelles, échelles fixes, pylônes)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0203, Label = "Construction, surface en hauteur – Mobiles (comprend échafaudages, échelles mobiles, nacelles, plate-forme élévatrice)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0204, Label = "Construction, surface en hauteur – Temporaire (comprend les échafaudages temporaires, harnais, balançoires)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0205, Label = "Construction, surface en hauteur – Flottantes (comprend les plate-formes de forage, les échafaudages sur barques)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0299, Label = "Autre bâtiments, constructions, surfaces en hauteur – connus du groupe 02 mais non listé ci-dessus" },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Bâtiments, constructions, surface – en profondeur (intérieur ou extérieur)", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0300, Label = "Bâtiment, construction, surface – en profondeur (intérieur ou extérieur) – Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0301, Label = "Fouilles, tranchée, puits, fosse, escarpements, fosses de garage" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0302, Label = "Souterrains, galeries" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0303, Label = "Milieux sous-marins" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0399, Label = "Autre bâtiment, construction, surface en profondeur connus du groupe 03 mais non listé ci-dessus." },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Dispositif de distribution de matière, d’alimentation, canalisation", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0400, Label = "Dispositif de distribution de matière, d’alimentation, canalisation – Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0401, Label = "Dispositif de distribution de matière, d’alimentation, canalisation - fixes – pour gaz, air, liquides, solides – y compris les trémies" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0402, Label = "Dispositif de distribution de matière, d’alimentation, canalisation – mobiles" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0403, Label = "Egouts, drainages" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0499, Label = "Dispositif de distribution de matière, d’alimentation, canalisation connus du groupe 04 mais non listé ci- dessus." },
                };

                saveAgentDetails(agentDetails, context);


                agentID = searchIDAgent("Moteurs, dispositifs de transmission et de stockage d’énergie", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0500, Label = "Moteur, dispositifs de transmission et de stockage d’énergie – Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0501, Label = "Moteur, générateur d’énergie (thermique, électrique, rayonnement) y compris les compresseurs, les pompes" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0502, Label = "Dispositifs de transmission et stockage d’énergie (mécanique, pneumatique, hydraulique, électrique y compris batteries et accumulateurs)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0599, Label = "Autres moteurs, dispositifs de transmission et de stockage d’énergie connus du groupe 05 mais non listé ci-dessus" },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Outils à main, non motorisés", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0600, Label = "Outil à main non motorisés - Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0601, Label = "Outil à main non motorisés - pour scier" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0602, Label = "Outil à main non motorisés - pour couper, séparer - (comprend ciseaux, cisailles, sécateurs)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0603, Label = "Outil à main non motorisés - pour tailler, mortaiser, ciseler, rogner, tondre" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0604, Label = "Outil à main non motorisés – pour gratter, polir, poncer" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0605, Label = "Outil à main non motorisés - pour percer, tourner, visser" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0606, Label = "Outil à main non motorisés - pour clouer, riveter, agrafer" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0607, Label = "Outil à main non motorisés - pour coudre, tricoter" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0608, Label = "Outil à main non motorisés - pour souder, coller" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0609, Label = "Outil à main non motorisés - pour extraction de matériaux et de travail du sol - (comprend les outils agricoles" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0610, Label = "Outil à main non motorisés - pour cirer, lubrifier, laver, nettoyer" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0611, Label = "Outil à main non motorisés - pour peindre" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0612, Label = "Outil à main non motorisés – pour maintenir, saisir" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0613, Label = "Outil à main non motorisés - pour travaux de cuisine (sauf couteaux)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0614, Label = "Outil à main non motorisés - pour travaux médicaux et chirurgicaux – piquant, coupant" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0615, Label = "Outil à main non motorisés - pour travaux médicaux et chirurgicaux - non coupant, autres" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0699, Label = "Autres outil à main non motorisés connus du groupe 06 mais non listé ci-dessus" },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Outils tenus ou guidés à la main, mécaniques", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0700, Label = "Outil tenu ou guidé à la main, mécanique - Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0701, Label = "Outil mécanique à la main - pour scier" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0702, Label = "Outil mécanique à la main - pour couper, séparer - (comprend ciseaux, cisailles, sécateurs)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0703, Label = "Outil mécanique à la main – pour tailler, mortaiser, ciseler, rogner, tondre - (taille haie voir 09.02)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0704, Label = "Outil mécanique à la main - pour gratter, polir, poncer - (comprend tronçonneuse à disque)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0705, Label = "Outil mécanique à la main - pour percer, tourner, visser" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0706, Label = "Outil mécanique à la main - pour clouer, riveter, agrafer" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0707, Label = "Outil mécanique à la main - pour coudre, tricoter" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0708, Label = "Outil mécanique à la main - pour souder, coller" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0709, Label = "Outil mécanique à la main - pour extraction de matériaux et travail du sol - (comprend les outils agricoles, les brise-béton)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0710, Label = "Outil mécanique à la main - pour cirer, lubrifier, laver, nettoyer - (comprend aspirateur, nettoyeur haute pression)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0711, Label = "Outil mécanique à la main - pour peindre" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0712, Label = "Outil mécanique à la main - pour maintenir, saisir" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0713, Label = "Outil mécanique à la main – pour travaux de cuisine (sauf couteaux)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0714, Label = "Outil mécanique à la main - pour chauffer - (comprend séchoir, décapeur thermique, fer à repasser)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0715, Label = "Outil mécanique à la main - pour travaux médicaux et chirurgicaux – piquants, coupants" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0716, Label = "Outil mécanique à la main - pour travaux médicaux et chirurgicaux – non coupant, autres 07-17 Pistolets pneumatiques (sans précision de l’outil)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0799, Label = "Autres outils mécanique tenus ou guidé à main motorisés connus du groupe 07 mais non listé ci-dessus." },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Outils à main – sans précision sur la motorisation", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0800, Label = "Outil à main - sans précision sur la motorisation - Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0801, Label = "Outil à main sans précision sur la motorisation - pour scier" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0802, Label = "Outil à main sans précision sur la motorisation - pour couper, séparer - (comprend ciseaux, cisailles, sécateurs)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0803, Label = "Outil à main sans précision sur la motorisation – pour tailler, mortaiser, ciseler, rogner, tondre" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0804, Label = "Outil à main sans précision sur la motorisation - pour gratter, polir, poncer" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0805, Label = "Outil à main sans précision sur la motorisation - pour percer, tourner, visser" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0806, Label = "Outil à main sans précision sur la motorisation - pour clouer, riveter, agrafer" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0807, Label = "Outil à main sans précision sur la motorisation - pour coudre, tricoter" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0808, Label = "Outil à main sans précision sur la motorisation - pour souder, coller" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0809, Label = "Outil à main sans précision sur la motorisation - pour extraction de matériaux et travail au sol (comprend les outils agricoles)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0810, Label = "Outil à main sans précision sur la motorisation - pour cirer, lubrifier, laver, nettoyer" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0811, Label = "Outil à main sans précision sur la motorisation - pour peindre" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0812, Label = "Outil à main sans précision sur la motorisation - pour maintenir, saisir" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0813, Label = "Outil à main sans précision sur la motorisation - pour travaux de cuisine" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0814, Label = "Outil à main sans précision sur la motorisation - pour travaux médicaux et chirurgicaux - piquants, coupants" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0815, Label = "Outil à main sans précision sur la motorisation - pour travaux médicaux et chirurgicaux - non coupants - autres" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0899, Label = "Autres outils à main sans précision sur la motorisation connus du groupe 08 mais non listé ci-dessus." },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Machine et équipement – portables ou mobiles", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0900, Label = "Machines et équipements – portables ou mobiles - Non précisé 09.01Machine portable ou mobiles d’extraction et de travail du sol – mines, carrières et engins de bâtiments, travaux publics" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0902, Label = "Machines portables ou mobiles – de travail du sol, agriculture" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0903, Label = "Machine portables ou mobiles (hors travail au sol) - de chantier de construction" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0904, Label = "Machine mobiles de nettoyage des sols" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 0999, Label = "Autres machines et équipements portables ou mobiles connus du groupe 09 mais non listés ci-dessus" },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Machines et équipements – fixes", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1000, Label = "Machines et équipements - fixes - Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1001, Label = "Machines fixes d’extraction et de travail du sol" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1002, Label = "Machine pour la préparation des matériaux, concasser, pulvériser, filtrer, séparer, mélanger, malaxer" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1003, Label = "Machines pour la transformation des matériaux - procédés chimiques (réacteurs, fermenteurs)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1004, Label = "Machines pour la transformation des matériaux - procédé à chaud (four, séchoir, étuves,..)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1005, Label = "Machines pour la transformation des matériaux - procédé à froid (produit de froid)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1006, Label = "Machines pour la transformation des matériaux - autres procédés" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1007, Label = "Machines pour la transformation des matériaux –" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1008, Label = "Machines à former - par calandrage, laminage, machines à cylindres (y compris machine de papeterie)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1009, Label = "Machine à former - par injection, extrusion, soufflage, filage, moulage, fusion, coulée" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1010, Label = "Machines d’usinage - pour raboter, fraiser, surfacer, meuler, polir, tourner, percer" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1011, Label = "Machines d’usinage - pour scier" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1012, Label = "Machines d’usinage - pour couper, fendre, rogner -(comprend presse à découper, cisaille, massicot, oxycoupage)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1013, Label = "Machines pour le traitement des surfaces - nettoyer, laver, sécher, peindre, imprimer" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1014, Label = "Machines pour le traitement des surfaces - galvanisation, traitement électrolytique des surfaces" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1015, Label = "Machines à assembler (souder, coller, clouer, visser, riveter, filer, câbler, coudre, agrafer)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1016, Label = "Machines à conditionner, emballer (remplir, étiqueter, fermer)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1017, Label = "Autres machines d’industries spécifiques (machines diverses de contrôle, d’essais)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1018, Label = "Machines spécifiques utilisées en agriculture ne se rattachant pas au machines ci-dessus" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1099, Label = "Autres machines et équipements fixes connus du groupe 10 mais non listés ci-dessus" },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Dispositif de convoyage, de transport et de stockage", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1100, Label = "Dispositif de convoyage, de transport et de stockage - Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1101, Label = "Convoyeurs fixes, matériels et système de manutention continue - à tapis, escaliers roulants, téléphériques, transporteurs…" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1102, Label = "Elévateurs, ascenseurs, matériels de mise à niveau - monte-charge, élévateur à godets, vérin, cric, …" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1103, Label = "Grues fixes, mobiles, embarquées sur véhicules, ponts roulants, matériels d’élévation à charge suspendue" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1104, Label = "Dispositif mobile de manutention, chariots de manutention (chariots motorisés ou non - brouette, transpalettes,…" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1105, Label = "Appareils de levage, amarrage, préhension et matériels divers de manutention - (comprend élingues, crochets, cordage…)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1106, Label = "Dispositifs de stockage, emballage, conteneurs (silos, réservoirs) – fixes - citernes, bassins, réservoir,…" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1107, Label = "Dispositifs de stockage, emballage, conteneurs - mobiles" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1108, Label = "Accessoires de stockage, rayonnages, paletiers, palettes" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1109, Label = "Emballages divers, petits et moyens, mobiles (bennes, récipients divers, bouteilles, caisses, extincteurs…)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1199, Label = "Autres dispositif de convoyage, de transport et de stockage connus du groupe 11 mais non listés ci-dessus" },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Véhicule terrestres", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1200, Label = "Véhicules terrestres - Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1201, Label = "Véhicules - poids lourds : camions de charges, bus et autocars (transports de passagers)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1202, Label = "Véhicules - légers : charges ou passagers" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1203, Label = "Véhicules - deux, trois roues, motorisés ou non" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1204, Label = "Autres véhicules terrestres : ski, patins à roulettes,…" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1299, Label = "Autres véhicules terrestres connus du groupe 12 mais non listés ci-dessus" },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Autres véhicules de transports", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1300, Label = "Autres véhicules de transport - Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1301, Label = "Véhicules - sur rails y compris monorails suspendus : charges" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1302, Label = "Véhicules - sur rails y compris monorails suspendus : passagers" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1303, Label = "Véhicules - nautiques : charges" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1304, Label = "Véhicules - nautiques : passagers" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1305, Label = "Véhicules - nautiques : pêche" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1306, Label = "Véhicules - aérien : charge" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1307, Label = "Véhicules - aérien : passagers" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1399, Label = "Autres véhicules de transport connus du groupe 13 mais non listés ci-dessus" },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Matériaux, objets, produits, éléments constitutifs de machines, bris, poussières", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1400, Label = "Matériaux, objets, produits, éléments constitutifs de machines, bris, poussières - Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1401, Label = "Matériaux de construction – gros et petits : -agent préfabriqué, coffrage, poutrelle, brique, tuile,…" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1402, Label = "Elements de construction ou éléments constitutifs de machine, de véhicule : -châssis, carter, manivelle, roue,…" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1403, Label = "Pièces travaillées ou éléments, outils de machines (y compris les fragments et éclats en provenance de ces agents matériels)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1404, Label = "Eléments d’assemblage : visserie, clou, boulon,…" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1405, Label = "Particules, poussières, éclats, morceaux, projections, échardes et autres éléments brisés" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1406, Label = "Produits - de l’agriculture (comprend grains, paille, autres produits agricoles)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1507, Label = "Produits – pour l’agriculture, l’élevage (comprend engrais, aliments pour le bétail)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1408, Label = "Produits stockés - comprend les objets et emballages disposés dans un stockage" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1409, Label = "Produits stockés - en rouleaux, bobines" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1410, Label = "Charges - transportées sur dispositif de manutention mécanique, de transport" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1411, Label = "Charges - suspendues à un dispositif de mise à niveau, une grue" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1412, Label = "Charges - manutentionnées à la main" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1499, Label = "Autres matériaux, objets, produits, éléments de machines connus du groupe 14 mais non listés ci-dessus" },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Substances chimiques, explosives, radioactives, biologiques", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1500, Label = "Substances chimiques, explosives, radioactives, biologiques - Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1501, Label = "Matières - caustiques, corrosives (solides, liquides ou gazeux)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1502, Label = "Matières - nocives, toxiques (solides, liquides ou gazeux)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1503, Label = "Matières - inflammables (solides, liquides ou gazeux)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1504, Label = "Matières - explosives, réactives (solides, liquides ou gazeux)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1505, Label = "Gaz, vapeurs sans effets spécifiques (inerte pour la vie, asphyxiantes)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1506, Label = "Substances - radioactives" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1507, Label = "Substances - biologiques" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1508, Label = "Substances, matières - sans danger spécifique (eau, matières inertes)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1599, Label = "Autres substances chimiques, explosives, radioactives, biologiques connus du groupe 15 mais non listés ci-dessus" },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Dispositif et équipement de sécurité", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1600, Label = "Dispositifs et équipements de sécurité - Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1601, Label = "Dispositifs de sécurité - sur machine" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1602, Label = "Dispositifs de protection - individuels" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1603, Label = "Dispositifs et appareils - de secours" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1699, Label = "Autres dispositifs et équipements de sécurité connus du groupe 16 mais non listés ci-dessus" },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Equipements de bureau et personnels, matériel de sport, armes, appareillage domestique", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1700, Label = "Equipements de bureau et personnels, matériel de sport, armes, appareillage domestique - Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1701, Label = "Mobilier" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1702, Label = "Equipements – informatiques, bureautique, reprographie, communication" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1703, Label = "Equipements – pour enseignement, écriture, dessin - comprend : machines à écrire, timbrer, agrandisseur, horodateur,…" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1704, Label = "Objets et équipements pour le sport et les jeux" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1505, Label = "Armes" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1706, Label = "Objets personnels, vêtements" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1707, Label = "Instruments de musique" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1708, Label = "Appareillage, ustensiles, objets, linge de type domestique (usage professionnel)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1799, Label = "Autres équipements de bureau et personnels, matériel de sport, armes connus du groupe 17 mais non listés ci-dessus" },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Organismes vivants et êtres humains", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1800, Label = "Organismes vivants et êtres humains - Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1801, Label = "Arbres, plantes et cultures" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1802, Label = "Animaux - domestiques et d’élevage" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1803, Label = "Animaux - sauvages, insectes, serpents" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1804, Label = "Micro-organismes" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1805, Label = "Agents infectieux viraux" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1806, Label = "Humain" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1899, Label = "Autres organismes vivants et êtres humains connus du groupe 18 mais non listés ci-dessus" },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Déchets en vrac", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1900, Label = "Déchets en vrac - Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1901, Label = "Déchets en vrac - de matière, produits, matériaux, objets" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1902, Label = "Déchets en vrac - de substances chimiques" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1903, Label = "Déchets en vrac - de substances biologiques, végétaux, animaux" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 1999, Label = "Autres déchets en vrac connus du groupe 16 mais non listés ci-dessus" },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Phénomène physique et éléments naturels", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 2000, Label = "Phénomène physiques et éléments naturels - Non précisé" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 2001, Label = "Phénomène physiques - bruit, radiation naturelle, lumière, arc lumineux, pressurisation, dépressurisation, pression." },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 2002, Label = "Eléments naturels et atmosphériques - (comprend étendues d’eau, boue, pluie, grêle, neige, verglas, coup de vent,…)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 2003, Label = "Catastrophes naturelles - (comprend inondation, volcanisme, tremblement de terre, raz de marée, feu, incendie,…)" },
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 2099, Label = "Autres phénomène physiques et éléments naturels connus du groupe 20 mais non listés ci-dessus" },
                };

                saveAgentDetails(agentDetails, context);

                agentID = searchIDAgent("Autres agents matériels non listés dans cette classification", context);

                agentDetails = new MaterialAgentDetail[]
                {
                    new MaterialAgentDetail{ MaterialAgentID = agentID, Code = 2100, Label = "Autres agents matériels non listés dans cette classification" },
                };

                saveAgentDetails(agentDetails, context);

                transaction.Commit();
            }
        }
    }
}
