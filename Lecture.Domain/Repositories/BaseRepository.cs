using Lecture.Data.Entities;
using Lecture.Domain.Enums;

namespace Lecture.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly RentACarDbContext DbContext;

        protected BaseRepository(RentACarDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected ResponseResultType SaveChanges()
        {
            var hasChanges = DbContext.SaveChanges() > 0;
            if (hasChanges)
                return ResponseResultType.Success;

            return ResponseResultType.NoChanges;
        }
    }
}
