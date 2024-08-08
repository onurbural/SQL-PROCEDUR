using StoreProcedure.Models;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProcedure
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var context = new PROCEDURContext())
            {
                try
                {
                    var values1 = await context.Procedures.GetCategoryHierarchyWParams1Async(26);
                    var values2 = await GetCategoriesByIdsAsync(context, new List<int> { 26, 2, 3, 4, 1 });

                    var katalogAgaciList = values1.Select(value => new KatalogAgaci
                    {
                        CategoryID = value.CategoryID,
                        CategoryName = value.CategoryName,
                        ParentCategoryID = value.ParentCategoryID,
                        FullPath = value.FullPath,
                        Level = value.Level,
                        AltKategoriler = Array.Empty<KatalogAgaci>()
                    }).ToList();

                    katalogAgaciList.AddRange(values2.Select(value => new KatalogAgaci
                    {
                        CategoryID = value.CategoryID,
                        CategoryName = value.CategoryName,
                        ParentCategoryID = value.ParentCategoryID,
                        FullPath = value.FullPath,
                        Level = value.Level,
                        AltKategoriler = Array.Empty<KatalogAgaci>()
                    }));

                    var rootCategories = BuildCategoryTree(katalogAgaciList);

                    foreach (var rootCategory in rootCategories)
                    {
                        PrintCategoryTree(rootCategory);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        static List<KatalogAgaci> BuildCategoryTree(List<KatalogAgaci> categories)
        {
            var lookup = categories.ToLookup(c => c.ParentCategoryID);
            foreach (var category in categories)
            {
                category.AltKategoriler = lookup[category.CategoryID].ToArray();
            }
            return lookup[null].ToList(); 
        }

        static void PrintCategoryTree(KatalogAgaci category, string indent = "")
        {
            Console.WriteLine($"{indent}{category.CategoryName}");

            foreach (var subCategory in category.AltKategoriler)
            {
                PrintCategoryTree(subCategory, indent + "  ");
            }
        }

        static async Task<List<IDLISTESIYLEGETIRMEResult>> GetCategoriesByIdsAsync(PROCEDURContext context, List<int> ids)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("CategoryID", typeof(int));
            foreach (var id in ids)
            {
                dataTable.Rows.Add(id);
            }
            return await context.Procedures.IDLISTESIYLEGETIRMEAsync(dataTable);
        }
    }
}