using System.Diagnostics;
using System.IO.Compression;
using System.Net.Http.Headers;
using Minesweeper.Models;
using Minesweeper.Utils.Helpers;
using Newtonsoft.Json;

namespace Minesweeper.Controllers;

public static class UpdateController
{
    /// <summary>
    ///     Check if an update is available using the GitHub api.
    /// </summary>
    /// <returns>All necessary parameters of the latest update.</returns>
    public static UpdateModel CheckForUpdate()
    {
        const string apiBase = "https://api.github.com";
        const string apiPath = "repos/ManuelKlaer/windows-forms-minesweeper/releases?per_page=1";

        // Initialize a new HttpClient
        using HttpClient client = new();
        client.BaseAddress = new Uri(apiBase);
        client.DefaultRequestHeaders.Add("User-Agent", "MinesweeperUpdateCheck");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Make an api request
        HttpResponseMessage response = client.GetAsync(apiPath).Result;
        response.EnsureSuccessStatusCode();

        // Deserialize the received json object
        dynamic jsonData = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result) ??
                           throw new InvalidOperationException("Couldn't deserialize json data from api.");

        // Load values from json
        int id = jsonData[0].id;
        string versionCode = jsonData[0].tag_name;
        string name = jsonData[0].name;
        string body = jsonData[0].body;
        string author = jsonData[0].author.login;
        bool isPreRelease = jsonData[0].prerelease;
        bool isDraft = jsonData[0].draft;
        string url = jsonData[0].html_url;

        // Find download packages
        string? downloadPortable = null;
        string? downloadInstaller = null;

        foreach (dynamic asset in jsonData[0].assets)
        {
            string assetName = asset.name;
            string assetUrl = asset.browser_download_url;

            if (assetName.EndsWith(".zip")) downloadPortable = assetUrl;
            else if (assetName.EndsWith(".appxbundle")) downloadInstaller = assetUrl;
        }

        // Create new UpdateModel and return it
        return new UpdateModel
        {
            Id = id,
            Version = UtilsClass.GetVersion(versionCode),
            Name = name,
            Body = body,
            Author = author,
            IsPreRelease = isPreRelease,
            IsDraft = isDraft,
            Url = url,
            DownloadPortableUrl = downloadPortable,
            DownloadInstallerUrl = downloadInstaller
        };
    }

    /// <summary>
    ///     Install an update.
    /// </summary>
    /// <param name="update">The update to install.</param>
    public static void InstallUpdate(UpdateModel update)
    {
        string downloadLocation = Path.Join(ApplicationInfo.StorageLocation, "tmp_update");
        string downloadFile = Path.Join(downloadLocation, ApplicationInfo.IsAppxPackage ? "Minesweeper.appxbundle" : "Minesweeper.zip");

        // Delete any old directory which may exists
        try
        {
            if (Directory.Exists(downloadLocation)) Directory.Delete(downloadLocation, true);
        }
        catch (UnauthorizedAccessException) { }
        catch (IOException) { }

        // Create a temporary directory to store the downloaded files
        if (!Directory.Exists(downloadLocation)) Directory.CreateDirectory(downloadLocation);

        // Download the update
        using HttpClient client = new();
        using Task<Stream> s = client.GetStreamAsync(ApplicationInfo.IsAppxPackage ? update.DownloadInstallerUrl : update.DownloadPortableUrl);
        using FileStream fs = new(downloadFile, FileMode.OpenOrCreate);
        s.Result.CopyTo(fs);

        // Release all file handles
        fs.Close();

        // Process the update
        if (ApplicationInfo.IsAppxPackage) // Update is a appxbundle
        {
            // Create a new shell process
            ProcessStartInfo psInfo = new()
            {
                FileName = downloadFile,
                UseShellExecute = true
            };

            // Start the shell process
            Process.Start(psInfo);

            // Close this application
            Environment.Exit(0);
        }
        else // Update is a zip archive
        {
            // Extract the archive
            ZipFile.ExtractToDirectory(downloadFile, downloadLocation, true);

            // Run the new executable to update the original executable
            ProcessStartInfo psInfo = new()
            {
                FileName = Path.Join(downloadLocation, "Minesweeper.exe"),
                Arguments = "--update",
                WorkingDirectory = downloadLocation,
                UseShellExecute = true
            };

            Process.Start(psInfo);

            // Close this application
            Environment.Exit(0);
        }
    }

    /// <summary>
    ///     Apply an update package (.zip archive)
    /// </summary>
    /// <param name="updatePackage">The path to the update package.</param>
    /// <param name="destination">The destination path to use for installation.</param>
    /// <exception cref="FileNotFoundException">Invalid update package</exception>
    public static void ApplyUpdatePackage(string updatePackage, string destination)
    {
        // Check if the update package exists
        if (!File.Exists(updatePackage))
            throw new FileNotFoundException("Invalid update package");

        // Apply update package
        ZipFile.ExtractToDirectory(updatePackage, destination, true);

        // Start the updated application
        ProcessStartInfo psInfo = new()
        {
            FileName = Path.Join(destination, "Minesweeper.exe"),
            WorkingDirectory = destination,
            UseShellExecute = true
        };

        Process.Start(psInfo);

        // Close this application
        Environment.Exit(0);
    }
}