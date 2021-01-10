using System;
using Lecture.Domain.Repositories;

namespace Lecture.Domain.Factories
{
    public static class RepositoryFactory
    {
        public static TRepository GetRepository<TRepository>() where TRepository : BaseRepository
        {
            var context = DbContextFactory.GetRentACarDbContext();
            return (TRepository) Activator.CreateInstance(typeof(TRepository), context);
        }
    }
}
