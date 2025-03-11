class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: VersionUpdater.exe <release-type> <json-file-path>");
            Console.WriteLine("release-type: 'minor' or 'patch'");
            return;
        }

        try
        {
            VersionManager.UpdateVersion(args[1], args[0]);
            Console.WriteLine("Version updated successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
