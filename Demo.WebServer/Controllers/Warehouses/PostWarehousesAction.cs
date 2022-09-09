﻿using AutoMapper;
using Demo.Contracts.Dtos;
using Demo.DAL.Actions;
using Demo.DAL.Interfaces;
using Demo.WebServer.Entities;

namespace Demo.WebServer.Controllers.Warehouses
{
    public class PostWarehousesAction : DatabaseAction
    {
        public PostWarehousesAction(IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IMapper Mapper { get; }

        public async Task ExecuteAsync(IEnumerable<WarehouseDto> warehouseDtos)
        {
            using (var uow = UnitOfWorkFactory.Invoke())
            {
                var warehouses = Mapper.Map<List<Warehouse>>(warehouseDtos);
                await uow.Repository<Warehouse>().AddAsync(warehouses);
                await uow.CommitAsync();
            }
        }
    }
}
