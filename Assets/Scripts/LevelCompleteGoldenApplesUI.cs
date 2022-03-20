using UnityEngine;
public class LevelCompleteGoldenApplesUI : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject goldenApplesGroup_difficulty;
    private UnityEngine.UI.Text goldenApplesBonus_difficulty;
    private UnityEngine.UI.Button difficultySettingButton;
    private UnityEngine.GameObject goldenApplesGroup_pets;
    private UnityEngine.UI.Text goldenApplesBonus_pets;
    private UnityEngine.GameObject petFtuxGroup;
    private UnityEngine.UI.Text petFtuxDescription;
    private UnityEngine.UI.Button petFtuxOkButton;
    
    // Methods
    public void Setup()
    {
        this.SetupDifficultySettingUI();
        this.SetupPetsUI();
    }
    private void SetupDifficultySettingUI()
    {
        if((MonoSingleton<DifficultySettingManager>.Instance) == 0)
        {
                return;
        }
        
        if((MonoSingleton<DifficultySettingManagerGameplay>.Instance) == 0)
        {
                return;
        }
        
        DifficultySettingManagerGameplay val_5 = MonoSingleton<DifficultySettingManagerGameplay>.Instance;
        this.goldenApplesGroup_difficulty.SetActive(value:  (val_5.ShouldShowGoldenApplesBonus == true) ? 1 : 0);
        if(val_5.ShouldShowGoldenApplesBonus == false)
        {
                return;
        }
        
        DifficultySettingManagerGameplay val_7 = MonoSingleton<DifficultySettingManagerGameplay>.Instance;
        string val_8 = val_7.GoldenApplesAward.ToString();
        this.difficultySettingButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LevelCompleteGoldenApplesUI::OnClick_DifficultySettingButton()));
    }
    private void SetupPetsUI()
    {
        this.goldenApplesGroup_pets.SetActive(value:  false);
        this.petFtuxGroup.SetActive(value:  false);
        if((MonoSingleton<WADPetsManager>.Instance) == 0)
        {
                return;
        }
        
        WADPets.WADPet val_3 = WADPetsManager.GetPetByAbility(ability:  2);
        if(val_3.IsActive() == false)
        {
                return;
        }
        
        string val_5 = val_3.CachedValueModifier.ToString();
        this.goldenApplesGroup_pets.SetActive(value:  true);
        if(val_3.IsFtuxShown != false)
        {
                return;
        }
        
        val_3.IsFtuxShown = true;
        UnityEngine.Coroutine val_7 = this.StartCoroutine(routine:  this.StartShowingPetFtux(pet:  val_3));
    }
    private System.Collections.IEnumerator StartShowingPetFtux(WADPets.WADPet pet)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .pet = pet;
        return (System.Collections.IEnumerator)new LevelCompleteGoldenApplesUI.<StartShowingPetFtux>d__11();
    }
    private void OnClick_DifficultySettingButton()
    {
        WGFlyoutManager val_2 = MonoSingleton<WGFlyoutManager>.Instance.ShowUGUIMonolith<WGDifficultySettingPopup>(showNext:  false);
    }
    public LevelCompleteGoldenApplesUI()
    {
    
    }
    private void <StartShowingPetFtux>b__11_0()
    {
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  new System.Action(object:  this, method:  System.Void LevelCompleteGoldenApplesUI::<StartShowingPetFtux>b__11_1()));
    }
    private void <StartShowingPetFtux>b__11_1()
    {
        if(this.petFtuxGroup != null)
        {
                this.petFtuxGroup.SetActive(value:  false);
            return;
        }
        
        throw new NullReferenceException();
    }

}
