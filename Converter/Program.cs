namespace Converter;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Action> conversions = new Dictionary<string, Action>()
        {
            {"image", () => ImageConverterUtility.CreateImage()},
        };
        Console.WriteLine("What type of file do you want to convert?");
        foreach (var conversion in conversions)
        {
            Console.WriteLine(conversion.Key);
        }
        
        string? conversionType = Console.ReadLine().ToLower().Trim();
        if(conversionType != null && !conversions.ContainsKey(conversionType))
        {
            Console.WriteLine("Invalid conversion type.");
            return;
        }

        if (conversionType != null) conversions[conversionType].Invoke();
        
        
        
    }
}