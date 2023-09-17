using System;
using System.IO;
using System.Transactions;
using Converter;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Bmp;
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
            {"gif", () => utility.ConvertToGif(utility._inputFile, utility._outputFolder)},
        };

        utility.getLocations();
        Console.WriteLine("File locations set!");
        utility.setType(conversions);
    }
    
    public void ConvertToPng(string inputFilePath, string outputFolderPath)
    {
        EnsureOutputDirectoryExists(outputFolderPath);

        try
        {
            using (var image = Image.Load(inputFilePath))
            {
                string pngFilePath = Path.Combine(outputFolderPath,
                    Path.GetFileNameWithoutExtension(inputFilePath) + ".png");
                image.Save(pngFilePath, new PngEncoder());
            }
        }
        catch(Exception e)
        {
            try
            {
                BackupImageConverter.ConvertToPng(inputFilePath, outputFolderPath);
                
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error converting to PNG.");
                Console.WriteLine(exception);
                throw;
            }
        }
    }

    private void ConvertToJpg(string inputFilePath, string outputFolderPath, int quality = 90)
    {
        EnsureOutputDirectoryExists(outputFolderPath);
        try
        {
            using (var image = Image.Load(inputFilePath))
            {

                string jpgFilePath = Path.Combine(outputFolderPath,
                    Path.GetFileNameWithoutExtension(inputFilePath) + ".jpg");
                image.Save(jpgFilePath, new JpegEncoder { Quality = quality });


            }
        }catch (UnknownImageFormatException e)
        {
            try{BackupImageConverter.ConvertToJpg(inputFilePath, outputFolderPath, quality);}
            catch (Exception exception)
            {
                Console.WriteLine("Error converting to JPG.");
                Console.WriteLine(exception);
                throw;
            }
        }   
    }
    public void ConvertToGif(string inputFilePath, string outputFolderPath)
    {
        EnsureOutputDirectoryExists(outputFolderPath);

        using (var image = Image.Load(inputFilePath))
        {
            string gifFilePath = Path.Combine(outputFolderPath, Path.GetFileNameWithoutExtension(inputFilePath) + ".gif");
            image.Save(gifFilePath, new GifEncoder());
        }
    }
    
}