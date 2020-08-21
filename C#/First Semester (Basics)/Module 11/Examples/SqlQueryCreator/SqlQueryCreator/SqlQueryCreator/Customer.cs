namespace SqlQueryCreator
{
    // Использование атрибутов (суффикс Attribute можно опустить)
    [Table("Customers")]
    public class Customer : IEntity
    {
        [Column("CustomerID")]
        public int Id { get; set; }

        [ColumnAttribute("CustomerName")] // а можно суффикс Attribute не опускать, но обычно опускают
        public string Name { get; set; }

        [Column("CustomerAddress")]
        public string Address { get; set; }
    }
}
