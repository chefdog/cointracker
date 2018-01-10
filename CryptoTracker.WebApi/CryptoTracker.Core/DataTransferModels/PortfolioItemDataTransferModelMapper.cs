using System;
using System.Collections.Generic;
using System.Text;
using CryptoTracker.Core.Models;

namespace CryptoTracker.Core.DataTransferModels
{
    public static class PortfolioItemDataTransferModelMapper
    {
        public static PortfolioItemDataTransferModel ToDto(this PortfolioItemModel entity)
        {
            return new PortfolioItemDataTransferModel
            {
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
                Created = dto.Created,
                LastModified = dto.LastModified,
                LastModifiedBy = dto.LastModifiedBy,
                Rating = dto.Rating,
                Title = dto.Title,
            };
        }
    }
}
