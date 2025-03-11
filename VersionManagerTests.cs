using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text.Json;

[TestClass]
public class VersionManagerTests
{
    private string testFilePath;

    [TestInitialize]
    public void Setup()
    {
        testFilePath = Path.GetTempFileName();
        var initialJson = @"{
            ""Version"": ""1.6.23"",
            ""Patch"": {
                ""Name"": ""Patch022024"",
                ""Directory"": ""Patch022024"",
                ""Ordinal"": ""1"",
                ""Scripts"": [""script1.sql"", ""script2.sql""]
            }
        }";
        File.WriteAllText(testFilePath, initialJson);
    }

    [TestCleanup]
    public void Cleanup()
    {
        if (File.Exists(testFilePath))
            File.Delete(testFilePath);
    }

    [TestMethod]
    public void UpdateVersion_MinorRelease_IncrementsMinorResetsPath()
    {
        // Act
        VersionManager.UpdateVersion(testFilePath, "minor");

        // Assert
        var updatedJson = File.ReadAllText(testFilePath);
        var projectDetails = JsonSerializer.Deserialize<VersionManager.ProjectDetails>(updatedJson);
        Assert.AreEqual("1.7.0", projectDetails.Version);
    }

    [TestMethod]
    public void UpdateVersion_PatchRelease_IncrementsPatch()
    {
        // Act
        VersionManager.UpdateVersion(testFilePath, "patch");

        // Assert
        var updatedJson = File.ReadAllText(testFilePath);
        var projectDetails = JsonSerializer.Deserialize<VersionManager.ProjectDetails>(updatedJson);
        Assert.AreEqual("1.6.24", projectDetails.Version);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void UpdateVersion_InvalidReleaseType_ThrowsException()
    {
        VersionManager.UpdateVersion(testFilePath, "invalid");
    }
}