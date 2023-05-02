using System.Text.Json.Serialization;
using User.Data.DTOModel;

namespace BancoAppWeb.Models.Todolist
{
    public class ViewModelTask
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("color")]
        public int Color { get; set; }


        [JsonPropertyName("todolistid")]
        public int TodoListId { get; set; }

        [JsonPropertyName("tasks")]
        public List<DTOTodoListTask> dtolisttask { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("created")]
        public string created { get; set; }
        [JsonPropertyName("updated")]
        public string updated { get; set; }

    }


    public class ViewModelAddTask
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("priority")]
        public Priority Priority { get; set; }
    }
}
