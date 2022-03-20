using UnityEngine;
public class UpdatePromptComponent : AppComponent
{
    // Properties
    public virtual twelvegigs.storage.JsonDictionary UpdatePromptConfig { get; }
    
    // Methods
    public UpdatePromptComponent(string gameName, string gameObjectName)
    {
        mem[1152921515595827904] = "UpdatePromptComponent";
    }
    public override void onStartApp()
    {
    
    }
    public override void onInitialServerUpdate()
    {
        UpdatePrompt.Init(serverConfiguration:  this);
    }
    public override void onServerUpdate()
    {
        UpdatePrompt.Init(serverConfiguration:  this);
    }
    private void ShowUpdatePrompt()
    {
        UpdatePrompt.Init(serverConfiguration:  this);
    }
    public virtual twelvegigs.storage.JsonDictionary get_UpdatePromptConfig()
    {
        null = null;
        return getUpdatePromptConfiguration();
    }

}
