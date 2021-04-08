using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqFoxxpy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dog> dogs = new List<Dog>
            {
                new Dog("Berger Australien", "Banzaï", 1, 28),
                new Dog("Berger Australien", "Letto", 3, 30),
                new Dog("Berger Australien", "Princesse", 8, 32),
                new Dog("Berger Allemand", "Floyd", 10, 32),
                new Dog("Caniche", "Igor", 13, 9),
                new Dog("Labrador", "Swing", 15, 25),
                new Dog("Teckel", "Wonki", 2, 5),
                new Dog("Terre Neuve", "Albator", 1, 50),
                new Dog("Carlin", "Pataud", 13, 10),
                new Dog("Boxer", "Frank", 6, 25),
                new Dog("Lévrier Afghan", "Précieuse", 9, 26),
                new Dog("Yorkshire", "Kakou", 3, 6)
            };
            //1. Récupérer tous les chiens qui sont de la race "Berger Australien"
            var query = from d in dogs
                        where d.Race == "Berger Australien"
                        select d;

            //1.5. Récupérer tous les chiens qui sont de la race "Berger Australien" et les trier par leur nom
            var query2 = from d in dogs
                        where d.Race == "Berger Australien"
                        orderby d.Name
                        select d;

            //2. Récupérer tous les chiens âgés de 5 ans et plus, dont la longueur du nom est supérieure à 5 lettres
            var query3 = from d in dogs
                         where d.Age >= 5 && d.Name.Length > 5
                         select d;

            //2.5 Récupérer tous les chiens âgés de 5 ans et plus, dont la longueur du nom est supérieure à 5 lettres
            //Trier les chiens par leur poids
            var query4 = from d in dogs
                         where d.Age >= 5 && d.Name.Length > 5
                         orderby d.Weight ascending
                         select d;

            //3. Trier les chiens par leur âge (tri décroissant) puis leur poids (tri croissant)
            var query5 = from d in dogs
                         orderby d.Age descending, d.Weight ascending
                         select d;

            //4. Récupérer les noms de chien dont le nom de race tient en un seul mot
            //Leur poids doit être supérieur à 15 kilos
            //Leur nom doit contenir un "i"
            //Trier les chiens par la longueur de leur prénom
            var query6 = from d in dogs
                        where !d.Race.Contains(" ")
                        where d.Weight > 15
                        where d.Name.ToLower().Contains("i")
                        orderby d.Name.Length ascending
                        select d;

            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }

        }
    }

    internal class Dog
    {
        private string race;
        private string name;
        private int age;
        private int weight;
        
        public Dog(string race, string name, int age, int weight)
        {
            this.race = race;
            this.name = name;
            this.age = age;
            this.weight = weight;
        }

        public string Race
        {
            get
            {
                return this.race;
            }
            set
            {
                this.race = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }

    }
}
