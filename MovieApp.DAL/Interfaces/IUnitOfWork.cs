using MovieApp.DAL.Entities;
using MovieApp.DAL.Interfaces;
using System;
using System.Threading.Tasks;


namespace MovieApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Movie> Movies { get; }
        Task<int> CompleteAsync();
    }
}