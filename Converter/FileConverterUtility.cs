namespace Converter;

public abstract class FileConverterUtility
{
    protected string? _inputFile;
    protected string? _outputFolder;


    protected void getLocations()
    {
        Console.WriteLine("Enter the path of the file you want to convert:");
        _inputFile = Console.ReadLine();

        StripQuotes(ref _inputFile);

        Console.WriteLine("Enter the path of the output folder (Leave empty for the same folder):");
        _outputFolder = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(_outputFolder))
        {
            _outputFolder = Path.GetDirectoryName(_inputFile);
        }
        else
            StripQuotes(ref _outputFolder);
    }

    protected void setType(Dictionary<string, Action> conversions)
    {
        Console.WriteLine("Select the type of conversion you want to do:");
        foreach (var conversion in conversions)
        {
            Console.WriteLine(conversion.Key);
        }
        string? conversionType = Console.ReadLine();
        if (conversionType != null && !conversions.ContainsKey(conversionType))
        {
            Console.WriteLine("Invalid conversion type.");
            return;
        }
        conversions[conversionType].Invoke();
        Console.WriteLine("Conversion complete.");
    }

    protected static void StripQuotes(ref string? input)
    {


        if (input != null && input.StartsWith("\"") && input.EndsWith("\""))
        {
            input = input.Substring(1, input.Length - 2);
        }
    }


    protected static void EnsureOutputDirectoryExists(string outputFolderPath)
    {
        if (!Directory.Exists(outputFolderPath))
        {
            Directory.CreateDirectory(outputFolderPath);
        }
    }
}