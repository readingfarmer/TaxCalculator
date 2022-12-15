using Price.Calculator.Model.Enum;

namespace Price.Calculator.Model
{
    /// <summary>
    /// 商品返回信息
    /// </summary>
    public class GoodsResponse : Goods
    {
        /// <summary>
        /// 物品总税
        /// </summary>
        public decimal TotalTaxes { get; set; }

        /// <summary>
        /// 物品总价（含税）
        /// </summary>
        public decimal TotalPrice { get; set; }
    }
}