
using System.Collections.Generic;
using WebApplication4.Models;


namespace WebApplication4.Dtos
{
    public class FieldDto
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public int Id { get; set; }
        public List<FieldValue> Values { get; set; } = new List<FieldValue>();
        public FieldType Type { get; set; }
        public string Name { get; set; }
    }
}
