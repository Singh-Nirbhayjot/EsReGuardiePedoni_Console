using System;
using System.Collections.Generic;
using System.Text;
using EsReGuardiePedoni;

namespace EsReGuardiePedoni_Console
{
    public class CPedone : CPersonaggio
    {
        public CPedone(string n) : base(n) { }

        public override string SubisceAttacco()
        {
            return "Il Pedone " + this.Nome + " si sta preparando";
        }
    }
}
