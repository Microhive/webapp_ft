using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class ArticleQuery
    {
        public readonly AppDb Db;
        public ArticleQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Article> GetOne(int id)
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `articles` WHERE `id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.UInt32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<Article>> GetAll()
        {
            var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `articles`";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        private async Task<List<Article>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<Article>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new Article
                    {
                        Id = await reader.GetFieldValueAsync<uint>(0),
                        Name = await reader.GetFieldValueAsync<string>(1),
                        Description = await reader.GetFieldValueAsync<string>(2),
                        Cost = await reader.GetFieldValueAsync<float>(3),
                        BitCoinAddress = await reader.GetFieldValueAsync<string>(4)
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}
