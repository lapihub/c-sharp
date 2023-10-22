using System.Security.Cryptography.X509Certificates;

namespace ContactList_Project_Test3.Services;

public class FileManager
{
    private static readonly string filePath = @"C:\\Users\\User\\OneDrive\\Skrivbord\contactlist.json";

    public static void SaveToFile(string contentAsJson)
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

