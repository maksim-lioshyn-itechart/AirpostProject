using Dapper;
using DataAccessLayer.Interfaces;
using ORM;
using ORM.Attributes;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public abstract class BaseRepository<T>: IBaseOperationRepository<T> where T: BasicModel
    {
        public void Create(T entity)
        {
            var columnNames = typeof(T).GetColumnAttributeValue().ToList();
            string fields = string.Empty;
            string values = string.Empty;
            var lastColumn = columnNames.Last();
            foreach (var property in columnNames)
            {
                var value = entity.GetType().GetProperty(property.Name)?.GetValue(entity, null);
                if (value != null)
                {
                    if (lastColumn != property)
                    {
                        fields += $"{property.Name}, ";
                        values += $"'{value}', ";
                    }
                    else
                    {
                        fields += $"{property.Name}";
                        values += $"'{value}'";
                    }
                }
            }
            
            using IDbConnection db = new ApplicationContext().OpenConnection();
            var sqlQuery = $"INSERT INTO {TableName()} ({fields}) VALUES({values})";
            db.Execute(sqlQuery, entity);
        }

        public T GetById(Guid id)
        {
            using IDbConnection db = new ApplicationContext().OpenConnection();
            return db.Query<T>($"SELECT * FROM {TableName()} WHERE Id = '{id}'").FirstOrDefault();
        }

        public List<T> GetAll()
        {
            using IDbConnection db = new ApplicationContext().OpenConnection();
            return db.Query<T>($"SELECT * FROM {TableName()}").ToList();
        }

        public void Update(T entity)
        {
            using IDbConnection db = new ApplicationContext().OpenConnection();
            var columnNames = typeof(T).GetColumnAttributeValue().ToList();
            var sqlQuery = $"UPDATE {TableName()} SET ";
            foreach (var property in columnNames)
            {
                var value = entity.GetType().GetProperty(property.Name)?.GetValue(entity, null);

                if (value != null)
                {
                    sqlQuery += $"{property.Name} = '{value}', ";
                }
            }

            sqlQuery = sqlQuery.Substring(0,sqlQuery.Length - 2) + $" WHERE Id = '{entity.Id}'";
            db.Execute(sqlQuery, entity);
        }

        public void Delete(Guid id)
        {
            using IDbConnection db = new ApplicationContext().OpenConnection();
            var sqlQuery = $"DELETE FROM {TableName()} WHERE Id = '{id}'";
            db.Execute(sqlQuery, new { id });
        }

        private static string TableName() => typeof(T).GetTableAttributeValue((AirportTableAttribute att) => att.Name);
    }
}