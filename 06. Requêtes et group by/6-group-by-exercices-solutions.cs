using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqFoxxpy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Personne> personnes = new List<Personne>()
            {
                new Personne("Garett", "Ramzy", 45, "M"),
                new Personne("Caire", "Joe", 35, "M"),
                new Personne("Clay", "Alicia", 18, "F"),
                new Personne("Bavette", "Simone", 68, "F"),
                new Personne("Henry", "Thierry", 44, "M"),
                new Personne("Jacquesonne", "Janett", 25, "F"),
                new Personne("Buveur", "Joe", 25, "M"),
                new Personne("Louet", "Karim", 31, "M"),
                new Personne("Louette", "Karima", 31, "F"),
                new Personne("Caire", "Paul", 19, "M"),
                new Personne("Mille", "Camille", 20, "F"),
                new Personne("Cent", "Camille", 40, "F"),
                new Personne("Million", "Camille", 60, "M"),
                new Personne("Gold", "Roger", 17, "M"),
                new Personne("Lion", "Sandra", 8, "F"),
                new Personne("René", "Jean", 6, "M")
            };

            //1. Faire un group by sur le genre (sexe) des personnes présentes dans la liste d'objets Personne()
            var querySexe = from p in personnes
                            group p by p.Sexe;

            foreach(var item in querySexe) //Affiche les valeurs possibles pour Sexe
            {
                Console.WriteLine(item.Key);
                foreach(var personne in item)
                {
                    Console.WriteLine($"=> {personne.Nom} {personne.Prenom}"); //Affiche les personnes pour chaque sexe
                }
            }

            Console.WriteLine("----------------------------------");
            //2. Faire un group by sur l'âge des personnes. Faire un tri croissant par âge.
            var queryAge = from p in personnes
                           orderby p.Age
                           group p by p.Age;

            foreach (var item in queryAge) //Affiche les valeurs possibles pour Sexe
            {
                Console.WriteLine($"Age : {item.Key}");
                foreach (var personne in item)
                {
                    Console.WriteLine($"=> {personne.Nom} {personne.Prenom}"); //Affiche les personnes pour chaque sexe
                }
            }

            Console.WriteLine("----------------------------------");
            //3. Faire un group by sur le prénom des personnes, et afficher les noms de famille par prénom.
            //Trier les prénoms par ordre décroissant.
            //Récupérer les personnes majeures (18 ans et plus)
            var queryPrenom = from p in personnes
                              where p.Age >= 18
                              orderby p.Prenom descending
                              group p by p.Prenom;

            foreach(var item in queryPrenom)
            {
                Console.WriteLine($"Prenom : {item.Key}");
                foreach(var personne in item)
                {
                    Console.WriteLine($"=> {personne.Nom}");
                }
            }

            Console.WriteLine("----------------------------------");
            //4. Grouper les éléments d'une liste de nombres. D'un côté les chiffres/nombres pairs, de l'autre ceux impairs.
            List<int> nombres = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 20, 11, 13, 12, 14, 18, 17, 16, 14, 14 };
            var queryPair = from n in nombres
                            group n by n % 2 == 0;

            foreach (var item in queryPair)
            {
                string estPair = "";
                if (item.Key) { estPair = "Pair"; }
                else { estPair = "Impair"; }

                Console.WriteLine($"Clé : {estPair}");
                foreach (var nombre in item)
                {
                    Console.WriteLine($"=> {nombre}");
                }
            }


            Console.WriteLine("----------------------------------");
            //5 Grouper les individus par la première lettre de leur nom et faire un tri croissant sur l'attribut Nom de la classe Personne
            var queryInitiale = from p in personnes
                                orderby p.Nom
                                group p by p.Nom[0];

            foreach (var item in queryInitiale)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var personne in item)
                {
                    Console.WriteLine($"=> {personne.Nom}");
                }
            }


        }

    }

    class Personne
    {
        private string nom;
        private string prenom;
        private int age;
        private string sexe;
        private bool est_ingenieur;

        public Personne(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        public Personne(string nom, string prenom, bool ingenieur)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.est_ingenieur = ingenieur;
        }

        public Personne(string nom, string prenom, int age, string sexe)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.age = age;
            this.sexe = sexe;
        }

        public Personne(string nom, string prenom, int age, string sexe, bool ingenieur)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.age = age;
            this.sexe = sexe;
            this.est_ingenieur = ingenieur;
        }

        public string Nom
        {
            get
            {
                return this.nom;
            }
            set
            {
                this.nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return this.prenom;
            }

            set
            {
                this.prenom = value;
            }
        }

        public bool Est_ingenieur
        {
            get
            {
                return this.est_ingenieur;
            }
            set
            {
                this.est_ingenieur = value;
            }
        }

        public string Sexe
        {
            get
            {
                return this.sexe;
            }
            set
            {
                this.sexe = value;
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

    }

}
