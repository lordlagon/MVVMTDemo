using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace RestClient.Services
{
    public class TabloidService : GenericRest<Tabloid>
    {
        //TODO testar retorno das chamadas
        //http://powerfarma.com.br/Tabloide/getTabloide
        public TabloidService() : base("http://powerfarma.com.br/Tabloide/", new HttpClient())
        {
        }
    }
}
