namespace Converter;
using FFMpegCore;

public class VideoConverterUtility : FileConverterUtility
{
    
    public VideoConverterUtility()
    { }
    
    public static void CreateVideo()
    {
        var utility = new VideoConverterUtility();

        Dictionary<string, Action> conversions = new Dictionary<string, Action>()
        {
            {"mp4", () => utility.ConvertToMp4(utility._inputFile, utility._outputFolder)},
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

    private void ConvertToMov(string inputFilePath, string outputFolderPath)
    {
        EnsureOutputDirectoryExists(outputFolderPath);
        string movFilePath = Path.Combine(outputFolderPath, Path.GetFileNameWithoutExtension(inputFilePath) + ".mov");
        FFMpegArguments.FromFileInput(inputFilePath).OutputToFile(movFilePath).ProcessSynchronously();
    }
    
    
}