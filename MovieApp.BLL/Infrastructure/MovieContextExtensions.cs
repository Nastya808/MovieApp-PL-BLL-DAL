using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


public static class MovieContextExtensions
{
    public static void EnsureDatabaseCreated(this MovieContext context)
    {
        if (context.Database.EnsureCreated())
        {
        }
    }
}
