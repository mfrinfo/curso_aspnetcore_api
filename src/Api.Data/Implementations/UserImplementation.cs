using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations {
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository {
        private DbSet<UserEntity> _dataset;
        public UserImplementation (MyContext context) : base (context) {
            _dataset = _context.Set<UserEntity> ();
        }

        public async Task<UserEntity> FindByLogin (string email) {
            return await _dataset.FirstOrDefaultAsync (u => u.Email.Equals (email));
        }
    }
}
