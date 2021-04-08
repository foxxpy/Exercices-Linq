using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqFoxxpy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Personne> personnes = new List<Personne>
            {
                new Personne("Beauvoir", "Simon", 16, "M"),
                new Personne("Beauvoir", "Simone", 25, "F"),
                new Personne("De Caunes", "Richard", 41, "M"),
                new Personne("Sullivan", "Sullivan", 31, "M"),
                new Personne("Rémy", "Camille", 22, "F"),
                new Personne("Manchon", "Camille", 19, "M"),
                new Personne("Thiebaud", "Marie", 61, "F"),
                new Personne("Crouchon", "Mélanie", 55, "F"),
                new Personne("Baline", "Mélodie", 74, "F"),
                new Personne("Karine", "Pascal", 31, "M"),
                new Personne("Katherine", "Pascale", 36, "F"),
                new Personne("Zoula", "Charles", 20, "M"),
                new Personne("Romain", "Collin", 34, "M"),
                new Personne("Fouchard", "Aïcha", 48, "F"),
                new Personne("Blandine", "Maëva", 18, "F")
            };

            //Créer une variable majeur qui est égale à True si l'âge de la personne est supérieure ou égale à 18
            //sinon False
            var query = from p in personnes
                        let nom_complet = p.Nom + " " + p.Prenom
                        select new {nom_complet = nom_complet, Age = p.Age };


            //Créer une variable "initiale" qui contient seulement les initiales du nom et du prénom : p.Nom[0]+"."+p.Prenom[0]
            //Sélectionner seulement les personnes majeures (18 ans et plus)
            //Sélectionner également les personnes âgées de moins de 50 ans
            //Créer une variable taille_nom_complet = longueur du prénom + longueur du nom
            //Créer un objet anonyme avec les attributs : Nom, prénom, initiale, taille_nom_complet, age

            var bigQuery = from p in personnes
                           let initiale = p.Nom[0] + "." + p.Prenom[0]
                           let taille_nom_complet = p.Nom.Length + p.Prenom.Length
                           where p.Age >= 18 && p.Age < 50
                           select new {Nom = p.Nom, Prenom = p.Prenom, Initiale = initiale, Taille_nom_complet = taille_nom_complet, Age = p.Age  };

            //Affichage du résultat de la requête
            foreach (var item in bigQuery)
            {
                Console.WriteLine(item.Nom+" "+item.Prenom+" "+item.Initiale+" "+item.Taille_nom_complet+" "+item.Age);
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
