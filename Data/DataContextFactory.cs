using System;
using Microsoft.EntityFrameworkCore;

namespace DonMacaron.Data;

public class DataContextFactory
{
    private readonly DbContextOptions<DataContext> _options;

    public DataContextFactory(DbContextOptions<DataContext> options)
    {
        _options = options;
    }

    public DataContext CreateDbContext()
    {
        return new DataContext(_options);
    }
}

