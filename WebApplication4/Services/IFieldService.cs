using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication4.Dtos;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public interface IFieldService
    {
        Task<FieldDto> GetFieldByIdAsync(int fieldId);
        Task<List<FieldDto>> GetFieldsAsync();
        Task<List<FieldDto>> GetFieldsByCustomerIdAsync(int customerId);
        List<Field> getCachedFields(); // used for gettting the cached fields - not the best practice 
        Task<int> CreateFieldAsync(CreateFieldDto fieldDto, CancellationToken token);
        Task<int> UpdateFieldAsync(UpdateFieldDto fieldDto, CancellationToken token);
    }
}
