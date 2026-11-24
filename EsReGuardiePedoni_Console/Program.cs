using System;
using System.Collections.Generic;

namespace EsReGuardiePedoni
{
    class Program
    {
        static void Stampa(List<string> righe)
        {
            foreach (string riga in righe)
                Console.WriteLine(riga);
        }

        static void Main(string[] args)
        {
            CGestionale gestionale = new CGestionale();
            bool caricato = false;
            string scelta = "";

            while (scelta != "0")
            {
                Console.WriteLine();
                Console.WriteLine("1) Apri file  2) Passo  3) Esegui tutto  0) Esci");
                scelta = Console.ReadLine();

                if (scelta == "1")
                {
                    Console.Write("Percorso del file: ");
                    gestionale.Carica(Console.ReadLine());
                    caricato = true;

                    Console.WriteLine("Comandi letti:");
                    foreach (string c in gestionale.Comandi)
                        Console.WriteLine("  " + c);
                }
                else if (scelta == "2" && caricato)
                {
                    Stampa(gestionale.EseguiComando());
                }
                else if (scelta == "3" && caricato)
                {
                    while (!gestionale.Finito)
                        Stampa(gestionale.EseguiComando());
                }
            }
        }
    }
}