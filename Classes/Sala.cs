using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExLemaf
{
    public class Sala
    {
        public string nome { get; set; }
        public int lugares { get; set; }
        public bool computador { get; set; }
        public bool wifi { get; set; }
        public bool tv { get; set; }
        public bool webcam { get; set; }

        public Sala(string nome, int lugares, bool computador, bool wifi, bool tv, bool webcam)
        {
            this.nome = nome;
            this.lugares = lugares;
            this.computador = computador;
            this.wifi = wifi;
            this.tv = tv;
            this.webcam = webcam;
        }
        
        public Sala(){}

    }
}