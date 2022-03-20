using UnityEngine;
public class ButtonGotoScene : MyButton
{
    // Fields
    public SceneType sceneIndex;
    public AmplitudePluginHelper.FeatureAccessPoints accessPoint;
    public bool abortDailyChallenge;
    
    // Methods
    public override void OnButtonClick()
    {
        var val_5;
        this.OnButtonClick();
        if(this.abortDailyChallenge != false)
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance) != 0)
        {
                MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge = false;
        }
        
        }
        
        val_5 = null;
        val_5 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = this.accessPoint;
        GameBehavior val_4 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public ButtonGotoScene()
    {
        this.accessPoint = 4;
    }

}
