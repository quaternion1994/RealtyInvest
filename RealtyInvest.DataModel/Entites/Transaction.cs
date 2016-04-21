namespace RealtyInvest.DataModel.Entites
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public string Volume { get; set; }
        public TransactionType Type { get; set; }
        public System.DateTime Date { get; set; }
        public virtual Investor Investor { get; set; }
        public virtual RealEstate RealEstate { get; set; }
    }
}
