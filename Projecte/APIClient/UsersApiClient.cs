using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Projecte.Model;
using System.Configuration;
using Projecte.Entity;




namespace Projecte.APIClient
{
    public class UsersApiClient
    {
        string ServidorApi;
        
        
        public UsersApiClient()
        {
            ServidorApi = ConfigurationManager.AppSettings["ServidorApi"];
        }
        
        /// <summary>
        /// Obté un usuari a partir del Id
        /// </summary>
        /// <param name="Id">Codi d'usuari</param>
        /// <returns>Usuari o null si no el troba</returns>
            public async Task<Tasca> GetUserAsync(int ID)
            {
            Tasca taska = new Tasca();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ServidorApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Enviem una petició GET al endpoint /users/{Id}
                    HttpResponseMessage response = await client.GetAsync($"resposable/{ID}");
                    if (response.IsSuccessStatusCode)
                    {
                        //Reposta 204 quan no ha trobat dades
                        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            taska = null;
                        }
                        else
                        {
                            //Obtenim el resultat i el carreguem al Objecte User
                            taska = await response.Content.ReadAsAsync<Tasca>();
                      
                            response.Dispose();
                        }
                    }
                    else
                    {
                        //TODO: que fer si ha anat malament? retornar null? 
                    }
                }
                return taska;
            }



        /// <summary>
        /// Obté una llista de tots els usuaris de la base de dades
        /// </summary>
        /// <returns></returns>
        public async Task<List<responsable>> GetUsersAsync()
        {
            List<responsable> responsables = new List<responsable>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServidorApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /users}
                HttpResponseMessage response = await client.GetAsync("responsable");
                if (response.IsSuccessStatusCode)
                {
                    //Obtenim el resultat i el carreguem al objecte llista d'usuaris
                    responsables = await response.Content.ReadAsAsync<List<responsable>>();
                    
                    response.Dispose();
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? missatge?
                    
                }
            }
            return responsables;
        }



        /// <summary>
        /// Afegeix un nou usuari
        /// </summary>
        /// <param name="user">Usuari que volem afegir</param>
        /// <returns></returns>
        public async Task AddAsync(responsable nom)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServidorApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició POST al endpoint /users}
                HttpResponseMessage response = await client.PostAsJsonAsync("responsable", nom);
                response.EnsureSuccessStatusCode();
            }
        }

        /// <summary>
        /// Modificar un usuari
        /// </summary>
        /// <param name="user">Usuari que volem modificar</param>
        /// <returns></returns>
        public async Task UpdateAsync(responsable nom)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServidorApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició PUT al endpoint /users/Id
                HttpResponseMessage response = await client.PutAsJsonAsync($"api/responsable/{nom.ID}", nom);
                response.EnsureSuccessStatusCode();
            }
        }


        /// <summary>
        /// Modificar un usuari
        /// </summary>
        /// <param name="user">Usuari que volem modificar</param>
        /// <returns></returns>
        public async Task DeleteAsync(int ID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServidorApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició DELETE al endpoint /users/Id
                HttpResponseMessage response = await client.DeleteAsync($"responsable/{ID}");
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
