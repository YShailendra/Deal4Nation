using Products.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Products.Repository.Image
{
    public interface IImageRepository: IBaseRepository<ImageModel>
    {
        Task<IEnumerable<ImageModel>> GetImagesByIds(List<Guid> imageIds);
    }
}