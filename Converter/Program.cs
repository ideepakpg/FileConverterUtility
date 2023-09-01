class Program
{
    static void Main(string[] args)
    {
        string inputFile = @"C:\Users\thega\Downloads\IMG_5365.png";
        string outputFolder = @"C:\Users\thega\Downloads\";


        ImageConverterUtility.ConvertToJpg(inputFile, outputFolder);

        Console.WriteLine("Conversion complete.");
    }
}