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
            public async Task<Tasca> GettascaAsync()
            {
            Tasca taska = new Tasca();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ServidorApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Enviem una petició GET al endpoint /users/{Id}
                    HttpResponseMessage response = await client.GetAsync("Tasca?estat=todo");
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
        public async Task<List<responsable>> GetResponsablesAsync()
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

        public async Task<List<Tasca>> GetTascadoneAsync()
        {
            List<Tasca> tasques = new List<Tasca>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServidorApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /users}
                HttpResponseMessage response = await client.GetAsync($"Tasca?estat=done") ;
                if (response.IsSuccessStatusCode)
                {
                    //Obtenim el resultat i el carreguem al objecte llista d'usuaris
                    tasques = await response.Content.ReadAsAsync<List<Tasca>>();

                    response.Dispose();
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? missatge?

                }
            }
            return tasques;
        }

        public async Task<List<Tasca>> GetTascatodoAsync()
        {
            List<Tasca> tasques = new List<Tasca>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServidorApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /users}
                HttpResponseMessage response = await client.GetAsync($"Tasca?estat=todo");
                if (response.IsSuccessStatusCode)
                {
                    //Obtenim el resultat i el carreguem al objecte llista d'usuaris
                    tasques = await response.Content.ReadAsAsync<List<Tasca>>();

                    response.Dispose();
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? missatge?

                }
            }
            return tasques;
        }

        public async Task<List<Tasca>> GetTascadoingAsync()
        {
            List<Tasca> tasques = new List<Tasca>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServidorApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /users}
                HttpResponseMessage response = await client.GetAsync($"Tasca?estat=doing");
                if (response.IsSuccessStatusCode)
                {
                    //Obtenim el resultat i el carreguem al objecte llista d'usuaris
                    tasques = await response.Content.ReadAsAsync<List<Tasca>>();

                    response.Dispose();
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? missatge?

                }
            }
            return tasques;
        }







        public async Task AddAsync(Tasca nom)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServidorApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició POST al endpoint /users}
                HttpResponseMessage response = await client.PostAsJsonAsync("Tasca", nom);
                response.EnsureSuccessStatusCode();
            }
        }

        /// <summary>
        /// Modificar un usuari
        /// </summary>
        /// <param name="user">Usuari que volem modificar</param>
        /// <returns></returns>
        public async Task UpdateAsync(Tasca nom)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServidorApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició PUT al endpoint /users/Id
                HttpResponseMessage response = await client.PutAsJsonAsync($"Tasca/{nom.ID}", nom);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task UpdateAsyncrespo(responsable nom)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServidorApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició PUT al endpoint /users/Id
                HttpResponseMessage response = await client.PutAsJsonAsync($"responsable/{nom.ID}", nom);
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

        public async Task DeleteTascaAsync(int ID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServidorApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició DELETE al endpoint /users/Id
                HttpResponseMessage response = await client.DeleteAsync($"Tasca/{ID}");
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
