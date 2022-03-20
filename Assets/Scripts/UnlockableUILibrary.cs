using UnityEngine;
public class UnlockableUILibrary : WGUnlockableUIElement
{
    // Properties
    protected override bool FeatureHidden { get; }
    protected override int UnlockLevel { get; }
    protected override bool FeatureLocked { get; }
    
    // Methods
    protected override bool get_FeatureHidden()
    {
        return false;
    }
    protected override int get_UnlockLevel()
    {
        return ChapterBookLogic.GetFirstLevelOfSecondBook();
    }
    protected override bool get_FeatureLocked()
    {
        return (bool)(TheLibraryLogic.LifetimeBooksEarned < 1) ? 1 : 0;
    }
    protected override void OnClickUnlocked()
    {
        null = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 52;
        TheLibraryUI.ShowTheLibrary(onCloseAction:  0);
    }
    public UnlockableUILibrary()
    {
    
    }

}
