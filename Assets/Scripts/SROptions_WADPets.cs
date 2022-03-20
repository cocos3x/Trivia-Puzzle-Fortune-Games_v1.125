using UnityEngine;
public class SROptions_WADPets : SuperLuckySROptionsParent<SROptions_WADPets>, INotifyPropertyChanged
{
    // Properties
    public string Food { get; }
    public string SetFood { get; set; }
    public string GoldieCards { get; set; }
    public string SimonCards { get; set; }
    public string HuskyCards { get; set; }
    public string HammerCards { get; set; }
    public string CocoCards { get; set; }
    public string PersiaCards { get; set; }
    public bool UseMinutes { get; set; }
    
    // Methods
    public static void NotifyPropertyChanged(string propertyName)
    {
        if((SuperLuckySROptionsParent<T>._Instance) == 0)
        {
                return;
        }
        
        propertyName = ???;
        goto typeof(T).__il2cppRuntimeField_190;
    }
    public void Back()
    {
        var val_5;
        var val_5 = 0;
        val_5 = val_5 + 1;
        val_5 = 18;
        SRDebug.Instance.ClearPinnedOptions();
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_5 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
        SuperLuckySROptionsController.OpenGameSpecificOptionsController();
    }
    public string get_Food()
    {
        Player val_1 = App.Player;
        return (string)val_1._food.ToString();
    }
    public void set_SetFood(string value)
    {
        string val_8 = value;
        Player val_1 = App.Player;
        int val_2 = val_1._food;
        if((System.Int32.TryParse(s:  val_8 = value, result: out  val_2)) == false)
        {
                return;
        }
        
        val_8 = val_2;
        Player val_4 = App.Player;
        if(val_8 == val_4._food)
        {
                return;
        }
        
        App.Player.SetPetsFood(amount:  val_2);
        App.Player.SaveState();
        DebugMessageDisplay.DisplayMessage(msgTxt:  "Set Pets Food to " + val_2, displayTime:  3f);
        SROptions_WADPets.NotifyPropertyChanged(propertyName:  "Food");
    }
    public string get_SetFood()
    {
        Player val_1 = App.Player;
        return (string)val_1._food.ToString();
    }
    public void PetsFoodDown10()
    {
        Player val_2 = App.Player;
        App.Player.SetPetsFood(amount:  val_2._food - 10);
        SROptions_WADPets.NotifyPropertyChanged(propertyName:  "Food");
    }
    public void PetsFoodDown1()
    {
        Player val_2 = App.Player;
        App.Player.SetPetsFood(amount:  val_2._food - 1);
        SROptions_WADPets.NotifyPropertyChanged(propertyName:  "Food");
    }
    public void PetsFoodUp1()
    {
        Player val_2 = App.Player;
        App.Player.SetPetsFood(amount:  val_2._food + 1);
        SROptions_WADPets.NotifyPropertyChanged(propertyName:  "Food");
    }
    public void PetsFoodUp10()
    {
        Player val_2 = App.Player;
        App.Player.SetPetsFood(amount:  val_2._food + 10);
        SROptions_WADPets.NotifyPropertyChanged(propertyName:  "Food");
    }
    public void UnlockAllPets()
    {
        List.Enumerator<T> val_2 = WADPetsManager.GetAllPetsCollection().GetEnumerator();
        label_5:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(0 != 0)
        {
            goto label_5;
        }
        
        0.Upgrade(hackLevel:  1);
        goto label_5;
        label_2:
        0.Dispose();
    }
    public void ResetAllPets()
    {
        List.Enumerator<T> val_2 = WADPetsManager.GetAllPetsCollection().GetEnumerator();
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
        WADPets.WADPetsUtils.QHACK_ResetWADPetsCollection();
        MonoSingleton<WADPetsManager>.Instance.ResetLevelCompleteEventTracking();
    }
    public void set_GoldieCards(string value)
    {
        WADPets.WADPet val_1 = WADPetsManager.GetPetByAbility(ability:  0);
        int val_2 = val_1.Cards;
        if((System.Int32.TryParse(s:  value, result: out  val_2)) == false)
        {
                return;
        }
        
        if((val_2 & 2147483648) != 0)
        {
                return;
        }
        
        val_1.Cards = val_2;
        DebugMessageDisplay.DisplayMessage(msgTxt:  "Set Goldie Cards to " + val_2, displayTime:  3f);
    }
    public string get_GoldieCards()
    {
        WADPets.WADPet val_1 = WADPetsManager.GetPetByAbility(ability:  0);
        return val_1.Cards.ToString();
    }
    public void set_SimonCards(string value)
    {
        WADPets.WADPet val_1 = WADPetsManager.GetPetByAbility(ability:  4);
        int val_2 = val_1.Cards;
        if((System.Int32.TryParse(s:  value, result: out  val_2)) == false)
        {
                return;
        }
        
        if((val_2 & 2147483648) != 0)
        {
                return;
        }
        
        val_1.Cards = val_2;
        DebugMessageDisplay.DisplayMessage(msgTxt:  "Set Simon Cards to " + val_2, displayTime:  3f);
    }
    public string get_SimonCards()
    {
        WADPets.WADPet val_1 = WADPetsManager.GetPetByAbility(ability:  4);
        return val_1.Cards.ToString();
    }
    public void set_HuskyCards(string value)
    {
        WADPets.WADPet val_1 = WADPetsManager.GetPetByAbility(ability:  5);
        int val_2 = val_1.Cards;
        if((System.Int32.TryParse(s:  value, result: out  val_2)) == false)
        {
                return;
        }
        
        if((val_2 & 2147483648) != 0)
        {
                return;
        }
        
        val_1.Cards = val_2;
        DebugMessageDisplay.DisplayMessage(msgTxt:  "Set Husky Cards to " + val_2, displayTime:  3f);
    }
    public string get_HuskyCards()
    {
        WADPets.WADPet val_1 = WADPetsManager.GetPetByAbility(ability:  5);
        return val_1.Cards.ToString();
    }
    public void set_HammerCards(string value)
    {
        WADPets.WADPet val_1 = WADPetsManager.GetPetByAbility(ability:  3);
        int val_2 = val_1.Cards;
        if((System.Int32.TryParse(s:  value, result: out  val_2)) == false)
        {
                return;
        }
        
        if((val_2 & 2147483648) != 0)
        {
                return;
        }
        
        val_1.Cards = val_2;
        DebugMessageDisplay.DisplayMessage(msgTxt:  "Set Hammer Cards to " + val_2, displayTime:  3f);
    }
    public string get_HammerCards()
    {
        WADPets.WADPet val_1 = WADPetsManager.GetPetByAbility(ability:  3);
        return val_1.Cards.ToString();
    }
    public void set_CocoCards(string value)
    {
        WADPets.WADPet val_1 = WADPetsManager.GetPetByAbility(ability:  2);
        int val_2 = val_1.Cards;
        if((System.Int32.TryParse(s:  value, result: out  val_2)) == false)
        {
                return;
        }
        
        if((val_2 & 2147483648) != 0)
        {
                return;
        }
        
        val_1.Cards = val_2;
        DebugMessageDisplay.DisplayMessage(msgTxt:  "Set Coco Cards to " + val_2, displayTime:  3f);
    }
    public string get_CocoCards()
    {
        WADPets.WADPet val_1 = WADPetsManager.GetPetByAbility(ability:  2);
        return val_1.Cards.ToString();
    }
    public void set_PersiaCards(string value)
    {
        WADPets.WADPet val_1 = WADPetsManager.GetPetByAbility(ability:  1);
        int val_2 = val_1.Cards;
        if((System.Int32.TryParse(s:  value, result: out  val_2)) == false)
        {
                return;
        }
        
        if((val_2 & 2147483648) != 0)
        {
                return;
        }
        
        val_1.Cards = val_2;
        DebugMessageDisplay.DisplayMessage(msgTxt:  "Set Persia Cards to " + val_2, displayTime:  3f);
    }
    public string get_PersiaCards()
    {
        WADPets.WADPet val_1 = WADPetsManager.GetPetByAbility(ability:  1);
        return val_1.Cards.ToString();
    }
    public void ShowPetsInfoHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Pets Info", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetWADPetsInfo()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public bool get_UseMinutes()
    {
        WADPetsManager val_1 = MonoSingleton<WADPetsManager>.Instance;
        return (bool)val_1.QHACK_UseMinutes;
    }
    public void set_UseMinutes(bool value)
    {
        WADPetsManager val_1 = MonoSingleton<WADPetsManager>.Instance;
        val_1.QHACK_UseMinutes = value;
    }
    public SROptions_WADPets()
    {
    
    }

}
