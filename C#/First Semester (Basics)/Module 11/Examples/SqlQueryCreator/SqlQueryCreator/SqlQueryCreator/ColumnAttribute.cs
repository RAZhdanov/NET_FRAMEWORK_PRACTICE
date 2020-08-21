using System;

namespace SqlQueryCreator
{
    // Создание собственного атрибута (который можно использовать для свойств и полей)
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(string columnName)
        {
            ColumnName = columnName ?? string.Empty;
        }

        public string ColumnName { get; } // Readonly property. C# 6
    }

}
