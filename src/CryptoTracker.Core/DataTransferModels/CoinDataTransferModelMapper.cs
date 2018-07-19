using CryptoTracker.Core.Models;

namespace CryptoTracker.Core.DataTransferModels
{
    public static class CoinDataTransferModelMapper
    {
        public static CoinDataTransferModel ToDto(this CoinModel entity)
        {
            return new CoinDataTransferModel
            {
                Id = entity.Id,
                Created = entity.Created,
                LastModified = entity.LastModified,
                LastModifiedBy = entity.LastModifiedBy,
                Rating = entity.Rating,
                Title = entity.Title,
                Tag = entity.Tag
            };
        }

        public static CoinModel ToModel(this CoinDataTransferModel dto)
        {
            return new CoinModel
            {
                Id = dto.Id,
                Created = dto.Created,
                LastModified = dto.LastModified,
                LastModifiedBy = dto.LastModifiedBy,
                Rating = dto.Rating,
                Title = dto.Title,
                Tag = dto.Tag
            };
        }
    }
}
