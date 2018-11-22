using System;
using MySql.Data.MySqlClient;

namespace WebApplication1
{
    public class AppDb : IDisposable
    {
        public MySqlConnection Connection;

        public AppDb()
        {
            Connection = new MySqlConnection("Server=35.189.82.169;Uid=loodse;Pwd=Password123;port=80;Database=loodse;");
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
