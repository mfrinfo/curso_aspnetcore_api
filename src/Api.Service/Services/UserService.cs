using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDtoCreateResult> Post(UserDto user)
        {
            //Cria um Modelo de Negócio
            var model = _mapper.Map<UserModel>(user);

            //Cria uma entidade baseada no Modelo
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.InsertAsync(entity);

            //Retorna uma Dto com Resultado do Insert
            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDto user)
        {
            //Cria um Modelo de Negócio
            var model = _mapper.Map<UserModel>(user);

            //Cria uma entidade baseada no Modelo
            var entity = _mapper.Map<UserEntity>(model);

            var result = await _repository.UpdateAsync(entity);

            //Retorna uma Dto com Resultado do Update
            return _mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}
