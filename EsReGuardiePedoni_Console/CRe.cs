using System;
using System.Collections.Generic;
using System.Text;
using EsReGuardiePedoni;

namespace EsReGuardiePedoni_Console
{
    public class CRe : CPersonaggio
    {
        public CRe(string n) : base(n) { }

        public override string SubisceAttacco()
        {
            return "Il Re " + this.Nome + " è sotto attacco";
        }
    }
}
