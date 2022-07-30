using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestBooks.Domain.Common;
using TestBooks.Domain.Entities;
using TestBooks.Domain.Repositories;

namespace TestBooks.Infrastructure.Repositories
{
    public class BooksRepository : IBooksRepository
    {

        private string _FakeAPIUrl;
        private readonly HttpClient _client;

        public BooksRepository()
        {
            _FakeAPIUrl = "https://fakerestapi.azurewebsites.net";
            _client = new HttpClient();
            Uri fakeAPIuri = new Uri(_FakeAPIUrl, UriKind.Absolute);
            _client.BaseAddress = fakeAPIuri;   
        }
        


        public async Task<TaskResult<TestBooks.Domain.Entities.Books>> AddAsync(TestBooks.Domain.Entities.Books entity)
        {
            TaskResult<TestBooks.Domain.Entities.Books> taskResult = new TaskResult<TestBooks.Domain.Entities.Books>();
            try
            {
                var bookJson = JsonConvert.SerializeObject(entity);
                var data = new StringContent(bookJson, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("/api/v1/Books", data);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    taskResult.Data = JsonConvert.DeserializeObject<TestBooks.Domain.Entities.Books>(content);
                    taskResult.AddMessage("Se ha agregado el libro Correctamente!");
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

        public async Task<TaskResult<TestBooks.Domain.Entities.Books>> DeleteAsync(int id)
        {
            TaskResult<TestBooks.Domain.Entities.Books> taskResult = new TaskResult<TestBooks.Domain.Entities.Books>();
            try
            {
                var response = await _client.DeleteAsync($"api/v1/Books/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var book = await this.GetAsync(id);
                    taskResult.Data = book.Data;
                    taskResult.AddMessage($"Se ha eliminado el libro de id {id}Correctamente!");
                }

                else {

                    taskResult.AddMessage($"Ha ocurrido un error al momento de borrar el libro de id {id}!");

                }
            }
            catch (Exception e)
            {

                taskResult.AddErrorMessage("Ha ocurrido un error al momento de borrar el libro: " + e.Message);
            }
           return taskResult;
        }

        public async Task<TaskResult<IEnumerable<TestBooks.Domain.Entities.Books>>> GetAsync()
        {
            TaskResult<IEnumerable<TestBooks.Domain.Entities.Books>> taskResult = new  TaskResult<IEnumerable<TestBooks.Domain.Entities.Books>>();
            try
            {
               var response = await _client.GetAsync("api/v1/Books");
                var content = await response.Content.ReadAsStringAsync();
                taskResult.Data = JsonConvert.DeserializeObject<IEnumerable <TestBooks.Domain.Entities.Books>> (content);
                taskResult.AddMessage("Se recuperaron los libros Correctamente!");
            }
            catch (Exception e)
            {

                taskResult.AddErrorMessage("Ha ocurrido un error al momento de obtener los libros! "+e.Message);
            }
            return taskResult;
        }

        public async Task<TaskResult<TestBooks.Domain.Entities.Books>> GetAsync(int id)
        {
            
            TaskResult<TestBooks.Domain.Entities.Books> taskResult = new TaskResult<TestBooks.Domain.Entities.Books>();
            try
            {
                var response = await _client.GetAsync($"api/v1/Books/{id}");
                var content = await response.Content.ReadAsStringAsync();
                taskResult.Data = JsonConvert.DeserializeObject<TestBooks.Domain.Entities.Books>(content);
                taskResult.AddMessage($"Se ha recuperado el libro de id {id} Correctamente!");
            }
            catch (Exception e)
            {

                taskResult.AddErrorMessage("Ha ocurrido un error al momento de recuperar el libro: " + e.Message);
            }
            return taskResult;

        }

        public async Task<TaskResult<TestBooks.Domain.Entities.Books>> UpdateAsync(int id, TestBooks.Domain.Entities.Books entity)
        {
            TaskResult<TestBooks.Domain.Entities.Books> taskResult = new TaskResult<TestBooks.Domain.Entities.Books>();
            try
            {
                var bookJson = JsonConvert.SerializeObject(entity);
                var data = new StringContent(bookJson, Encoding.UTF8, "application/json");

                var response = await _client.PutAsync($"/api/v1/Books/{id}", data);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    taskResult.Data = JsonConvert.DeserializeObject<TestBooks.Domain.Entities.Books>(content);
                    taskResult.AddMessage("Se ha actualizado el libro Correctamente!");
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
