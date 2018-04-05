using ExLemaf.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace ExLemaf
{
    public partial class entrada : System.Web.UI.Page
    {
        Reservado reservados = new Reservado();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCriaSala_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paginas/criaSala.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Sala sala = new Sala();

            if (fuEntrada.FileName == "")
            {

                sala = buscaSala(calDataInicio.SelectedDate.Date, txtHoraInicio.Text, calDataFim.SelectedDate.Date, txtHoraFim.Text,
                        Convert.ToInt32(txtNumPessoas.Text), cbComputador.Checked, cbTV.Checked, cbWebcam.Checked, cbWifi.Checked);

                if (sala != null)
                {
                    adicionaReserva(sala);
                }
                else
                {
                    sugestaoData();
                }
            }
            else
            {

                string caminho = fuEntrada.PostedFile.FileName;
                string textoEntrada = File.ReadAllText(caminho);                

                String[] texto = textoEntrada.Split(';');

                DateTime inicio = DateTime.Parse(texto[0]);
                string horaInicio = texto[1];
                DateTime fim = DateTime.Parse(texto[2]);
                string horaFim = texto[3];
                int pessoas = Convert.ToInt32(texto[4]);
                bool internet = false;
                bool webcam = false;
                if (texto[5] == "Sim")
                {
                    internet = true;
                }
                else
                {
                    internet = false;
                }
                if (texto[6] == "Sim")
                {
                    webcam = true;
                }
                else
                {
                    webcam = false;
                }

                buscaSala(inicio, horaInicio, fim, horaFim, pessoas, false, false, webcam, internet);

                if (sala != null)
                {
                    adicionaReserva(sala);
                }
                else
                {
                    sugestaoData();
                }
            }
        }

        private Sala buscaSala(DateTime dataInicio, string horaInicio, DateTime dataFim, string horaFim, int pessoas, bool pc, bool tv, bool webcam, bool wifi)
        {
            lblAviso.Text = "";
            lblReservas.Text = "";
            lblDicas.Text = "";
            lblSugest.Visible = false;

            Sala sala = new Sala();
            List<Sala> indisponivel = new List<Sala>();

            Locais local = new Locais();
            List<Sala> salas = local.pegaSalas();

            for(int i = 0; i< salas.Count; i++)
            {
                if(viabilidadeSala(salas[i], pessoas, pc, tv, wifi, webcam))
                {
                    sala = salas[i];

                    Reservado item = new Reservado();

                    List<Reserva> reservas = item.pegaReservas();

                    Reserva reserva = new Reserva(sala, dataInicio, dataFim, txtHoraInicio.Text, txtHoraFim.Text, txtMinInicio.Text, txtMinFim.Text);

                    if (tempoMinimo(reserva) || tempoMaximo(reserva) || finalDeSemana(reserva) || duracaoReuniao(reserva))
                    {
                        lblAviso.Text = lblAviso.Text + "Não está obedecendo as regras de agendamento</br>";
                    }
                    else if (reservas == null)
                    {
                        return sala;
                    }
                    else                    
                    {
                        if(salaDisponivel(reservas, sala, reserva) == false)
                        {
                            return sala;
                        }
                    }   
                }else
                {
                    lblAviso.Text = "Não há salas com os requisitos necessários disponível </br>";
                    return null;
                }
            }

            if(verificaSala(sala, indisponivel))
            {
                return sala;
            }

            return null;
        }

        private void sugestaoData()
        {
            lblSugest.Visible = true;
            Reservado reservas = new Reservado();
            Sala sala = new Sala();
            int a = 1;
            int dicas = 0;

            do
            {
                DateTime dataInicio = calDataInicio.SelectedDate.Date.AddDays(a);
                DateTime dataFim = calDataFim.SelectedDate.Date.AddDays(a);               

                sala = buscaSala(dataInicio, txtHoraInicio.Text, dataFim, txtHoraFim.Text,Convert.ToInt32(txtNumPessoas.Text),
                                cbComputador.Checked, cbTV.Checked, cbWebcam.Checked, cbWifi.Checked);
                a++;

                if (sala != null)
                {
                    reservas.reservas.Add(new Reserva(sala, calDataInicio.SelectedDate.Date.AddDays(a), calDataFim.SelectedDate.AddDays(a), txtHoraInicio.Text, txtHoraFim.Text, txtMinInicio.Text, txtMinFim.Text));
                    dicas++;
                }

            } while (dicas < 3);

            for(int i=0; i< reservas.reservas.Count; i++)
            {
                lblDicas.Text = lblDicas.Text + "Data: " + reservas.reservas[i].dataInicio.Date.AddHours(reservas.reservas[i].dataInicio.Hour).ToString()
                    + " - " + reservas.reservas[i].dataFim.Date.AddHours(reservas.reservas[i].dataFim.Hour).ToString() + "</br>";


            }
            
        }

        private bool salaDisponivel(List<Reserva> reservas, Sala sala, Reserva reserva)
        {
            for (int j = 0; j < reservas.Count; j++)
            {
                if (reservas[j].sala.nome == sala.nome)
                {
                    //estão na mesma sala

                    if (conflitoData(reservas[j], reserva))
                    {
                        //marcaram na mesma data

                        if (conflitoHora(reservas[j], reserva))
                        {
                            //mesmo horário
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        protected void adicionaReserva(Sala sala)
        {
            lblAviso.Text = "Adicionando Reserva";
            string caminho = AppDomain.CurrentDomain.BaseDirectory;
            string jsonString = File.ReadAllText(caminho + @"\Json\reservas.json");

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            List<Reserva> reservas = (List<Reserva>)javaScriptSerializer.Deserialize(jsonString, typeof(List<Reserva>));

            Reserva reserva = new Reserva(sala, calDataInicio.SelectedDate, calDataFim.SelectedDate, txtHoraInicio.Text, txtHoraFim.Text, txtMinInicio.Text, txtMinFim.Text);

            if (reservas != null)
            {
                for (int i = 0; i < reservas.Count; i++)
                {
                    reservados.reservas.Add(reservas[i]);
                }
            }

            reservados.reservas.Add(reserva);

            reservados.reservas = reservados.reservas.OrderBy(a => a.id).ToList();

            var json = JsonConvert.SerializeObject(reservados.reservas, Formatting.Indented);

            using (StreamWriter writer = new StreamWriter(caminho + @"\Json\reservas.json", false))
            {
                writer.Write(json);
            }

            lblAviso.Text = "Reserva efetuada com sucesso";
        }

        protected void btnVerReservas_Click(object sender, EventArgs e)
        {
            lblReservas.Text = ""; 
            Reservado leitura = new Reservado();
            List<Reserva> lista = leitura.pegaReservas();

            for(int i=0; i<lista.Count; i++)
            {
                lblReservas.Text = lblReservas.Text + lista[i].id + " - Sala: " + lista[i].sala.nome
                    + " - " + lista[i].dataInicio + " - " + lista[i].dataFim + "</br>";
            }

        }

        private bool tempoMinimo(Reserva reserva)
        {
            DateTime agora = new DateTime();
            agora = DateTime.Now;

            if (reserva.dataInicio.Subtract(agora).Days < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool tempoMaximo(Reserva reserva)
        {
            DateTime agora = new DateTime();
            agora = DateTime.Now;

            if (reserva.dataInicio.Subtract(agora).Days > 40)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool finalDeSemana(Reserva reserva)
        {
            if((reserva.dataInicio.DayOfWeek == DayOfWeek.Saturday) || (reserva.dataFim.DayOfWeek == DayOfWeek.Saturday)
            || (reserva.dataInicio.DayOfWeek == DayOfWeek.Sunday) || (reserva.dataFim.DayOfWeek == DayOfWeek.Sunday))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool duracaoReuniao(Reserva reserva)
        {
            if (reserva.dataInicio.Date != reserva.dataFim.Date)
            {
                if((24 - reserva.dataInicio.Hour) + reserva.dataFim.Hour > 8)
                {
                    lblAviso.Text = "reunião tem mais de 8 horas";
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (reserva.dataFim.Hour - reserva.dataInicio.Hour > 8)
                {
                    lblAviso.Text = "reunião tem mais de 8 horas";
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool conflitoHora(Reserva reserva1, Reserva reserva2)
        {

            if((reserva1.dataInicio.Hour <= reserva2.dataInicio.Hour) && (reserva2.dataInicio.Hour < reserva1.dataFim.Hour))
            {
                return true;
            }else
            if((reserva1.dataInicio.Hour < reserva2.dataFim.Hour) && (reserva2.dataFim.Hour <= reserva1.dataFim.Hour))
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }

        private bool conflitoData(Reserva reserva1, Reserva reserva2)
        {
            if (reserva1.dataInicio.Date == reserva2.dataInicio.Date)
            {
                return true;
            }
            else
                if (reserva1.dataFim.Date == reserva2.dataInicio.Date)
            {
                return true;
            }
            else
                if (reserva1.dataInicio.Date == reserva2.dataFim.Date)
            {
                return true;
            }
            else
                if (reserva1.dataFim.Date == reserva2.dataFim.Date)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool verificaSala(Sala sala, List<Sala> indisponivel)
        {
            if (indisponivel != null)
            {
                for (int i = 0; i < indisponivel.Count; i++)
                {
                    if (indisponivel[i].nome == sala.nome)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool viabilidadeSala(Sala sala, int pessoas, bool pc, bool tv, bool wifi, bool webcam)
        {
            if((sala.lugares >= pessoas)
                && ((sala.computador == pc) || (sala.computador == true)) 
                && ((sala.tv == tv) || (sala.tv == true)) 
                && ((sala.webcam == webcam) || (sala.webcam == true)) 
                && ((sala.wifi == wifi) || (sala.wifi == true)))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}