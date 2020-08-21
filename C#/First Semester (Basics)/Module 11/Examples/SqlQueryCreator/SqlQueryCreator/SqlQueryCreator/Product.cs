namespace SqlQueryCreator
{
    [Table("Products")]
    class Product : IEntity
    {
        [Column("ProductID")]
        public int Id { get; set; }

        [Column("ProductName")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Cost")]
        public decimal Cost { get; set; }
    }
}
