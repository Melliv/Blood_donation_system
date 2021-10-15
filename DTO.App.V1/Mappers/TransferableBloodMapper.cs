using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DTO.App.V1.Mappers
{
    public class TransferableBloodMapper: BaseMapper<BLL.App.DTO.TransferableBlood, DTO.App.V1.TransferableBlood>, IBaseMapper<BLL.App.DTO.TransferableBlood, DTO.App.V1.TransferableBlood>
    {
        public TransferableBloodMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}