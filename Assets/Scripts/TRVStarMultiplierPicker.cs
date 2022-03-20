using UnityEngine;
public class TRVStarMultiplierPicker : MonoBehaviour
{
    // Fields
    private TRVStarMultiplierButton buttonPrefab;
    private UnityEngine.UI.HorizontalLayoutGroup buttonParent;
    private System.Collections.Generic.List<TRVStarMultiplierButton> myButtons;
    private bool hasSetup;
    
    // Methods
    private void OnEnable()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerSync");
        TRVEcon val_3 = App.GetGameSpecificEcon<TRVEcon>();
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  val_3.variableEntryUnlock)) != false)
        {
                this.Setup();
            return;
        }
        
        this.gameObject.SetActive(value:  false);
    }
    private void OnServerSync()
    {
        TRVEcon val_2 = App.GetGameSpecificEcon<TRVEcon>();
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  val_2.variableEntryUnlock)) != false)
        {
                this.Refresh();
            return;
        }
        
        this.gameObject.SetActive(value:  false);
    }
    private void Setup()
    {
        if(this.hasSetup != false)
        {
                return;
        }
        
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        if(((System.Linq.Enumerable.ToList<System.Int32>(source:  val_1.variableEntryCost)) != null) && ((public static System.Collections.Generic.List<TSource> System.Linq.Enumerable::ToList<System.Int32>(System.Collections.Generic.IEnumerable<TSource> source)) != 0))
        {
                if(1152921515450617360 >= 1)
        {
                int val_9 = 0;
            .<>4__this = this;
            .buttonValue = val_9;
            if(1152921504963342336 <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            TRVEcon val_4 = App.GetGameSpecificEcon<TRVEcon>();
            string val_5 = System.String.Format(format:  "{0}X", arg0:  val_4.variableMultipliers[val_9]);
            typeof(System.Security.Policy.ApplicationSecurityManager).__il2cppRuntimeField_28 = new System.Action(object:  new TRVStarMultiplierPicker.<>c__DisplayClass6_0(), method:  System.Void TRVStarMultiplierPicker.<>c__DisplayClass6_0::<Setup>b__0());
            val_9 = val_9 + 1;
        }
        
            this.Refresh();
            this.hasSetup = true;
            return;
        }
        
        this.gameObject.SetActive(value:  false);
        UnityEngine.Debug.LogError(message:  "Error parsing variable entry cost knobs");
    }
    private void Refresh()
    {
        TRVEcon val_2 = App.GetGameSpecificEcon<TRVEcon>();
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  val_2.variableEntryUnlock)) != false)
        {
                var val_8 = 0;
            do
        {
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            (GameEcon.__il2cppRuntimeField_cctor_finished + 0) + 32.SetSelectedUI(selected:  (val_8 == TRVMainController.currentMultiplier) ? 1 : 0);
            val_8 = val_8 + 1;
        }
        while(this.myButtons != null);
        
        }
        
        this.gameObject.SetActive(value:  false);
    }
    private void OnDisable()
    {
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnServerSync");
    }
    public TRVStarMultiplierPicker()
    {
        this.myButtons = new System.Collections.Generic.List<TRVStarMultiplierButton>();
    }

}
