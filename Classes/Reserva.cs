using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ExLemaf.Classes
{
    public class Reserva
    {
        public int id { get; set; }
        public Sala sala { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }

        public Reserva(){}
        
        public Reserva(Sala sala, DateTime dataInicio, DateTime dataFim, string horaInicio, string horaFim, string minInicio, string minFim)
        {
            criaId();
            this.sala = sala;
            this.dataInicio = dataInicio;
            this.dataInicio = this.dataInicio.AddHours(Convert.ToDouble(horaInicio));
            this.dataInicio = this.dataInicio.AddMinutes(Convert.ToDouble(minInicio));

            this.dataFim = dataFim;
            this.dataFim = this.dataFim.AddHours(Convert.ToDouble(horaFim));
            this.dataFim = this.dataFim.AddMinutes(Convert.ToDouble(minFim));
        }

        public Reserva(DateTime dataInicio, DateTime dataFim, string horaInicio, string horaFim, string minInicio, string minFim)
        {
            criaId();
            this.dataInicio = dataInicio;
            this.dataInicio = this.dataInicio.AddHours(Convert.ToDouble(horaInicio));
            this.dataInicio = this.dataInicio.AddMinutes(Convert.ToDouble(minInicio));

            this.dataFim = dataFim;
            this.dataFim = this.dataFim.AddHours(Convert.ToDouble(horaFim));
            this.dataFim = this.dataFim.AddMinutes(Convert.ToDouble(minFim));
        }

        private void criaId()
        {
            string caminho = AppDomain.CurrentDomain.BaseDirectory;
            Reservado reservado = new Reservado();

            if(reservado.pegaReservas() == null)
            {
                this.id = 1;
            }
            else
            {
                string jsonString = File.ReadAllText(caminho + @"\Json\reservas.json");

                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();

                List<Reserva> reserva = (List<Reserva>)javaScriptSerializer.Deserialize(jsonString, typeof(List<Reserva>));

                this.id = reserva[reserva.Count - 1].id + 1;
            }
        }

    }
}