using System;

namespace EsReGuardiePedoni
{
    public abstract class CPersonaggio
    {
        private string nome;
        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Il nome non può essere vuoto");
                nome = value;
            }
        }

        public CPersonaggio(string n)
        {
            this.Nome = n;
        }

        public abstract string SubisceAttacco();
    }
}