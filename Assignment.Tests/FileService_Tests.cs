using AssignmentShared.Interfaces;
using AssignmentShared.Services;

namespace Assignment.Tests;

public class FileService_Tests
{
    [Fact]
    public void SaveToFileShould_SaveContentToFile_ThenReturnTrue()
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
}
