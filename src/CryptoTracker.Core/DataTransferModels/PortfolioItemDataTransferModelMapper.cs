using CryptoTracker.Core.Models;

namespace CryptoTracker.Core.DataTransferModels
{
    public static class PortfolioItemDataTransferModelMapper
    {
        public static PortfolioItemDataTransferModel ToDto(this PortfolioItemModel entity)
        {
            return new PortfolioItemDataTransferModel
            {
                Id = entity.Id,
                Created = entity.Created,
                LastModified = entity.LastModified,
                LastModifiedBy = entity.LastModifiedBy,
                Rating = entity.Rating,
                Title = entity.Title
            };
        }

        public static PortfolioItemModel ToModel(this PortfolioItemDataTransferModel dto)
        {
            return new PortfolioItemModel
            {
                Id = dto.Id,
                Created = dto.Created,
                LastModified = dto.LastModified,
                LastModifiedBy = dto.LastModifiedBy,
                Rating = dto.Rating,
                Title = dto.Title
            };
        }
    }
}
