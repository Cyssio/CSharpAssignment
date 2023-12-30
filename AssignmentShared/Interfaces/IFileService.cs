namespace AssignmentShared.Interfaces;

public interface IFileService
{
    /// <summary>
    /// Save the updated content to a specified filepath
    /// </summary>
    /// <param name="filePath">Enter the filepath with extension (eg. c\project\myfile.json)</param>
    /// <param name="content">Enter content as a string</param>
    /// <returns>Returns true if saved, else false if failed</returns>
    bool SaveToFile (string filePath, string content);


    /// <summary>
    /// Get content as string from a specified filepath
    /// </summary>
    /// <param name="filePath">Enter the filepath with extension (eg. c\project\myfile.json)</param>
    /// <returns>Returns file content as string if file exists, else returns null</returns>
    string GetContentFromFile(string filePath);
}
