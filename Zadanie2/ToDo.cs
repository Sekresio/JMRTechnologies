using System.Collections.Generic;
using System.Linq;
using Zadanie2.DemoSource;

namespace Zadanie2
{
    public class ToDo
    {
        public static IEnumerable<(Account, Person)> MatchPersonToAccount(
            IEnumerable<Group> groups,
            IEnumerable<Account> accounts,
            IEnumerable<string> emails)
        {
            var accountPerson = new List<(Account, Person)>();
            var accountsDictionary = accounts.ToDictionary(a => a.EmailAddress);

            foreach (var group in groups)
            {
                var people = group.People;

                foreach (var person in people)
                {
                    var emailAddresses = person.Emails;

                    foreach (var emailAddress in emailAddresses)
                    {
                        var account = accountsDictionary[emailAddress];
                        accountPerson.Add((account, person));
                    }
                }
            }

            return accountPerson;
        }
    }
}