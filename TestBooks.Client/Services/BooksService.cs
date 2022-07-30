using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestBooks.Client.Models;

namespace TestBooks.Client.Services
{
    public class BooksService : IBooksService
    {
        private string _FakeAPIUrl;
        private readonly HttpClient _client;

        public BooksService()
        {
            _FakeAPIUrl = "https://localhost:44321";
            _client = new HttpClient();
            Uri fakeAPIuri = new Uri(_FakeAPIUrl, UriKind.Absolute);
            _client.BaseAddress = fakeAPIuri;
        }

        public async Task<TaskResult<Books>> AddAsync(Books entity)
        {
            TaskResult<Books> taskResult = new TaskResult<Books>();
            try
            {
                var bookJson = JsonConvert.SerializeObject(entity);
                var data = new StringContent(bookJson, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("/api/Books", data);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    taskResult = JsonConvert.DeserializeObject<TaskResult<Books>>(content);

                }

                else
                {
                    taskResult.AddMessage("Ha ocurrido un error al momento de agregar el libro.!");
                }

            }
            catch (Exception e)
            {

                taskResult.AddErrorMessage("Ha ocurrido un error al momento de agregar el libro: " + e.Message);
            }
            return taskResult;
        }

        public async Task<TaskResult<Books>> DeleteAsync(int id)
        {
            TaskResult<Books> taskResult = new TaskResult<Books>();
            try
            {
                var response = await _client.DeleteAsync($"api/Books/{id}");

                if (response.IsSuccessStatusCode)
                {
                    taskResult = await this.GetAsync(id);
                    
                }
                else
                {
                    taskResult.AddMessage($"Ha ocurrido un error al momento de borrar el libro de id {id}!");
                }
            }
            catch (Exception e)
            {

                taskResult.AddErrorMessage("Ha ocurrido un error al momento de borrar el libro: " + e.Message);
            }
            return taskResult;
        }

        public async Task<TaskResult<IEnumerable<Books>>> GetAsync()
        {
            TaskResult<IEnumerable<Books>> taskResult = new TaskResult<IEnumerable<Books>>();
            try
            {
                var response = await _client.GetAsync("api/Books");
                var content = await response.Content.ReadAsStringAsync();
                taskResult = JsonConvert.DeserializeObject< TaskResult<IEnumerable<Books>>>(content);
            }
            catch (Exception e)
            {

                taskResult.AddErrorMessage("Ha ocurrido un error al momento de obtener los libros! " + e.Message);
            }
            return taskResult;
        }

        public async Task<TaskResult<Books>> GetAsync(int id)
        {

            TaskResult<Books> taskResult = new TaskResult<Books>();
            try
            {
                var response = await _client.GetAsync($"api/Books/{id}");
                var content = await response.Content.ReadAsStringAsync();
                taskResult = JsonConvert.DeserializeObject<TaskResult<Books>>(content);

            }
            catch (Exception e)
            {

                taskResult.AddErrorMessage("Ha ocurrido un error al momento de recuperar el libro: " + e.Message);
            }
            return taskResult;

        }

        public async Task<TaskResult<Books>> UpdateAsync(int id, Books entity)
        {
            TaskResult<Books> taskResult = new TaskResult<Books>();
            try
            {
                var bookJson = JsonConvert.SerializeObject(entity);
                var data = new StringContent(bookJson, Encoding.UTF8, "application/json");

                var response = await _client.PutAsync($"/api/Books/{id}", data);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    taskResult = JsonConvert.DeserializeObject<TaskResult<Books>>(content);
                }

                else
                {

                    taskResult.AddMessage("Ha ocurrido un error al momento de actualizar el libro.!");

                }

            }
            catch (Exception e)
            {

                taskResult.AddErrorMessage("Ha ocurrido un error al momento de actualizar el libro: " + e.Message);
            }
            return taskResult;
        }
    }
}
