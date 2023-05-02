using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace User.Data.DTOModel
{
    public class DTOTodoList : DTOTodoBase
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("color")]
        public int Color { get; set; }

        [JsonPropertyName("tasks")]
        public List<DTOTodoListTask> Tasks { get; set; }

    }

    public class DTOAddTodoList : DTOTodoBase
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
    }

    public class DTOEditTodoList : DTOTodoBase
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
    }



}
