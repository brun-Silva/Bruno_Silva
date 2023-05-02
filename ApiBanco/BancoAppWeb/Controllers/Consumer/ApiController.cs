using Azure;
using BancoAppWeb.Models.Todolist;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.WebPages;
using User.Data.DTOModel;

namespace BancoAppWeb.Controllers
{
    public class ApiController : Controller
    {
        private readonly HttpClient _httpClient;

        public ApiController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult IndexTodoList()
        {
            var response = _httpClient.GetAsync("https://localhost:7072/api/todolist/getalllists").Result;

            var content = response.Content.ReadAsStringAsync().Result;
            var todolist = JsonSerializer.Deserialize<List<DTOTodoList>>(content);
            
            //var strJson = JsonSerializer.Serialize(todolist);


            var viewmodelhome = new ViewModelHomeTodo { dtoTodoList = todolist };

            return View("IndexTodoList", viewmodelhome);
        }

        public IActionResult ViewCard(int id)
        {
            var response = _httpClient.GetAsync($"https://localhost:7072/api/todolist/getbyid?listid={id}").Result;

            var content = response.Content.ReadAsStringAsync().Result;
            var todolist = JsonSerializer.Deserialize<ViewModelTask>(content);

            //var strJson = JsonSerializer.Serialize(todolist);
            //deveria receber um dto a partir da API, e aqui usar o mapper com o profile adequado e converter o DTO em uma view
            //como não recebemos um DTO vindo da API, convertemos diretamente o objeto recebido em JSON para uma view (o que é errado)


            return View("ViewCardTask", todolist);
        }

        public IActionResult Delettask(int id)
        {

           var a  = _httpClient.DeleteAsync($"https://localhost:7072/api/todolist/task/deletetask?taskid={id}").Result;

            var content = a.Content.ReadAsStringAsync().Result;
            int result = Int32.Parse(content);

            return ViewCard(result);
        }

        public IActionResult DeletList(int id)
        {

            var a = _httpClient.DeleteAsync($"https://localhost:7072/api/todolist/deletetodolist?todolistId={id}").Result;

            return IndexTodoList();
        }

        public IActionResult CreateTask(ViewModelAddTask viewmodeladd)
        {

            var response = _httpClient.PostAsJsonAsync<ViewModelAddTask>("https://localhost:7072/api/todolist/task/createtask", viewmodeladd).Result;
            if (response.IsSuccessStatusCode)
            {
                return ViewCard(viewmodeladd.Id);
            }
            else
            {
                return ViewCard(viewmodeladd.Id);
            }

        }


        public IActionResult CompleteTask(int Id, int listId)
        {
            var content = new StringContent(string.Empty);
            _ =  _httpClient.PostAsync($"https://localhost:7072/api/todolist/task/complete?taskid={Id}",content).Result;


            return ViewCard(listId);
        }


        public IActionResult GoToViewAddList( )
        {
            return View("ViewAddList");
        }

        public IActionResult CreateList(ViewModelAddList viewmodeladd)
        {
          viewmodeladd.color = 10;
          viewmodeladd.tasks = new List<DTOTodoListTask>();
          var response = _httpClient.PostAsJsonAsync<ViewModelAddList>("https://localhost:7072/api/todolist/createlist", viewmodeladd).Result;

           return IndexTodoList();
        }

    }
}