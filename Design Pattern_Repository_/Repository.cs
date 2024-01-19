using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.ObjectModel;
using System.Data.Common;

namespace Design_Pattern_Repository_
{
    class Repository<T> : IRepository<T> where T : new()
    {
        private readonly SqlConnection connection;
        private readonly string tableName = $"[{typeof(T).Name}s]";
        
        public Repository()
        {
            var connectionString = @"Data Source = PC; Initial Catalog = WorkWithC#;Integrated Security=True;";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        public void Add(T entity)
        {
            var properties = typeof(T)
                .GetProperties()
                .Where(x => x.Name != "Id");

            var propertyNames = properties.Select(x => x.Name);
            var columnNames = string.Join(",", propertyNames);
            var parametrNames = string.Join(",", propertyNames.Select(_ => $"@{_}"));

            var commandText = $"Insert Into {tableName} ({columnNames}) Values ({parametrNames})";
            var command = GetCommand(commandText);

            foreach (var property in properties)
            {
                command.Parameters.AddWithValue(property.Name, property.GetValue(entity));
            }

            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            var commandText = $"DELETE From {tableName} Where Id = @id";
            var command = GetCommand(commandText);
            command.Parameters.AddWithValue("id",id);
            command.ExecuteNonQuery();
        }

        public IEnumerable<T> Get()
        {
            var results = new List<T>();

            var commandText = $"Select * From {tableName}";
            var command = GetCommand(commandText);

            using (var reader = command.ExecuteReader())
            {

                var schema = reader.GetColumnSchema();
                while(reader.Read())
                {
                    results.Add(CreateObject(reader, schema));
                }

                return results;
            }

        }

        public T Get(int id)
        {
            var commandText = $"Select * From {tableName} Where Id = @id";
            var command = GetCommand(commandText);
            command.Parameters.AddWithValue("id", id);

            using (var reader = command.ExecuteReader())
            {
                var schema = reader.GetColumnSchema();
                if (!reader.Read())
                {
                    return default(T);
                }

                return CreateObject(reader, schema);
            }
        }

        public void Update(T entity)
        {
            var properties = typeof(T).GetProperties();

            var propertyNames = properties
                .Where(x => x.Name != "Id")
                .Select(x => x.Name);

            var setPropertyString = propertyNames
                .Select(x => $"{x} = @{x}");
            var setProperties = string.Join(",", setPropertyString);

            var commandText = $"Update {tableName} Set {setProperties} Where Id = @Id";
            var command = GetCommand(commandText);

            foreach(var property in properties) 
            {
                command.Parameters.AddWithValue(property.Name, property.GetValue(entity));
            }

            command.ExecuteNonQuery();
        }

        protected T CreateObject(SqlDataReader reader, ReadOnlyCollection<DbColumn> schema)
        {
            var result = new T();

            for (int columnCount = 0; columnCount < schema.Count; columnCount++)
            {
                var columnName = schema[columnCount].ColumnName;
                var columnType = schema[columnCount].DataType;
                var columnValue = reader[columnCount];

                var value = Convert.ChangeType(columnValue, columnType);

                var property = typeof(T)
                    .GetProperties()
                    .FirstOrDefault(p => p.Name == columnName);

                if(property?.PropertyType == columnType)
                {
                    property.SetValue(result, value);
                }
            }

            return result;
        }

        private SqlCommand GetCommand(string command)
        {
            return new SqlCommand(command, connection);
        }
    }
}
