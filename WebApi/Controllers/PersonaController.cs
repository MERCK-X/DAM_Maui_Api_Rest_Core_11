using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapaEntidad;
using WebApi.Models;
using System.Text.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonaController : ControllerBase
    {
        [HttpGet]
        public List<PersonaCLS> listaPersona()
        {
            List<PersonaCLS> lista = new List<PersonaCLS>();

            try
            {
                using (DbAb7234BdveterinariaContext bd = new DbAb7234BdveterinariaContext())
                {
                    lista = (from persona in bd.Personas
                             where persona.Bhabilitado == 1
                             select new PersonaCLS
                             {
                                 iidpersona = persona.Iidpersona,
                                 nombrecompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                 correo = persona.Correo,
                                 fechanacimientocadena = persona.Fechanacimiento == null ? "" :
                                 persona.Fechanacimiento.Value.ToString("dd/MM/yyyy")
                             }).ToList();
                }
                return lista;
            }
            catch (Exception)
            {

                return lista;
            }
        }

        //Listado con filtro

        [HttpGet("{nombrecompleto}")]
        public List<PersonaCLS> listaPersona(string nombrecompleto)
        {
            List<PersonaCLS> lista = new List<PersonaCLS>();

            try
            {
                using (DbAb7234BdveterinariaContext bd = new DbAb7234BdveterinariaContext())
                {
                    lista = (from persona in bd.Personas
                             where persona.Bhabilitado == 1
                             && (persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno).Contains(nombrecompleto)
                             select new PersonaCLS
                             {
                                 iidpersona = persona.Iidpersona,
                                 nombrecompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                 correo = persona.Correo,
                                 fechanacimientocadena = persona.Fechanacimiento == null ? "" :
                                 persona.Fechanacimiento.Value.ToString("dd/MM/yyyy")
                             }).ToList();
                }
                return lista;
            }
            catch (Exception)
            {

                return lista;
            }
        }

        //Recuperar por id

        [HttpGet("recuperarPersonaPorId/{id}")]
        public PersonaCLS recuperarPersonaPorId(int id)
        {
            PersonaCLS oPersonaCLS = new PersonaCLS();

            try
            {
                using (DbAb7234BdveterinariaContext bd = new DbAb7234BdveterinariaContext())
                {
                    oPersonaCLS = (from persona in bd.Personas
                                   where persona.Bhabilitado == 1 && persona.Iidpersona == id
                                   select new PersonaCLS
                                   {
                                       iidpersona = persona.Iidpersona,
                                       nombre = persona.Nombre,
                                       appaterno = persona.Appaterno,
                                       apmaterno = persona.Apmaterno,
                                       correo = persona.Correo,
                                       fechanacimiento = (DateTime)persona.Fechanacimiento,
                                       fechanacimientocadena = persona.Fechanacimiento == null ? "" :
                                       persona.Fechanacimiento.Value.ToString("dd/MM/yyyy"),
                                       iisexo = (int)persona.Iidsexo
                                   }).First();
                }
                return oPersonaCLS;
            }
            catch (Exception)
            {

                return oPersonaCLS;
            }
        }
    }
}