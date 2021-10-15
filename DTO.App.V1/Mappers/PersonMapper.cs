using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;using BLL.App.DTO;
using Contracts.DAL.Base.Mappers;

namespace DTO.App.V1.Mappers
{
    public class PersonMapper: BaseMapper<BLL.App.DTO.Person, DTO.App.V1.Person>, IBaseMapper<BLL.App.DTO.Person, DTO.App.V1.Person>
    {
        public PersonMapper(IMapper mapper) : base(mapper)
        {
        }

    }
}
