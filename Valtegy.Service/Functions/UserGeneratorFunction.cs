using Newtonsoft.Json;
using System.ComponentModel;

namespace Valtegy.Service.Functions
{
    public static class UserGeneratorFunction
    {
        public static string GetHtml(string htmlTemplate, object data)
        {
            return Format(htmlTemplate, JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(data)));
        }

        private static  string Format(string input, object p)
        {
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(p))
                input = input.Replace("{" + prop.Name + "}", (prop.GetValue(p) ?? "(null)").ToString());

            return input;
        }
    }
}
