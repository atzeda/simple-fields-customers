
using System.Collections.Generic;
using WebApplication4.Models;

namespace WebApplication4.Dtos
{
    public class CreateFieldDto
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public List<FieldValue> Values { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
    }
}
