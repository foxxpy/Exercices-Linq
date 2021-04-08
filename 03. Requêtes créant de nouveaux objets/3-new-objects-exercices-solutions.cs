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
                new Personne("Hallyday", "Johnny", false),
                new Personne("Vartan", "Sylvie", false),
                new Personne("Drucker", "Michel", false),
                new Personne("Antoine", "Antoine", true),
                new Personne("Philippe", "Edouard", false),
                new Personne("Demorand", "Patricia", true),
                new Personne("Ulysse", "Margareth", true),
                new Personne("Zenith", "Méryl", true),
                new Personne("Bobo", "Jojo", false)
            };

            //1. Créer un itérable d'ingénieurs, trier par nom, et ensuite par prénom
            var queryIngenieurs = from p in personnes
                        where p.Est_ingenieur
                        orderby p.Nom, p.Prenom
                        select new Ingenieur(p.Nom, p.Prenom);


            //2. Récupérer la liste des personnes qui ne sont pas ingénieures.
            var queryTechniciens = from p in personnes
                                   where !p.Est_ingenieur
                                   select new Technicien(p.Nom, p.Prenom);


            //3. Créer une liste d'objets anonymes (Ingénieurs + techniciens)
            var queryAnonymous = from p in personnes
                                 select new {nom_complet = p.Nom+" "+p.Prenom};

            
            foreach (var item in queryAnonymous)
            {
                Console.WriteLine(item.nom_complet);
            }

        }

    }

    class Personne
    {
        private string nom;
        private string prenom;
        private bool est_ingenieur;

        public Personne(string nom, string prenom, bool ingenieur)
        {
            this.nom = nom;
            this.prenom = prenom;
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

    }

    class Ingenieur
    {
        private string nom;
        private string prenom;
        private string specialite;

        public Ingenieur(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        public Ingenieur(string nom, string prenom, string specialite)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.specialite = specialite;
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

        public string Specialite
        {
            get
            {
                return this.specialite;
            }
            set
            {
                this.specialite = value;
            }
        }

    }

    class Technicien
    {
        private string nom;
        private string prenom;

        public Technicien(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
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
    }
}
