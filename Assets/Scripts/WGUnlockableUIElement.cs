using UnityEngine;
public class WGUnlockableUIElement : FrameSkipper, IPointerClickHandler, IEventSystemHandler
{
    // Fields
    protected UnityEngine.UI.Image lockImage;
    private System.Collections.Generic.List<UnityEngine.UI.Text> textToDarken;
    private System.Collections.Generic.List<UnityEngine.UI.Image> imageToDarken;
    private UnityEngine.Color textLockedColor;
    private UnityEngine.Color textUnlockedColor;
    public bool topToolTip;
    protected UnityEngine.UI.Button buttonToLock;
    protected WGUnlockableUIElement.UiLockedState myLastUiState;
    private UnityEngine.GameObject currentToolTip;
    private bool setSiblingIndexWhenHidden;
    private int startingSiblingIndex;
    private UnityEngine.UI.Button.ButtonClickedEvent desiredButtonClickEvent;
    
    // Properties
    protected virtual bool FeatureLocked { get; }
    protected virtual bool FeatureHidden { get; }
    protected virtual int UnlockLevel { get; }
    protected virtual string ToolTipText { get; }
    
    // Methods
    protected virtual void Start()
    {
        mem[1152921517996272624] = 60;
        if(this.buttonToLock == 0)
        {
                UnityEngine.Debug.LogError(message:  "make sure " + this.transform.name + " has a button for the WGUnlockableUIElement to work with");
            this.enabled = false;
            return;
        }
        
        this.buttonToLock.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGUnlockableUIElement::OnPreClickCheck()));
        if(this.setSiblingIndexWhenHidden != false)
        {
                this.startingSiblingIndex = this.gameObject.transform.GetSiblingIndex();
        }
        
        this.CheckHiddenOrLocked();
    }
    protected virtual void OnEnable()
    {
        this.myLastUiState = 0;
        goto typeof(WGUnlockableUIElement).__il2cppRuntimeField_170;
    }
    private void OnPreClickCheck()
    {
        this.buttonToLock.m_OnClick.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGUnlockableUIElement::OnPreClickCheck()));
        this.desiredButtonClickEvent = this.buttonToLock.m_OnClick;
        this.CheckHiddenOrLocked();
        if((this & 1) != 0)
        {
                return;
        }
        
        if((this & 1) != 0)
        {
                return;
        }
        
        if(this.desiredButtonClickEvent.GetPersistentEventCount() >= 1)
        {
                this.desiredButtonClickEvent.Invoke();
        }
        
        this.buttonToLock.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGUnlockableUIElement::OnPreClickCheck()));
    }
    protected virtual bool get_FeatureLocked()
    {
        return (bool)(App.Player < this) ? 1 : 0;
    }
    protected virtual bool get_FeatureHidden()
    {
        return false;
    }
    protected virtual int get_UnlockLevel()
    {
        return 0;
    }
    protected virtual string get_ToolTipText()
    {
        return (string)System.String.Format(format:  Localization.Localize(key:  "unlock_tooltip", defaultValue:  "Unlocks at level {0}", useSingularKey:  false), arg0:  this);
    }
    public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if(this.buttonToLock != null)
        {
                return;
        }
        
        if((this & 1) != 0)
        {
                return;
        }
        
        if((this & 1) == 0)
        {
                return;
        }
        
        goto typeof(WGUnlockableUIElement).__il2cppRuntimeField_1F0;
    }
    private void PlaceToolTip()
    {
        UnityEngine.GameObject val_8;
        UnityEngine.Object val_9;
        val_8 = 1152921504765632512;
        if(this.currentToolTip != 0)
        {
                return;
        }
        
        DynamicToolTip val_3 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        this.currentToolTip = val_3.gameObject;
        val_8 = this.buttonToLock.gameObject;
        val_9 = 0;
        if(this.lockImage != val_9)
        {
                val_9 = 0;
            val_8 = this.lockImage.gameObject;
        }
        
        val_3.ShowToolTip(objToToolTip:  val_8, text:  this, topToolTip:  this.topToolTip, displayDuration:  3.5f, width:  0f, height:  0f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
    }
    protected virtual void OnClickLocked()
    {
        this.PlaceToolTip();
    }
    protected virtual void OnClickUnlocked()
    {
    
    }
    protected override void UpdateLogic()
    {
        this.UpdateLogic();
        this.CheckHiddenOrLocked();
    }
    private void CheckHiddenOrLocked()
    {
        UnityEngine.Object val_14;
        var val_15;
        UnityEngine.Object val_34;
        UnityEngine.UI.Image val_35;
        UiLockedState val_36;
        if((this & 1) == 0)
        {
            goto label_1;
        }
        
        if(this.myLastUiState == 1)
        {
                return;
        }
        
        val_34 = 0;
        if((UnityEngine.Object.op_Implicit(exists:  this.lockImage)) != false)
        {
                val_35 = this.lockImage;
            if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
            val_34 = 0;
            UnityEngine.GameObject val_2 = val_35.gameObject;
            if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
            val_2.SetActive(value:  false);
        }
        
        val_34 = public static UnityEngine.CanvasGroup MethodExtensionForMonoBehaviourTransform::GetOrAddComponent<UnityEngine.CanvasGroup>(UnityEngine.GameObject gameObject);
        UnityEngine.CanvasGroup val_4 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.gameObject);
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34 = 0;
        val_4.alpha = 0f;
        if(this.setSiblingIndexWhenHidden != false)
        {
                val_34 = 0;
            UnityEngine.GameObject val_5 = this.gameObject;
            if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
            val_34 = 0;
            UnityEngine.Transform val_6 = val_5.transform;
            if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
            val_34 = 0;
            val_6.SetAsLastSibling();
        }
        
        val_35 = this.buttonToLock;
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35.interactable = false;
        val_36 = 1;
        goto label_65;
        label_1:
        if((this & 1) == 0)
        {
            goto label_14;
        }
        
        if(this.myLastUiState == 2)
        {
                return;
        }
        
        if((this.myLastUiState == 1) && (this.startingSiblingIndex != 1))
        {
                val_34 = 0;
            UnityEngine.GameObject val_7 = this.gameObject;
            if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
            val_34 = 0;
            UnityEngine.Transform val_8 = val_7.transform;
            if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
            val_8.SetSiblingIndex(index:  this.startingSiblingIndex);
        }
        
        val_34 = 0;
        if((UnityEngine.Object.op_Implicit(exists:  this.lockImage)) != false)
        {
                val_35 = this.lockImage;
            if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
            val_34 = 0;
            UnityEngine.GameObject val_10 = val_35.gameObject;
            if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
            val_10.SetActive(value:  true);
        }
        
        val_34 = public static UnityEngine.CanvasGroup MethodExtensionForMonoBehaviourTransform::GetOrAddComponent<UnityEngine.CanvasGroup>(UnityEngine.GameObject gameObject);
        UnityEngine.CanvasGroup val_12 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.gameObject);
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34 = 0;
        val_12.alpha = 1f;
        val_35 = this.buttonToLock;
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35.interactable = false;
        if((this.textToDarken == null) || (1152921513414506544 < 1))
        {
            goto label_86;
        }
        
        List.Enumerator<T> val_13 = this.textToDarken.GetEnumerator();
        label_31:
        val_34 = public System.Boolean List.Enumerator<UnityEngine.UI.Text>::MoveNext();
        if(val_15.MoveNext() == false)
        {
            goto label_29;
        }
        
        val_35 = val_14;
        if(val_35 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_31;
        label_14:
        if(this.myLastUiState == 3)
        {
                return;
        }
        
        if((this.myLastUiState == 1) && (this.startingSiblingIndex != 1))
        {
                val_34 = 0;
            UnityEngine.GameObject val_17 = this.gameObject;
            if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
            val_34 = 0;
            UnityEngine.Transform val_18 = val_17.transform;
            if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
            val_18.SetSiblingIndex(index:  this.startingSiblingIndex);
        }
        
        val_34 = 0;
        if((UnityEngine.Object.op_Implicit(exists:  this.lockImage)) != false)
        {
                val_35 = this.lockImage;
            if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
            val_34 = 0;
            UnityEngine.GameObject val_20 = val_35.gameObject;
            if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
            val_20.SetActive(value:  false);
        }
        
        val_34 = public static UnityEngine.CanvasGroup MethodExtensionForMonoBehaviourTransform::GetOrAddComponent<UnityEngine.CanvasGroup>(UnityEngine.GameObject gameObject);
        UnityEngine.CanvasGroup val_22 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.gameObject);
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34 = 0;
        val_22.alpha = 1f;
        val_35 = this.buttonToLock;
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35.interactable = true;
        if((this.textToDarken == null) || (1152921513414506544 < 1))
        {
            goto label_83;
        }
        
        List.Enumerator<T> val_23 = this.textToDarken.GetEnumerator();
        label_51:
        if(val_15.MoveNext() == false)
        {
            goto label_46;
        }
        
        val_35 = val_14;
        val_34 = 0;
        if(val_35 == val_34)
        {
            goto label_51;
        }
        
        if(val_14 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_51;
        label_29:
        val_15.Dispose();
        label_86:
        if((this.imageToDarken == null) || (1152921517997955296 < 1))
        {
            goto label_89;
        }
        
        List.Enumerator<T> val_26 = this.imageToDarken.GetEnumerator();
        label_56:
        val_34 = public System.Boolean List.Enumerator<UnityEngine.UI.Image>::MoveNext();
        if(val_15.MoveNext() == false)
        {
            goto label_54;
        }
        
        val_35 = 0;
        UnityEngine.Color val_28 = UnityEngine.Color.gray;
        if(val_14 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_56;
        label_46:
        val_15.Dispose();
        label_83:
        if((this.imageToDarken == null) || (1152921517997955296 < 1))
        {
            goto label_80;
        }
        
        List.Enumerator<T> val_29 = this.imageToDarken.GetEnumerator();
        label_64:
        if(val_15.MoveNext() == false)
        {
            goto label_59;
        }
        
        if(val_14 == 0)
        {
            goto label_64;
        }
        
        UnityEngine.Color val_32 = UnityEngine.Color.white;
        goto label_64;
        label_54:
        val_15.Dispose();
        label_89:
        val_36 = 2;
        goto label_65;
        label_59:
        val_15.Dispose();
        label_80:
        val_36 = 3;
        label_65:
        this.myLastUiState = val_36;
        if(val_36 == this.myLastUiState)
        {
                return;
        }
    
    }
    protected virtual void SetNewState(WGUnlockableUIElement.UiLockedState newState)
    {
    
    }
    protected virtual void UpdateButton()
    {
    
    }
    public WGUnlockableUIElement()
    {
        this.topToolTip = true;
        this.startingSiblingIndex = 0;
    }

}
