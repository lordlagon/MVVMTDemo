using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MockedWebService.Services
{
    public class PersonService : GenericRest<Person>
    {
        public PersonService() : base("http://powerfarma.com.br/PessoaNuvem/", new HttpClient())
        {
        }
    }
}
