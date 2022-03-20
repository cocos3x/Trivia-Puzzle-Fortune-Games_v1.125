using UnityEngine;
public class FTUXFeatureWindow : MonoBehaviour
{
    // Fields
    private UnityEngine.Transform window;
    private UnityEngine.UI.Text description;
    private UnityEngine.UI.Button button;
    private UnityEngine.UI.Text buttonText;
    private UnityEngine.GameObject shuffleFtux;
    private UnityEngine.GameObject pickerHintFtux;
    private System.Collections.Generic.List<UnityEngine.UI.Button> ftuxButtons;
    private System.Collections.Generic.List<UnityEngine.Transform> highlightFeatures;
    private UnityEngine.GameObject handPickTarget;
    private bool isSetup;
    private bool isEnabledCalled;
    
    // Methods
    private void OnEnable()
    {
        this.highlightFeatures.Add(item:  this.window);
        if(this.isSetup != false)
        {
                MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
            MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
            MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  this.highlightFeatures.ToArray());
            GameBehavior val_6 = App.getBehavior;
            if(App.Player != (val_6.<metaGameBehavior>k__BackingField))
        {
                return;
        }
        
            if(this.handPickTarget == 0)
        {
                return;
        }
        
            this.pickerHintFtux.SetActive(value:  true);
            PluginExtension.MoveLocalY(transform:  this.window.transform, deltaY:  450f);
            DG.Tweening.Tween val_10 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.25f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void FTUXFeatureWindow::<OnEnable>b__11_0()), ignoreTimeScale:  true);
            return;
        }
        
        this.isEnabledCalled = true;
    }
    public void Setup(string description, string buttonText, System.Collections.Generic.List<UnityEngine.GameObject> featureTargets)
    {
        var val_2;
        var val_3;
        object val_17;
        UnityEngine.UI.Button val_18;
        System.Collections.Generic.List<UnityEngine.UI.Button> val_19;
        var val_20;
        val_17 = this;
        this.shuffleFtux.SetActive(value:  false);
        this.pickerHintFtux.SetActive(value:  false);
        List.Enumerator<T> val_1 = featureTargets.GetEnumerator();
        label_12:
        val_18 = public System.Boolean List.Enumerator<UnityEngine.GameObject>::MoveNext();
        if(val_3.MoveNext() == false)
        {
            goto label_6;
        }
        
        if(val_2 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_18 = public UnityEngine.UI.Button UnityEngine.GameObject::GetComponentInChildren<UnityEngine.UI.Button>();
        UnityEngine.UI.Button val_5 = val_2.GetComponentInChildren<UnityEngine.UI.Button>();
        val_19 = this.ftuxButtons;
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        val_18 = val_5;
        val_19.Add(item:  val_18);
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Events.UnityAction val_6 = null;
        val_18 = val_17;
        val_6 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FTUXFeatureWindow::Close());
        if(val_5.m_OnClick == null)
        {
                throw new NullReferenceException();
        }
        
        val_5.m_OnClick.AddListener(call:  val_6);
        val_18 = val_2.transform;
        if(this.highlightFeatures == null)
        {
                throw new NullReferenceException();
        }
        
        this.highlightFeatures.Add(item:  val_18);
        goto label_12;
        label_6:
        val_3.Dispose();
        this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FTUXFeatureWindow::Close()));
        val_20 = App.Player;
        GameBehavior val_10 = App.getBehavior;
        if(val_20 == (val_10.<metaGameBehavior>k__BackingField))
        {
                this.shuffleFtux.SetActive(value:  true);
        }
        else
        {
                val_20 = App.Player;
            GameBehavior val_12 = App.getBehavior;
            if(val_20 == (val_12.<metaGameBehavior>k__BackingField))
        {
                if((featureTargets + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            this.handPickTarget = featureTargets + 16 + 32;
        }
        
        }
        
        this.isSetup = true;
        if(this.isEnabledCalled == false)
        {
                return;
        }
        
        MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
        val_17 = MonoSingleton<GameMaskOverlay>.Instance;
        val_17.ShowOverlay(contentToOverlay:  this.highlightFeatures.ToArray());
    }
    private void Close()
    {
        object val_6;
        var val_8;
        List.Enumerator<T> val_1 = this.ftuxButtons.GetEnumerator();
        label_5:
        val_6 = public System.Boolean List.Enumerator<UnityEngine.UI.Button>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Events.UnityAction val_3 = null;
        val_6 = this;
        val_3 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FTUXFeatureWindow::Close());
        if(456 == 0)
        {
                throw new NullReferenceException();
        }
        
        456.RemoveListener(call:  val_3);
        goto label_5;
        label_2:
        0.Dispose();
        val_8 = null;
        MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.CloseOverlay(onClosed:  0);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public FTUXFeatureWindow()
    {
        this.ftuxButtons = new System.Collections.Generic.List<UnityEngine.UI.Button>();
        this.highlightFeatures = new System.Collections.Generic.List<UnityEngine.Transform>();
    }
    private void <OnEnable>b__11_0()
    {
        UnityEngine.Vector3 val_3 = this.handPickTarget.transform.position;
        this.pickerHintFtux.transform.position = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }

}
