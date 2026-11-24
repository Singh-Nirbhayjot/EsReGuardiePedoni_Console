using System;
using System.Collections.Generic;
using System.Text;

namespace EsReGuardiePedoni_Console
{
    public class CScrittore
    {
        public void Svuota()
        {
            File.WriteAllText("output.txt", "");
        }

        public void Scrivi(string frase)
        {
            File.AppendAllText("output.txt", frase + "\n");
        }
    }
}
