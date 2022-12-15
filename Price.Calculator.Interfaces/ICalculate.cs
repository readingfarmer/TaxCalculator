using Price.Calculator.Model;

namespace Price.Calculator.Interfaces
{
    /// <summary>
    /// 物品价格计算接口
    /// </summary>
    public interface ICalculate
    {
        /// <summary>
        /// 计算金额
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        GoodsResponse SetAmount(Goods goods);

        /// <summary>
        /// 计算金额
        /// </summary>
        /// <param name="goodList"></param>
        /// <returns></returns>
        List<GoodsResponse> SetAmount(List<Goods> goodList);
    }
}
