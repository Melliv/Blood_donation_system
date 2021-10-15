using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class TransferableBloodMapper : BaseMapper<DAL.App.DTO.TransferableBlood, Domain.App.TransferableBlood>,  IBaseMapper<DAL.App.DTO.TransferableBlood, Domain.App.TransferableBlood>
    {
        public TransferableBloodMapper(IMapper mapper) : base(mapper)
        {
        }

    }
}