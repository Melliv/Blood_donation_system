using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class TransferableBloodMapper: BaseMapper<BLL.App.DTO.TransferableBlood, DAL.App.DTO.TransferableBlood>, IBaseMapper<BLL.App.DTO.TransferableBlood, DAL.App.DTO.TransferableBlood>
    {
        public TransferableBloodMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}