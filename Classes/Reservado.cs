using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ExLemaf.Classes
{
    public class Reservado
    {
        public List<Reserva> reservas;

        public Reservado()
        {
            reservas = new List<Reserva>();
        }

        public List<Reserva> pegaReservas()
        {
            string caminho = AppDomain.CurrentDomain.BaseDirectory;
            string jsonString = File.ReadAllText(caminho + @"\Json\reservas.json");

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();

            return (List<Reserva>)javaScriptSerializer.Deserialize(jsonString, typeof(List<Reserva>));
        }
    }
}