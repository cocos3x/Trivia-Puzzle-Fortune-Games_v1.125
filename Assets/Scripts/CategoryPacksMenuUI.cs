using UnityEngine;
public class CategoryPacksMenuUI : MonoSingleton<CategoryPacksMenuUI>
{
    // Fields
    private static System.Action awakeCommand;
    private PrefabsFromFolder prefabsFolder;
    private System.Collections.Generic.Stack<UnityEngine.GameObject> screenStack;
    
    // Methods
    private void Start()
    {
        if(CategoryPacksMenuUI.awakeCommand != null)
        {
                CategoryPacksMenuUI.awakeCommand.Invoke();
        }
        
        CategoryPacksMenuUI.awakeCommand = 0;
        DeviceKeypressManager.AddBackAction(backAction:  new System.Action(object:  this, method:  System.Void CategoryPacksMenuUI::HandleBackButtonClose()));
    }
    private void OnDisable()
    {
        DeviceKeypressManager.RemoveBackAction(backAction:  new System.Action(object:  this, method:  System.Void CategoryPacksMenuUI::HandleBackButtonClose()));
    }
    public static void ShowMainScreen()
    {
        CategoryPacksMenuUI.ShowScreen<CategoryPacksScreenMain>();
    }
    public static void Exit()
    {
        GameBehavior val_1 = App.getBehavior;
        UnityEngine.AsyncOperation val_2 = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName:  val_1.<metaGameBehavior>k__BackingField);
    }
    public void BackButtonPressed()
    {
        if(this.screenStack != null)
        {
                if(true >= 1)
        {
                UnityEngine.GameObject val_1 = this.screenStack.Peek();
            if(val_1 != 0)
        {
                val_1.SetActive(value:  false);
            UnityEngine.GameObject val_3 = this.screenStack.Pop();
        }
        
        }
        
            if((this.screenStack != null) && (1152921515901634640 > 0))
        {
                this.screenStack.Peek().SetActive(value:  true);
            return;
        }
        
        }
        
        CategoryPacksMenuUI.Exit();
    }
    public void ShowPopupNoNetwork()
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
        MonoSingleton<CategoriesWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    public void ShowPopupReward(CategoryCompletionReward reward, int categoriesCleared)
    {
        MonoSingleton<CategoriesWindowManager>.Instance.ShowUGUIMonolith<CategoryPackCompletionRewardPopup>(showNext:  false).Initialize(_rewardData:  reward, categoriesCleared:  categoriesCleared);
    }
    private static void ShowScreen<T>()
    {
        var val_8;
        System.Action val_9;
        var val_10;
        val_8 = mem[__RuntimeMethodHiddenParam + 48 + 302];
        val_8 = __RuntimeMethodHiddenParam + 48 + 302;
        if((val_8 & 1) == 0)
        {
                val_8 = mem[__RuntimeMethodHiddenParam + 48 + 302];
            val_8 = __RuntimeMethodHiddenParam + 48 + 302;
        }
        
        val_9 = mem[__RuntimeMethodHiddenParam + 48 + 184 + 8];
        val_9 = __RuntimeMethodHiddenParam + 48 + 184 + 8;
        if(val_9 == 0)
        {
                val_10 = mem[__RuntimeMethodHiddenParam + 48 + 302];
            val_10 = __RuntimeMethodHiddenParam + 48 + 302;
            if((val_10 & 1) == 0)
        {
                val_10 = mem[__RuntimeMethodHiddenParam + 48 + 302];
            val_10 = __RuntimeMethodHiddenParam + 48 + 302;
        }
        
            System.Action val_1 = null;
            val_9 = val_1;
            val_1 = new System.Action(object:  __RuntimeMethodHiddenParam + 48 + 184, method:  __RuntimeMethodHiddenParam + 48 + 8);
            mem2[0] = val_9;
        }
        
        CategoryPacksMenuUI.awakeCommand = val_9;
        if((MonoSingleton<CategoryPacksMenuUI>.Instance) == 0)
        {
                GameBehavior val_4 = App.getBehavior;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  val_4.<metaGameBehavior>k__BackingField, mode:  1);
            return;
        }
        
        CategoryPacksMenuUI val_5 = MonoSingleton<CategoryPacksMenuUI>.Instance;
        if(val_5.screenStack >= 1)
        {
                CategoryPacksMenuUI val_6 = MonoSingleton<CategoryPacksMenuUI>.Instance;
            val_6.screenStack.Peek().SetActive(value:  false);
        }
        
        val_1.Invoke();
        CategoryPacksMenuUI.awakeCommand = 0;
    }
    private void HandleBackButtonClose()
    {
        CategoryPacksMenuUI.Exit();
    }
    public CategoryPacksMenuUI()
    {
        this.screenStack = new System.Collections.Generic.Stack<UnityEngine.GameObject>();
    }

}
