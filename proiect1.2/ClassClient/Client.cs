using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassClient
{
    public class Client
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int ID = 0;
        private const int NUME = 1;
        private const int PRENUME = 2;

        public int Idclient { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public double Nrtel { get; set; }
        public string Adresa { get; set; }
        public Client()
        {
            Nume = string.Empty;
            Prenume = string.Empty;
            Adresa = string.Empty;
            Nrtel = 0;
        }
        public Client(int Idclient, string nume, string prenume)
        {
            this.Idclient = Idclient;
            this.Nume = nume;
            this.Prenume = prenume;
        }
        public Client(int Idclient, string nume, string prenume, string adresa, double nrTel)
        {
            this.Idclient = Idclient;
            this.Nume = nume;
            this.Prenume = prenume;
            this.Adresa = adresa;
            this.Nrtel = nrTel;
        }
        public string Info()
        {
            string info = $"Id:{Idclient} Nume:{Nume ?? " NECUNOSCUT "} Prenume: {Prenume ?? " NECUNOSCUT "}";

            return info;
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectStudentPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                Idclient.ToString(),
                (Nume ?? " NECUNOSCUT "),
                (Prenume ?? " NECUNOSCUT "));

            return obiectStudentPentruFisier;
        }
        public Client(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            this.Idclient = Convert.ToInt32(dateFisier[ID]);
            this.Nume = dateFisier[NUME];
            this.Prenume = dateFisier[PRENUME];
        }
    }
}
