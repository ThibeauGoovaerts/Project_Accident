using WebApplication4.Models;

namespace WebApplication4.Data {
	public class ProposedMesureInitializer {
		public static void Initialize(AccidentContext context) {
			context.Database.EnsureCreated();

			if (context.ProposedMesures.Any()) {
				return;
			}

			using (var transaction = context.Database.BeginTransaction()) {
				var proposedMesures = new ProposedMesure[]
				{
					new ProposedMesure { Label="Néant"},
					new ProposedMesure { Label="Facteur individuel"},
					new ProposedMesure { Label="Facteur matériel"},
				};

				foreach (ProposedMesure p in proposedMesures) {
					context.ProposedMesures.Add(p);
				}

				context.SaveChanges();

				transaction.Commit();
			}
		}
	}
}

