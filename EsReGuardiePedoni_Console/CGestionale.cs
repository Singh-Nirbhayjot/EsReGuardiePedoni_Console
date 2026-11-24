using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using EsReGuardiePedoni_Console;

namespace EsReGuardiePedoni
{
    public class CGestionale
    {
        public CRe Re;
        public ObservableCollection<CGuardia> Guardie;
        public ObservableCollection<CPedone> Pedoni;
        public List<string> Comandi;
        public CScrittore Scrittore;
        public int Indice;
        public bool Finito;

        public CGestionale()
        {
            this.Guardie = new ObservableCollection<CGuardia>();
            this.Pedoni = new ObservableCollection<CPedone>();
            this.Comandi = new List<string>();
            this.Scrittore = new CScrittore();
            this.Indice = 0;
            this.Finito = false;
        }

        public void Carica(string percorso)
        {
            string[] righe = File.ReadAllLines(percorso);

            this.Guardie.Clear();
            this.Pedoni.Clear();
            this.Comandi.Clear();
            this.Indice = 0;
            this.Finito = false;
            this.Scrittore.Svuota();

            this.Re = new CRe(righe[0]);

            foreach (string nome in righe[1].Split(' '))
                this.Guardie.Add(new CGuardia(nome));

            foreach (string nome in righe[2].Split(' '))
                this.Pedoni.Add(new CPedone(nome));

            for (int i = 3; i < righe.Length; i++)
            {
                this.Comandi.Add(righe[i]);
                if (righe[i] == "End")
                    break;
            }
        }
        public List<string> EseguiComando()
        {
            List<string> risposte = new List<string>();

            if (this.Finito)
                return risposte;

            string comando = this.Comandi[this.Indice];
            this.Indice++;
            risposte.Add("> " + comando);

            if (comando == "End")
            {
                risposte.Add("Simulazione terminata");
                this.Finito = true;
            }
            else if (comando == "Attacca Re")
            {
                string fraseRe = this.Re.SubisceAttacco();
                risposte.Add(fraseRe);
                this.Scrittore.Scrivi(fraseRe);

                foreach (CGuardia g in this.Guardie)
                    risposte.Add(g.SubisceAttacco());
                foreach (CPedone p in this.Pedoni)
                    risposte.Add(p.SubisceAttacco());
            }
            else if (comando.StartsWith("Cattura "))
            {
                this.Cattura(comando.Substring(8));
            }
            else
            {
                risposte.Add("Comando non valido");
            }

            return risposte;
        }
        private void Cattura(string nome)
        {
            for (int i = 0; i < this.Guardie.Count; i++)
            {
                if (this.Guardie[i].Nome == nome)
                {
                    this.Guardie.RemoveAt(i);
                    return;
                }
            }
            for (int i = 0; i < this.Pedoni.Count; i++)
            {
                if (this.Pedoni[i].Nome == nome)
                {
                    this.Pedoni.RemoveAt(i);
                    return;
                }
            }
        }
    }
}