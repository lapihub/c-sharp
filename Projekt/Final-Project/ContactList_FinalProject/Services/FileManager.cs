namespace ContactList_FinalProject.Services;

public class FileManager
{
    // filePath visar till sökvägen till mitt skrivbord 
    private static readonly string filePath = @"C:\Users\User\OneDrive\Skrivbord\contacts.json";

    public static void SaveToFile (string contentAsJson)
    {
        using var sw = new StreamWriter(filePath); // using delen: efter det som är skrivet har körts så kommer den att automatiskt förstöra den
        sw.WriteLine(contentAsJson);
    }

    public static string ReadFromFile()
    {
        if (File.Exists(filePath)) // kontrollera om filen finns eller inte 
        {
            using var sr = new StreamReader(filePath);
            return sr.ReadToEnd();
        }
        return null!;
    }
}
