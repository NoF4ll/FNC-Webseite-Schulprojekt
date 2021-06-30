using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjekt_Beispiel.Models.db
{

    interface IRepositoryArticle
    {
        void Open();

        void Close();

        Article getArticleById(int ArticleId);

        List<Article> GetAllReturnedArticles();

        List<Article> GetAllArticles();

        List<Registration> GetAllUsers();

        List<Comment> GetAllComments();

        bool Insert(Article article);

        bool InsertComment(Comment comment);
        bool Delete(int articleId);
        bool Update(int articleId, Article newArticleData);

        bool InsertUser(Registration user);

        bool loginInsert(String user, String password);


    }
}
