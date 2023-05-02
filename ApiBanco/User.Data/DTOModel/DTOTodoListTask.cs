using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace User.Data.DTOModel
{
    public class DTOTodoListTask : DTOTodoBase
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        [JsonPropertyName("isComplete")]
        public bool IsComplete { get; set; }

        [JsonPropertyName("todoListId")]
        public int TodoListId { get; set; }

        [JsonPropertyName("todolist")]
        public DTOTodoList TodoList { get; set; }

    }

    public class DTOAddTodoListTask : DTOTodoBase
    {
        [JsonPropertyName("todolist")]
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public int TodoListId { get; set; }

    }
}
