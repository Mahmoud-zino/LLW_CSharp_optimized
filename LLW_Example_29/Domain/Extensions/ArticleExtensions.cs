using Domain.Exceptions;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Extensions
{
    public static class ArticleExtensions
    {
        //convert & Validate Extension Methods
        public static int ConvertStringIdToInt(this string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new EmptyIdException();

            if (!int.TryParse(id, out int res))
                throw new InvalidIdException();

            return res;
        }

        public static double ConvertStringPriceToDouble(this string price)
        {
            if (string.IsNullOrEmpty(price))
                throw new EmptyPriceException();

            if (!double.TryParse(price, out double res))
                throw new InvalidPriceException();

            return res;
        }

        private static Article ValidateId(this Article article, List<Article> articles)
        {
            if (articles.Any(a => a.Id == article.Id))
                throw new DuplicateIdException();

            return article;
        }

        private static Article ValidateTitle(this Article article)
        {
            if (string.IsNullOrEmpty(article.Title))
                throw new EmptyTitleException();

            return article;
        }

        private static Article ValidateDescription(this Article article)
        {
            if (string.IsNullOrEmpty(article.Description))
                throw new EmptyDescriptionException();

            return article;
        }

        //overloading the validate function:
        //add mode
        public static Article Validate(this Article article, List<Article> articles)
        {
            return article.ValidateId(articles)
                          .ValidateTitle()
                          .ValidateDescription();
        }

        //edit mode
        public static Article Validate(this Article article)
        {
            return article.ValidateTitle()
                          .ValidateDescription();
        }
    }
}
