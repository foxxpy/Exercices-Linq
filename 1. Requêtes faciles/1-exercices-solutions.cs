using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqFoxxpy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> entiers = new List<int> {4,5,2,3,1,1,0,5,8,9,10,15,16,20,21,4,5 };

            //1. Récupérer tous les nombres supérieurs à 5
            var query = from n in entiers
                        where n > 5
                        select n;

            //2. Récupérer les nombres supérieurs ou égaux à 15 et inférieurs à 20
            var query2 = from n in entiers
                         where n >= 15 && n < 20
                         select n;

            var query2_2 = from n in entiers
                           where n >= 15
                           where n < 20
                           select n;

            //3. Nombres supérieurs à 2, qui sont des multiples de 2, inférieurs à 20, différents de 8
            var query3 = from n in entiers
                        where n > 2
                        where n % 2 == 0
                        where n < 20
                        where n != 8
                        select n;

            var query3_2 = from n in entiers
                           where n > 2 && n % 2 == 0 && n < 20 && n != 8
                           select n;

            List<string> fruits = new List<string> { "Banane", "Ananas", "Cerise", "Framboise", "Groseilles", "Pomme",
            "Poire", "Tomate", "Kiwi", "Raisin", "Mangue", "Datte"};

            //4. Récupérer tous les fruits dont le nom contient plus de 5 lettres
            var query4 = from f in fruits
                         where f.Length > 5
                         select f;

            //5. Récupérer tous les fruits dont le nom commence par "P", dont la longueur du nom est supérieure à 4, 
            //qui contiennent un "o" mais pas de "m"
            var query5 = from f in fruits
                         where f.ToUpper()[0] == 'P'
                         where f.Length > 4
                         where f.Contains('o')
                         where !f.Contains('m')
                         select f;


            //6. Trier les fruits selon leur longueur
            var query6 = from f in fruits
                         orderby f.Length
                         select f;


            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

        }
    }

}
