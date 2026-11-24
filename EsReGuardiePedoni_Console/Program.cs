using System;
using System.Collections.Generic;
using System.Threading;

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
            bool esci = false;

            while (!esci)
            {
                Console.WriteLine();
                Console.WriteLine("1) Apri file  2) Passo  3) Esegui tutto  0) Esci");
                string scelta = Console.ReadLine();

                if (scelta == "1")
                {
                    Console.Write("Percorso del file: ");
                    string percorso = Console.ReadLine();
                    try
                    {
                        gestionale.Carica(percorso);
                        caricato = true;
                        Console.WriteLine("Comandi letti:");
                        foreach (string c in gestionale.Comandi)
                            Console.WriteLine("  " + c);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Errore: " + ex.Message);
                    }
                }
                else if (scelta == "2")
                {
                    if (caricato)
                        Stampa(gestionale.EseguiComando());
                    else
                        Console.WriteLine("Apri prima un file");
                }
                else if (scelta == "3")
                {
                    if (!caricato)
                    {
                        Console.WriteLine("Apri prima un file");
                    }
                    else
                    {
                        while (!gestionale.Finito)
                        {
                            Stampa(gestionale.EseguiComando());
                            if (!gestionale.Finito)
                                Thread.Sleep(1000);
                        }
                    }
                }
                else if (scelta == "0")
                {
                    esci = true;
                }
            }
        }
    }
}