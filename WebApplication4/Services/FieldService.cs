
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication4.Dtos;
using WebApplication4.Models;
using WebApplication4.Models.Shared;

namespace WebApplication4.Services
{
    public class FieldService : IFieldService
    {
        IMemoryCache _cache;
        public FieldService(IMemoryCache cache)
        {
            _cache = cache;
        }

        List<Field> items = new List<Field>();       

        public async Task<FieldDto> GetFieldByIdAsync(int fieldId)
        {
            var field = await Task.Run(() => ((List<Field>)_cache.Get("items")).Find(i => i.Id == fieldId));

            if (field == null)
                throw new Exception($"Field with id: {fieldId} does not exist");

            var fieldDto = new FieldDto
            {
                Id = field.Id,
                CustomerId = field.CustomerId,
                Type = field.Type,
                UserId = field.UserId,
                Values = field.Values,
                Name = field.Name
            };

            return fieldDto;
        }

        public async Task<List<FieldDto>> GetFieldsAsync()
        {
            var fields = new List<FieldDto>();

            if (_cache.Get("items") != null)
                foreach (var field in await Task.Run(() => ((List<Field>)_cache.Get("items"))))
                {
                    fields.Add(new FieldDto
                    {
                        Id = field.Id,
                        CustomerId = field.CustomerId,
                        Type = field.Type,
                        UserId = field.UserId,
                        Values = field.Values,
                        Name = field.Name
                    });
                }

            return fields;
        }

        public async Task<List<FieldDto>> GetFieldsByCustomerIdAsync(int customerId)
        {
            var filteredList = new List<FieldDto>();

            if (_cache.Get("items") != null)
                foreach (var field in await Task.Run(() => ((List<Field>)_cache.Get("items"))))
                {
                    filteredList.Add(new FieldDto
                    {
                        Id = field.Id,
                        CustomerId = field.CustomerId == customerId ? field.CustomerId : 0,
                        Type = field.Type,
                        UserId = field.UserId,
                        Values = field.Values.Where(v => v.CustomerId == customerId).ToList(),
                        Name = field.Name
                    });
                }

            return filteredList;
        }

        public async Task<int> CreateFieldAsync(CreateFieldDto fieldDto, CancellationToken token)
        {
            var field = new Field(fieldDto.CustomerId, fieldDto.UserId, fieldDto.Values, fieldDto.Type, fieldDto.Name);

            field.Id = new Random().Next(1000000000);
            field.Audit = new Audit(DateTime.Now, null);

            return await Task.Run(() => (CreateField(field)));
        }

        public async Task<int> UpdateFieldAsync(UpdateFieldDto fieldDto, CancellationToken token)
        {
            var field = await Task.Run(()=> ((List<Field>)_cache.Get("items")).Find(i => i.Id == fieldDto.FieldId));

            if (field == null)
                throw new Exception($"Field with id: {fieldDto.FieldId} does not exist");

            field.EditDateTimes.Add(DateTime.Now);

            return field.Id;
        }

        public List<Field> getCachedFields()
        {
            return (List<Field>)_cache.Get("items");
        }

        private int CreateField(Field field)
        {
            if (_cache.Get("items") != null)
                items = (List<Field>)_cache.Get("items");

            items.Add(field);

            _cache.Set("items", items);

            return field.Id;
        }
    }
}
