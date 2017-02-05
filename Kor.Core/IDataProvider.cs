using Newtonsoft.Json.Linq;

namespace Kor.Core
{
    public interface IDataProvider
    {
        JObject GetData();
    }
}