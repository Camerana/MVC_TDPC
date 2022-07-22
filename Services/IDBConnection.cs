using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_TDPC.Services
{
    public interface IDBConnection
    {
        string Connect();
    }

    public class SQLServerConnection : IDBConnection
    {
        public string Connect()
        {
            return "Sono connesso a SQL Server";
        }
    }
    public class PostgreSQLConnection : IDBConnection
    {
        public string Connect()
        {
            return "Sono connesso a Postgres";
        }
    }
}
