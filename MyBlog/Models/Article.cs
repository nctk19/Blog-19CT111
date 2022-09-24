using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Models
{
    public class Article:BaseEntity
    {
        public String Title{get;set;}
        public String Content{get;set;}
        public int ViewCount{get;set;}

        [ForeignKey("Author")]
        public Guid AuthorId{get;set;}
        public object AuthorID { get; internal set; }
        public User Author{get;set;}

        public Guid CategoryId{get;set;}
        public Category Category{get;set;}
        public ICollection<Tag> Tags{get;set;}
        public ICollection<Comment> Comments{get;set;}
        public ICollection<User> Likers{get;set;}
    }
}