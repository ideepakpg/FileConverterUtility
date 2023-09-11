namespace Converter;

public abstract class FileConverterUtility
{
    protected string? _inputFile;
    protected string? _outputFolder;
    
    
    protected void getLocations()
    {
        Console.WriteLine("Paste the file path of your file:");
        _inputFile = Console.ReadLine();

        StripQuotes(ref _inputFile);
        
        Console.WriteLine("Paste the output folder path:");
        _outputFolder = Console.ReadLine();
        //If outputfolder is blank, use the input folder
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