using System.Text.Json;

namespace ConsoleApp1;

public class JsonFileReader : BaseFileReader
{
    public override string SupportedFormat => "JSON";

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening JSON stream...");

        string fullText = File.ReadAllText(filePath);

        using JsonDocument document = JsonDocument.Parse(fullText);

        int count = 0;

        if (document.RootElement.ValueKind == JsonValueKind.Object)
        {
            count = document.RootElement.EnumerateObject().Count();
            Console.WriteLine($" -> Parsed {count} root properties.");
        }
        else if (document.RootElement.ValueKind == JsonValueKind.Array)
        {
            count = document.RootElement.GetArrayLength();
            Console.WriteLine($" -> Parsed {count} root elements.");
        }

        string displayContent = fullText.Length > 100
            ? fullText.Substring(0, 100) + "..."
            : fullText;

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("----------------------------\n");
    }
}