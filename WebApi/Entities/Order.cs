using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Order
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        
        public int OrderId{get;set;}
        public string Genre{get;set;}
        public double Invoice{get;set;}
        public Product Product{get;set;}


    }
}