namespace Price.Calculator.Common
{
    public class RoundUpUtil
    {
        /// <summary>
        /// 向上取值
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static decimal RoundUp(decimal price, decimal nearestNumSize = 0.05m)
        {
            return Math.Ceiling(decimal.Divide(price, nearestNumSize)) * nearestNumSize;
        }
    }
}
