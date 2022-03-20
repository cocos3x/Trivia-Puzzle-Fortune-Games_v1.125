using UnityEngine;
public class FPHPhraseOfTheDayGameplayController : FPHGameplayController
{
    // Methods
    protected override void Start()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnLocalize");
    }
    public override void Init()
    {
        var val_5;
        FPHGameplayState val_1 = new FPHGameplayState();
        mem[1152921515988702376] = val_1;
        MonoSingleton<FPHPhraseOfTheDayController>.Instance.SetupLevel(newGame: ref  mem[1152921515988702376]);
        MonoSingleton<FPHGameplayUIController>.Instance.StartGameplay(newState:  val_1);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_4.Add(key:  "Daily Phrases", value:  true);
        val_4.Add(key:  "Phrase ID ", value:  mem[1152921515988734368] + 16);
        val_5 = null;
        val_5 = null;
        App.trackerManager.track(eventName:  "Level Start", data:  val_4);
    }
    public override bool CheckAnswer(bool triggerCallbackOnlyOnCorrect = False, bool solveModeUsed = False)
    {
        bool val_2 = System.String.op_Equality(a:  GetCurrentDisplayString(), b:  mem[41975936]);
        this.SolveModeExit(removePlayerEntries:  false);
        if(val_2 != false)
        {
                mem[41] = 1;
        }
        else
        {
                if((val_2 | (~triggerCallbackOnlyOnCorrect)) == false)
        {
                return val_2;
        }
        
        }
        
        if(this == null)
        {
                return val_2;
        }
        
        this.Invoke(obj:  val_2);
        return val_2;
    }
    public override void SpendGems(int gems, string source)
    {
        App.Player.AddGems(amount:  -gems, source:  "Daily Phrases", subsource:  0);
    }
    public override void ProcessLevelComplete(bool success)
    {
        success = success;
        MonoSingleton<FPHPhraseOfTheDayController>.Instance.CompleteQuestion(correctAnswer:  success);
    }
    public override void UpdateGameSave(FPHGameplayState updatedData)
    {
        MonoSingleton<FPHPhraseOfTheDayController>.Instance.UpdateSavedGame(state:  updatedData);
    }
    public override void RevealAnswer()
    {
        var val_4 = 0;
        label_8:
        if(val_4 >= mem[72057594037928216])
        {
            goto label_3;
        }
        
        100663296.set_Item(index:  0, value:  147633.Chars[0]);
        256.set_Item(index:  0, value:  1);
        val_4 = val_4 + 1;
        if(true != 0)
        {
            goto label_8;
        }
        
        label_3:
        MonoSingleton<FPHGameplayUIController>.Instance.UpdateGameplayState(updatedState:  null);
        MonoSingleton<FPHPhraseOfTheDayController>.Instance.CompleteQuestion(correctAnswer:  false);
    }
    public void OnLocalize()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public override bool IsTutorialLevel()
    {
        return false;
    }
    public override bool IsKeyboardTutorial()
    {
        return false;
    }
    public override bool IsTokenFeatureTutorial()
    {
        return false;
    }
    public override System.Collections.Generic.Dictionary<string, object> GatherLevelCompleteTrackingData(bool isSuccess, string failReason)
    {
        return this.GatherLevelCompleteTrackingData(isSuccess:  isSuccess, failReason:  failReason);
    }
    private void OnDisable()
    {
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnLocalize");
    }
    public FPHPhraseOfTheDayGameplayController()
    {
    
    }

}
