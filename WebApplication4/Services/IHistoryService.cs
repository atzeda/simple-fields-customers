using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication4.Dtos;

namespace WebApplication4.Services
{
    public interface IHistoryService
    {
        Task<List<HistoryDto>> GetHistoryAsync();
    }
}
