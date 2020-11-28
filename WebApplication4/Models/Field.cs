
using System;
using System.Collections.Generic;
using WebApplication4.Models.Shared;
using WebApplication4.Validations;

namespace WebApplication4.Models
{
    public class Field: Entity
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public List<FieldValue> Values { get; set; } = new List<FieldValue>();
        public string Name { get; set; }
        public FieldType Type { get; set; }
        public List<DateTime> EditDateTimes { get; set; } = new List<DateTime>();

        public Field(int customerId, int userId, List<FieldValue> values, int type, string name) {

            Validate.IntegerGreaterThanOrEqualToZero(customerId, "Field: CustomerId");
            Validate.IntegerGreaterThanOrEqualToZero(userId, "Field: UserId");
            Validate.NotEmpty(values, "Field: Values");
            Validate.IntegerGreaterThanOrEqualToZero(type, "Field: Type");
            Validate.NotNullOrWhitespace(name, "Field: Name");

            CustomerId = customerId;
            UserId = userId;
            Type = (FieldType)Enum.ToObject(typeof(FieldType), type);
            Values = values;
            Name = name;
        }
    }
}
