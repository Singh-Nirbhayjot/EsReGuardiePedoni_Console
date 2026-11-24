using System;
using System.Collections.Generic;
using System.Text;
using EsReGuardiePedoni;

namespace EsReGuardiePedoni_Console
{
    public class CGuardia : CPersonaggio
    {
        public CGuardia(string n) : base(n) { }

        public override string SubisceAttacco()
        {
            return "La Guardia " + this.Nome + " sta difendendo";
        }
    }
}
