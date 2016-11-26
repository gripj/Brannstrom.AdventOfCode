using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day13
{
    public class SeatArranger
    {
        private List<Person> _people;
        private readonly Person _host = new Person("Host");
        private bool IncludeHost { get; set; }

        public void SeatHost() => IncludeHost = true;

        public int GetBestSeatPlacements()
        {
            AskForOpinions();

            var seatingArrangements = GetPossibleSeatingArrangements(_people);
            var happinessRatings = seatingArrangements.Select(GetTotalHappinessForSeatingArrangement).ToList();

            return happinessRatings.Max();
        }

        private void AskForOpinions()
        {
            foreach (var opinion in ReadOpinionsList())
                RememberOpinion(opinion);

            if (IncludeHost)
                AskForOpinionsInvolvingHost();           
        }

        private void RememberOpinion(string opinion)
        {
            var parts = opinion.Remove(opinion.Length - 1).Split(' ');

            var subject = CreatePersonIfNotExists(parts.First());
            var aboutPerson = CreatePersonIfNotExists(parts.Last());
            var happinessRating = GetHappinessRating(opinion);

            subject.Opinions.Add(aboutPerson, happinessRating);
        }

        private Person CreatePersonIfNotExists(string name)
        {
            if (_people == null)
                _people = new List<Person>();

            if (!PersonExists(name))
                _people.Add(new Person(name));

            return _people.First(x => x.Name.Equals(name));
        }

        private bool PersonExists(string name) => _people.Any(x => x.Name.Equals(name));

        private void AskForOpinionsInvolvingHost()
        {
            foreach (var person in _people)
            {
                person.Opinions.Add(_host, 0);
                _host.Opinions.Add(person, 0);
            }
            _people.Add(_host);
        }

        private static int GetHappinessRating(string opinion)
        {
            var happinessRating = Convert.ToInt32(Regex.Match(opinion, @"\d+").Value);
            if (opinion.Contains("lose"))
                happinessRating = -happinessRating;
            return happinessRating;
        }

        public List<List<T>> GetPossibleSeatingArrangements<T>(IReadOnlyList<T> people)
        {
            var currentArrangement = new T[people.Count];
            var @isInPermutation = new bool[people.Count];
            var possibleArrangements = new List<List<T>>();

            PermuteArrangements(people, @isInPermutation,
                currentArrangement, possibleArrangements, 0);

            return possibleArrangements;
        }

        private static void PermuteArrangements<T>(
            IReadOnlyList<T> people, 
            IList<bool> isInPermutation,
            IList<T> currentArrangement, 
            ICollection<List<T>> possibleArrangements,
            int position)
        {
            if (position == people.Count)
                possibleArrangements.Add(currentArrangement.ToList());

            else
                for (var i = 0; i < people.Count; i++)
                    if (!isInPermutation[i])
                    {
                        isInPermutation[i] = true;

                        currentArrangement[position] = people[i];

                        PermuteArrangements(people, isInPermutation,
                            currentArrangement, possibleArrangements,
                            position + 1);

                        isInPermutation[i] = false;
                    }
        }

        private static int GetTotalHappinessForSeatingArrangement(List<Person> people)
        {
            var totalHappiness = 0;
            var amountOfPeople = people.Count;
            for (var i = 0; i < amountOfPeople; i++)
            {
                var toTheLeft = i == 0 ? people.Last() : people[i - 1];
                var toTheRight = i == amountOfPeople - 1 ? people.First() : people[i + 1];
                totalHappiness += people[i].GetOpinionAboutPerson(toTheLeft);
                totalHappiness += people[i].GetOpinionAboutPerson(toTheRight);
            }
            return totalHappiness;
        }

        private static IEnumerable<string> ReadOpinionsList()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brannstrom.AdventOfCode.Day13.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }
    }
}
