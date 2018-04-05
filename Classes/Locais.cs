using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;

namespace ExLemaf.Classes
{
    public class Locais
    {
        public List<Sala> salas { get; set; }

        public Locais()
        {
            salas = new List<Sala>();
        }

        public List<Sala> pegaSalas()
        {
            string caminho = AppDomain.CurrentDomain.BaseDirectory;  
            string jsonStringSala = File.ReadAllText(caminho + @"\Json\salas.json");

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();

            return (List<Sala>)javaScriptSerializer.Deserialize(jsonStringSala, typeof(List<Sala>));
        }
    }
}