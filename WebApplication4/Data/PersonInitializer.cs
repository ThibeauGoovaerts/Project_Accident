using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class PersonInitializer
    {
        public static void Initialize(AccidentContext context)
        {
            context.Database.EnsureCreated();

            if (context.Persons.Any())
            {
                return;
            }

            using(var transaction = context.Database.BeginTransaction())
            {

                var employees = new Person[]
                {
                    new Person { FirstName="Roger", LastName = "Ô", employementType = "Interne", Role = 2 },
                    new Person { FirstName="Patricia", LastName = "ALBERT-ROGUE", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Pierre-Lucas", LastName = "DA-COSTA", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Alfred-Emmanuel", LastName = "SEGUIN", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Bernadette", LastName = "HARDY", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Isaac", LastName = "DEVAUX", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Aimé", LastName = "BOULAY", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Paul", LastName = "DE-BERGERAC", employementType = "Interne", Role = 1 },
                    new Person { FirstName="René", LastName = "SANCHEZ", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Martin-Étienne", LastName = "LEFORT", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Paul", LastName = "GUILBERT", employementType = "Interne", Role = 2 },
                    new Person { FirstName="Céline", LastName = "VOISIN", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Philippine-Laetitia", LastName = "DIAZ", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Frédéric", LastName = "BIGOT-SANCHEZ", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Lorraine", LastName = "GALLET-DE-LEMONNIER", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Pierre", LastName = "BARBE", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Christophe", LastName = "BOUVET", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Claude", LastName = "LEVY", employementType = "Interne", Role = 1 },
                    new Person { FirstName="David-Pierre", LastName = "NICOLAS", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Tristan", LastName = "LEROUX", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Sylvie", LastName = "DEVAUX", employementType = "Interne", Role = 2 },
                    new Person { FirstName="Emmanuel-Grégoire", LastName = "DA-SILVA", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Camille", LastName = "MILLET", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Stéphane", LastName = "DE-GREGOIRE", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Bernadette", LastName = "RIOU", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Benjamin", LastName = "LE-BRUNET", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Laurent", LastName = "COLAS", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Patrick", LastName = "LEMOINE", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Honoré", LastName = "DUPUIS-DELAUNAY", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Yves", LastName = "LE-JACQUOT", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Sophie", LastName = "PASCAL", employementType = "Interne", Role = 2 },
                    new Person { FirstName="Anastasie", LastName = "JOUBERT", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Tristan", LastName = "DE-TOUSSAINT", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Hugues", LastName = "BOULAY-VIDAL", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Roger", LastName = "PIRES", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Guillaume", LastName = "MARECHAL", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Édith", LastName = "LEMONNIER", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Noël", LastName = "MOREAU", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Françoise", LastName = "PELTIER", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Sabine", LastName = "ROUSSEAU", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Raymond", LastName = "PRUVOST", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Charles", LastName = "DELAUNAY-ROBIN", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Auguste", LastName = "TEIXEIRA", employementType = "Interne", Role = 4 },
                    new Person { FirstName="Juliette", LastName = "ROGER", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Claire", LastName = "MARCHAL", employementType = "Interne", Role = 3 },
                    new Person { FirstName="Thérèse", LastName = "LE-ROUX", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Adélaïde", LastName = "RENARD", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Marthe-Marthe", LastName = "NEVEU", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Henri", LastName = "MAILLARD", employementType = "Interne", Role = 1 },
                    new Person { FirstName="Céline", LastName = "LE-TEXIER", employementType = "Interne", Role = 3 },
                };

                foreach (Person employee in employees)
                {
                    context.Persons.Add(employee);
                }

                context.SaveChanges();

                transaction.Commit();
            }
        }
    }
}
