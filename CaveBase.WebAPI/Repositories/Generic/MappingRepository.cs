using AutoMapper;
using CaveBase.Library.Models;
using CaveBase.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaveBase.WebAPI.Repositories.Generic
{
    public class MappingRepository<T> : Repository<T> where T : EntityBase
    {
        protected readonly IMapper mapper;

        public MappingRepository(CaveServiceContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }
    }
}
