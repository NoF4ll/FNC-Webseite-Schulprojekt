using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjekt_Beispiel.Models.db
{

        public class RepositoryArticle : IRepositoryArticle
        {
        private string connectionString = "server=localhost;database=db_onlineshop;user=root;pwd=bichl601";

        private MySqlConnection conn = null;

        public void Open()
        {
            if (this.conn == null)
            {
                this.conn = new MySqlConnection(this.connectionString);
            }
            if (this.conn.State != ConnectionState.Open)
            {
                this.conn.Open();
            }
        }
        public void Close()
        {

            if ((this.conn != null) && (this.conn.State == ConnectionState.Open))
            {
                this.conn.Close();
            }
        }

        public bool Delete(int articleId)
        {
            if (this.conn.State == ConnectionState.Open)
            {
                DbCommand cmdDelete = this.conn.CreateCommand();
                cmdDelete.CommandText = "delete from returned_articles where article_id = " + articleId;

                return cmdDelete.ExecuteNonQuery() == 1;
            }
            throw new Exception("Verbindung zur DB ist nicht geöffnet!");
        }

        public List<Article> GetAllReturnedArticles()
        {

            if (this.conn.State == ConnectionState.Open)
            {
                List<Article> articles = new List<Article>();


                DbCommand cmdSelect = this.conn.CreateCommand();

                cmdSelect.CommandText = "select * from returned_articles order by article_id";

                using (DbDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        articles.Add(new Article
                        {

                            ArticleId = Convert.ToInt32(reader["article_id"]),
                            Firstname = Convert.ToString(reader["firstname"]),
                            Lastname = Convert.ToString(reader["lastname"]),
                            Articlename = Convert.ToString(reader["articlename"]),
                            Reason = Convert.ToString(reader["reason"]),
                        });
                    }

                }   

                if (articles.Count == 0)
                {
                    return null;
                }

                return articles;
            }

            throw new Exception("Datebank: Verbindung ist nicht geöffnet!");
        }
        
        public List<Article> GetAllArticles()
        {
            if (this.conn.State == ConnectionState.Open)
            {
                List<Article> articles = new List<Article>();


                DbCommand cmdSelect = this.conn.CreateCommand();

                cmdSelect.CommandText = "select * from articles order by id";

                using (DbDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        articles.Add(new Article
                        {

                            ArticleId = Convert.ToInt32(reader["id"]),
                            Articlename = Convert.ToString(reader["articlename"]),
                            Description = Convert.ToString(reader["description"]),
                            Price = Convert.ToDouble(reader["price"]),
                            ImagePath = Convert.ToString(reader["imagePath"]),
                            ReleaseDate = Convert.ToDateTime(reader["releaseDate"]),
                        });
                    }

                }

                if (articles.Count == 0)
                {
                    return null;
                }

                return articles;
            }

            throw new Exception("Datebank: Verbindung ist nicht geöffnet!");
        }

        public List<Registration> GetAllUsers()
        {

            if (this.conn.State == ConnectionState.Open)
            {
                List<Registration> users = new List<Registration>();


                DbCommand cmdSelect = this.conn.CreateCommand();

                cmdSelect.CommandText = "select * from user";

                using (DbDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new Registration
                        {

                            username = Convert.ToString(reader["username"]),
                            password = Convert.ToString(reader["password"]),
                            
                        });
                    }

                }

                if (users.Count == 0)
                {
                    return null;
                }

                return users;
            }

            throw new Exception("Datebank: Verbindung ist nicht geöffnet!");
        }

       

        public List<Comment> GetAllComments()
        {

            if (this.conn.State == ConnectionState.Open)
            {
                List<Comment> comments = new List<Comment>();


                DbCommand cmdSelect = this.conn.CreateCommand();

                cmdSelect.CommandText = "select * from comments order by date desc";

                using (DbDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comments.Add(new Comment
                        {
                            Text = Convert.ToString(reader["text"]),
                            Creator = Convert.ToString(reader["creator"]),
                            Rating = Convert.ToInt32(reader["rating"]),
                            Date = Convert.ToDateTime(reader["date"]),
                            ImagePath = Convert.ToString(reader["imagePath"])
                        }); 
                    }

                }

                if (comments.Count == 0)
                {
                    return null;
                }

                return comments;
            }

            throw new Exception("Datebank: Verbindung ist nicht geöffnet!");
        }



        public Article getArticleById(int ArticleId)
        {
            if (this.conn.State == ConnectionState.Open)
            {
                Article articles = new Article();


                DbCommand cmdSelect = this.conn.CreateCommand();

                cmdSelect.CommandText = "select * from returned_articles where article_id =" + ArticleId;

                using (DbDataReader reader = cmdSelect.ExecuteReader())
                {
                    reader.Read();
                    articles.ArticleId = Convert.ToInt32(reader["article_id"]);
                    articles.Firstname = Convert.ToString(reader["firstname"]);
                    articles.Lastname = Convert.ToString(reader["lastname"]);
                    articles.Articlename = Convert.ToString(reader["articlename"]);
                    articles.Reason = Convert.ToString(reader["reason"]);
                }



                return articles;
            }

            throw new Exception("Datebank: Verbindung ist nicht geöffnet!");
        }

        public bool Insert(Article article)
        {
            if (article == null)
            {
                return false;
            }
            if (this.conn.State != ConnectionState.Open)
            {
                return false;
            }
           
                DbCommand cmdInsert = this.conn.CreateCommand();

                cmdInsert.CommandText = "insert into returned_articles values(null,@firstname,@lastname,@articlename,@reason);";

                DbParameter paramFirstname = cmdInsert.CreateParameter();
                paramFirstname.ParameterName = "firstname";
                paramFirstname.DbType = DbType.String;
                paramFirstname.Value = article.Firstname;

                DbParameter paramLastname = cmdInsert.CreateParameter();
                paramLastname.ParameterName = "Lastname";
                paramLastname.DbType = DbType.String;
                paramLastname.Value = article.Lastname;

                DbParameter paramArticlename = cmdInsert.CreateParameter();
                paramArticlename.ParameterName = "articlename";
                paramArticlename.DbType = DbType.String;
                paramArticlename.Value = article.Articlename;

                DbParameter paramReason= cmdInsert.CreateParameter();
                paramReason.ParameterName = "reason";
                paramReason.DbType = DbType.String;
                paramReason.Value = article.Reason;



                cmdInsert.Parameters.Add(paramFirstname);
                cmdInsert.Parameters.Add(paramLastname);
                cmdInsert.Parameters.Add(paramArticlename);
                cmdInsert.Parameters.Add(paramReason);
;
                return cmdInsert.ExecuteNonQuery() == 1;
            
        }
        public bool InsertComment(Comment comment)
        {
            if (comment == null)
            {
                return false;
            }
            if (this.conn.State != ConnectionState.Open)
            {
                return false;
            }

            DbCommand cmdInsert = this.conn.CreateCommand();

            cmdInsert.CommandText = "insert into comments values(@text,@creator,@rating,@date,@imagePath);";

            DbParameter pText = cmdInsert.CreateParameter();
            pText.ParameterName = "text";
            pText.DbType = DbType.String;
            pText.Value = comment.Text;

            DbParameter pCreator = cmdInsert.CreateParameter();
            pCreator.ParameterName = "creator";
            pCreator.DbType = DbType.String;
            pCreator.Value = comment.Creator;

            DbParameter pRating = cmdInsert.CreateParameter();
            pRating.ParameterName = "rating";
            pRating.DbType = DbType.Int32;
            pRating.Value = comment.Rating;

            DbParameter pDate = cmdInsert.CreateParameter();
            pDate.ParameterName = "date";
            pDate.DbType = DbType.DateTime;
            pDate.Value = DateTime.Now;

            DbParameter pImagePath = cmdInsert.CreateParameter();
            pImagePath.ParameterName = "imagePath";
            pImagePath.DbType = DbType.String;
            pImagePath.Value = comment.ImagePath;

            cmdInsert.Parameters.Add(pText);
            cmdInsert.Parameters.Add(pCreator);
            cmdInsert.Parameters.Add(pRating);
            cmdInsert.Parameters.Add(pDate);
            cmdInsert.Parameters.Add(pImagePath);
            return cmdInsert.ExecuteNonQuery() == 1;

        }
        public bool Update(int articleId, Article newArticleData)
        {
            if (newArticleData == null)
            {
                return false;
            }
            if (this.conn.State != ConnectionState.Open)
            {
                return false;
            }
            return false;
        }

        public bool InsertUser(Registration user)
        {
            if(user == null)
            {
                return false;
            }
            if (this.conn.State != ConnectionState.Open)
            {
                return false;
            }
            DbCommand cmdInsert = this.conn.CreateCommand();

            cmdInsert.CommandText = "insert into user values(@username,@password);";

            DbParameter paramUsername = cmdInsert.CreateParameter();
            paramUsername.ParameterName = "username";
            paramUsername.DbType = DbType.String;
            paramUsername.Value = user.username;

            DbParameter paramPassword = cmdInsert.CreateParameter();
            paramPassword.ParameterName = "password";
            paramPassword.DbType = DbType.String;
            paramPassword.Value = user.password;

            cmdInsert.Parameters.Add(paramUsername);
            cmdInsert.Parameters.Add(paramPassword);

            return cmdInsert.ExecuteNonQuery() == 1;
        }

        MySqlDataReader dr;
        public bool loginInsert(string username, string password)
        {
            if (this.conn.State != ConnectionState.Open)
            {
                return false;
            }


            MySqlCommand loginle = this.conn.CreateCommand();
            MySqlParameter parambenutzername = loginle.CreateParameter();

            loginle.CommandText = "select * from user where username=@username and password=@password;";

            parambenutzername.ParameterName = "username";
            parambenutzername.DbType = DbType.String;
            parambenutzername.Value = username;

            MySqlParameter parampassword = loginle.CreateParameter();
            parampassword.ParameterName = "password";
            parampassword.DbType = DbType.String;
            parampassword.Value = password;

            loginle.Parameters.Add(parambenutzername);
            loginle.Parameters.Add(parampassword);

            dr = loginle.ExecuteReader();
            if (dr.Read())
            {
                return true;
            }
            return false;

        }
    }
}
