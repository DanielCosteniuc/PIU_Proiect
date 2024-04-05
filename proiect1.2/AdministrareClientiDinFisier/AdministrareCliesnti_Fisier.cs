using ClassClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrareClientiDinFisier
{
    public class AdministrareCliesnti_Fisier
    {
        private const int NR_MAX_STUDENTI = 50;
        private string numeFisier;

        public AdministrareCliesnti_Fisier(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddClient(Client client)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(client.ConversieLaSir_PentruFisier());
            }
        }

        public Client[] GetStudenti(out int nrStudenti)
        {
            Client[] clienti = new Client[NR_MAX_STUDENTI];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrStudenti = 0;

                // citeste cate o linie si creaza un obiect de tip Student
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    clienti[nrStudenti++] = new Client(linieFisier);
                }
            }

            return clienti;
        }
    }
}
