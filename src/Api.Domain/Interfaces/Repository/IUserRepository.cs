using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repository {
    public interface IUserRepository : IRepository<UserEntity> {
        Task<UserEntity> FindByLogin (string email);
    }
}
