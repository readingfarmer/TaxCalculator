using Price.Calculator.Common;

namespace Price.Calculator.Service.Tax
{
    public class BaseTax
    {
        /// <summary>
        /// 税率
        /// </summary>
        protected decimal _rate;

        public BaseTax(decimal rate)
        {
            this._rate = rate;
        }

        /// <summary>
        /// 获取税收
        /// </summary>
        /// <param name="goodPrice">商品价格</param>
        /// <returns></returns>
        public virtual decimal GetTax(decimal goodPrice)
        {
            if (this._rate <= 0m || goodPrice <= 0m)
            {
                return decimal.Zero;
            }
            return RoundUpUtil.RoundUp(this._rate * goodPrice);
        }
    }
}
