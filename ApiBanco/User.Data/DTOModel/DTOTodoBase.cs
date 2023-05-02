using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace User.Data.DTOModel
{
    public class DTOTodoBase
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("updated")]
        public DateTime Updated { get; set; }
    }
}
