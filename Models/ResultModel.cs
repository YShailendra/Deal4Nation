namespace Products.Models
{
    public class ResultModel <T> where T:class{
        
        public bool HasError {get;set;}
        public string[] ErrorMessage {get;set;}

        public T Result {get;set;}
    }
}