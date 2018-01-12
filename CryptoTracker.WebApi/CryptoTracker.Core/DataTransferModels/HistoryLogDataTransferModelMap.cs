using CryptoTracker.Core.Models;

namespace CryptoTracker.Core.DataTransferModels
{
    public static class HistoryLogDataTransferModelMap
    {
        public static HistoryLogDataTransferModel ToDto(this HistoryLogModel entity)
        {
            return new HistoryLogDataTransferModel
            {
                Id =  entity.Id,
                Created = entity.Created,
                LastModified = entity.LastModified,
                LastModifiedBy = entity.LastModifiedBy,
                Rating = entity.Rating,
                Title = entity.Title,
                ParamKey = entity.ParamKey,
                ParamValue = entity.ParamValue
            };
        }

        public static HistoryLogModel ToModel(this HistoryLogDataTransferModel dto)
        {
            return new HistoryLogModel
            {
                Id = dto.Id,
                Created = dto.Created,
                LastModified = dto.LastModified,
                LastModifiedBy = dto.LastModifiedBy,
                Rating = dto.Rating,
                Title = dto.Title,
                ParamKey = dto.ParamKey,
                ParamValue = dto.ParamValue
            };
        }
    }
}
