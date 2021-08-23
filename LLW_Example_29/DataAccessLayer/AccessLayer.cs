using Domain.Extensions;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public abstract class AccessLayer : IDisposable
    {
        public abstract List<Article> Get();

        public virtual void Add(Article article)
        {
            article.Validate(this.Get());
        }

        public virtual void Update(Article article)
        {
            article.Validate();
        }

        public abstract void Delete(Article article);

        //important for sql based accessLayers
        public abstract void Dispose();
    }
}
