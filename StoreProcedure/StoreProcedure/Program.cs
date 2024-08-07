using StoreProcedure.Models;
using System;
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
                    var values = await context.Procedures.GetCategoryHierarchyWParams1Async(2);
                    foreach (var value in values)
                    {
                        Console.WriteLine(value.FullPath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
