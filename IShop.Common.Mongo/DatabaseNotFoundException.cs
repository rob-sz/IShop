using System;

namespace IShop.Common.Mongo
{
    public class DatabaseNotFoundException : Exception
    {
        public string DatabaseName { get; set; }

        public DatabaseNotFoundException(string databaseName)
            : this(string.Empty, databaseName)
        {
        }

        public DatabaseNotFoundException(string message, string databaseName)
            : base(message)
        {
            DatabaseName = databaseName;
        }
    }
}
