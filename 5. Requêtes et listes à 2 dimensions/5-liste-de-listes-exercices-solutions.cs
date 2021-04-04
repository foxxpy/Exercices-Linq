using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqFoxxpy
{
    class Program
    {
        static void Main(string[] args)
        {

            List<List<Personne>> personnes = new List<List<Personne>>
            {
                new List<Personne>() {new Personne("Drucker", "Michel"),
                                      new Personne("Bedia", "Ramzy"),
                                      new Personne("Judor", "Eric")},

                new List<Personne>() {new Personne("Diaz", "Cameron"),
                                      new Personne("Depardieu", "Gerard"),
                                      new Personne("Stallone", "Sylvester"),
                                      new Personne("Macron", "Emmanuel")},

                new List<Personne>() {new Personne("Benzema", "Karim"),
                                      new Personne("Antoine", "Eric"),
                                      new Personne("Ruiz", "Olivia"),
                                      new Personne("Clavier", "Christian"),
                                      new Personne("Einstein", "Albert")}
            };


            //1. Récupérer tous les noms dont la longueur est supérieure à 5
            var query = from p in personnes
                        from person in p
                        where person.Nom.Length > 5
                        select person;

            //2. Récupérer tous les noms contenant un "e"
            //Récupérer tous les prénoms contenant un "a"
            //Trier par nom (tri décroissant)
            //Créer un objet anonyme avec un attribut identite = prénom+" "+nom
            var query2 = from lp in personnes
                         from p in lp
                         where p.Nom.ToLower().Contains("e")
                         where p.Prenom.ToLower().Contains("a")
                         orderby p.Nom descending
                         select new {identite = p.Prenom+" "+p.Nom };


            //3. Récupérer toutes les listes qui contiennent plus de 4 personnes
            //Récupérer les personnes dont le nom commence par "A" ou "B" ou "C"
            //Trier les personnes par prénom (tri croissant)
            //Créer un objet anonyme avec l'attribut "initiale" = 1ère lettre du prénom+"."+1ère lettre du nom
            var query3 = from lp in personnes
                         where lp.Count > 4
                         from p in lp
                         where p.Nom.ToUpper().Contains("A") || p.Nom.ToUpper().Contains("B") || p.Nom.ToUpper().Contains("C")
                         orderby p.Prenom ascending
                         select new {initiale = p.Prenom[0]+"."+p.Nom[0] };


            //4. Récupérer toutes les listes qui contiennent moins de 5 personnes
            //Afficher toutes les personnes comme ceci : Nom+" "+Prenom
            var query4 = from lp in personnes
                         from p in lp
                         where lp.Count < 5
                         select p;

            //Affichage du résultat de la requête
            foreach (var item in query4)
            {
                Console.WriteLine(item.Nom+" "+item.Prenom);
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
