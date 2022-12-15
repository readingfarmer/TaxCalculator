using Price.Calculator.Model.Enum;

namespace Price.Calculator.Model
{
    /// <summary>
    /// 商品信息
    /// </summary>
    public class Goods
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { set; get; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { set; get; }

        /// <summary>
        /// 单位(名称)
        /// </summary>
        public string? Unit { set; get; }

        /// <summary>
        /// 是否进口
        /// </summary>
        public bool IsImport { set; get; }

        /// <summary>
        /// 物品分类, 对应GoodCategory枚举
        /// </summary>
        public GoodCategory Category { set; get; }

        /// <summary>
        /// 单价价格
        /// </summary>
        public decimal Price { get; set; }
    }
}