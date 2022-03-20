using UnityEngine;
public abstract class UGUILocalizeComponent : MonoBehaviour
{
    // Fields
    public string key;
    public string[] keyParams;
    public bool localizeKeyParams;
    public bool isTitle;
    protected string mLanguage;
    protected bool mStarted;
    private bool hasFormattedUnlocalizedText;
    
    // Methods
    private void OnLocalize()
    {
        if(Localization.GAME_NAME == 0)
        {
                return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if((System.String.op_Inequality(a:  this.mLanguage, b:  val_2.<metaGameBehavior>k__BackingField.GetCurrentLanguage())) == false)
        {
                return;
        }
        
        this = ???;
        goto typeof(UGUILocalizeComponent).__il2cppRuntimeField_170;
    }
    private void OnEnable()
    {
        if(this.mStarted == false)
        {
                return;
        }
        
        if(Localization.GAME_NAME == 0)
        {
                return;
        }
        
        this = ???;
        goto typeof(UGUILocalizeComponent).__il2cppRuntimeField_170;
    }
    private void Awake()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnLocalize");
    }
    private void Start()
    {
        this.mStarted = true;
        if(Localization.GAME_NAME == 0)
        {
                return;
        }
        
        this = ???;
        goto typeof(UGUILocalizeComponent).__il2cppRuntimeField_170;
    }
    public virtual void Localize()
    {
        this.mLanguage = Localization.GAME_NAME + 80;
        if((System.String.IsNullOrEmpty(value:  Localization.GAME_NAME + 80)) != false)
        {
                if((System.String.IsNullOrEmpty(value:  this.key)) != false)
        {
                this.key = this;
        }
        
        }
        
        string val_3 = this.getLocalizedValue(k:  this.key);
        if(val_3 == null)
        {
            goto label_5;
        }
        
        if(this.isTitle == false)
        {
            goto label_6;
        }
        
        label_17:
        string val_6 = System.String.Format(format:  App.getGameEcon.titleFormat, arg0:  val_3);
        goto label_10;
        label_5:
        if((this.keyParams == null) || (this.keyParams.Length == 0))
        {
            goto label_12;
        }
        
        if(this.isTitle == false)
        {
            goto label_13;
        }
        
        string val_8 = App.getGameEcon.titleFormat;
        string val_9 = System.String.Format(format:  this, args:  this.keyParams);
        goto label_17;
        label_6:
        label_10:
        label_26:
        if(UnityEngine.Application.isPlaying != false)
        {
                return;
        }
        
        this.gameObject.SetActive(value:  false);
        this.gameObject.SetActive(value:  true);
        return;
        label_12:
        if((this.isTitle == false) || (this.hasFormattedUnlocalizedText == true))
        {
            goto label_26;
        }
        
        string val_15 = System.String.Format(format:  App.getGameEcon.titleFormat, arg0:  this);
        this.hasFormattedUnlocalizedText = true;
        goto label_26;
        label_13:
        string val_16 = System.String.Format(format:  this, args:  this.keyParams);
        goto label_10;
    }
    protected abstract string getCurrentText(); // 0
    public abstract void updateLabel(string val); // 0
    private string getLocalizedValue(string k)
    {
        System.Array val_8;
        System.String[] val_10;
        val_8 = this;
        bool val_1 = System.String.IsNullOrEmpty(value:  k);
        if((System.String.op_Equality(a:  Localization.GAME_NAME.Get(key:  k, defaultValue:  "", useSingularKey:  false), b:  k)) != false)
        {
                return 0;
        }
        
        if(this.keyParams == null)
        {
                return Localization.GAME_NAME.Get(key:  k, defaultValue:  "", useSingularKey:  false);
        }
        
        if(this.keyParams.Length == 0)
        {
                return Localization.GAME_NAME.Get(key:  k, defaultValue:  "", useSingularKey:  false);
        }
        
        if(this.localizeKeyParams != false)
        {
                string[] val_4 = new string[0];
            val_8 = val_4;
            System.Array.Copy(sourceArray:  this.keyParams, destinationArray:  val_4, length:  this.keyParams.Length);
            int val_8 = val_4.Length;
            if(val_8 >= 1)
        {
                var val_9 = 0;
            val_8 = val_8 & 4294967295;
            do
        {
            mem2[0] = Localization.GAME_NAME.Get(key:  null, defaultValue:  1152921505059157200, useSingularKey:  false);
            val_9 = val_9 + 1;
        }
        while(val_9 < (val_4.Length << ));
        
        }
        
            string val_6 = Localization.GAME_NAME.Get(key:  k, defaultValue:  "", useSingularKey:  false);
            val_10 = val_8;
            return System.String.Format(format:  Localization.GAME_NAME.Get(key:  k, defaultValue:  "", useSingularKey:  false), args:  val_10 = this.keyParams);
        }
        
        return System.String.Format(format:  Localization.GAME_NAME.Get(key:  k, defaultValue:  "", useSingularKey:  false), args:  val_10);
    }
    protected UGUILocalizeComponent()
    {
    
    }

}
