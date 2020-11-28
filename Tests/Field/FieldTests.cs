using System;
using System.Collections.Generic;
using WebApplication4.Models;
using Xunit;

namespace Tests
{
    public class FieldTests
    {
        #region Construction

        [Fact]
        public void Construction_WithCorrectValues_AssignsPropertiesCorrectly()
        {
            //arrange
            var customerId = 1;
            var userId = 1;
            var values = new List<FieldValue> { new FieldValue { CustomerId = 1, Value = "val" } };
            var name = "a name";
            var type = (int)FieldType.Textbox;

            //act
            var field = new Field(customerId, userId, values, type, name);

            //assert
            Assert.Equal(1, field.CustomerId);
            Assert.Equal(1, field.UserId);
            Assert.Equal(values, field.Values);
            Assert.Equal("a name", field.Name);
            Assert.Equal(FieldType.Textbox, field.Type);
        }

        [Fact]
        public void Construction_WithNullOrWhitespaceName_ThrowsArgumentNullException()
        {
            //arrange
            var customerId = 1;
            var userId = 1;
            var values = new List<FieldValue> { new FieldValue { CustomerId = 1, Value = "val" } };
            var type = (int)FieldType.Textbox;

            //act 
            var exception = Assert.Throws<ArgumentNullException>(delegate
            {
                new Field(customerId, userId, values, type, null);
            });

            //assert            
            Assert.Equal($"Value cannot be null. (Parameter 'Field: Name')", exception.Message);
        }
        #endregion
    }
}
