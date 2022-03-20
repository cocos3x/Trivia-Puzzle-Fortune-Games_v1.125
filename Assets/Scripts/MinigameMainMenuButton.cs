using UnityEngine;
public class MinigameMainMenuButton : MonoBehaviour
{
    // Methods
    private void Start()
    {
        var val_11;
        System.Func<MiniGame, System.Boolean> val_13;
        var val_14;
        System.Func<MiniGame, System.Int32> val_16;
        if(((MonoSingleton<Bootstrapper>.Instance.DeeplinkedWhichMinigame) & 2147483648) == 0)
        {
                return;
        }
        
        AppConfigs val_3 = App.Configuration;
        if(val_3.minigamesConfig.minigames != null)
        {
                AppConfigs val_4 = App.Configuration;
            val_11 = null;
            val_11 = null;
            val_13 = MinigameMainMenuButton.<>c.<>9__0_0;
            if(val_13 == null)
        {
                System.Func<MiniGame, System.Boolean> val_5 = null;
            val_13 = val_5;
            val_5 = new System.Func<MiniGame, System.Boolean>(object:  MinigameMainMenuButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean MinigameMainMenuButton.<>c::<Start>b__0_0(MiniGame x));
            MinigameMainMenuButton.<>c.<>9__0_0 = val_13;
        }
        
            val_14 = null;
            val_14 = null;
            val_16 = MinigameMainMenuButton.<>c.<>9__0_1;
            if(val_16 == null)
        {
                System.Func<MiniGame, System.Int32> val_7 = null;
            val_16 = val_7;
            val_7 = new System.Func<MiniGame, System.Int32>(object:  MinigameMainMenuButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 MinigameMainMenuButton.<>c::<Start>b__0_1(MiniGame x));
            MinigameMainMenuButton.<>c.<>9__0_1 = val_16;
        }
        
            if(App.Player >= (System.Linq.Enumerable.Min<MiniGame>(source:  System.Linq.Enumerable.Where<MiniGame>(source:  val_4.minigamesConfig.minigames, predicate:  val_5), selector:  val_7)))
        {
                return;
        }
        
        }
        
        this.gameObject.SetActive(value:  false);
    }
    public MinigameMainMenuButton()
    {
    
    }

}
