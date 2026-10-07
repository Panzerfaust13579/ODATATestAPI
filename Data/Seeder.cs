using System;
using ODATATestAPI.Models;

namespace ODATATestAPI.Data;

public class Seeder
{
    public static void SeedData(DataContext context)
    {
        if (!context.Clients.Any())
        {
            var clients = new List<Client>
            {
                new() {Id = 1, Name = "Client 1", Type = CustomerType.Retail, CreditLimit = 1000, CustomerSince = DateTime.Now.AddYears(-2)},
                new() {Id = 2, Name = "Client 2", Type = CustomerType.Wholesale, CreditLimit = 1500, CustomerSince = DateTime.Now.AddYears(-1)}
            };
            context.Clients.AddRange(clients);
            context.SaveChanges();
        }
    }
}
