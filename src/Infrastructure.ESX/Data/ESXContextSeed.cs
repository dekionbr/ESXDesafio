using ApplicationCore.ESX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.ESX.Data
{
    public class ESXContextSeed
    {
        public static async Task SeedAsync(ESXContext context, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!context.Brands.Any())
                {
                    context.Brands.AddRange(
                        GetPreconfiguredBrands());

                    await context.SaveChangesAsync();
                }

                if (!context.Assets.Any())
                {
                    context.Assets.AddRange(
                        GetPreconfiguredAssets());

                    await context.SaveChangesAsync();
                }

            }
            catch (Exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    await SeedAsync(context, retryForAvailability);
                }
            }
        }

        private static IEnumerable<Brand> GetPreconfiguredBrands()
        {
            return new List<Brand>()
            {
                new Brand() { Name = "Philips"},
                new Brand() { Name = "Lenovo"},
                new Brand() { Name = "Microsoft"}
            };
        }


        private static IEnumerable<Assets> GetPreconfiguredAssets()
        {
            return new List<Assets>()
            {
                new Assets() { Name = "Monitor Philips", Description = "Monitor wide 19", BrandId = 1},
                new Assets() { Name = "Notebook", Description = "Linha ideapad320", BrandId = 2},
                new Assets() { Name = "Periféricos bluetooth", Description = "Conjunto de mouse e teclado", BrandId = 3}
            };
        }
    }
}
