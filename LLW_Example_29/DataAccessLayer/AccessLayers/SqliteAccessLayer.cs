using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DataAccessLayer.AccessLayers
{
    public class SqliteAccessLayer : AccessLayer
    {
        private readonly SQLiteConnection connection;

        public SqliteAccessLayer(string connectionString)
        {
            this.connection = new(connectionString);
            this.connection.Open();
        }

        public override List<Article> Get()
        {
            List<Article> articles = new List<Article>();

            SQLiteCommand cmd = new("select id, title, description, price from articles;", this.connection);

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    articles.Add(new Article()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        Title = reader["title"].ToString(),
                        Description = reader["description"].ToString(),
                        Price = double.Parse(reader["price"].ToString())
                    });
                }
            }

            return articles;
        }

        public override void Add(Article article)
        {
            base.Add(article);

            SQLiteCommand cmd = new("insert into articles (id, title, description, price) values (@ID, @TITLE, @DESC, @PRICE);", this.connection);

            //avoid sql injection
            cmd.Parameters.AddWithValue("@ID", article.Id);
            cmd.Parameters.AddWithValue("@TITLE", article.Title);
            cmd.Parameters.AddWithValue("@DESC", article.Description);
            cmd.Parameters.AddWithValue("@PRICE", article.Price);

            cmd.ExecuteNonQuery();
        }

        public override void Update(Article article)
        {
            base.Update(article);

            SQLiteCommand cmd = new("update articles set title = @TITLE, description = @DESC, price = @PRICE where id = @ID;", this.connection);

            //avoid sql injection
            cmd.Parameters.AddWithValue("@ID", article.Id);
            cmd.Parameters.AddWithValue("@TITLE", article.Title);
            cmd.Parameters.AddWithValue("@DESC", article.Description);
            cmd.Parameters.AddWithValue("@PRICE", article.Price);

            cmd.ExecuteNonQuery();
        }

        public override void Delete(Article article)
        {
            SQLiteCommand cmd = new("delete from articles where id = @ID", this.connection);

            //avoid sql injection
            cmd.Parameters.AddWithValue("@ID", article.Id);

            cmd.ExecuteNonQuery();
        }

        public override void Dispose()
        {
            if (this.connection is not null)
            {
                if (this.connection.State == System.Data.ConnectionState.Open)
                    this.connection.Close();
                this.connection.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
