using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.AccessLayers
{
    public class ListAccessLayer : AccessLayer
    {
        private List<Article> articles;

        public ListAccessLayer()
        {
            this.articles = new List<Article>()
            {
                //add fake data
                new Article()
                {
                    Id = 1,
                    Title = "car",
                    Description = "4x4",
                    Price = 5000.60
                },
                new Article()
                {
                    Id = 2,
                    Title = "pc",
                    Description = "work pc",
                    Price = 1500
                },
                new Article()
                {
                    Id = 3,
                    Title = "gum",
                    Description = "gum gum",
                    Price = 0.50
                },
            };
        }

        public override List<Article> Get()
        {
            return this.articles;
        }

        public override void Add(Article article)
        {
            base.Add(article);

            this.articles.Add(article);
        }

        public override void Update(Article article)
        {
            base.Update(article);

            foreach (Article a in this.articles)
            {
                if (a.Id != article.Id)
                    continue;

                a.Title = article.Title;
                a.Description = article.Description;
                a.Price = article.Price;
                return;
            }
        }

        public override void Delete(Article article)
        {
            //using FirstOrDefault returns null when no article was found
            //so the Remove function can ignore with no problems
            this.articles.Remove(this.articles.FirstOrDefault(a => a.Id == article.Id));
        }

        public override void Dispose()
        {
            this.articles = null;
            GC.SuppressFinalize(this);
        }
    }
}
