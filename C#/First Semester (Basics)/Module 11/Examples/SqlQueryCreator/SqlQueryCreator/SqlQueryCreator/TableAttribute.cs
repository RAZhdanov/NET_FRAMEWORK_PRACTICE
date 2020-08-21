using System;

namespace SqlQueryCreator
{
    // Создание собственного атрибута (который можно использовать только для класса)
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public TableAttribute(string tableName)
        {
            TableName = tableName ?? string.Empty;
        }

        public string TableName { get; } // Readonly property. C# 6
    }
}
