using System;
using System.IO;
using System.Transactions;
using Converter;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

public class ImageConverterUtility : FileConverterUtility
{

    public ImageConverterUtility()
    { }
    
    public static void CreateImage()
    {
        var utility = new ImageConverterUtility();

        Dictionary<string, Action> conversions = new Dictionary<string, Action>()
        {
            {"jpg", () => utility.ConvertToJpg(utility._inputFile, utility._outputFolder)},
            {"png", () => utility.ConvertToPng(utility._inputFile, utility._outputFolder)},
        };

        utility.getLocations();
        Console.WriteLine("File locations set!");
        utility.setType(conversions);
    }
    public void ConvertToPng(string inputFilePath, string outputFolderPath)
    {
        EnsureOutputDirectoryExists(outputFolderPath);

        using (var image = Image.Load(inputFilePath))
        {
            string pngFilePath = Path.Combine(outputFolderPath, Path.GetFileNameWithoutExtension(inputFilePath) + ".png");
            image.Save(pngFilePath, new PngEncoder());
        }
    }

    public void ConvertToJpg(string inputFilePath, string outputFolderPath, int quality = 90)
    {
        EnsureOutputDirectoryExists(outputFolderPath);

        using (var image = Image.Load(inputFilePath))
        {
            string jpgFilePath = Path.Combine(outputFolderPath, Path.GetFileNameWithoutExtension(inputFilePath) + ".jpg");
            image.Save(jpgFilePath, new JpegEncoder { Quality = quality });
        }
    }
}