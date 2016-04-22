using System.Security.AccessControl;

namespace RealtyInvest.DataModel.Entites
{
    public class Resource
    {
        public long Id { get; set; } 
        public ResourceType Type { get; set; }
        public string Url { get; set; }  
    }
}