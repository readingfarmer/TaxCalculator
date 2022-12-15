namespace Price.Calculator.Service.Tax
{
    /// <summary>
    /// 进口税
    /// Import duty is an additional sales tax applicable on all imported goods at a rate of 5%, with no exemptions.
    /// </summary>
    public class ImportDuty : BaseTax
    {
        public ImportDuty(decimal rate = 0.05m)
            : base(rate)
        {

        }
    }
}
