using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common
{
    public class ConvertJSON
    {
        public string ConvertToJSON(IEnumerable<Object> list)
        {
            return JsonConvert.SerializeObject(list);
        }
    }
}
