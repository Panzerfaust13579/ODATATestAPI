using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODATATestAPI.Data;
using ODATATestAPI.Models;

namespace ODATATestAPI.Controllers
{
    public class ClientsController(DataContext dbContext) : ODataController
    {
        [EnableQuery]
        public ActionResult<IQueryable<Client>> Get()
        {
            return Ok(dbContext.Clients);
        }

        [HttpGet("odata/Clients({key})")]
        public ActionResult<Client> Get([FromRoute] int key)
        {
            var customer = dbContext.Clients.SingleOrDefault(d => d.Id == key);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        public ActionResult Post([FromBody] Client customer)
        {
            dbContext.Clients.Add(customer);

            dbContext.SaveChanges();

            return Created(customer);
        }

        public ActionResult Put([FromRoute] int key, [FromBody] Client updatedCustomer)
        {
            var customer = dbContext.Clients.SingleOrDefault(d => d.Id == key);

            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = updatedCustomer.Name;
            customer.Type = updatedCustomer.Type;
            customer.CreditLimit = updatedCustomer.CreditLimit;
            customer.CustomerSince = updatedCustomer.CustomerSince;

            dbContext.SaveChanges();

            return Updated(customer);
        }

        public ActionResult Patch([FromRoute] int key, [FromBody] Delta<Client> delta)
        {
            var customer = dbContext.Clients.SingleOrDefault(d => d.Id == key);

            if (customer == null)
            {
                return NotFound();
            }

            delta.Patch(customer);

            dbContext.SaveChanges();

            return Updated(customer);
        }

        public ActionResult Delete([FromRoute] int key)
        {
            var customer = dbContext.Clients.SingleOrDefault(d => d.Id == key);

            if (customer != null)
            {
                dbContext.Clients.Remove(customer);
            }

            dbContext.SaveChanges();

            return NoContent();
        }
    }
}
// :D