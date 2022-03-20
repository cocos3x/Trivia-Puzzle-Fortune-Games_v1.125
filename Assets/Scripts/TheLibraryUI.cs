using UnityEngine;
public class TheLibraryUI : MonoSingleton<TheLibraryUI>
{
    // Fields
    private static System.Action AwakeCommand;
    private static System.Action OnCloseAction;
    private PrefabsFromFolder prefabsFromFolder;
    private UnityEngine.Canvas mainUICanvas;
    private System.Collections.Generic.Stack<UnityEngine.GameObject> screenStack;
    
    // Methods
    public static void ShowTheLibrary(System.Action onCloseAction)
    {
        System.Action val_12;
        var val_13;
        var val_14;
        System.Action val_16;
        var val_17;
        val_12 = onCloseAction;
        val_13 = null;
        if(TheLibraryLogic.LifetimeBooksEarned < 1)
        {
                return;
        }
        
        TheLibraryUI.OnCloseAction = val_12;
        if((MonoSingleton<TheLibraryUI>.Instance) == 0)
        {
                val_14 = null;
            val_14 = null;
            val_16 = TheLibraryUI.<>c.<>9__2_0;
            if(val_16 == null)
        {
                System.Action val_4 = null;
            val_16 = val_4;
            val_4 = new System.Action(object:  TheLibraryUI.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TheLibraryUI.<>c::<ShowTheLibrary>b__2_0());
            TheLibraryUI.<>c.<>9__2_0 = val_16;
        }
        
            TheLibraryUI.AwakeCommand = val_16;
            GameBehavior val_5 = App.getBehavior;
            val_12 = val_5.<metaGameBehavior>k__BackingField;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  val_12, mode:  1);
        }
        else
        {
                TheLibraryUI val_6 = MonoSingleton<TheLibraryUI>.Instance;
            UnityEngine.GameObject val_8 = val_6.prefabsFromFolder.LoadStrictlyTypeNamedPrefab<TheLibraryMainScreen>(allowMultiple:  false).gameObject;
            val_12 = val_8;
            if(val_8.activeSelf != true)
        {
                val_12.SetActive(value:  true);
        }
        
            TheLibraryUI val_10 = MonoSingleton<TheLibraryUI>.Instance;
            val_10.screenStack.Push(item:  val_12);
        }
        
