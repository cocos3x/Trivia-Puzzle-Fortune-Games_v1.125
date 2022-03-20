using UnityEngine;
public class WGDifficultySettingPopup : MonoBehaviour
{
    // Fields
    private DifficultyTapToSelectButton normalModeButton;
    private DifficultyTapToSelectButton difficultModeButton;
    private UnityEngine.UI.Button normalModeSelectButton;
    private UnityEngine.UI.Button difficultModeSelectButton;
    
    // Methods
    private void Awake()
    {
        UnityEngine.UI.Button val_1 = this.normalModeButton.GetComponent<UnityEngine.UI.Button>();
        val_1.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGDifficultySettingPopup::<Awake>b__4_0()));
        this.normalModeSelectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGDifficultySettingPopup::<Awake>b__4_1()));
        UnityEngine.UI.Button val_4 = this.difficultModeButton.GetComponent<UnityEngine.UI.Button>();
        val_4.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGDifficultySettingPopup::<Awake>b__4_2()));
        this.difficultModeSelectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGDifficultySettingPopup::<Awake>b__4_3()));
    }
    private void OnEnable()
    {
        this.UpdateModeButtons();
    }
    private void OnClick_DifficultyMode(DifficultyMode mode)
    {
        if((MonoSingleton<DifficultySettingManager>.Instance.GetMode()) == mode)
        {
                return;
        }
        
        MonoSingleton<DifficultySettingManager>.Instance.UpdateSetting(mode:  mode);
        this.UpdateModeButtons();
        if(MainController.instance != 0)
        {
                DifficultySettingManager val_6 = MonoSingleton<DifficultySettingManager>.Instance;
            MainController val_7 = MainController.instance;
            val_6.DifficultyChangedOnLevelComplete = val_7.isGameComplete;
        }
        
        if((MonoSingleton<DifficultySettingUIController_Leagues>.Instance) == 0)
        {
                return;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "UpdateDifficultySettingIcon_Leagues");
    }
    private void UpdateModeButtons()
    {
        this.normalModeButton.Setup();
        this.difficultModeButton.Setup();
    }
    public WGDifficultySettingPopup()
    {
    
    }
    private void <Awake>b__4_0()
    {
        this.OnClick_DifficultyMode(mode:  0);
    }
    private void <Awake>b__4_1()
    {
        this.OnClick_DifficultyMode(mode:  0);
    }
    private void <Awake>b__4_2()
    {
        this.OnClick_DifficultyMode(mode:  1);
    }
    private void <Awake>b__4_3()
    {
        this.OnClick_DifficultyMode(mode:  1);
    }

}
