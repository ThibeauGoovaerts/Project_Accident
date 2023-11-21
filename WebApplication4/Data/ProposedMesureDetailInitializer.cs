using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data {
	public class ProposedMesureDetailInitializer {
		private static int searchIDProposedMesureDetail(string s, AccidentContext context) {
			int id = context.ProposedMesures.First(d => d.Label == s).ID;
			return id;
		}

		private static void saveProposedMesureDetails(ProposedMesureDetail[] proposedMesureDetails, AccidentContext context) {
			foreach (ProposedMesureDetail proposedMesureDetail in proposedMesureDetails) {
				context.ProposedMesureDetails.Add(proposedMesureDetail);
			}

			context.SaveChanges();
		}

		public static void Initialize(AccidentContext context) {
			context.Database.EnsureCreated();

			if (context.ProposedMesureDetails.Any()) {
				return;
			}

			using (var transaction = context.Database.BeginTransaction()) {

				int proposedMesureID = searchIDProposedMesureDetail("Néant", context);
				
				var proposedMesureDetails = new ProposedMesureDetail[]
				{
					new ProposedMesureDetail{ ProposedMesureID = proposedMesureID, Code= 1, Label="Néant"},
				};

				ProposedMesure p = new ProposedMesure { Label = "aaaa" };

				saveProposedMesureDetails(proposedMesureDetails, context);

				proposedMesureID = searchIDProposedMesureDetail("Facteur individuel", context);

				proposedMesureDetails = new ProposedMesureDetail[]
				{
					new ProposedMesureDetail{ ProposedMesureID = proposedMesureID, Code= 21, Label="Poste de travail"},
					new ProposedMesureDetail{ ProposedMesureID = proposedMesureID, Code= 22, Label="Apprentissage"},
					new ProposedMesureDetail{ ProposedMesureID = proposedMesureID, Code= 23, Label="Révision des consignes"},
					new ProposedMesureDetail{ ProposedMesureID = proposedMesureID, Code= 24, Label="Surveillance des méthodes de travail"},
					new ProposedMesureDetail{ ProposedMesureID = proposedMesureID, Code= 25, Label="Adaptation physique ou psychique au poste de travail"},
					new ProposedMesureDetail{ ProposedMesureID = proposedMesureID, Code= 26, Label="Autres mesures individuelles"},
				};

				saveProposedMesureDetails(proposedMesureDetails, context);

				proposedMesureID = searchIDProposedMesureDetail("Facteur matériel", context);

				proposedMesureDetails = new ProposedMesureDetail[]
				{
					new ProposedMesureDetail{ ProposedMesureID = proposedMesureID, Code= 31, Label="Inspection"},
					new ProposedMesureDetail{ ProposedMesureID = proposedMesureID, Code= 32, Label="Entretien"},
					new ProposedMesureDetail{ ProposedMesureID = proposedMesureID, Code= 33, Label="Matériel"},
					new ProposedMesureDetail{ ProposedMesureID = proposedMesureID, Code= 34, Label="Equipement de protection individuelle ou collective"},
					new ProposedMesureDetail{ ProposedMesureID = proposedMesureID, Code= 35, Label="Environnement, facteurs d'ambiance"},
					new ProposedMesureDetail{ ProposedMesureID = proposedMesureID, Code= 36, Label="Autres mesures matérielles"},
				};

				saveProposedMesureDetails(proposedMesureDetails, context);

				transaction.Commit();
			}
		}
	}
}
