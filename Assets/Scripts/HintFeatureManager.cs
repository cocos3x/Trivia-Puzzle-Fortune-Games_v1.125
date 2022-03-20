using UnityEngine;
public class HintFeatureManager : MonoSingleton<HintFeatureManager>
{
    // Fields
    private System.Collections.Generic.List<HintFeatureHandler> freeHintManagers;
    private HintFeatureHandler lastChosen;
    private bool freeHintOnLastCheck;
    private WGHintButton <wgHbutton>k__BackingField;
    
    // Properties
    public WGHintButton wgHbutton { get; set; }
    public bool PlayerEligableFreeHint { get; }
    
    // Methods
    public WGHintButton get_wgHbutton()
    {
        return (WGHintButton)this.<wgHbutton>k__BackingField;
    }
    private void set_wgHbutton(WGHintButton value)
    {
        this.<wgHbutton>k__BackingField = value;
    }
    public override void InitMonoSingleton()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void HintFeatureManager::OnSceneLoaded(SceneType scene)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        return;
        label_5:
    }
    private void Start()
    {
        this.freeHintManagers.AddRange(collection:  this.gameObject.GetComponents<HintFeatureHandler>());
        List.Enumerator<T> val_3 = this.freeHintManagers.GetEnumerator();
        label_7:
        if(0.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((0 & 1) == 0)
        {
            goto label_7;
        }
        
        goto label_7;
        label_4:
        0.Dispose();
    }
    private void OnDestroy()
    {
        this.freeHintManagers.Clear();
    }
    private void OnSceneLoaded(SceneType scene)
    {
        var val_2;
        var val_3;
        UnityEngine.Events.UnityAction val_14;
        if(scene != 2)
        {
                return;
        }
        
        List.Enumerator<T> val_1 = this.freeHintManagers.GetEnumerator();
        label_5:
        if(val_3.MoveNext() == false)
        {
            goto label_3;
        }
        
        if(val_2 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_5;
        label_3:
        val_3.Dispose();
        if(WordRegion.instance != 0)
        {
                WordRegion.instance.addOnLevelLoadCompleteAction(callback:  new System.Action(object:  this, method:  System.Void HintFeatureManager::OnLevelStarted()));
        }
        
        val_14 = 1152921504877826048;
        if(MainController.instance != 0)
        {
                MainController val_11 = MainController.instance;
            UnityEngine.Events.UnityAction val_12 = null;
            val_14 = val_12;
            val_12 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void HintFeatureManager::OnLevelCompeleted());
            val_11.onLevelComplete.AddListener(call:  val_12);
        }
        
        this.UpdateFreeHintEligable();
    }
    private void OnLevelStarted()
    {
        List.Enumerator<T> val_1 = this.freeHintManagers.GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_4;
        label_2:
        0.Dispose();
    }
    private void OnLevelCompeleted()
    {
        List.Enumerator<T> val_1 = this.freeHintManagers.GetEnumerator();
        label_5:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((0 & 1) == 0)
        {
            goto label_5;
        }
        
        goto label_5;
        label_2:
        0.Dispose();
    }
    public void UpdateFreeHintEligable()
    {
        System.Collections.Generic.List<HintFeatureHandler> val_1;
        bool val_2;
        bool val_1 = true;
        val_1 = this.freeHintManagers;
        this.lastChosen = 0;
        var val_3 = 0;
        label_10:
        if(val_3 >= val_1)
        {
            goto label_2;
        }
        
        if(val_1 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_1 = val_1 + 0;
        var val_2 = (true + 0) + 32;
        if((((true + 0) + 32) & 1) == 0)
        {
            goto label_5;
        }
        
        val_1 = 0;
        if(val_2 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + 0;
        var val_4 = ((true + 0) + 32 + 0) + 32;
        if(((((true + 0) + 32 + 0) + 32) & 1) != 0)
        {
            goto label_9;
        }
        
        label_5:
        val_3 = val_3 + 1;
        if(this.freeHintManagers != null)
        {
            goto label_10;
        }
        
        label_2:
        val_2 = 0;
        goto label_12;
        label_9:
        if(val_4 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_4 = val_4 + 0;
        this.lastChosen = (((true + 0) + 32 + 0) + 32 + 0) + 32;
        val_2 = true;
        label_12:
        this.freeHintOnLastCheck = val_2;
    }
    public void OnHintUsed(bool wasFree)
    {
        UnityEngine.Object val_2;
        var val_3;
        List.Enumerator<T> val_1 = this.freeHintManagers.GetEnumerator();
        label_9:
        if(val_3.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(val_2 != this.lastChosen)
        {
            goto label_5;
        }
        
        if(val_2 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_9;
        label_5:
        if(val_2 == 0)
        {
                throw new NullReferenceException();
        }
        
        bool val_6 = wasFree;
        goto label_9;
        label_2:
        val_3.Dispose();
        this.UpdateFreeHintEligable();
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<WordGameEventsController>.Instance)) == false)
        {
                return;
        }
        
        MonoSingleton<WordGameEventsController>.Instance.OnAnyHintUsed(wasFree:  wasFree);
    }
    public bool get_PlayerEligableFreeHint()
    {
        return (bool)this.freeHintOnLastCheck;
    }
    public void DoHintButtonStartBehavior(WGHintButton button)
    {
        this.<wgHbutton>k__BackingField = button;
        if(this.lastChosen != 0)
        {
            goto typeof(HintFeatureHandler).__il2cppRuntimeField_190;
        }
    
    }
    public HintFeatureManager()
    {
        this.freeHintManagers = new System.Collections.Generic.List<HintFeatureHandler>();
    }

}