        MonoSingleton<AdsUIController>.Instance.BannerAdsUnblocked = false;
        val_17 = null;
        val_17 = null;
        TheLibraryLogic.prefs_server_queue = TheLibraryLogic.prefs_server_queue;
    }
    public static void ShowTheLibraryCollection(string collectionName, bool trackLibraryAccessed = False)
    {
        var val_15;
        System.Action val_16;
        var val_17;
        val_15 = trackLibraryAccessed;
        .collectionName = collectionName;
        if((MonoSingleton<TheLibraryUI>.Instance) == 0)
        {
                System.Action val_4 = null;
            val_16 = val_4;
            val_4 = new System.Action(object:  new TheLibraryUI.<>c__DisplayClass3_0(), method:  System.Void TheLibraryUI.<>c__DisplayClass3_0::<ShowTheLibraryCollection>b__0());
            TheLibraryUI.AwakeCommand = val_16;
            GameBehavior val_5 = App.getBehavior;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  val_5.<metaGameBehavior>k__BackingField, mode:  1);
        }
        else
        {
                TheLibraryUI val_6 = MonoSingleton<TheLibraryUI>.Instance;
            if(val_6.screenStack >= 1)
        {
                TheLibraryUI val_7 = MonoSingleton<TheLibraryUI>.Instance;
            val_7.screenStack.Peek().SetActive(value:  false);
        }
        
            TheLibraryUI val_9 = MonoSingleton<TheLibraryUI>.Instance;
            TheLibraryCollectionScreen val_10 = val_9.prefabsFromFolder.LoadStrictlyTypeNamedPrefab<TheLibraryCollectionScreen>(allowMultiple:  false);
            val_16 = val_10;
            val_10.Setup(collectionName:  (TheLibraryUI.<>c__DisplayClass3_0)[1152921515900688528].collectionName);
            UnityEngine.GameObject val_11 = val_16.gameObject;
            if(val_11.activeSelf != true)
        {
                val_11.SetActive(value:  true);
        }
        
            TheLibraryUI val_13 = MonoSingleton<TheLibraryUI>.Instance;
            val_13.screenStack.Push(item:  val_11);
        }
        
        MonoSingleton<AdsUIController>.Instance.BannerAdsUnblocked = false;
        if(val_15 == false)
        {
                return;
        }
        
        val_15 = 1152921504898859008;
        val_17 = null;
        val_17 = null;
        TheLibraryLogic.prefs_server_queue = TheLibraryLogic.prefs_server_queue;
    }
    public static void HandleTheLibraryClose()
    {
        var val_4;
        TheLibraryUI.AwakeCommand = 0;
        LibraryWindowManager val_1 = MonoSingleton<LibraryWindowManager>.Instance;
        val_1.canShowWindows = false;
        GameBehavior val_2 = App.getBehavior;
        UnityEngine.AsyncOperation val_3 = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName:  val_2.<metaGameBehavior>k__BackingField);
        if(TheLibraryUI.OnCloseAction != null)
        {
                TheLibraryUI.OnCloseAction.Invoke();
            val_4 = 1152921504900141064;
        }
        
        TheLibraryUI.OnCloseAction = 0;
    }
    public static void ForceTheLibraryClose()
    {
        if((MonoSingleton<TheLibraryUI>.Instance) == 0)
        {
                return;
        }
        
        TheLibraryUI.AwakeCommand = 0;
        GameBehavior val_3 = App.getBehavior;
        UnityEngine.AsyncOperation val_4 = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName:  val_3.<metaGameBehavior>k__BackingField);
    }
    public static void HideMainUICanvas()
    {
        if((MonoSingleton<TheLibraryUI>.Instance) == 0)
        {
                return;
        }
        
        TheLibraryUI val_3 = MonoSingleton<TheLibraryUI>.Instance;
        val_3.mainUICanvas.enabled = false;
    }
    public static void ShowMainUICanvas()
    {
        if((MonoSingleton<TheLibraryUI>.Instance) == 0)
        {
                return;
        }
        
        TheLibraryUI val_3 = MonoSingleton<TheLibraryUI>.Instance;
        val_3.mainUICanvas.enabled = true;
    }
    private void Start()
    {
        if(TheLibraryUI.AwakeCommand != null)
        {
                TheLibraryUI.AwakeCommand.Invoke();
            TheLibraryUI.AwakeCommand = 0;
        }
        
        DeviceKeypressManager.AddBackAction(backAction:  new System.Action(object:  this, method:  System.Void TheLibraryUI::HandleBackButtonClose()));
    }
    private void OnDisable()
    {
        DeviceKeypressManager.RemoveBackAction(backAction:  new System.Action(object:  this, method:  System.Void TheLibraryUI::HandleBackButtonClose()));
    }
    public void BackButtonPressed()
    {
        if(this.screenStack == null)
        {
            goto label_9;
        }
        
        if(true >= 1)
        {
                UnityEngine.GameObject val_1 = this.screenStack.Peek();
            if(val_1 != 0)
        {
                val_1.SetActive(value:  false);
            UnityEngine.GameObject val_3 = this.screenStack.Pop();
        }
        
        }
        
        if((this.screenStack == null) || ((public UnityEngine.GameObject System.Collections.Generic.Stack<UnityEngine.GameObject>::Pop()) == 0))
        {
            goto label_9;
        }
        
        this.screenStack.Peek().SetActive(value:  true);
        goto label_11;
        label_9:
        TheLibraryUI.HandleTheLibraryClose();
        label_11:
        MonoSingleton<AdsUIController>.Instance.BannerAdsUnblocked = true;
    }
    private void HandleBackButtonClose()
    {
        TheLibraryUI.HandleTheLibraryClose();
    }
    public TheLibraryUI()
    {
        this.screenStack = new System.Collections.Generic.Stack<UnityEngine.GameObject>();
    }

}
