using FFMpegCore.Enums;

namespace Converter;
using FFMpegCore;

public class VideoConverterUtility : FileConverterUtility
{
    
    public VideoConverterUtility()
    { }
    
    public static void CreateVideo()
    {
        var utility = new VideoConverterUtility();
        var codec = VideoCodec.LibX264;
        Dictionary<string, Action> conversions = new Dictionary<string, Action>()
        {
            {"mp4", () => utility.ConvertToMp4(utility._inputFile, utility._outputFolder)},
            {"mp4 codec", () => utility.ConvertToMp4(utility._inputFile, utility._outputFolder, codec)},
            {"mov", () => utility.ConvertToMov(utility._inputFile, utility._outputFolder)},
        };

        utility.getLocations();
        Console.WriteLine("File locations set!");
        utility.setType(conversions);
    }
    
    private void ConvertToMp4(string inputFilePath, string outputFolderPath)
    {
        EnsureOutputDirectoryExists(outputFolderPath);
        string mp4FilePath = Path.Combine(outputFolderPath, Path.GetFileNameWithoutExtension(inputFilePath) + ".mp4");
        FFMpegArguments.FromFileInput(inputFilePath).OutputToFile(mp4FilePath).ProcessSynchronously();
    }
    
    private void ConvertToMp4(string inputFilePath, string outputFolderPath, Codec codec)
    {
        EnsureOutputDirectoryExists(outputFolderPath);
        string mp4FilePath = Path.Combine(outputFolderPath, Path.GetFileNameWithoutExtension(inputFilePath) + ".mp4");
        FFMpegArguments.FromFileInput(inputFilePath).OutputToFile(mp4FilePath, true, options => options.WithVideoCodec(codec)).ProcessSynchronously();
    }

    private void ConvertToMov(string inputFilePath, string outputFolderPath)
    {
        EnsureOutputDirectoryExists(outputFolderPath);
        string movFilePath = Path.Combine(outputFolderPath, Path.GetFileNameWithoutExtension(inputFilePath) + ".mov");
        FFMpegArguments.FromFileInput(inputFilePath).OutputToFile(movFilePath).ProcessSynchronously();
    }
    
}