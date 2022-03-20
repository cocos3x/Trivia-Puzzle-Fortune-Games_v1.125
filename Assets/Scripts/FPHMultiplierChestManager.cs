using UnityEngine;
public class FPHMultiplierChestManager : MonoSingleton<FPHMultiplierChestManager>
{
    // Fields
    private const int INCORRECTS_PER_CHEST = 2;
    private string PERSISTANT_LEVEL_CHEST_DATA_KEY;
    private string QUALITY_KEY;
    private string INCORRECTS_KEY;
    private FPHMultiplerChestGameplayUI gameplayUI;
    private FPHChestType currentChestQuality;
    private int currentChestIncorrects;
    
    // Properties
    public FPHChestType GetCurrentChestType { get; }
    
    // Methods
    public FPHChestType get_GetCurrentChestType()
    {
        return (FPHChestType)this.currentChestQuality;
    }
    public override void InitMonoSingleton()
    {
        FPHGameplayController val_1 = FPHGameplayController.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnLetterSubmitted, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void FPHMultiplierChestManager::OnLetterSubmitted(bool correctGuess)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_11;
        }
        
        }
        
        val_1.OnLetterSubmitted = val_3;
        FPHGameplayController val_4 = FPHGameplayController.Instance;
        System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnLevelLoaded, b:  new System.Action<FPHGameplayState>(object:  this, method:  System.Void FPHMultiplierChestManager::OnLevelLoaded(FPHGameplayState loadedFPHGameplayState)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_11;
        }
        
        }
        
        val_4.OnLevelLoaded = val_6;
        FPHGameplayController val_7 = FPHGameplayController.Instance;
        System.Delegate val_9 = System.Delegate.Combine(a:  val_7.OnLevelSaved, b:  new System.Action<FPHGameplayState>(object:  this, method:  System.Void FPHMultiplierChestManager::OnLevelSaved(FPHGameplayState savedFPHGameplayState)));
        if(val_9 != null)
        {
                if(null != null)
        {
            goto label_11;
        }
        
        }
        
        val_7.OnLevelSaved = val_9;
        return;
        label_11:
    }
    private void OnDestroy()
    {
        if((UnityEngine.Object.op_Implicit(exists:  FPHGameplayController.Instance)) == false)
        {
                return;
        }
        
        FPHGameplayController val_3 = FPHGameplayController.Instance;
        1152921504901894144 = val_3.OnLetterSubmitted;
        System.Delegate val_5 = System.Delegate.Remove(source:  1152921504901894144, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void FPHMultiplierChestManager::OnLetterSubmitted(bool correctGuess)));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_3.OnLetterSubmitted = val_5;
        return;
        label_10:
    }
    private void OnLetterSubmitted(bool correctGuess)
    {
        FPHChestType val_2;
        int val_3;
        if(correctGuess == true)
        {
                return;
        }
        
        val_2 = this.currentChestQuality;
        if(val_2 == 1)
        {
                return;
        }
        
        val_3 = this.currentChestIncorrects + 1;
        this.currentChestIncorrects = val_3;
        if(val_3 == 2)
        {
                val_3 = 0;
            val_2 = val_2 - 1;
            this.currentChestQuality = val_2;
            this.currentChestIncorrects = 0;
        }
        
        if(this.gameplayUI != null)
        {
                this.gameplayUI.SetChestStates(currentChestIndex:  val_2, currentIncorrects:  0, animated:  false);
            return;
        }
        
        throw new NullReferenceException();
    }
    private void OnLevelLoaded(FPHGameplayState loadedFPHGameplayState)
    {
        this.currentChestQuality = 1.48219693752374E-323;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<System.String, System.Object>>(value:  CPlayerPrefs.GetString(key:  this.PERSISTANT_LEVEL_CHEST_DATA_KEY, defaultValue:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  new System.Collections.Generic.Dictionary<System.String, System.Object>())));
        if((val_4.ContainsKey(key:  this.QUALITY_KEY)) != false)
        {
                bool val_7 = System.Enum.TryParse<FPHChestType>(value:  val_4.Item[this.QUALITY_KEY], result: out  this.currentChestQuality);
        }
        
        if((val_4.ContainsKey(key:  this.INCORRECTS_KEY)) != false)
        {
                bool val_11 = System.Int32.TryParse(s:  val_4.Item[this.INCORRECTS_KEY], result: out  1152921515974224028);
        }
        
        loadedFPHGameplayState.chestType = this.currentChestQuality;
        this.gameplayUI.SetChestStates(currentChestIndex:  3, currentIncorrects:  0, animated:  false);
    }
    private void OnLevelSaved(FPHGameplayState savedFPHGameplayState)
    {
        string val_3;
        if(savedFPHGameplayState != null)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  this.QUALITY_KEY, value:  this.currentChestQuality);
            val_1.Add(key:  this.INCORRECTS_KEY, value:  this.currentChestIncorrects);
            val_3 = Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_1);
            CPlayerPrefs.SetString(key:  this.PERSISTANT_LEVEL_CHEST_DATA_KEY, val:  val_3);
            savedFPHGameplayState.chestType = this.currentChestQuality;
        }
        else
        {
                CPlayerPrefs.DeleteKey(key:  this.PERSISTANT_LEVEL_CHEST_DATA_KEY);
        }
        
        this.gameplayUI.SetChestStates(currentChestIndex:  this.currentChestQuality, currentIncorrects:  this.currentChestIncorrects, animated:  false);
    }
    public FPHMultiplierChestManager()
    {
        this.PERSISTANT_LEVEL_CHEST_DATA_KEY = "FPHGPSCHEST";
        this.QUALITY_KEY = "quality";
        this.currentChestQuality = 3;
        this.INCORRECTS_KEY = "incorrects";
    }

}
