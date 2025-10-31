using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Cursus {
        public string naam { get; set; }
        public string code { get; set; }
        public int punten { get; set; }
        public string categorie { get; set; }
        public char status { get; set; }


        public Cursus(string code, string naam, int punten, string categorie, char status = 'N') {
            this.code = code;
            this.naam = naam;
            this.punten = punten;
            this.categorie = categorie;
            this.status = status;
        }
    }
}
