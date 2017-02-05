using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Kor.Core
{
    public class DataService
    {
        private IDataProvider _dataProvider;
        public DataService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public JObject Cars()
        {
            return _dataProvider.GetData();
        }

        public IEnumerable<JObject> Hondas()
        {
            var q = Cars();
            var cars = (JArray)q["cars"];
            return cars
                .Where(car => ((string)car["make"]) == "Honda")
                .Select(car => car as JObject);

        }
    }
}