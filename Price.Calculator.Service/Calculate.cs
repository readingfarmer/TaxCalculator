using Price.Calculator.Common;
using Price.Calculator.Interfaces;
using Price.Calculator.Model;
using Price.Calculator.Service.Tax;

namespace Price.Calculator.Service
{
    public class Calculate : ICalculate
    {
        /// <summary>
        /// 计算金额
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public GoodsResponse SetAmount(Goods goods)
        {
            var _compositeTax = new CompositeTax();
            var result = Transform.To<Goods, GoodsResponse>(goods);
            if (goods != null)
            {
                // 进口税率
                if (goods.IsImport)
                {
                    _compositeTax.AddTax(new ImportDuty());
                }
                // 销售税
                if ((int)goods.Category <= 0 || (int)goods.Category >= 4)
                {
                    _compositeTax.AddTax(new SalesTax());
                }
                // 商品计税前总价
                var preTotalPrice = goods.Count * goods.Price;
                // 商品总税
                result.TotalTaxes = _compositeTax.GetTotalTax(preTotalPrice);
                // 商品计税后总价
                result.TotalPrice = preTotalPrice + result.TotalTaxes;
            }
            return result;
        }

        /// <summary>
        /// 计算金额
        /// </summary>
        /// <param name="goodList"></param>
        /// <returns></returns>
        public List<GoodsResponse> SetAmount(List<Goods> goodList)
        {
            var result = new List<GoodsResponse>();
            if (goodList != null && goodList.Count > 0)
            {
                foreach (var goods in goodList)
                {
                    result.Add(this.SetAmount(goods));
                }
            }
            return result;
        }
    }
}