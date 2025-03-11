using System.Text.Json;

public class VersionManager
{
    public class PatchInfo
    {
        public required string Name { get; set; }
        public required string Directory { get; set; }
        public required string Ordinal { get; set; }
        public required List<string> Scripts { get; set; }
    }

    public class ProjectDetails
    {
        public required string Version { get; set; }
        public required PatchInfo Patch { get; set; }
    }

    public static void UpdateVersion(string filePath, string releaseType)
    {
        var jsonContent = File.ReadAllText(filePath);
        var projectDetails = JsonSerializer.Deserialize<ProjectDetails>(jsonContent) 
            ?? throw new InvalidOperationException("Failed to deserialize JSON file");

        var version = projectDetails.Version.Split('.');
        if (version.Length != 3)
            throw new ArgumentException("Invalid version format");

        if (int.TryParse(version[0], out int major) &&
            int.TryParse(version[1], out int minor) &&
            int.TryParse(version[2], out int patch))
        {
            switch (releaseType.ToLower())
            {
                case "minor":
                    minor++;
                    patch = 0;
                    break;
                case "patch":
                    patch++;
                    break;
                default:
                    throw new ArgumentException("Invalid release type. Use 'minor' or 'patch'");
            }

            projectDetails.Version = $"{major}.{minor}.{patch}";
            var options = new JsonSerializerOptions { WriteIndented = true };
            string updatedJson = JsonSerializer.Serialize(projectDetails, options);
            File.WriteAllText(filePath, updatedJson);
        }
        else
        {
            throw new ArgumentException("Version numbers must be numeric");
        }
    }
}