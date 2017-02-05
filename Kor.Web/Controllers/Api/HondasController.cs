using System.Web.Http;
using Kor.Core;

namespace Kor.Web.Controllers.Api
{
    public class HondasController : ApiController
    {
        DataService ds = new DataService(new ConcreteDataProvider());

        public HondasController(IDataProvider dataProvider)
        {
            ds = new DataService(dataProvider);
        }

        [ActionName("get")]
        [Authorize()]
        //// GET api/<controller>
        public dynamic Get()
        {
            return new { cars = ds.Hondas() };
        }
    }
}