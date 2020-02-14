using System;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace TransformConsoleApp
{
    public class Converter
    {
        public string ToInsertConvert(Type tClass)
        {
            var builder = new StringBuilder();
            builder.Append($"public const string insert{tClass.Name} =@\"INSERT INTO {tClass.Name}s (");
            var propertyInfos = tClass.GetProperties();
            
            foreach (var propertyInfo in propertyInfos)
            {
                builder.Append($"{propertyInfo.Name},");
            }

            builder.Remove(builder.Length - 1, 1);
            builder.Append(") VALUES (");

            foreach (var propertyInfo in propertyInfos)
            {
                builder.Append($"@{propertyInfo.Name},");
            }
            
            builder.Remove(builder.Length - 1, 1);
            builder.Append(")\"");
            return builder.ToString();
        }

        public string ToUpdateConvert(Type tClass)
        {
            var builder = new StringBuilder();
            builder.Append($"UPDATE {tClass.Name}s (");
            var propertyInfos = tClass.GetProperties();

            foreach (var propertyInfo in propertyInfos)
            {
                builder.Append($"{propertyInfo.Name} = @{propertyInfo.Name},");
            }

            builder.Remove(builder.Length - 1, 1);
            builder.Append(" WHERE Id = @Id");

            return builder.ToString();
        }
    }
}
