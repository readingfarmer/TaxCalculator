namespace Price.Calculator.Service.Tax
{
    /// <summary>
    /// 混合税, 如: 销售税 + 进口税
    /// </summary>
    public class CompositeTax
    {
        public List<BaseTax> Taxes = new List<BaseTax>();

        public void AddTax(BaseTax salesTax)
        {
            Taxes.Add(salesTax);
        }

        /// <summary>
        /// 计算混合总税
        /// </summary>
        /// <param name="goodPrice"></param>
        /// <returns></returns>
        public decimal GetTotalTax(decimal goodPrice)
        {
            var result = decimal.Zero;
            if (goodPrice > 0m && Taxes.Count > 0)
            {
                foreach (var tax in Taxes)
                {
                    result += tax.GetTax(goodPrice);
                }
            }
            return result;
        }
    }
}
