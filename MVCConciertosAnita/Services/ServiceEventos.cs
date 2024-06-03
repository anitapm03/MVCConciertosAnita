using MVCConciertosAnita.Models;
using System.Net.Http.Headers;

namespace MVCConciertosAnita.Services
{
    public class ServiceEventos
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceEventos(IConfiguration configuration)
        {
            this.UrlApi = configuration.GetValue<string>
                ("ApiUrls:ApiConciertos");
            this.header = new MediaTypeWithQualityHeaderValue
                ("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response =
                    await client.GetAsync(this.UrlApi + request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        //get categorias
        public async Task<List<CategoriaEvento>> GetCategorias()
        {
            string request = "/api/Eventos/GetCategorias";
            List<CategoriaEvento> data =
                await this.CallApiAsync<List<CategoriaEvento>>(request);
            return data;
        }

        //get eventos
        public async Task<List<Evento>> GetEventos()
        {
            string request = "/api/Eventos/GetEventos";
            List<Evento> data =
                await this.CallApiAsync<List<Evento>>(request);
            return data;
        }


        //find evento categoria
        public async Task<List<Evento>>
           FindEventoCategoria(int idcategoria)
        {
            string request = "/api/Eventos/FindEventoCategoria/" + idcategoria;
            List<Evento> data =
                await this.CallApiAsync<List<Evento>>(request);
            return data;
        }
    }
}
