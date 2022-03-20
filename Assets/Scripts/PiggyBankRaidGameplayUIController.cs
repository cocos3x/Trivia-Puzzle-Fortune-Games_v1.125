using UnityEngine;
public class PiggyBankRaidGameplayUIController : MonoSingleton<PiggyBankRaidGameplayUIController>
{
    // Fields
    private EventButtonPanel eventButtonPanel;
    private WGEventButtonProgressPiggyBankRaid eventButton;
    
    // Methods
    public void RefreshEventProgressButton()
    {
        var val_13;
        var val_14;
        var val_15;
        System.Predicate<WGEventButtonV2> val_17;
        WGEventButtonProgressPiggyBankRaid val_18;
        val_13 = this;
        val_14 = 1152921504765632512;
        if(this.eventButtonPanel == 0)
        {
            goto label_3;
        }
        
        val_15 = null;
        val_15 = null;
        val_17 = PiggyBankRaidGameplayUIController.<>c.<>9__2_0;
        if(val_17 == null)
        {
                System.Predicate<WGEventButtonV2> val_2 = null;
            val_17 = val_2;
            val_2 = new System.Predicate<WGEventButtonV2>(object:  PiggyBankRaidGameplayUIController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean PiggyBankRaidGameplayUIController.<>c::<RefreshEventProgressButton>b__2_0(WGEventButtonV2 x));
            PiggyBankRaidGameplayUIController.<>c.<>9__2_0 = val_17;
        }
        
        WGEventButtonV2 val_3 = this.eventButtonPanel.btnList.Find(match:  val_2);
        val_18 = 0;
        goto label_13;
        label_3:
        val_18 = this.eventButton;
        goto label_14;
        label_13:
        this.eventButton = ;
        label_14:
        if( == 0)
        {
                return;
        }
        
        val_13 = ???;
        val_17 = ???;
        val_14 = ???;
        goto mem[(WGEventButtonV2.__il2cppRuntimeField_typeHierarchy + (WGEventButtonProgressPiggyBankRaid.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_3 : 0] + 400;
    }
    public PiggyBankRaidGameplayUIController()
    {
    
    }

}
