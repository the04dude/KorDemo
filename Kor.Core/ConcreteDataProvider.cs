using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Kor.Core
{
    public class ConcreteDataProvider : IDataProvider
    {
        public JObject GetData()
        {
            var sourceUrl = @"https://s3.amazonaws.com/elasticbeanstalk-us-east-1-253941727413/interview/car.json";
            var response = WebRequest.Create(sourceUrl).GetResponse();
            var dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            var reader = new StreamReader(dataStream);

            // Read the content.  
            var responseFromServer = reader.ReadToEnd();
            return JObject.Parse(responseFromServer);
        }
    }
}