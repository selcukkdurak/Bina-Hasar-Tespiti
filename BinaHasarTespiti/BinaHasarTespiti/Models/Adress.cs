using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BinaHasarTespiti.Models
{
    public class Adress
    {
        public int id { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public string mahalle { get; set; }
        public string sokak { get; set; }
        public string binaNo { get; set; }
        public string durum { get; set; }
    }
}