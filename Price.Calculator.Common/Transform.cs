using Newtonsoft.Json;

namespace Price.Calculator.Common
{
    public class Transform
    {
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static T To<R, T>(R resource)
            where R : class
            where T : class
        {
            var result = default(T);
            if (resource != null)
            {
                result = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(resource));
            }
            return result;
        }
    }
}