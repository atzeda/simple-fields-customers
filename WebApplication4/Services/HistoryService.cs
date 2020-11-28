using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Dtos;

namespace WebApplication4.Services
{
    public class HistoryService : IHistoryService
    {

        IFieldService _fieldService;

        public HistoryService(IFieldService fieldService) {

            _fieldService = fieldService;        
        }

        public async Task<List<HistoryDto>> GetHistoryAsync()
        {
            var history = new List<HistoryDto>();

            var fields = await Task.Run(() => _fieldService.getCachedFields());            

            foreach (var field in fields) {

                history.Add(new HistoryDto
                {
                    FieldId = field.Id,
                    DateCreated = field.Audit.DateCreated,
                    DatesModified = field.EditDateTimes
                });             
            }

            return history;
        }
    }
}
