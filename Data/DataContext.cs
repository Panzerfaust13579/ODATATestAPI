using System;
using Microsoft.EntityFrameworkCore;
using ODATATestAPI.Models;

namespace ODATATestAPI.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; }
}
