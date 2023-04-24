using Core.Entites;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenricRepo<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int Id);
        Task<IReadOnlyList<T>>ListAllAsync();
        Task<T> GetByFilterAsync(IHelpers<T> Help);
        Task<IReadOnlyList<T>> listAllByFilterAsync(IHelpers<T> Help);

        Task<int> GetCountAsync(IHelpers<T> Help);
    }
}
