using System.Text.Json.Serialization;
using User.Data.DTOModel;

namespace BancoAppWeb.Models.Todolist
{
    public class ViewModelAddList
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("color")]
        public int color { get; set; }

        [JsonPropertyName("tasks")]
        public List<DTOTodoListTask> tasks { get; set; }
        
    }
}
