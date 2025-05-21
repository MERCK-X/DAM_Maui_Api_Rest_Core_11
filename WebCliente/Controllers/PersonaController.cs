﻿using System.Text.Json;
using CapaEntidad;
using Microsoft.AspNetCore.Mvc;
using WebCliente.Clases;

namespace WebCliente.Controllers
{
    public class PersonaController : Controller
    {

        private string urlbase;
        private string cadena;
        private readonly IHttpClientFactory _httpClientFactory;

        public PersonaController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            urlbase = configuration["baseurl"];

            _httpClientFactory = httpClientFactory;

        }

        //Traemos la data como string
        //Listar personas
        public async Task<List<PersonaCLS>> ListarPersonas()
        {
            //var cliente = _httpClientFactory.CreateClient();
            //cliente.BaseAddress = new Uri(urlbase);

            //string cadena = await cliente.GetStringAsync("api/Persona");
            //List<PersonaCLS> lista = JsonSerializer.Deserialize<List<PersonaCLS>>(cadena);
            //return lista;

            return await ClientHttp.GetAll<PersonaCLS>(_httpClientFactory, urlbase, "api/Persona/");
        }

        //Filtrar personas
        public async Task<List<PersonaCLS>> FiltrarPersonas(string nombrecompleto)
        {
            // var cliente = _httpClientFactory.CreateClient();
            //cliente.BaseAddress = new Uri(urlbase);

            // string cadena = await cliente.GetStringAsync("api/Persona/" + nombrecompleto);
            // List<PersonaCLS> lista = JsonSerializer.Deserialize<List<PersonaCLS>>(cadena);
            // return lista;

            return await ClientHttp.GetAll<PersonaCLS>(_httpClientFactory, urlbase,
                "api/Persona/" + nombrecompleto);


        }

        public async Task<PersonaCLS> RecuperarPersona(int id)
        {
           return await ClientHttp.Get<PersonaCLS>(_httpClientFactory, urlbase,
               "api/Persona/Recuperar/" + id);
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}