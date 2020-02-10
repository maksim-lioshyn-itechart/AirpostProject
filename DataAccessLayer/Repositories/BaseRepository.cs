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
    public abstract class BaseRepository<T>: IBaseRepository<T> where T: BasicModel
    {
        internal readonly IUnitOfWork UnitOfWork;

        internal BaseRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Create(T entity)
        {
            var columnNames = typeof(T).GetColumnAttributeValue().ToList();
            string fields = string.Empty;
            string values = string.Empty;
            var lastColumn = columnNames.Last();
            foreach (var property in columnNames)
            {
                var value = entity.GetType().GetProperty(property.Name)?.GetValue(entity, null);

                fields += $"{property.Name}";
                values += $"'{value}'";

                if (lastColumn != property)
                {
                    fields += ", ";
                    values += ", ";
                }
            }

            UnitOfWork.Saving($"INSERT INTO {TableName()} ({fields}) VALUES({values})");
        }

        public T GetById(Guid id)
        {
            using IDbConnection db = new ApplicationContext().OpenConnection();
            return db.Query<T>($"SELECT * FROM {TableName()} WHERE Id = '{id}'").FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            using IDbConnection db = new ApplicationContext().OpenConnection();
            return db.Query<T>($"SELECT * FROM {TableName()}");
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

            UnitOfWork.Saving(sqlQuery.Substring(0, sqlQuery.Length - 2) + $" WHERE Id = '{entity.Id}'");
        }

        public void Delete(Guid id)
        {
            UnitOfWork.Saving($"DELETE FROM {TableName()} WHERE Id = '{id}'");
        }

        public static string TableName() => typeof(T).GetTableAttributeValue((AirportTableAttribute att) => att.Name);
    }
}