using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Person
    {
        public int personId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string favoriteColour { get; set; }
        public int age { get; set; }
        public bool isWorking { get; set; }

        public Person(int personId, string firstName, string lastName, string favoriteColour, int age, bool IsWorking)
        {
            this.personId = personId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.favoriteColour = favoriteColour;
            this.age = age;
            this.isWorking = IsWorking;
        }

        public void ChangeFavoriteColour()
        {
            favoriteColour = "White";
        }

        public int ChangeAgeInTenYears()
        {
            return age = this.age + 10;
        }

        public override string ToString()
        {
            return $"personId: {personId}, firstName: {firstName}, lastName: {lastName}, favoriteColour: {favoriteColour}, Age: {age}, IsWorking: {isWorking}";
        }
        public class Relation
    { 

            public enum RelationshipType
        {
            Sister,
            Brother
        }

        public RelationshipType Relationship { get; set; }

        public void ShowRelationship(Person Gina, Person Mary)
        {
            Console.WriteLine($"{Gina.firstName} {Gina.lastName} is the {Relationship.ToString()} of {Mary.firstName} {Mary.lastName}");
        }

        public void ShowRelationship2(Person Ian, Person Mike)
        {
            Console.WriteLine($"{Ian.firstName} {Ian.lastName} is the {Relationship.ToString()} of {Mike.firstName} {Mike.lastName}");
        }

    }

    class Program
    {
        static void Main()
        {
            Person Ian = new Person(1, "Ian", "Brooks", "red", 30, true);


            Person Gina = new Person(2, "Gina", "James", "Green", 18, false);


            Person Mike = new Person(3, "Mike", "Briscoe", "Blue", 45, true);


            Person Mary = new Person(4, "Mary", "Beals", "Yellow", 28, true);


            Console.WriteLine($"{Gina.firstName} {Gina.lastName}'s favorite colour is {Gina.favoriteColour}.");

            Console.WriteLine("Mike's Information: ");

            var properties = typeof(Person).GetProperties();

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(Mike)}");
            }

            Ian.ChangeFavoriteColour();
            Console.WriteLine($"Ian Brooks's favorite colour is: {Ian.favoriteColour}");

            Mary.ChangeAgeInTenYears();
            Console.WriteLine($"Mary Beals's age in 10 years is: {Mary.age}");

            Relation relation = new Relation();

            relation.Relationship = Relation.RelationshipType.Sister;
            relation.ShowRelationship(Gina, Mary);
            relation.Relationship = Relation.RelationshipType.Brother;
            relation.ShowRelationship(Ian, Mike);

            List<Person> people = new List<Person>
            {
                new Person(1, "ian", "Brooks", "Red", 30, true),
                new Person(2, "Gina", "James", "Green", 18, false),
                new Person(3, "Mike", "Briscoe", "Blue", 45, true),
                new Person(4, "Mary", "Beals", "Yellow", 28, true)
            };

            double averageAge = people.Average(person => person.age);

            var youngestPerson = people.OrderBy(person => person.age).First();
            var oldestPerson = people.OrderByDescending(person => person.age).First();

            var peopleWithMFirstName = people.Where(person => person.firstName.StartsWith("M")).ToList();

            var peopleWithBlueFavoriteColour = people.FirstOrDefault(person => person.favoriteColour.Equals("Blue", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"Average Age: {averageAge}");
            Console.WriteLine($"Youngest Person: {youngestPerson}");
            Console.WriteLine($"Oldest Person: {oldestPerson}");

            Console.WriteLine($"People with an M in their first name:");
            foreach (var person in peopleWithMFirstName)
            {
                Console.WriteLine($"{person.firstName} {person.lastName}");
            }

            if (peopleWithBlueFavoriteColour != null )
            {
                Console.WriteLine("Person Who likes the colour Blue is:");
                Console.WriteLine(peopleWithBlueFavoriteColour.ToString());
            }
            else
            {
                Console.WriteLine("No one has their favorite colour as Blue");
            }
            
        }
    }
}
