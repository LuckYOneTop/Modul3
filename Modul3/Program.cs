using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        List<int> values = Enumerable.Range(1, 10).ToList();
        Task<List<int>> task1 = GetUniqueValuesAsync(values);
        Task<List<int>> task2 = GetFirstThreeValuesAsync(values);
        Task<List<int>> task3 = GetSortedValuesAsync(values);
        await Task.WhenAll(task1, task2, task3);
        List<int> result = task1.Result.Concat(task2.Result).Concat(task3.Result).ToList();

        
        Console.WriteLine(string.Join(" ", result));
    }

    static async Task<List<int>> GetUniqueValuesAsync(List<int> values)
    {
        await Task.Delay(3000); 

        return values.Distinct().ToList();
    }

    static async Task<List<int>> GetFirstThreeValuesAsync(List<int> values)
    {
        await Task.Delay(3000);

        return values.Take(3).ToList();
    }

    static async Task<List<int>> GetSortedValuesAsync(List<int> values)
    {
        await Task.Delay(3000); 
        return values.OrderBy(x => x % 2 == 0).ThenByDescending(x => x).ToList();
    }
}
