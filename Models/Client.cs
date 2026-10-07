using System;

namespace ODATATestAPI.Models;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public CustomerType Type { get; set; }
    public decimal CreditLimit { get; set; }
    public DateTime CustomerSince { get; set; }
    public List<Order> Orders { get; set; } = [];

}
