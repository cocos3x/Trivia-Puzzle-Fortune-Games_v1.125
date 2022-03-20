using UnityEngine;
public class PortraitCollectionEventStartPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text collectionTitle;
    private UnityEngine.UI.Text descText;
    private UnityEngine.UI.Text timerText;
    private FPHPlayButton playButton;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Image collectionBanner;
    
    // Properties
    public FPHPlayButton getPlayButton { get; }
    
    // Methods
    public FPHPlayButton get_getPlayButton()
    {
        return (FPHPlayButton)this.playButton;
    }
    private void OnEnable()
    {
        FPHPortraitCollectionController val_1 = MonoSingleton<FPHPortraitCollectionController>.Instance;
        if(val_1.progress != null)
        {
                MonoSingleton<FPHPortraitCollectionController>.Instance.OnEventStartSeen();
            string val_3 = val_1.progress.chosenCollection.ToUpper();
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PortraitCollectionEventStartPopup::OnClose()));
            this.playButton.onPlayResult = new System.Action<System.Boolean>(object:  this, method:  System.Void PortraitCollectionEventStartPopup::OnPressPlayResult(bool result));
            this.collectionBanner.sprite = MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionBanner(collection:  val_1.progress.chosenCollection);
            FrameSkipper val_8 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(child:  this);
            val_8.updateLogic = new System.Action(object:  this, method:  System.Void PortraitCollectionEventStartPopup::UpdateTimerText());
            return;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnPressPlayResult(bool result)
    {
        System.Action val_6;
        var val_7;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) == 1) && (result != true))
        {
                WGStoreProxy val_2 = UnityEngine.Object.FindObjectOfType<WGStoreProxy>();
            if(val_2 != 0)
        {
                val_7 = null;
            val_7 = null;
            val_6 = PortraitCollectionEventStartPopup.<>c.<>9__9_0;
            if(val_6 == null)
        {
                System.Action val_4 = null;
            val_6 = val_4;
            val_4 = new System.Action(object:  PortraitCollectionEventStartPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void PortraitCollectionEventStartPopup.<>c::<OnPressPlayResult>b__9_0());
            PortraitCollectionEventStartPopup.<>c.<>9__9_0 = val_6;
        }
        
            val_2.Init(outOfCredits:  true, onCloseAction:  val_4);
        }
        
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void UpdateTimerText()
    {
        System.TimeSpan val_2 = MonoSingleton<FPHPortraitCollectionController>.Instance.GetTimeRemaining();
        object[] val_3 = new object[4];
        val_3[0] = val_2._ticks.Days.ToString(format:  "0");
        val_3[1] = val_2._ticks.Hours.ToString(format:  "0");
        val_3[2] = val_2._ticks.Minutes.ToString(format:  "0");
        val_3[3] = val_2._ticks.Seconds.ToString(format:  "0");
        string val_12 = System.String.Format(format:  "{0}d {1}h {2}m {3}s", args:  val_3);
    }
    private void OnClose()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public PortraitCollectionEventStartPopup()
    {
    
    }

}
