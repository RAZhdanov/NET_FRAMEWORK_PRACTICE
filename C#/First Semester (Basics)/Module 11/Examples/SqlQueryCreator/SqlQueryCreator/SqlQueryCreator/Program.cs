using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

// Демонстрация работы с атрибутами
// Пример строит SQL запросы для произвольных классов сущностей, получая название таблиц и колонок базы данных из специально созданных атрибутов
// Реально никто так SQL запросы не строит (как минимум нужно использовать SqlParameter). Пример приведен исключительно для демонстрации работы с атрибутами

namespace SqlQueryCreator
{
    class Program
    {
        // Метод строит SQL запрос (insert) на основе атрибутов
        static string CreateSqlInsertString(IEntity entity)
        {
            Type entityType = entity.GetType();
            if (entityType.IsDefined(typeof(TableAttribute))) // проверяем, помечен ли тип атрибутом TableAttribute
            {
                StringBuilder sqlQuery = new StringBuilder("insert into ");
                TableAttribute tableAttribute = (TableAttribute)Attribute.GetCustomAttribute(entityType, typeof(TableAttribute)); // получение конкретного атрибута у типа
                sqlQuery.AppendFormat("{0} (", tableAttribute.TableName);  // используем свойства самого атрибута
                List<string> columns = new List<string>();
                List<string> values = new List<string>();
                foreach (PropertyInfo property in entityType.GetProperties()) // По всем свойствам типа (используем Reflection)
                {
                    if (property.IsDefined(typeof(ColumnAttribute))) // проверяем, помечено ли свойство атрибутом ColumnAttribute
                    {
                        ColumnAttribute columnAttribute = (ColumnAttribute)Attribute.GetCustomAttribute(property, typeof(ColumnAttribute)); // получение атрибута ColumnAttribute у свойства
                        columns.Add(columnAttribute.ColumnName);
                        values.Add(string.Format("'{0}'", property.GetValue(entity).ToString())); // Конечно, формат строки должен зависеть от типа свойства, но для простоты, сделаем ToString() и возьмем в ''
                    }
                }
                sqlQuery.AppendFormat("{0}) values ({1});", string.Join(", ", columns), string.Join(", ", values));
                return sqlQuery.ToString();
            }
            return string.Empty;
        }

        static void Main()
        {
            Customer customer = new Customer { Id = 5, Name = "Петров И.И.", Address = "Деревня дедушки" };
            string customerSqlInsetString = CreateSqlInsertString(customer);
            Console.WriteLine(customerSqlInsetString);
            Console.WriteLine();

            Product product = new Product { Id = 123, Name = "Byke", Cost = 15000, Description = "Белая Крутотень" };
            string productSqlInsetString = CreateSqlInsertString(product);
            Console.WriteLine(productSqlInsetString);
            Console.WriteLine();

            Order o = new Order
            {
                Id = 27,
                Name = "Заказ первого покупателя",
                Date = DateTime.Now,
                CustomerId = 5,
                Customer = customer,
                Products = new Product[] { product }
            };
            string orderSqlInsetString = CreateSqlInsertString(o);
            Console.WriteLine(orderSqlInsetString);

            Console.ReadLine();
        }
    }
}
