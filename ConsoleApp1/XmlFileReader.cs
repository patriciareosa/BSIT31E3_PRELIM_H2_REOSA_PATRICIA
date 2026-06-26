using System.Xml.Linq;

namespace ConsoleApp1;

public class XmlFileReader : BaseFileReader
{
    public override string SupportedFormat => "XML";

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening XML stream...");

        XDocument document = XDocument.Load(filePath);

        string rootName = document.Root?.Name.LocalName ?? "Unknown";
        int descendantCount = document.Descendants().Count();

        Console.WriteLine($" -> Root element: <{rootName}> with {descendantCount} descendant nodes.");

        string fullText = document.ToString();

        string displayContent = fullText.Length > 100
            ? fullText.Substring(0, 100) + "..."
            : fullText;

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("----------------------------\n");
    }
}