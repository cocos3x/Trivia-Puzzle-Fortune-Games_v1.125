using UnityEngine;
public class WGLanguageSelectPopup : MonoBehaviour
{
    // Fields
    private LanguageSelectToggle _toggleButtonPrefab;
    private UnityEngine.UI.ToggleGroup togglesParent;
    private System.Collections.Generic.List<UnityEngine.Sprite> flags;
    private UnityEngine.GameObject bottom_confirm_group;
    private UnityEngine.UI.Button button_confirm;
    private UnityEngine.UI.Button button_close;
    private UnityEngine.GameObject main_vertical_group;
    private System.Collections.Generic.List<UnityEngine.UI.Toggle> toggleButtons;
    private System.Collections.Generic.List<LanguageSelectToggle> languageSelections;
    private System.Collections.Generic.List<string> languageNames;
    private bool hasInitialized;
    private string useLanguage;
    private System.Collections.Generic.Dictionary<string, string> defaultLanguageNames;
    
    // Properties
    private LanguageSelectToggle toggleButtonPrefab { get; }
    
    // Methods
    private LanguageSelectToggle get_toggleButtonPrefab()
    {
        LanguageSelectToggle val_3;
        if(this._toggleButtonPrefab == 0)
        {
                this._toggleButtonPrefab = PrefabLoader.LoadPrefab<LanguageSelectToggle>(featureName:  "LanguageSelect");
            return val_3;
        }
        
        val_3 = this._toggleButtonPrefab;
        return val_3;
    }
    private void Awake()
    {
        UnityEngine.Events.UnityAction val_11;
        var val_12;
        UnityEngine.RectTransform val_13;
        UnityEngine.Events.UnityAction val_1 = null;
        val_11 = val_1;
        val_1 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLanguageSelectPopup::OnClick_Close());
        this.button_close.m_OnClick.AddListener(call:  val_1);
        if(this.toggleButtonPrefab == 0)
        {
                return;
        }
        
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnWordData");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnLocalize");
        UnityEngine.Events.UnityAction val_6 = null;
        val_11 = val_6;
        val_6 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLanguageSelectPopup::OnClick_Confirm());
        this.button_confirm.m_OnClick.AddListener(call:  val_6);
        this.main_vertical_group.SetActive(value:  false);
        this.languageNames = Localization.GetLanguageNames();
        if(1152921517887925776 == 1)
        {
                this.GenerateToggleableButton(language:  null, isSolo:  true, flag:  this.GetFlagSpriteByIndex(index:  0));
            val_12 = 0;
        }
        else
        {
                if(1152921517887925776 >= 1)
        {
                do
        {
            if(0 >= 1152921517887925776)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            this.GenerateToggleableButton(language:  null, isSolo:  false, flag:  this.GetFlagSpriteByIndex(index:  0));
            val_11 = 0 + 1;
        }
        while(val_11 < 44475768);
        
        }
        
            val_12 = 1;
        }
        
        this.bottom_confirm_group.SetActive(value:  true);
        this.main_vertical_group.SetActive(value:  true);
        UnityEngine.Transform val_10 = this.main_vertical_group.transform;
        if(val_10 != null)
        {
                val_10 = (null == null) ? (val_10) : 0;
        }
        else
        {
                val_13 = 0;
        }
        
        UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot:  val_13);
        this.hasInitialized = true;
    }
    private UnityEngine.Sprite GetFlagSpriteByIndex(int index)
    {
        var val_1;
        bool val_1 = true;
        if((this.flags != null) && (val_1 > index))
        {
                if(val_1 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_1 = val_1 + (index << 3);
            val_1 = mem[(true + (index) << 3) + 32];
            val_1 = (true + (index) << 3) + 32;
            return (UnityEngine.Sprite)val_1;
        }
        
        val_1 = 0;
        return (UnityEngine.Sprite)val_1;
    }
    private void GenerateToggleableButton(string language, bool isSolo, UnityEngine.Sprite flag)
    {
        if(flag == 0)
        {
                return;
        }
        
        LanguageSelectToggle val_4 = UnityEngine.Object.Instantiate<LanguageSelectToggle>(original:  this.toggleButtonPrefab, parent:  this.togglesParent.transform);
        string val_5 = val_4.FormatNameToKey(fileName:  language);
        val_4.Setup(locLanguage:  Localization.Localize(key:  val_5, defaultValue:  this.defaultLanguageNames.Item[val_5.FormatNameToKey(fileName:  language)], useSingularKey:  false), isSolo:  (this.languageNames == 1) ? 1 : 0, flag:  flag);
        val_4.toggle.name = language;
        val_4.toggle.group = this.togglesParent;
        val_4.toggle.onValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  this, method:  System.Void WGLanguageSelectPopup::OnValueChanged(bool isOn)));
        if(isSolo == true)
        {
            goto label_12;
        }
        
        GameBehavior val_11 = App.getBehavior;
        if((System.String.op_Equality(a:  language, b:  val_11.<metaGameBehavior>k__BackingField.GetCurrentLanguage())) == false)
        {
            goto label_17;
        }
        
        label_12:
        val_4.toggle.isOn = true;
        this.useLanguage = language;
        goto label_18;
        label_17:
        val_4.toggle.isOn = false;
        label_18:
        this.toggleButtons.Add(item:  val_4.toggle);
        this.languageSelections.Add(item:  val_4);
    }
    private string FormatNameToKey(string fileName)
    {
        return System.String.Format(format:  "{0}_upper", arg0:  fileName);
    }
    private void OnLocalize()
    {
        var val_6 = 4;
        do
        {
            var val_1 = val_6 - 4;
            if(val_1 >= true)
        {
                return;
        }
        
            if(true <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(W9 <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(true <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            0.Setup(locLanguage:  Localization.Localize(key:  this.FormatNameToKey(fileName:  0), defaultValue:  this.defaultLanguageNames.Item[this.FormatNameToKey(fileName:  0)], useSingularKey:  false), isSolo:  (this.languageNames == 1) ? 1 : 0, flag:  0);
            val_6 = val_6 + 1;
        }
        while(this.languageSelections != null);
        
        throw new NullReferenceException();
    }
    private void OnValueChanged(bool isOn)
    {
        System.Collections.Generic.List<UnityEngine.UI.Toggle> val_2;
        if(this.hasInitialized == false)
        {
                return;
        }
        
        if(isOn == false)
        {
                return;
        }
        
        val_2 = this.toggleButtons;
        var val_3 = 4;
        label_8:
        var val_1 = val_3 - 4;
        if(val_1 >= this.hasInitialized)
        {
                return;
        }
        
        if(this.hasInitialized <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((this.hasInitialized + 32 + 280) != 0)
        {
            goto label_7;
        }
        
        val_3 = val_3 + 1;
        if(this.toggleButtons != null)
        {
            goto label_8;
        }
        
        label_7:
        val_2 = this.toggleButtons;
        if((this.hasInitialized + 32 + 280) <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.useLanguage = this.hasInitialized + 32 + 280 + 32.name;
    }
    private void OnClick_Confirm()
    {
        UnityEngine.PlayerPrefs.SetString(key:  "Language", value:  this.useLanguage);
        GameBehavior val_1 = App.getBehavior;
        if((System.String.op_Inequality(a:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  this.useLanguage)) != false)
        {
                UnityEngine.PlayerPrefs.SetInt(key:  "settings_override_language", value:  1);
        }
        
        Localization.GAME_NAME.__unknownFiledOffset_38 = this.useLanguage;
        Localization.GAME_NAME.currentLanguage = this.useLanguage;
        GameBehavior val_4 = App.getBehavior;
        Localization.GAME_NAME.setLocalizedCurrency(currencyKey:  val_4.<metaGameBehavior>k__BackingField);
        WordApp.LanguageChanged();
        CUtils.ReloadScene(useScreenFader:  false);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGLanguageSelectPopup()
    {
        this.useLanguage = "";
        System.Collections.Generic.Dictionary<System.String, System.String> val_1 = new System.Collections.Generic.Dictionary<System.String, System.String>();
        val_1.Add(key:  "en_upper", value:  "ENGLISH");
        val_1.Add(key:  "es_upper", value:  "SPANISH");
        val_1.Add(key:  "fr_upper", value:  "FRENCH");
        val_1.Add(key:  "de_upper", value:  "GERMAN");
        this.defaultLanguageNames = val_1;
    }

}
