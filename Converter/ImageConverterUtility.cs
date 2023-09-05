
using ImageMagick;

namespace Converter;

public static class ImageConverterUtility
{
    public static void ConvertToPng(string inputFilePath, string? outputFolderPath)
    {
        EnsureOutputDirectoryExists(outputFolderPath);

        using (MagickImage image = new MagickImage(inputFilePath))
        {
            string pngFilePath = Path.Combine(outputFolderPath, Path.GetFileNameWithoutExtension(inputFilePath) + ".png");
            image.Format = MagickFormat.Png;
            image.Write(pngFilePath);
        }
    }
    //To JPG
    public static void ConvertToJpg(string? inputFilePath, string? outputFolderPath)
    {
        EnsureOutputDirectoryExists(outputFolderPath);

        using (MagickImage image = new MagickImage(inputFilePath))
        {
            string jpgFilePath = Path.Combine(outputFolderPath, Path.GetFileNameWithoutExtension(inputFilePath) + ".jpg");
            image.Format = MagickFormat.Jpg;
            image.Quality = 90; // Set JPEG quality (0 to 100)
            image.Write(jpgFilePath);
        }
    }
    // Overload with quality parameter
    public static void ConvertToJpg(string inputFilePath, string? outputFolderPath, int quality)
    {
        EnsureOutputDirectoryExists(outputFolderPath);

        using (MagickImage image = new MagickImage(inputFilePath))
        {
            string jpgFilePath = Path.Combine(outputFolderPath, Path.GetFileNameWithoutExtension(inputFilePath) + ".jpg");
            image.Format = MagickFormat.Jpg;
            image.Quality = quality; // Set JPEG quality (0 to 100)
            image.Write(jpgFilePath);
        }
    }
    

    private static void EnsureOutputDirectoryExists(string? outputFolderPath)
    {
        if (!Directory.Exists(outputFolderPath))
        {
            Directory.CreateDirectory(outputFolderPath);
        }
    }
}