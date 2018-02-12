using CryptoTracker.Core.Models;

namespace CryptoTracker.Core.DataTransferModels
{
    public static class PortfolioDataTransferModelMapper
    {
        public static PortfolioDataTransferModel ToDto(this PortfolioModel entity)
        {
            return new PortfolioDataTransferModel
            {
                Id= entity.Id,
                Created = entity.Created,
                LastModified = entity.LastModified,
                Description = entity.Description,
                IsPrivate = entity.IsPrivate,
                IsShared = entity.IsShared,
                LastModifiedBy = entity.LastModifiedBy,
                Rating = entity.Rating,
                Title = entity.Title,
                UserId = entity.UserId
            };
        }

        public static PortfolioModel ToModel(this PortfolioDataTransferModel dto)
        {
            return new PortfolioModel
            {
                Id = dto.Id,
                Created = dto.Created,
                LastModified = dto.LastModified,
                Description = dto.Description,
                IsPrivate = dto.IsPrivate,
                IsShared = dto.IsShared,
                LastModifiedBy = dto.LastModifiedBy,
                Rating = dto.Rating,
                Title = dto.Title,
                UserId = dto.UserId                
            };
        }
    }
}
