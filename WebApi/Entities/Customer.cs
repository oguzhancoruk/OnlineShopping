using System.ComponentModel.DataAnnotations.Schema;

namespace  WebApi.Entities
{
    public class Customer
    
    {   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get;set;}
        public string Name{get;set;}
        public string SurName{get;set;}
        public string Email{get;set;}
        public string Password{get;set;}
        public int Phone{get;set;}
        public string Adress{get;set;}
        public double Invoice{get;set;}
        public Order Order{get;set;}
      
    }
    
    }

