using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Security;

namespace Api.Service.Services {
    public class LoginService : ILoginService {
        private IUserRepository _repository;
        public LoginService (IUserRepository repository) {
            _repository = repository;
        }
        public async Task<object> FindByLogin (UserEntity user) {
            var baseUser = new UserEntity ();
            if (user != null && !string.IsNullOrWhiteSpace (user.Email)) {
                baseUser = await _repository.FindByLogin (user.Email);
                if (baseUser == null) {
                    return null;
                } else {
                    return baseUser;
                }

            } else {
                return null;
            }

        }
    }
}
