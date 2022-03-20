using UnityEngine;
public class WGMessagePopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text title;
    private UnityEngine.UI.Text message;
    private UnityEngine.UI.Button close_button;
    private UnityEngine.UI.Button[] response_buttons;
    private UnityEngine.UI.Text[] response_buttons_text;
    private GemsCollectAnimationInstantiator gemsCollectAnimation;
    private WADPetFoodAnimationInstantiator petFoodCollectAnimation;
    private GridCoinCollectAnimationInstantiator coinCollectAnimation;
    private System.Func<bool>[] current_button_callbacks;
    private decimal showCollectAmount;
    private string showCollectType;
    private int dialogClickedIndex;
    
    // Methods
    private void Awake()
    {
        int val_3 = 0;
        do
        {
            if(val_3 >= this.response_buttons.Length)
        {
                return;
        }
        
            .<>4__this = this;
            .index = val_3;
            UnityEngine.UI.Button val_3 = this.response_buttons[val_3];
            this.response_buttons[0x0][0].m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new WGMessagePopup.<>c__DisplayClass11_0(), method:  System.Void WGMessagePopup.<>c__DisplayClass11_0::<Awake>b__0()));
            val_3 = val_3 + 1;
        }
        while(this.response_buttons != null);
        
        throw new NullReferenceException();
    }
    public void SetupMessage(string titleTxt, string messageTxt, bool[] shownButtons, string[] buttonTexts, bool showClose = True, System.Func<bool>[] buttonCallbacks, decimal collectAmount, string collectType = "credits")
    {
        var val_49;
        GridCoinCollectAnimationInstantiator val_50;
        if((System.String.IsNullOrEmpty(value:  titleTxt)) == false)
        {
            goto label_2;
        }
        
        if(this.title.transform.parent != 0)
        {
                if(this.title.transform.parent != null)
        {
            goto label_10;
        }
        
        }
        
        label_10:
        this.title.gameObject.SetActive(value:  false);
        label_2:
        this.current_button_callbacks = buttonCallbacks;
        this.showCollectAmount = collectAmount;
        mem[1152921517927982056] = collectAmount.lo;
        this.showCollectType = collectType;
        var val_52 = 0;
        label_29:
        if(val_52 >= this.response_buttons.Length)
        {
            goto label_15;
        }
        
        this.response_buttons[val_52].gameObject.SetActive(value:  true);
        UnityEngine.UI.Text val_50 = this.response_buttons_text[val_52];
        this.response_buttons[val_52].interactable = true;
        val_52 = val_52 + 1;
        if(this.response_buttons != null)
        {
            goto label_29;
        }
        
        label_15:
        this.close_button.gameObject.SetActive(value:  showClose);
        val_49 = null;
        val_49 = null;
        if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = this.showCollectAmount, hi = this.showCollectAmount, lo = showClose, mid = showClose}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                val_50 = this.coinCollectAnimation;
            if(val_50 != 0)
        {
                val_50 = this.coinCollectAnimation.gameObject;
            if(val_50 != 0)
        {
                this.coinCollectAnimation.gameObject.SetActive(value:  false);
        }
        
        }
        
            if((System.String.op_Inequality(a:  collectType, b:  "gems")) != false)
        {
                val_50 = this.gemsCollectAnimation;
            if(val_50 != 0)
        {
                val_50 = this.gemsCollectAnimation.gameObject;
            if(val_50 != 0)
        {
                this.gemsCollectAnimation.gameObject.SetActive(value:  false);
        }
        
        }
        
        }
        
            if(((System.String.op_Inequality(a:  collectType, b:  "pets_food")) != false) && (this.petFoodCollectAnimation != 0))
        {
                if(this.petFoodCollectAnimation.gameObject != 0)
        {
                this.petFoodCollectAnimation.gameObject.SetActive(value:  false);
        }
        
        }
        
            DeviceKeypressManager.AddBackAction(backAction:  new System.Action(object:  this, method:  System.Void WGMessagePopup::HandleBackPressed()));
            return;
        }
        
        if((System.String.op_Equality(a:  collectType, b:  "credits")) != false)
        {
                if(this.coinCollectAnimation == 0)
        {
                UnityEngine.GameObject val_29 = new UnityEngine.GameObject(name:  "GridCoinCollectAnimationInstantiator");
            val_29.transform.SetParent(p:  this.transform);
            val_29.transform.SetAsLastSibling();
            UnityEngine.Vector3 val_34 = UnityEngine.Vector3.zero;
            val_29.transform.localPosition = new UnityEngine.Vector3() {x = val_34.x, y = val_34.y, z = val_34.z};
            UnityEngine.Vector3 val_36 = UnityEngine.Vector3.one;
            val_29.transform.localScale = new UnityEngine.Vector3() {x = val_36.x, y = val_36.y, z = val_36.z};
            UnityEngine.RectTransform val_37 = val_29.AddComponent<UnityEngine.RectTransform>();
            UnityEngine.Vector3 val_38 = UnityEngine.Vector3.zero;
            UnityEngine.Vector2 val_39 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_38.x, y = val_38.y, z = val_38.z});
            val_37.sizeDelta = new UnityEngine.Vector2() {x = val_39.x, y = val_39.y};
            UnityEngine.Vector2 val_40 = new UnityEngine.Vector2(x:  0f, y:  1f);
            val_37.anchorMax = new UnityEngine.Vector2() {x = val_40.x, y = val_40.y};
            val_37.anchorMin = new UnityEngine.Vector2() {x = val_40.x, y = val_40.y};
            UnityEngine.Vector2 val_41 = new UnityEngine.Vector2(x:  20f, y:  -65f);
            val_37.anchoredPosition = new UnityEngine.Vector2() {x = val_41.x, y = val_41.y};
            this.coinCollectAnimation = val_29.AddComponent<GridCoinCollectAnimationInstantiator>();
            mem2[0] = 0;
        }
        
        }
        
        val_50 = 1152921504765632512;
        if(this.coinCollectAnimation != 0)
        {
                if(this.coinCollectAnimation != 0)
        {
                mem2[0] = 0;
        }
        
        }
        
        if(this.gemsCollectAnimation != 0)
        {
                if(this.gemsCollectAnimation != 0)
        {
                mem2[0] = 0;
        }
        
        }
        
        if(this.petFoodCollectAnimation == 0)
        {
                return;
        }
        
        if(this.petFoodCollectAnimation == 0)
        {
                return;
        }
        
        mem2[0] = 0;
    }
    public void OnDialogClick(int index)
    {
        decimal val_22;
        var val_23;
        var val_24;
        GemsCollectAnimationInstantiator val_26;
        int val_27;
        var val_28;
        decimal val_29;
        var val_30;
        this.dialogClickedIndex = index;
        val_23 = null;
        val_23 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = this.showCollectAmount, hi = this.showCollectAmount, lo = 41963520}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_3;
        }
        
        this.response_buttons[(long)index].interactable = false;
        if((System.String.op_Equality(a:  this.showCollectType, b:  "credits")) == false)
        {
            goto label_7;
        }
        
        this.coinCollectAnimation.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGMessagePopup::DoCloseCallbacks());
        UnityEngine.Vector3 val_5 = this.response_buttons[(long)index].transform.position;
        UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  0f, y:  1.2f, z:  0f);
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, b:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z});
        this.coinCollectAnimation.SetCoinStartPosition(pos:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z});
        Player val_8 = App.Player;
        val_22 = val_8._credits;
        Player val_9 = App.Player;
        decimal val_10 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_9._credits, hi = val_9._credits, lo = X25, mid = X25}, d2:  new System.Decimal() {flags = this.showCollectAmount, hi = this.showCollectAmount, lo = this.coinCollectAnimation, mid = this.coinCollectAnimation});
        this.coinCollectAnimation.Play(fromValue:  new System.Decimal() {flags = val_22, hi = val_22, lo = (long)index, mid = (long)index}, toValue:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, textTickTime:  0.5f, delayBeforeComplete:  0.25f);
        goto label_23;
        label_3:
        this.DoCloseCallbacks();
        return;
        label_7:
        if((System.String.op_Equality(a:  this.showCollectType, b:  "gems")) != false)
        {
                mem2[0] = new System.Action(object:  this, method:  System.Void WGMessagePopup::DoCloseCallbacks());
            val_26 = this.gemsCollectAnimation;
            Player val_13 = App.Player;
            val_22 = val_13._gems;
            Player val_14 = App.Player;
            decimal val_15 = System.Convert.ToDecimal(value:  val_14._gems);
            val_24 = val_15.lo;
            val_27 = val_15.flags;
            val_28 = val_24;
            val_29 = this.showCollectAmount;
            val_30 = X23;
        }
        else
        {
                if((System.String.op_Equality(a:  this.showCollectType, b:  "pets_food")) == false)
        {
                return;
        }
        
            mem2[0] = new System.Action(object:  this, method:  System.Void WGMessagePopup::DoCloseCallbacks());
            val_26 = this.petFoodCollectAnimation;
            Player val_18 = App.Player;
            val_22 = val_18._food;
            Player val_19 = App.Player;
            val_27 = val_19._food;
            val_28 = 0;
            decimal val_20 = System.Decimal.op_Implicit(value:  val_27);
            val_29 = this.showCollectAmount;
        }
        
        decimal val_21 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_20.flags, hi = val_20.hi, lo = val_20.lo, mid = val_20.mid}, d2:  new System.Decimal() {flags = val_29, hi = val_29});
        val_26.Play(fromValue:  val_22, toValue:  new System.Decimal() {flags = val_21.flags, hi = val_21.hi, lo = val_21.lo, mid = val_21.mid}, textTickTime:  0.5f, delayBeforeComplete:  0.25f, destinationObject:  0, originObject:  0);
        label_23:
        this.showCollectAmount = System.Decimal.MinusOne;
    }
    private void DoCloseCallbacks()
    {
        int val_4;
        if(this.current_button_callbacks == null)
        {
            goto label_1;
        }
        
        val_4 = this;
        if(this.current_button_callbacks[this.dialogClickedIndex].Invoke() == false)
        {
            goto label_5;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        goto label_5;
        label_1:
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        val_4 = this.dialogClickedIndex;
        label_5:
        mem2[0] = 0;
    }
    public void OnDisable()
    {
        DeviceKeypressManager.RemoveBackAction(backAction:  new System.Action(object:  this, method:  System.Void WGMessagePopup::HandleBackPressed()));
        this.current_button_callbacks = 0;
        this.dialogClickedIndex = 0;
    }
    public void SetupInternetRequired(System.Func<bool>[] buttonCallbacks)
    {
        int val_6;
        var val_7;
        bool[] val_3 = new bool[2];
        val_3[0] = true;
        string[] val_4 = new string[2];
        val_6 = val_4.Length;
        val_4[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_6 = val_4.Length;
        val_4[1] = "NULL";
        val_7 = null;
        val_7 = null;
        this.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_3, buttonTexts:  val_4, showClose:  false, buttonCallbacks:  buttonCallbacks, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    public void SetupPurchaseFail(System.Func<bool>[] buttonCallbacks)
    {
        int val_6;
        var val_7;
        bool[] val_3 = new bool[2];
        val_3[0] = true;
        string[] val_4 = new string[2];
        val_6 = val_4.Length;
        val_4[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_6 = val_4.Length;
        val_4[1] = "NO";
        val_7 = null;
        val_7 = null;
        this.SetupMessage(titleTxt:  Localization.Localize(key:  "purchase_failed_upper", defaultValue:  "", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "purchase_failed_explanation", defaultValue:  "", useSingularKey:  false), shownButtons:  val_3, buttonTexts:  val_4, showClose:  false, buttonCallbacks:  buttonCallbacks, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void HandleBackPressed()
    {
        if(((this.close_button.gameObject.activeInHierarchy != true) && (this.current_button_callbacks != null)) && (this.current_button_callbacks.Length != 0))
        {
                if(this.current_button_callbacks[0].Invoke() == false)
        {
                return;
        }
        
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGMessagePopup()
    {
        null = null;
        this.showCollectAmount = System.Decimal.MinusOne;
        this.dialogClickedIndex = 0;
        this.showCollectType = "";
    }

}
