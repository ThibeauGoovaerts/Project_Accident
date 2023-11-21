using WebApplication4.Models;

namespace WebApplication4.Data {
	public class LesionSeatInitializer {
		public static void Initialize(AccidentContext context) {
			context.Database.EnsureCreated();

			if (context.LesionSeats.Any()) {
				return;
			}

			using (var transaction = context.Database.BeginTransaction()) {
				var lesionSeats = new LesionSeat[]
				{
					new LesionSeat { Label="Localisation de la blessure non déterminée"},
					new LesionSeat { Label="Tête, sans autre spécification"},
					new LesionSeat { Label="Cou, y compris colonne vertébrale et vertèbres du cou"},
					new LesionSeat { Label="Dos, y compris colonne vertébrale et vertèbres du dos"},
					new LesionSeat { Label="Torse et organes, sans autre spécification"},
					new LesionSeat { Label="Membres inférieurs, sans autre spécification"},
					new LesionSeat { Label="Membres supérieurs, sans autre spécification"},
					new LesionSeat { Label="Ensemble du corps et endroits multiples, sans autre spécification"},
					new LesionSeat { Label="Autres parties du corps blessées"},
				};

				foreach (LesionSeat l in lesionSeats) {
					context.LesionSeats.Add(l);
				}

				context.SaveChanges();

				transaction.Commit();
			}
		}
	}
}

