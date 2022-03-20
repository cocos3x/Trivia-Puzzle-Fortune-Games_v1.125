using UnityEngine;
public class RaidAttackScreenUI : MonoSingleton<RaidAttackScreenUI>
{
    // Fields
    private static System.Action awakeCommand;
    private PrefabsFromFolder prefabsFolder;
    private WordForest.RaidAttackScreenTransition screenTransition;
    private System.Collections.Generic.Stack<UnityEngine.GameObject> screenStack;
    
    // Methods
    private void Start()
    {
        if(RaidAttackScreenUI.awakeCommand != null)
        {
                RaidAttackScreenUI.awakeCommand.Invoke();
        }
        
        RaidAttackScreenUI.awakeCommand = 0;
        DeviceKeypressManager.AddBackAction(backAction:  new System.Action(object:  this, method:  public System.Void RaidAttackScreenUI::BackButtonPressed()));
    }
    private void OnDisable()
    {
        DeviceKeypressManager.RemoveBackAction(backAction:  new System.Action(object:  this, method:  public System.Void RaidAttackScreenUI::BackButtonPressed()));
    }
    public static void ShowRaidScreen()
    {
        RaidAttackScreenUI.ShowScreen<WordForest.RaidScreenMain>(sceneType:  1);
        WGAudioController val_1 = MonoSingleton<WGAudioController>.Instance;
        val_1.music.Play(type:  0, trackIndex:  2);
    }
    public static void ShowAttackScreen()
    {
        RaidAttackScreenUI.ShowScreen<WordForest.AttackScreenMain>(sceneType:  2);
        WGAudioController val_1 = MonoSingleton<WGAudioController>.Instance;
        val_1.music.Play(type:  0, trackIndex:  1);
    }
    public static void Exit()
    {
        MainController val_1 = MainController.instance;
        val_1.mainCamera.enabled = true;
        WGAudioController val_2 = MonoSingleton<WGAudioController>.Instance;
        val_2.music.Play(type:  0, trackIndex:  0);
        GameBehavior val_3 = App.getBehavior;
        UnityEngine.AsyncOperation val_4 = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName:  val_3.<metaGameBehavior>k__BackingField);
    }
    public void BackButtonPressed()
    {
        if((this.screenStack != null) && (this.screenStack >= 1))
        {
                RaidAttackScreenUI val_1 = MonoSingleton<RaidAttackScreenUI>.Instance;
            val_1.screenTransition.ExtendCurtains(sceneType:  0, onComplete:  new System.Action(object:  this, method:  System.Void RaidAttackScreenUI::<BackButtonPressed>b__9_0()));
            return;
        }
        
        RaidAttackScreenUI.Exit();
    }
    public void ShowConnectionRequired()
    {
        int val_8;
        var val_9;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_8 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_8 = val_6.Length;
        val_6[1] = "NULL";
        val_9 = null;
        val_9 = null;
        MonoSingleton<RaidAttackWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private static void ShowScreen<T>(WordForest.RaidAttackActionType sceneType)
    {
        mem2[0] = sceneType;
        System.Action val_1 = new System.Action(object:  __RuntimeMethodHiddenParam + 48, method:  __RuntimeMethodHiddenParam + 48 + 16);
        RaidAttackScreenUI.awakeCommand = val_1;
        if((MonoSingleton<RaidAttackScreenUI>.Instance) == 0)
        {
                GameBehavior val_4 = App.getBehavior;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  val_4.<metaGameBehavior>k__BackingField, mode:  1);
            return;
        }
        
        RaidAttackScreenUI val_5 = MonoSingleton<RaidAttackScreenUI>.Instance;
        if(val_5.screenStack >= 1)
        {
                RaidAttackScreenUI val_6 = MonoSingleton<RaidAttackScreenUI>.Instance;
            val_6.screenStack.Peek().SetActive(value:  false);
        }
        
        val_1.Invoke();
        RaidAttackScreenUI.awakeCommand = 0;
    }
    public RaidAttackScreenUI()
    {
        this.screenStack = new System.Collections.Generic.Stack<UnityEngine.GameObject>();
    }
    private void <BackButtonPressed>b__9_0()
    {
        MainController val_1 = MainController.instance;
        val_1.mainCamera.enabled = true;
        UnityEngine.GameObject val_2 = this.screenStack.Peek();
        if(val_2 != 0)
        {
                val_2.SetActive(value:  false);
            UnityEngine.GameObject val_4 = this.screenStack.Pop();
        }
        
        if(1152921515901634640 >= 1)
        {
                this.screenStack.Peek().SetActive(value:  true);
        }
        
        RaidAttackScreenUI val_6 = MonoSingleton<RaidAttackScreenUI>.Instance;
        val_6.screenTransition.WithdrawCurtains(delay:  0.1f, onComplete:  new System.Action(object:  this, method:  System.Void RaidAttackScreenUI::<BackButtonPressed>b__9_1()));
    }
    private void <BackButtonPressed>b__9_1()
    {
        if((this.screenStack != null) && (this.screenStack > 0))
        {
                return;
        }
        
        RaidAttackScreenUI.Exit();
    }

}
