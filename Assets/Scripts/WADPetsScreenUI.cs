using UnityEngine;
public class WADPetsScreenUI : MonoSingleton<WADPetsScreenUI>
{
    // Fields
    private static System.Action awakeCommand;
    private PrefabsFromFolder prefabsFolder;
    private System.Collections.Generic.Stack<UnityEngine.GameObject> screenStack;
    
    // Methods
    private void Start()
    {
        if(WADPetsScreenUI.awakeCommand != null)
        {
                WADPetsScreenUI.awakeCommand.Invoke();
        }
        
        WADPetsScreenUI.awakeCommand = 0;
        DeviceKeypressManager.AddBackAction(backAction:  new System.Action(object:  this, method:  System.Void WADPetsScreenUI::HandleBackButtonClose()));
    }
    private void OnDisable()
    {
        DeviceKeypressManager.RemoveBackAction(backAction:  new System.Action(object:  this, method:  System.Void WADPetsScreenUI::HandleBackButtonClose()));
    }
    public static void ShowMainScreen()
    {
        WADPetsScreenUI.ShowScreen<PetsScreenMain>();
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
        
        WADPetsScreenUI.Exit();
    }
    private static void Exit()
    {
        GameBehavior val_1 = App.getBehavior;
        UnityEngine.AsyncOperation val_2 = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName:  val_1.<metaGameBehavior>k__BackingField);
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
        
        WADPetsScreenUI.awakeCommand = val_9;
        if((MonoSingleton<WADPetsScreenUI>.Instance) == 0)
        {
                GameBehavior val_4 = App.getBehavior;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  val_4.<metaGameBehavior>k__BackingField, mode:  1);
            return;
        }
        
        WADPetsScreenUI val_5 = MonoSingleton<WADPetsScreenUI>.Instance;
        if(val_5.screenStack >= 1)
        {
                WADPetsScreenUI val_6 = MonoSingleton<WADPetsScreenUI>.Instance;
            val_6.screenStack.Peek().SetActive(value:  false);
        }
        
        val_1.Invoke();
        WADPetsScreenUI.awakeCommand = 0;
    }
    private void HandleBackButtonClose()
    {
        WADPetsScreenUI.Exit();
    }
    public WADPetsScreenUI()
    {
        this.screenStack = new System.Collections.Generic.Stack<UnityEngine.GameObject>();
    }

}
