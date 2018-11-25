using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Services
{
    public class DbParameter
    {
        public SqlParameter ToSql { get; set; }
        public DbParameter(string name, object value)
        {
            ToSql = new SqlParameter(name, value);
        }

        public DbParameter(string name, object value, DbType type)
        {
            ToSql = new SqlParameter(name, value);
            ToSql.DbType = type;
        }
        public DbParameter(string name, object value, string type, ParameterDirection direction)
        {
            ToSql = new SqlParameter(name, value);
            ToSql.Direction = direction;
            ToSql.TypeName = type;
        }

        public DbParameter(string name, object value, ParameterDirection direction)
        {
            ToSql = new SqlParameter(name, value);
            ToSql.Direction = direction;
        }

        public DbParameter(string name, object value, int Size, ParameterDirection direction)
        {
            ToSql = new SqlParameter(name, value);
            ToSql.Direction = direction;
            ToSql.Size = Size;
        }
        public DbParameter(string name, object value, int Size)
        {
            ToSql = new SqlParameter(name, value);
            ToSql.Size = Size;
        }
    }

}
