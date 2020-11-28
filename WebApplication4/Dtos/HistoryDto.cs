
using System;
using System.Collections.Generic;

namespace WebApplication4.Dtos
{
    public class HistoryDto
    {
        public int FieldId { get; set; }
        public DateTime DateCreated { get; set; }
        public List<DateTime> DatesModified { get; set; }
    }
}
