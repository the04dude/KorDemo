using System;
using System.Net.Http;
using System.Web.Http;
using Kor.Core;

namespace Kor.Web.Controllers.Api
{
    public class CarsController : ApiController
    {
        DataService ds = new DataService(new ConcreteDataProvider());

        public CarsController(IDataProvider dataProvider)
        {
            ds = new DataService(dataProvider);
        }


        [ActionName("get")]
        //// GET api/<controller>
        public dynamic Get()
        {
            return ds.Cars();
        }
    }
}