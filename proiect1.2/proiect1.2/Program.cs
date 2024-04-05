using ClassClient;
using Nivel_StocareDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassClient;
using ClassMeniu;
using Nivel_StocareDate;


namespace proiect1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StocareDate adminClienti = new StocareDate();
            int nrClienti = 0;
            Client clientNou = new Client();

            string optiune;
            do
            {
                Console.WriteLine("C. Citire informatii student de la tastatura");
                Console.WriteLine("I. Afisarea informatiilor despre ultimului student introdus");
                Console.WriteLine("A. Afisare studenti din fisier");
                Console.WriteLine("S. Salvare client in fisier");
                Console.WriteLine("Z. Cautare dupa nume");
                Console.WriteLine("X. Inchidere program");

                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "C":
                        clientNou = CitireClientTastatura();

                        break;
                    case "I":
                        AfisareClient(clientNou);

                        break;
                    case "A":
                        Client[] clienti = adminClienti.GetClienti(out nrClienti);
                        AfisareClienti(clienti, nrClienti);

                        break;
                    case "S":
                        int idStudent = ++nrClienti;
                        clientNou.Idclient = idStudent;
                        //adaugare student in fisier
                        adminClienti.AddClient(clientNou);

                        break;
                    case "Z":
                        Client[] cauta = adminClienti.GetClienti(out nrClienti);
                        StocareDate.CautareDupaNume(cauta, nrClienti);
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");


            Console.ReadKey();
        }
        public static Client CitireClientTastatura()
        {
            Console.WriteLine("Introduceti numele");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele");
            string prenume = Console.ReadLine();

            Client client = new Client(0, nume, prenume);

            return client;
        }
        public static void AfisareClient(Client client)
        {
            string infoClient = string.Format("Clientul cu id-ul #{0} are numele: {1} {2}",
                    client.Idclient,
                    client.Nume ?? " NECUNOSCUT ",
                    client.Prenume ?? " NECUNOSCUT ");

            Console.WriteLine(infoClient);
        }

        public static void AfisareClienti(Client[] clienti, int nrClienti)
        {
            Console.WriteLine("Clientii sunt:");
            for (int i = 0; i < nrClienti; i++)
            {
                string infoClient = clienti[i].Info();
                Console.WriteLine(infoClient);
            }
        }

    
}
    }
