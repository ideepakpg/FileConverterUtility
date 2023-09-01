class Program
{
    static void Main(string[] args)
    {
        string inputFile = @"";
        string outputFolder = @"";


        ImageConverterUtility.ConvertToJpg(inputFile, outputFolder);

        Console.WriteLine("Conversion complete.");
    }
}
