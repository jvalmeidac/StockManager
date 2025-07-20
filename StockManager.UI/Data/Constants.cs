namespace StockManager.UI.Data;

public static class Constants
{
    public const string DatabaseFilename = "StockManagerData.db3";

    public static string DatabasePath =>
        $"Data Source={Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename)}";
}