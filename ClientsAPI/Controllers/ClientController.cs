using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClientsAPI.Data;
using ClientsAPI.Models;

namespace ClientsAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly APIcontext _context;
        public ClientController(APIcontext context)
        {
            _context = context;
        }

        //Create
        [HttpPost]
        public JsonResult Create(Client client)
        {
            if (client.ClientID == 0)
            {
                _context.Clients.Add(client);
            }
            else
            {
                var clientInDb = _context.Clients.Find(client.ClientID);

                if (clientInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                else
                {
                    clientInDb = client;
                }

               
            }
            _context.SaveChanges();

            return new JsonResult(Ok(client));
        }

        //Edit
        [HttpPut]
        
        public JsonResult Edit( Client client)
        {
            var result=_context.Clients.Find(client.ClientID);

            if(result != null)
            {
                result.FullName=client.FullName;
                result.Email=client.Email;
                result.PhoneNumber=client.PhoneNumber;
                result.Address=client.Address;

                _context.SaveChanges();
            }
            return new JsonResult(Ok(client));
        }

        //Get
        [HttpGet]
        public JsonResult GetSingle(int id)
        {
            var result = _context.Clients.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }


        //Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Clients.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Clients.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }


        //Get all
        [HttpGet()]
        public JsonResult GetAll()
        {
            var result = _context.Clients.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
