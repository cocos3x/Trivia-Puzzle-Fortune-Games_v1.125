using UnityEngine;
public class WGChallengeButton : MyButton
{
    // Fields
    private UnityEngine.ParticleSystem challengeProgressParticle;
    private bool hasShownCompletedThisScene;
    
    // Methods
    private void Awake()
    {
        WGChallengeController val_2 = MonoSingletonSelfGenerating<WGChallengeController>.Instance;
        if((App.Player >= val_2._unlockLevel) && ((MonoSingletonSelfGenerating<WGChallengeController>.Instance.featureEnabled) != false))
        {
                UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void WGChallengeButton::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
            WGChallengeController val_6 = MonoSingletonSelfGenerating<WGChallengeController>.Instance;
            System.Delegate val_8 = System.Delegate.Combine(a:  val_6.onAnyChallengeProgress, b:  new System.Action<System.Boolean, ChallengeType>(object:  this, method:  System.Void WGChallengeButton::OnProgressGained(bool isComplete, ChallengeType cType)));
            if(val_8 != null)
        {
                if(null != null)
        {
            goto label_18;
        }
        
        }
        
            val_6.onAnyChallengeProgress = val_8;
            return;
        }
        
        this.gameObject.SetActive(value:  false);
        return;
        label_18:
    }
    private void OnProgressGained(bool isComplete, ChallengeType cType)
    {
        if(isComplete != false)
        {
                if(this.hasShownCompletedThisScene == false)
        {
            goto label_1;
        }
        
        }
        
        this.challengeProgressParticle.Play();
        return;
        label_1:
        DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions.DOShakeRotation(target:  this.transform, duration:  0.7f, strength:  50f, vibrato:  20, randomness:  90f, fadeOut:  true);
        this.hasShownCompletedThisScene = true;
    }
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        this.hasShownCompletedThisScene = false;
    }
    public override void OnButtonClick()
    {
        var val_5;
        var val_6;
        this.OnButtonClick();
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                val_5 = null;
            val_5 = null;
            val_6 = 37;
        }
        else
        {
                val_5 = null;
            val_5 = null;
            val_6 = 36;
        }
        
        AmplitudePluginHelper.lastFeatureAccessPoint = 36;
        WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGChallengeWindow>(showNext:  false);
    }
    private void OnDestroy()
    {
        WGChallengeController val_1 = MonoSingletonSelfGenerating<WGChallengeController>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.onAnyChallengeProgress, value:  new System.Action<System.Boolean, ChallengeType>(object:  this, method:  System.Void WGChallengeButton::OnProgressGained(bool isComplete, ChallengeType cType)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.onAnyChallengeProgress = val_3;
        UnityEngine.SceneManagement.SceneManager.remove_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void WGChallengeButton::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
        return;
        label_5:
    }
    public WGChallengeButton()
    {
    
    }

}
