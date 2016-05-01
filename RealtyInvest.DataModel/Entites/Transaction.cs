namespace RealtyInvest.DataModel.Entites
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Volume { get; set; }
        public TransactionType Type { get; set; }
        public System.DateTime Date { get; set; }
        public int InvestorId { get; set; }
        public int OwnerId { get; set; }
        public virtual RealtyInvestUser Owner { get; set; }
        public virtual RealtyInvestUser Investor { get; set; }
        public virtual RealEstate RealEstate { get; set; }
    }
}
