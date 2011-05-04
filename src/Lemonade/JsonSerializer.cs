
using System.IO;
using System.Web.Script.Serialization;
using Sider;
using Sider.Serialization;

namespace Lemonade
{
  // TODO: Problem with finding the correct type.
  //   Type information shuold've been included in the serializerd
  //    json string for proper deserialization later and not 
  //    IDictionary<string, object>
  public class JsonSerializer : ISerializer<object>
  {
    private JavaScriptSerializer _json;
    private StringSerializer _string;

    private string _temp;

    public void Init(RedisSettings settings)
    {
      _json = new JavaScriptSerializer();
      _string = new StringSerializer();
      _string.Init(settings);
    }


    public object Read(Stream src, int length)
    {
      return _json.DeserializeObject(_string.Read(src, length));
    }

    public int GetBytesNeeded(object obj)
    {
      _temp = _json.Serialize(obj);
      return _string.GetBytesNeeded(_temp);
    }

    public void Write(object obj, Stream dest, int bytesNeeded)
    {
      _string.Write(_temp, dest, bytesNeeded);
    }
  }
}
