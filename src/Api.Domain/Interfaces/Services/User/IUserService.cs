using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.User {
    public interface IUserService {
        Task<UserEntity> Get (Guid id);
        Task<IEnumerable<UserEntity>> GetAll ();
        Task<UserEntity> Post (UserEntity user);
        Task<UserEntity> Put (UserEntity user);
        Task<bool> Delete (Guid id);
    }
}
