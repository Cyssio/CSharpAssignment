using AssignmentShared.Interfaces;
using AssignmentShared.Services;

namespace Assignment.Tests;

public class FileService_Tests
{
    [Fact]
    public void SaveToFile_ShouldReturnTrue_IfFilePathExists()
    {
        // Arrange
        IFileService fileService = new FileService();
        string filePath = @"c:\VS-Projects\testing.txt";
        string content = "Testing";

        // Act
        bool result = fileService.SaveToFile(filePath, content);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void SaveToFileShould_ReturnFalse_IfFilePathNotExists()
    {
        // Arrange
        IFileService fileService = new FileService();
        string filePath = @$"c:\{Guid.NewGuid()}testing.txt";
        string content = "Testing";

        // Act
        bool result = fileService.SaveToFile(filePath, content);

        // Assert
        Assert.False(result);
    }
}
