using UnityEngine;
public class WGLaunchSceneManager : MonoBehaviour
{
    // Fields
    private bool doneThisBefore;
    
    // Methods
    private void Awake()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnDeferredReady");
    }
    private void Start()
    {
        var val_2;
        WGAudioController val_1 = MonoSingleton<WGAudioController>.Instance;
        val_1.music.Play(type:  0, trackIndex:  0);
        val_2 = null;
        val_2 = null;
        if(WordApp.deferredEventHasFired == false)
        {
                return;
        }
        
        if(this.doneThisBefore != false)
        {
                return;
        }
        
        this.OnDeferredReady();
    }
    private void OnDeferredReady()
    {
        if(this.doneThisBefore != false)
        {
                return;
        }
        
        this.doneThisBefore = true;
        this.DoLevelsDataRequest();
        TheLibraryLogic.InitializePlayerData();
    }
    private void DoLevelsDataRequest()
    {
        null = null;
        GameNames val_4 = App.game;
        if(val_4 <= 4)
        {
            goto label_6;
        }
        
        if(val_4 > 18)
        {
                return;
        }
        
        val_4 = 1 << val_4;
        if(val_4 != 263296)
        {
            goto label_10;
        }
        
        return;
        label_6:
        if(val_4 != 1)
        {
                if(val_4 != 4)
        {
                return;
        }
        
        }
        
        label_10:
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                MonoSingletonSelfGenerating<WordLevelGen>.Instance.CallEmptyMethod();
            return;
        }
        
        MonoSingletonSelfGenerating<WADataParser>.Instance.CallEmptyMethod();
    }
    public WGLaunchSceneManager()
    {
    
    }

}
