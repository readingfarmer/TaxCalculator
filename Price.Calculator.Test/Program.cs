using Microsoft.Extensions.DependencyInjection;
using Price.Calculator.Interfaces;
using Price.Calculator.Model;
using Price.Calculator.Model.Enum;
using Price.Calculator.Service;

namespace Price.Calculator.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddTransient<ICalculate, Calculate>();

            var calculator = services.BuildServiceProvider()!.GetService<ICalculate>()!;

            #region 数据
            var firstBatch = new List<Goods>()
            {
                new Goods()
                {
                    Name = "book",
                    Count = 1,
                    IsImport = false,
                    Category = GoodCategory.Book,
                    Price = 12.49m
                },
                new Goods()
                {
                    Name = "music CD",
                    Count = 1,
                    IsImport = false,
                    Category = GoodCategory.Others,
                    Price = 14.99m
                },
                new Goods()
                {
                    Name = "chocolate bar",
                    Count = 1,
                    IsImport = false,
                    Category = GoodCategory.Food,
                    Price = 0.85m
                }
            };

            var secondBatch = new List<Goods>()
            {
                new Goods()
                {
                    Name = "chocolates",
                    Count = 1,
                    Unit = "box",
                    IsImport = true,
                    Category = GoodCategory.Food,
                    Price = 10.00m
                },
                new Goods()
                {
                    Name = "perfume",
                    Count = 1,
                    Unit = "bottle",
                    IsImport = true,
                    Category = GoodCategory.Others,
                    Price = 47.50m
                }
            };

            var thirdBatch = new List<Goods>()
            {
                new Goods()
                {
                    Name = "perfume",
                    Count = 1,
                    Unit = "bottle",
                    IsImport = true,
                    Category = GoodCategory.Others,
                    Price = 27.99m
                },
                new Goods()
                {
                    Name = "perfume",
                    Count = 1,
                    Unit = "bottle",
                    IsImport = false,
                    Category = GoodCategory.Others,
                    Price = 18.99m
                },
                new Goods()
                {
                    Name = "headache pills",
                    Count = 1,
                    Unit = "packet",
                    IsImport = false,
                    Category = GoodCategory.MedicalProducts,
                    Price = 9.75m
                },
                new Goods()
                {
                    Name = "chocolates",
                    Count = 1,
                    Unit = "box",
                    IsImport = true,
                    Category = GoodCategory.Food,
                    Price = 11.25m
                }
            };
            #endregion

            var inputGoodsSet = new List<List<Goods>>();
            var outputGoodsSet = new List<List<GoodsResponse>>();

            inputGoodsSet.Add(firstBatch);
            outputGoodsSet.Add(calculator.SetAmount(firstBatch));

            inputGoodsSet.Add(secondBatch);
            outputGoodsSet.Add(calculator.SetAmount(secondBatch));

            inputGoodsSet.Add(thirdBatch);
            outputGoodsSet.Add(calculator.SetAmount(thirdBatch));

            Input(inputGoodsSet);
            Ouput(outputGoodsSet);
        }

        /// <summary>
        /// 输入打印
        /// </summary>
        /// <param name="goodsSet"></param>
        private static void Input(List<List<Goods>> goodsSet)
        {
            Console.WriteLine("INPUT");
            Console.WriteLine();
            if (goodsSet == null || goodsSet.Count == 0)
            {
                Console.WriteLine($"暂无商品.");
                return;
            }
            int index = 1;
            foreach (var goodList in goodsSet)
            {
                Console.WriteLine($"Input {index}:");
                if (goodList == null || goodList.Count == 0)
                {
                    continue;
                }
                foreach (var goods in goodList)
                {
                    Console.WriteLine($"{goods.Count}{(goods.IsImport ? " imported" : "")} {(!string.IsNullOrWhiteSpace(goods.Unit) ? goods.Unit + " of " + goods.Name : goods.Name)} at {goods.Price}");
                }
                Console.WriteLine();
                index++;
            }
        }

        /// <summary>
        /// 输出打印
        /// </summary>
        /// <param name="goodsSet"></param>
        private static void Ouput(List<List<GoodsResponse>> goodsSet)
        {
            Console.WriteLine("OUTPUT");
            Console.WriteLine();
            if (goodsSet == null || goodsSet.Count == 0)
            {
                Console.WriteLine($"暂无商品.");
                return;
            }
            int index = 1;
            foreach (var goodList in goodsSet)
            {
                Console.WriteLine($"Output {index}:");
                if (goodList == null || goodList.Count == 0)
                {
                    continue;
                }
                foreach (var goods in goodList)
                {
                    Console.WriteLine($"{goods.Count}{(goods.IsImport ? " imported" : "")} {(!string.IsNullOrWhiteSpace(goods.Unit) ? goods.Unit + " of " + goods.Name : goods.Name)}: {goods.TotalPrice}");
                }
                var salesTaxes = goodList.Sum(_ => _.TotalTaxes);
                if (salesTaxes > 0m)
                {
                    Console.WriteLine($"Sales Taxes:{salesTaxes}");
                }
                Console.WriteLine($"Total:{goodList.Sum(_ => _.TotalPrice)}");
                Console.WriteLine();
                index++;
            }
        }
    }
}