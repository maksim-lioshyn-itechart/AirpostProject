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
        private readonly IUnitOfWork _unitOfWork;

        internal BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

            _unitOfWork.Saving($"INSERT INTO {TableName()} ({fields}) VALUES({values})");
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

            _unitOfWork.Saving(sqlQuery.Substring(0, sqlQuery.Length - 2) + $" WHERE Id = '{entity.Id}'");
        }

        public void Delete(Guid id)
        {
            _unitOfWork.Saving($"DELETE FROM {TableName()} WHERE Id = '{id}'");
        }

        private static string TableName() => typeof(T).GetTableAttributeValue((AirportTableAttribute att) => att.Name);
    }
}