using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.Services
{
    public class QuizService : GenericRest<Quiz>
    {
        //TODO testar retorno das chamadas
        //http://powerfarma.com.br/Pergunta/getByApp?strPesquisa=&situacao=1
        public QuizService() : base("http://powerfarma.com.br/Pergunta/", new HttpClient())
        {
        }
    }
}
