using ApplicationCore.ESX.Entities;
using ApplicationCore.ESX.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;

namespace ApplicationCore.ESX.Services
{
    public abstract class AppService<TCreateViewModel, TViewModel, TEntity> : AppService<TCreateViewModel,TViewModel>
        where TCreateViewModel : class
        where TViewModel : class
        where TEntity : EntityBase
    {
        protected readonly IMapper _mapper;
        protected readonly IRepository<TEntity> _repository;

        public AppService(IMapper mapper, IRepository<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<TViewModel> GetAll() => _repository.ListAll().ProjectTo<TViewModel>(_mapper.ConfigurationProvider);

        public TViewModel GetById(int id) => _mapper.Map<TViewModel>(_repository.GetById(id));

        public abstract void Register(TCreateViewModel viewModel);

        public abstract void Remove(int id);

        public abstract void Update(TViewModel viewModel);

        /// <summary>
        /// Método para liberar a memória
        /// </summary>
        public void Dispose() => GC.SuppressFinalize(this);
    }
}
