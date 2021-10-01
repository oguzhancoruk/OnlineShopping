using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Product
    {
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId{get;set;}
        public double Price{get;set;}
        public string Genre{get;set; }
    }
}