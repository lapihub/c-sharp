namespace ContactList_Project_Test2.Services;

public class FileManage
{
    private static readonly string filePath = @"C:\Users\User\Desktop\contactlist.json";
    public static void SaveToFile(string contentAsJson) // Innehåll som vi vill spara undan
    {
        using var sw = new StreamWriter(filePath);
        sw.WriteLine(contentAsJson);
    }

    public static string ReadFromFile()
    {
        if (File.Exists(filePath))
        {
            using var sr = new StreamReader(filePath);
            return sr.ReadToEnd();
        }

        return null!;
    }
}
