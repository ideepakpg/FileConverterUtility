class Program
{
    static void Main(string[] args)
    {
        
        string? inputFile = null;
        string? outputFolder = null;
        Dictionary<string, Action> conversions = new Dictionary<string, Action>()
        {
            {"jpg", () => ImageConverterUtility.ConvertToJpg(inputFile, outputFolder)},
            {"png", () => ImageConverterUtility.ConvertToPng(inputFile, outputFolder)},
        };
        Console.WriteLine("Paste the file path of your file:");
        inputFile = Console.ReadLine();
        //If inputfile is surrounded by quotes, remove them
        if (inputFile.StartsWith("\"") && inputFile.EndsWith("\""))
        {
            inputFile = inputFile.Substring(1, inputFile.Length - 2);
        }
        
        
        Console.WriteLine("Paste the output folder path:");
        outputFolder = Console.ReadLine();
        //If outputfolder is blank, use the input folder
        if (string.IsNullOrWhiteSpace(outputFolder))
        {
            outputFolder = Path.GetDirectoryName(inputFile);
        }
        Console.WriteLine("Select the conversion type:");
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
}
