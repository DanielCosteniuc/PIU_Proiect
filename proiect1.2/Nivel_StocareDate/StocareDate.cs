using ClassClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nivel_StocareDate
{
    public class StocareDate
    {
        private const int NR_MAX_CLIENTI = 50;

        private Client[] clienti;
        private int nrClienti;
        public static void CautareDupaNume(Client[] clienti, int nrClienti)
        {
            Console.WriteLine("Introdu numele clientului: ");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele: ");
            string prenume = Console.ReadLine();
            for (int i = 0; i < nrClienti; i++)
            {
                if (nume == clienti[i].Nume && prenume == clienti[i].Prenume)
                {
                    Console.WriteLine("Am gasit clientl");
                    string infoClient = clienti[i].Info();
                    Console.WriteLine(infoClient);
                }
                else
                    Console.WriteLine("clientul nu exista");

            }
        }
        public StocareDate()
        {
            clienti = new Client[NR_MAX_CLIENTI];
            nrClienti = 0;
        }

        public void AddClient(Client client)
        {
            clienti[nrClienti] = client;
            nrClienti++;
        }

        public Client[] GetClienti(out int nrClienti)
        {
            nrClienti = this.nrClienti;
            return clienti;
        }
    }
}
