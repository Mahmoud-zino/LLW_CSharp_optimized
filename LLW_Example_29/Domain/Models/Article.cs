using System;

namespace Domain.Models
{
    public class Article : ICloneable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public object Clone()
        {
            //shallow copy is enough for primitiv data types
            return this.MemberwiseClone();
        }
    }
}
