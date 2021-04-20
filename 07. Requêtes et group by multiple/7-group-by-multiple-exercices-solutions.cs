﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqMultipleKeys7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Chien> chiens = new List<Chien>()
            {
                new Chien("Gnocci", "Gnoc Gnoc", "Labrador", "Sable", "M", 1, 20),
                new Chien("Vagabond", "Gros Loup", "Labrador", "Noir", "M", 8, 25),
                new Chien("Milou", "Milos", "Labrador", "Sable", "M", 10, 24),
                new Chien("Sirène", "Sissy", "Labrador", "Sable","F", 4, 19),
                new Chien("Félicia", "Felicci", "Labrador", "Sable", "F", 6, 20),
                new Chien("Kratos", "Mon tueur", "Chihuahua", "Fauve", "M", 1, 2),
                new Chien("Jack", "Jaja", "Chihuahua", "Fauve", "M", 1, 2),
                new Chien("Mojave", "Mojojo", "Chihuahua", "Fauve", "M", 1, 2),
                new Chien("Hercule", "Herc", "Chihuahua", "Beige", "M", 35, 2),
                new Chien("Médusa", "Med", "Terre-Neuve", "Noire", "F", 6, 40),
                new Chien("Mélusine", "Mel", "Terre-Neuve", "Noire", "F", 7, 41),
                new Chien("Venus", "Violette", "Terre-Neuve", "Noire", "F", 8, 38),
                new Chien("Letto", "Lele", "Berger Australien", "Bleu Merle", "M", 3, 30),
                new Chien("Cabron", "Dum dum", "Berger Australien", "Bleu Merle", "M", 9, 31),
                new Chien("Banzaï", "Zaïzaï", "Berger Australien", "Noir et blanc", "M", 1, 28 ),
                new Chien("Haricot", "Harry", "Berger Australien", "Noir et blanc", "M", 2, 27),
                new Chien("Gédéon", "Gégé", "Berger Allemand", "Noir et feu", "M", 9, 31),
                new Chien("Bella", "Belbel", "Berger Allemand", "Noir et feu", "F", 5, 28),
                new Chien("Oui-oui", "oui", "Berger Allemand", "Sable", "M", 7, 35),
                new Chien("Pataud", "Patoche", "Carlin", "Sable", "M", 16, 8),
                new Chien("Killer", "Kiki", "Carlin", "Sable", "M", 10, 8),
                new Chien("Frank", "Colonel", "Carlin", "Noir", "M", 9, 9)
            };

            //1. Faire un group by multiple sur la race et la couleur
            //Trier par race, puis par couleur (ordre croissant)
            var queryRaceCouleur = from c in chiens
                                   orderby c.Race, c.Couleur
                                   group c by new { c.Race, c.Couleur };

            foreach(var key in queryRaceCouleur)
            {
                Console.WriteLine($" --- Key : {key.Key} --- ");
                foreach(var item in key)
                {
                    Console.WriteLine($"{item.Nom}");
                }
            }

            Console.WriteLine("--------------------------------------");
            //2. Faire un group by multiple sur la couleur et le sexe
            // Faire un tri croissant sur le sexe
            var queryCouleurSexe = from c in chiens
                                   orderby c.Sexe
                                   group c by new { c.Couleur, c.Sexe };

            foreach (var key in queryCouleurSexe)
            {
                Console.WriteLine($"Key : {key.Key}");
                foreach (var dog in key)
                {
                    Console.WriteLine($"{dog.Nom}");
                }
            }

            Console.WriteLine("--------------------------------------");
            //3. Faire un group by par sexe, age, couleur
            // Pour les chiens âgés entre 2 et 15 ans (inclus)
            // Sélectionner les chiens dont le surnom n'est pas un nom composé (on cherche les surnoms sans espace)
            //Trier par sexe (croissant), par âge (décroissant), par race (décroissant), par couleur (croissant)

            var queryFinal = from c in chiens
                             where c.Age >= 2 && c.Age <= 15
                             where !c.Surnom.Contains(" ")
                             orderby c.Sexe ascending, c.Age descending, c.Race descending, c.Couleur ascending
                             group c by new { c.Sexe, c.Age, c.Couleur };

            foreach (var key in queryFinal)
            {
                Console.WriteLine($"--- Key : {key.Key} ---");
                foreach (var item in key)
                {
                    Console.WriteLine($"{item.Nom}, {item.Surnom}, âge : {item.Age}, Race : {item.Race}");
                }
            }

        }
    }

    class Chien
    {
        string nom;
        string surnom;
        string race;
        string couleur;
        string sexe;
        int age;
        int poids;

        public Chien(string nom, string surnom, string race, string couleur, string sexe, int age, int poids)
        {
            this.nom = nom;
            this.surnom = surnom;
            this.race = race;
            this.couleur = couleur;
            this.sexe = sexe;
            this.age = age;
            this.poids = poids;
        }

        public string Nom
        {
            get{
                return this.nom;
            }
        }

        public string Surnom
        {
            get
            {
                return this.surnom;
            }
        }

        public string Race
        {
            get
            {
                return this.race;
            }
        }

        public string Couleur
        {
            get
            {
                return this.couleur;
            }
        }

        public string Sexe
        {
            get
            {
                return this.sexe;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
        }

        public int Poids
        {
            get
            {
                return this.poids;
            }
        }
    }
}
