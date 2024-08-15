using System.Text.Json;

using RememberThis.Models;

namespace RememberThis.Services;

public static class Storage
{
    private const string TestListFileName = "testlist.json";
    
    public static void WriteTestList(List<Test> data)  
    {  
        var path = Path.Combine(FileSystem.Current.AppDataDirectory, TestListFileName);
        var json = JsonSerializer.Serialize(data);
        File.WriteAllText(path, json);
    } 
    
    public static List<Test> ReadTestList()  
    {  
        var path = Path.Combine(FileSystem.Current.AppDataDirectory, TestListFileName);
        if (!Path.Exists(path)) return [];
        var json = File.ReadAllText(path);  
        return JsonSerializer.Deserialize<List<Test>>(json) ?? [];
    } 
}