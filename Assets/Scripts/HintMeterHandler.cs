using UnityEngine;
public class HintMeterHandler : HintFeatureHandler
{
    // Fields
    private static HintMeterHandler _Instance;
    private int progress;
    public System.Action<int> hintMeterUpdate;
    
    // Properties
    public static HintMeterHandler Instance { get; }
    public int progressTowardsFreeHint { get; set; }
    public int freeHintsRemaining { get; set; }
    private bool hasSeenSuperHintFtux { get; set; }
    public override bool freeHintEligable { get; }
    public override bool hasFreeHintsRemaining { get; }
    
    // Methods
    public static HintMeterHandler get_Instance()
    {
        return (HintMeterHandler)HintMeterHandler._Instance;
    }
    public int get_progressTowardsFreeHint()
    {
        return CPlayerPrefs.GetInt(key:  "hintMeterProgress", defaultValue:  0);
    }
    public void set_progressTowardsFreeHint(int value)
    {
        CPlayerPrefs.SetInt(key:  "hintMeterProgress", val:  value);
    }
    public int get_freeHintsRemaining()
    {
        return CPlayerPrefs.GetInt(key:  "hintMeterHints", defaultValue:  0);
    }
    public void set_freeHintsRemaining(int value)
    {
        CPlayerPrefs.SetInt(key:  "hintMeterHints", val:  value);
    }
    private bool get_hasSeenSuperHintFtux()
    {
        return CPlayerPrefs.GetBool(key:  "superHintFtux", defaultValue:  false);
    }
    private void set_hasSeenSuperHintFtux(bool value)
    {
        value = value;
        CPlayerPrefs.SetBool(key:  "superHintFtux", value:  value);
    }
    private void Awake()
    {
        HintMeterHandler._Instance = this;
    }
    public override void OnLevelStarted()
    {
        int val_1 = this.freeHintsRemaining;
        if(val_1 == 0)
        {
                return;
        }
        
        val_1.DoFreeHints();
    }
    public override bool get_freeHintEligable()
    {
        return false;
    }
    public override void OnHintUsed(bool freeHint)
    {
        string val_21;
        var val_22;
        val_21 = "hintMeterProgress";
        if((CPlayerPrefs.HasKey(key:  val_21)) != true)
        {
                val_22 = 1152921504893161472;
            val_21 = MonoSingleton<HintFeatureManager>.Instance;
            if(val_21 != 0)
        {
                HintFeatureManager val_4 = MonoSingleton<HintFeatureManager>.Instance;
            val_21 = val_4.<wgHbutton>k__BackingField;
            if(val_21 != 0)
        {
                HintFeatureManager val_6 = MonoSingleton<HintFeatureManager>.Instance;
            val_21 = val_6.<wgHbutton>k__BackingField;
            val_21.SetPopup(message:  Localization.Localize(key:  "hintmeter_tooltip", defaultValue:  "Every 4th hint is a SUPER HINT!!", useSingularKey:  false), interactablePopup:  false);
        }
        
        }
        
        }
        
        int val_8 = val_21.progressTowardsFreeHint;
        val_8.progressTowardsFreeHint = val_8 + 1;
        int val_10 = val_8.progressTowardsFreeHint;
        if((val_10 == 3) && (val_10.hasSeenSuperHintFtux != true))
        {
                val_22 = 1152921504893161472;
            val_21 = MonoSingleton<HintFeatureManager>.Instance;
            if(val_21 != 0)
        {
                HintFeatureManager val_14 = MonoSingleton<HintFeatureManager>.Instance;
            val_21 = val_14.<wgHbutton>k__BackingField;
            if(val_21 != 0)
        {
                HintFeatureManager val_16 = MonoSingleton<HintFeatureManager>.Instance;
            val_21 = val_16.<wgHbutton>k__BackingField;
            val_21.SetPopup(message:  Localization.Localize(key:  "hintmeterfull_tooltip", defaultValue:  "SUPER HINT Ready!", useSingularKey:  false), interactablePopup:  false);
        }
        
        }
        
            val_21.hasSeenSuperHintFtux = true;
        }
        
        int val_18 = val_21.progressTowardsFreeHint;
        if(val_18 == 4)
        {
                val_18.progressTowardsFreeHint = 0;
            App.getGameEcon.freeHintsRemaining = val_19.hintMeterFreeHints;
            val_21 = this;
            this.Invoke(methodName:  "DoFreeHints", time:  0.1f);
        }
        
        if(this.hintMeterUpdate == null)
        {
                return;
        }
        
        this.hintMeterUpdate.Invoke(obj:  this.progressTowardsFreeHint);
    }
    public override void OnMyFreeHintUsed()
    {
        this.progressTowardsFreeHint = 0;
    }
    public override bool get_hasFreeHintsRemaining()
    {
        return true;
    }
    private void DoFreeHints()
    {
        System.Func<LineWord, System.Boolean> val_24;
        UnityEngine.Object val_25;
        WGHintButton val_26;
        var val_27;
        var val_28;
        var val_30;
        System.Func<Cell, System.Boolean> val_32;
        UnityEngine.Object val_33;
        val_24 = 1152921515468090304;
        val_25 = MonoSingleton<HintFeatureManager>.Instance;
        bool val_2 = UnityEngine.Object.op_Inequality(x:  val_25, y:  0);
        if(val_2 == false)
        {
            goto label_11;
        }
        
        HintFeatureManager val_3 = MonoSingleton<HintFeatureManager>.Instance;
        val_25 = val_3.<wgHbutton>k__BackingField;
        if(val_25 == 0)
        {
            goto label_11;
        }
        
        HintFeatureManager val_5 = MonoSingleton<HintFeatureManager>.Instance;
        val_26 = val_5.<wgHbutton>k__BackingField;
        goto label_15;
        label_11:
        val_26 = 0;
        label_15:
        if(val_2.freeHintsRemaining < 1)
        {
                return;
        }
        
        val_27 = 1152921516473430672;
        do
        {
            if(val_26 != 0)
        {
                val_26.ToggleInteractable(state:  false);
        }
        
            WordRegion val_8 = WordRegion.instance;
            if(val_8 == 0)
        {
                return;
        }
        
            WordRegion val_10 = WordRegion.instance;
            val_28 = null;
            val_28 = null;
            val_24 = HintMeterHandler.<>c.<>9__22_0;
            if(val_24 == null)
        {
                System.Func<LineWord, System.Boolean> val_11 = null;
            val_24 = val_11;
            val_11 = new System.Func<LineWord, System.Boolean>(object:  HintMeterHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean HintMeterHandler.<>c::<DoFreeHints>b__22_0(LineWord x));
            HintMeterHandler.<>c.<>9__22_0 = val_24;
        }
        
            System.Collections.Generic.List<TSource> val_13 = System.Linq.Enumerable.ToList<LineWord>(source:  System.Linq.Enumerable.Where<LineWord>(source:  val_8, predicate:  val_11));
            if(as. 
           
           
          
        
        
        
         == 0)
        {
                return;
        }
        
            int val_14 = UnityEngine.Random.Range(min:  0, max:  -1383468960);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_30 = null;
            val_30 = null;
            val_32 = HintMeterHandler.<>c.<>9__22_1;
            if(val_32 == null)
        {
                System.Func<Cell, System.Boolean> val_15 = null;
            val_32 = val_15;
            val_15 = new System.Func<Cell, System.Boolean>(object:  HintMeterHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean HintMeterHandler.<>c::<DoFreeHints>b__22_1(Cell x));
            HintMeterHandler.<>c.<>9__22_1 = val_32;
            val_27 = 1152921516473430672;
        }
        
            var val_24 = 1152921516473463440;
            val_24 = System.Linq.Enumerable.ToList<Cell>(source:  System.Linq.Enumerable.Where<Cell>(source:  (HintMeterHandler.<>c.__il2cppRuntimeField_static_fields + (val_14) << 3) + 32 + 40, predicate:  val_15));
            if(as. 
           
           
          
        
        
        
         == 0)
        {
                return;
        }
        
            int val_18 = UnityEngine.Random.Range(min:  0, max:  -1018285424);
            if(val_24 <= val_18)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_24 = val_24 + (val_18 << 3);
            val_24 = mem[(1152921516473463440 + (val_18) << 3) + 32];
            val_24 = (1152921516473463440 + (val_18) << 3) + 32;
            int val_20 = WordRegion.instance.freeHintsRemaining;
            val_20.freeHintsRemaining = val_20 - 1;
            val_33 = val_26;
            if(val_33 != 0)
        {
                val_33 = val_26;
            val_33.ToggleInteractable(state:  true);
        }
        
        }
        while(this.freeHintsRemaining > 0);
    
    }
    public HintMeterHandler()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
