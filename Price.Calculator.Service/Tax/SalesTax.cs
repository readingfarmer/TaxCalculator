namespace Price.Calculator.Service.Tax
{
    /// <summary>
    /// 销售税
    /// Basic sales tax is applicable at a rate of 10% on all goods, except books, food, and medical products that are exempt. 
    /// </summary>
    public class SalesTax : BaseTax
    {
        public SalesTax(decimal rate = 0.1m) : base(rate)
        {
        }
    }
}
