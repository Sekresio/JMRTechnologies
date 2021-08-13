using System.Collections.Generic;
using System.Linq;
using Zadanie1.DemoSource;
using Zadanie1.DemoTarget;

namespace Zadanie1.DemoImplementation
{
    public class PeopleWithEmailsConverter
    {
        // Krótki opis takiego mapowania

        // *** WADY: ***
        // W tak spłaszczonych danych nie można wskazać pojedynczego unikalnego klucza.
        // W związku z tym nie można takich danych umieścić w prosty sposób w słowniku - wyszukiwanie po kluczu jest utrudnione.
        // Ponadto taka kolekcja zajmuje więcej miejsca w pamięci bo zawiera powielone dane.
        
        // *** ZALETY: ***
        // Nowa klasa jest płytka - tj. nie posiada zagnieżdzonych innych klas wewnątrz.
        // Sprawia to, że przeszukiwanie takiej kolekcji jest łatwiejsze - wystarczy jedna pętla.

        public static IEnumerable<PersonWithEmail> Flatten(IEnumerable<Person> people)
        {
            var peopleWithEmails = new List<PersonWithEmail>();

            if (people == null) return peopleWithEmails;

            foreach (var person in people)
            {
                if (person.Emails == null || !person.Emails.Any())
                {
                    continue;
                }

                var personSanitizedNameWithId = CreateSanitizedNameWithId(person);
                var personEmails = person.Emails;

                foreach (var personEmail in personEmails)
                {
                    var personFormattedEmail = CreateFormattedEmail(personEmail);
                     
                    var personWithEmail = new PersonWithEmail
                    {
                        SanitizedNameWithId = personSanitizedNameWithId,
                        FormattedEmail = personFormattedEmail
                    };

                    peopleWithEmails.Add(personWithEmail);
                }
            }

            return peopleWithEmails;
        }

        // todo: Get details about how name should be created
        private static string CreateSanitizedNameWithId(Person person)
        {
            var personNameWithId = $"{person.Id}{person.Name}";
            var personSanitizedNameWithId = StringSanitizer.SanitizeString(personNameWithId);
            return personSanitizedNameWithId;
        }

        // todo: Get details about how formatted email should be created
        private static string CreateFormattedEmail(EmailAddress email)
        {
            var formattedEmail = $"{email.EmailType}{email.Email}";
            return formattedEmail;
        }
    }
}