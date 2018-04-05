using ExLemaf.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExLemaf
{
    public partial class criaSala : System.Web.UI.Page
    {
        Locais lugares = new Locais();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnCriaSala_Click(object sender, EventArgs e)
        {
            string caminho = AppDomain.CurrentDomain.BaseDirectory;
            lblMostraSalas.Text = "";

            string jsonString = File.ReadAllText(caminho + @"\Json\salas.json");

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            List<Sala> salas = (List<Sala>)javaScriptSerializer.Deserialize(jsonString, typeof(List<Sala>));

            Sala sala = new Sala(txtNomeSala.Text, Convert.ToInt32(txtLugaresSala.Text),
                                cbPC.Checked, cbWifi.Checked, cbTV.Checked, cbWebcam.Checked);

            bool criar = true;
            if (salas != null)
            {
                for (int i = 0; i < salas.Count; i++)
                {
                    if (salas[i].nome == sala.nome)
                    {
                        criar = false;
                    }

                    lugares.salas.Add(salas[i]);
                }
            }

            if (criar) {

                lugares.salas.Add(sala);

                lugares.salas = lugares.salas.OrderBy(a => Convert.ToInt32(a.nome)).ToList();

                var json = JsonConvert.SerializeObject(lugares.salas, Formatting.Indented);

                using (StreamWriter writer = new StreamWriter(caminho + @"\Json\salas.json", false))
                {
                    writer.Write(json);
                }
            }
            else
            {
                lblMostraSalas.Text = "Sala já existe";
            }        
        }

        protected void btnVerSalas_Click(object sender, EventArgs e)
        {
            lblMostraSalas.Text = "";
            string caminho = AppDomain.CurrentDomain.BaseDirectory;

            string jsonString = File.ReadAllText(caminho + @"\Json\salas.json");

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            List<Sala> salas = (List<Sala>)javaScriptSerializer.Deserialize(jsonString, typeof(List<Sala>));

            for (int i = 0; i < salas.Count; i++)
            {
                lblMostraSalas.Text = lblMostraSalas.Text + salas[i].nome + "</br>";
            }
        }
    }
}