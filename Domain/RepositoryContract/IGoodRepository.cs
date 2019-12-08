using Domain.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryContract
{
    public interface IGoodRepository
    {
        Task<IEnumerable<Good>> GetAllGoods();
    }
}
