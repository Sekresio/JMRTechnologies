using System;
using System.Collections.Generic;
using Zadanie2.DemoSource;

namespace Zadanie2.Tests.Benchmark
{
    public class BenchmarkTestData
    {
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<string> Emails { get; set; }

        public static BenchmarkTestData GenerateBenchmarkTestData(int numberOfGroups, int numberOfPeoplePerGroup, int numberOfEmailsPerPerson)
        {
            var finalGroups = new List<Group>();
            var finalEmails = new List<string>();
            var finalAccounts = new List<Account>();

            for (var i = 0; i < numberOfGroups; i++)
            {
                var people = new List<Person>();

                for (var j = 0; j < numberOfPeoplePerGroup; j++)
                {
                    var emails = new List<EmailAddress>();

                    for (var k = 0; k < numberOfEmailsPerPerson; k++)
                    {
                        var email = GetRandomEmail();
                        emails.Add(email);
                        finalEmails.Add(email.Email);

                        var account = new Account
                        {
                            Id = Guid.NewGuid().ToString(),
                            EmailAddress = email
                        };
                        finalAccounts.Add(account);
                    }

                    var personGuid = Guid.NewGuid().ToString();
                    var person = new Person
                    {
                        Id = personGuid,
                        Name = personGuid,
                        Emails = emails
                    };

                    people.Add(person);
                }

                var groupGuid = Guid.NewGuid().ToString();
                var group = new Group
                {
                    Id = groupGuid,
                    Label = groupGuid,
                    People = people
                };

                finalGroups.Add(group);
            }

            var arguments = new BenchmarkTestData
            {
                Groups = finalGroups,
                Accounts = finalAccounts,
                Emails = finalEmails
            };

            return arguments;
        }

        private static EmailAddress GetRandomEmail()
        {
            return new($"{Guid.NewGuid()}@gmail.com", "type");
        }
    }
}