using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data {
	public class LesionSeatDetailInitializer {
		private static int searchIDLesionSeat(string s, AccidentContext context) {
			int id = context.LesionSeats.First(d => d.Label == s).ID;
			return id;
		}

		private static void saveLesionSeatDetails(LesionSeatDetail[] lesionSeatDetails, AccidentContext context) {
			foreach (LesionSeatDetail lesionSeatDetail in lesionSeatDetails) {
				context.LesionSeatDetails.Add(lesionSeatDetail);
			}

			context.SaveChanges();
		}

		public static void Initialize(AccidentContext context) {
			context.Database.EnsureCreated();

			if (context.LesionSeatDetails.Any()) {
				return;
			}

			using (var transaction = context.Database.BeginTransaction()) {

				int lesionSeatID = searchIDLesionSeat("Localisation de la blessure non déterminée", context);

				var lesionSeatDetails = new LesionSeatDetail[]
				{
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 00, Label="Localisation de la blessure non déterminé"},
				};

				saveLesionSeatDetails(lesionSeatDetails, context);

				lesionSeatID = searchIDLesionSeat("Tête, sans autre spécification", context);

				lesionSeatDetails = new LesionSeatDetail[]
				{
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code = 11, Label="Tête (caput), cerveau, nerfs crâniens et vaisseaux cérébraux"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code = 12, Label="Zone faciale"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code = 13, Label="Œil / yeux"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code = 14, Label="Oreille(s)"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code = 15, Label="Dentition"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code = 18, Label="Tête, multiples endroits affectés"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code = 19, Label="Autres parties de la tête"},
				};
				saveLesionSeatDetails(lesionSeatDetails, context);

				lesionSeatID = searchIDLesionSeat("Cou, y compris colonne vertébrale et vertèbres du cou", context);

				lesionSeatDetails = new LesionSeatDetail[]
				{
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code = 21, Label="Cou, y compris colonne vertébrale et vertèbres du cou"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code = 29, Label="Autres parties du cou"},
				};

				saveLesionSeatDetails(lesionSeatDetails, context);

				lesionSeatID = searchIDLesionSeat("Dos, y compris colonne vertébrale et vertèbres du dos", context);

				lesionSeatDetails = new LesionSeatDetail[]
				{
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code = 31, Label="Dos, y compris colonne vertébrale et vertèbres du dos"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code = 39, Label="Autres parties du dos"},
				};

				saveLesionSeatDetails(lesionSeatDetails, context);

				lesionSeatID = searchIDLesionSeat("Torse et organes, sans autre spécification", context);

				lesionSeatDetails = new LesionSeatDetail[]
				{
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 41,Label="Cage thoracique, côtes y compris omoplates et articulations\r\n"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 42,Label="Poitrine, y compris organes"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 43,Label="Abdomen et pelvis, y compris organes"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 48,Label="Torse, multiples endroits affectés"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 49,Label="Autres parties du torse"},
				};

				saveLesionSeatDetails(lesionSeatDetails, context);

				lesionSeatID = searchIDLesionSeat("Membres supérieurs, sans autre spécification", context);

				lesionSeatDetails = new LesionSeatDetail[]
				{
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 51,Label="Épaule et articulations de l'épaule"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 52,Label="Bras, y compris coude"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 53,Label="Main"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 54,Label="Doigt(s)"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 55,Label="Poignet"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 58,Label="Membres supérieurs, multiples endroits affectés"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 59,Label="Autres parties des membres supérieurs"},
				};

				saveLesionSeatDetails(lesionSeatDetails, context);

				lesionSeatID = searchIDLesionSeat("Membres inférieurs, sans autre spécification", context);

				lesionSeatDetails = new LesionSeatDetail[]
				{
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 61,Label="Hanche et articulation de la hanche"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 62,Label="Jambe, y compris genou"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 63,Label="Cheville"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 64,Label="Pied"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 65,Label="Orteil(s)"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 68,Label="Membres inférieurs, multiples endroits affectés"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 69,Label="Autres parties des membres inférieurs"},
				};

				saveLesionSeatDetails(lesionSeatDetails, context);

				lesionSeatID = searchIDLesionSeat("Ensemble du corps et endroits multiples, sans autre spécification", context);

				lesionSeatDetails = new LesionSeatDetail[]
				{
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 71,Label="Ensemble du corps (effets systémiques)"},
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 78,Label="Multiples endroits du corps affectés"},
				};

				saveLesionSeatDetails(lesionSeatDetails, context);

				lesionSeatID = searchIDLesionSeat("Autres parties du corps blessées", context);

				lesionSeatDetails = new LesionSeatDetail[]
				{
					new LesionSeatDetail{ LesionSeatID=lesionSeatID, Code= 99,Label="Autres parties du corps blessées"},
				};

				saveLesionSeatDetails(lesionSeatDetails, context);

				transaction.Commit();
			}
		}
	}
}
