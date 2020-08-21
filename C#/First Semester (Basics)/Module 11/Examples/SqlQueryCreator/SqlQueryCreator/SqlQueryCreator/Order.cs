using System;

namespace SqlQueryCreator
{
    [Table("Orders")]
    class Order : IEntity
    {
        [Column("OrderID")]
        public int Id { get; set; }

        [Column("OrderName")]
        public string Name { get; set; }

        [Column("OrderDate")]
        public DateTime Date { get; set; }

        [ColumnAttribute("CustomerID")] // а можно суффикс Attribute не опускать, но обычно опускают
        public int CustomerId { get; set; }

        public Customer Customer { get; set; } // Непомечен атрибутом и будет игнорироваться при построении SQL запроса

        public Product[] Products { get; set; }  // Непомечен атрибутом и будет игнорироваться при построении SQL запроса
    }
}
