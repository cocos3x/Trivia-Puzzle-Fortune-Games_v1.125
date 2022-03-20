using UnityEngine;
public class ForestMasterPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button buttonClose;
    private UnityEngine.UI.Slider progressBar;
    private UnityEngine.UI.Text progressBarText;
    private UnityEngine.UI.Text coinsRewardText;
    private UnityEngine.UI.Text acornsRewardText;
    private UnityEngine.UI.Button growButton;
    private UnityEngine.UI.Text timerText;
    private DG.Tweening.Sequence timerSequence;
    
    // Methods
    private void Start()
    {
        this.buttonClose.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ForestMasterPopup::Close()));
        this.growButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ForestMasterPopup::OnGrowButtonClicked()));
        float val_16 = 100f;
        val_16 = (((float)MonoSingleton<WordForest.WFOForestManager>.Instance.CurrentForestGrowth) / ((float)MonoSingleton<WordForest.WFOForestManager>.Instance.CurrentMaxGrowth)) * val_16;
        string val_9 = System.String.Format(format:  "{0}%", arg0:  UnityEngine.Mathf.RoundToInt(f:  val_16));
        decimal val_10 = ForestMasterEventHandler.<Instance>k__BackingField.GetCoinReward(showCurrentLevel:  true);
        GameEcon val_11 = App.getGameEcon;
        string val_12 = val_10.flags.ToString(format:  val_11.numberFormatInt);
        GameEcon val_14 = App.getGameEcon;
        string val_15 = ForestMasterEventHandler.<Instance>k__BackingField.GetAcornReward(showCurrentLevel:  true).ToString(format:  val_14.numberFormatInt);
        this.SetTimer();
    }
    private void OnDisable()
    {
        if(this.timerSequence == null)
        {
                return;
        }
        
        DG.Tweening.TweenExtensions.Kill(t:  this.timerSequence, complete:  false);
    }
    private void OnDestroy()
    {
        if(this.timerSequence == null)
        {
                return;
        }
        
        DG.Tweening.TweenExtensions.Kill(t:  this.timerSequence, complete:  false);
    }
    private void SetTimer()
    {
        if(this.timerSequence != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.timerSequence, complete:  false);
        }
        
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        this.timerSequence = val_1;
        DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void ForestMasterPopup::<SetTimer>b__11_0()));
        DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.timerSequence, interval:  1f);
        DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  this.timerSequence, loops:  0);
    }
    private string GetTimerText()
    {
        object[] val_1 = new object[4];
        val_1[0] = ForestMasterEventHandler.<Instance>k__BackingField.Days;
        val_1[1] = ForestMasterEventHandler.<Instance>k__BackingField.Hours;
        val_1[2] = ForestMasterEventHandler.<Instance>k__BackingField.Minutes;
        val_1[3] = ForestMasterEventHandler.<Instance>k__BackingField.Seconds;
        return (string)System.String.Format(format:  "{0}:{1:00}:{2:00}:{3:00}", args:  val_1);
    }
    private void OnGrowButtonClicked()
    {
        UnityEngine.Object val_10;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        if(SceneDictator.IsInGameScene() != false)
        {
                WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance;
            if(this != 0)
        {
                val_10 = MonoSingleton<WGWindowManager>.Instance.GetComponentInChildren<WGLevelClearPopup>();
            if(val_10 != 0)
        {
                val_10.CloseAndGoToScene(scene:  5);
            return;
        }
        
        }
        
        }
        
        GameBehavior val_8 = App.getBehavior;
        if((val_8.<metaGameBehavior>k__BackingField) == 5)
        {
                return;
        }
        
        GameBehavior val_9 = App.getBehavior;
        val_10 = ???;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public ForestMasterPopup()
    {
    
    }
    private void <SetTimer>b__11_0()
    {
        string val_1 = this.GetTimerText();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }

}
