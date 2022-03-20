using UnityEngine;
public struct InstalledAppsPlugin.GameApp
{
    // Fields
    private string uniqueName;
    private string packageName;
    private string assetName;
    public bool isInstalled;
    
    // Methods
    public InstalledAppsPlugin.GameApp(string gameName, string packageName, string assetName)
    {
        this = gameName;
        this.packageName = packageName;
        this.assetName = assetName;
        this.isInstalled = twelvegigs.plugins.InstalledAppsPlugin.IsInstalled(packageToCheck:  packageName);
    }
    public string GetGameName()
    {
        return (string)new InstalledAppsPlugin.GameApp();
    }
    public string GetPackageName()
    {
        return (string)this.packageName;
    }
    public string GetAssetName()
    {
        return (string)this.assetName;
    }

}
