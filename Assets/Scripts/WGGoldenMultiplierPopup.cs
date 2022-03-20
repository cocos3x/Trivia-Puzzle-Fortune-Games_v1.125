using UnityEngine;
public class WGGoldenMultiplierPopup : MonoBehaviour
{
    // Fields
    private const float BASE_HEIGHT = 1060;
    private const float BONUSUI_HEIGHT = 150;
    private const float BONUSUI_SPACE = 20;
    private UnityEngine.UI.Text multiplierText;
    private UnityEngine.UI.Text addMultiplierButtonText;
    private UnityEngine.UI.Text addMultiplierButtonCostText;
    private UnityEngine.GameObject addMultiplierButtonCostGroup;
    private MultiGraphicButton addMultiplierButton;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.GameObject notEnoughTooltip;
    private UnityEngine.GameObject flourishParticle;
    private UnityEngine.GameObject bonusPrefab;
    private UnityEngine.RectTransform bonusesParent;
    private UnityEngine.RectTransform mainUI;
    private UnityEngine.Sprite subs;
    private UnityEngine.Sprite difficulty;
    private UnityEngine.GameObject subsBonusUI;
    private UnityEngine.GameObject difficultyBonusUI;
    
    // Methods
    private void Awake()
    {
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGGoldenMultiplierPopup::Close()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGGoldenMultiplierPopup::OnClick_AddMultiplierButton()));
    }
    private void Start()
    {
        this.UpdateUI();
    }
    private void UpdateUI()
    {
        string val_4 = System.String.Format(format:  "{0}X", arg0:  MonoSingleton<GoldenMultiplierManager>.Instance.GetCurrentGoldenMultiplier.ToString(format:  "##.#"));
        bool val_6 = MonoSingleton<GoldenMultiplierManager>.Instance.IsMaxGoldedMultiplier;
        bool val_8 = val_6 ^ 1;
        this.addMultiplierButton.interactable = val_8;
        this.addMultiplierButtonCostGroup.SetActive(value:  val_8);
        if(val_6 != false)
        {
                string val_9 = Localization.Localize(key:  "max_reached_upper", defaultValue:  "MAX REACHED", useSingularKey:  false);
        }
        else
        {
                string val_13 = System.String.Format(format:  "+{0}X", arg0:  MonoSingleton<GoldenMultiplierManager>.Instance.GetMultiplierIncrement.ToString(format:  "0.#"));
        }
        
        if(val_6 != true)
        {
                GameEcon val_16 = App.getGameEcon;
            string val_18 = System.String.Format(format:  "{0}", arg0:  MonoSingleton<GoldenMultiplierManager>.Instance.GetNextCost.ToString(format:  val_16.numberFormatInt));
        }
        
        this.SetupBonusSection();
    }
    private void OnClick_AddMultiplierButton()
    {
        UnityEngine.ParticleSystemCurveMode val_13;
        UnityEngine.AnimationCurve val_14;
        if((MonoSingleton<GoldenMultiplierManager>.Instance.PurchaseMultiplier()) != false)
        {
                UnityEngine.ParticleSystem val_5 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.flourishParticle, parent:  this.multiplierText.transform, worldPositionStays:  false).GetComponent<UnityEngine.ParticleSystem>();
            EmissionModule val_6 = val_5.emission;
            float val_18 = 100f;
            val_18 = (MonoSingleton<GoldenMultiplierManager>.Instance.GetCurrentGoldenMultiplier) * val_18;
            int val_9 = UnityEngine.Mathf.RoundToInt(f:  val_18);
            MinMaxCurve val_12 = ParticleSystem.MinMaxCurve.op_Implicit(constant:  (float)(0 == 0) ? 600 : ((0 == 0) ? 300 : 100));
            ParticleSystem.Burst val_15 = new ParticleSystem.Burst(_time:  0f, _count:  new MinMaxCurve() {m_Mode = val_13, m_CurveMultiplier = val_13, m_CurveMin = val_14, m_CurveMax = val_14, m_ConstantMin = 0f, m_ConstantMax = 0f});
            val_6.m_ParticleSystem.SetBurst(index:  0, burst:  new Burst() {m_Time = val_15.m_Time, m_Count = new MinMaxCurve() {m_CurveMultiplier = val_15.m_Count.m_CurveMultiplier, m_CurveMax = val_15.m_Count.m_CurveMax, m_ConstantMin = val_15.m_Count.m_CurveMax, m_ConstantMax = val_15.m_Count.m_CurveMax}, m_RepeatCount = val_15.m_RepeatCount});
            val_5.Play();
            this.UpdateUI();
            return;
        }
        
        UnityEngine.Coroutine val_17 = this.StartCoroutine(routine:  this.ShowNotEnoughTooltip());
    }
    private System.Collections.IEnumerator ShowNotEnoughTooltip()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGGoldenMultiplierPopup.<ShowNotEnoughTooltip>d__22();
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void SetupBonusSection()
    {
        UnityEngine.GameObject val_23;
        var val_24;
        UnityEngine.Sprite val_25;
        UnityEngine.GameObject val_26;
        float val_27;
        if((MonoSingleton<GoldenMultiplierManager>.Instance.GetCurrentBonusFromSubs) <= 0f)
        {
            goto label_4;
        }
        
        if(this.subsBonusUI != 0)
        {
            goto label_7;
        }
        
        UnityEngine.GameObject val_4 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.bonusPrefab, parent:  this.bonusesParent);
        val_23 = val_4;
        this.subsBonusUI = val_4;
        goto label_10;
        label_4:
        val_24 = 0;
        goto label_11;
        label_7:
        val_23 = this.subsBonusUI;
        label_10:
        val_25 = this.subs;
        string val_9 = System.String.Format(format:  Localization.Localize(key:  "", defaultValue:  "Includes {0}X from your active Golden Ticket", useSingularKey:  false), arg0:  MonoSingleton<GoldenMultiplierManager>.Instance.GetCurrentBonusFromSubs.ToString());
        val_9.SetUpBonusUI(bonusUI:  val_23, iconImage:  val_25, descText:  val_9);
        val_24 = 1;
        label_11:
        if((MonoSingleton<GoldenMultiplierManager>.Instance.GetCurrentBonusFromDifficulty) <= 0f)
        {
            goto label_18;
        }
        
        if(this.difficultyBonusUI != 0)
        {
            goto label_21;
        }
        
        UnityEngine.GameObject val_13 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.bonusPrefab, parent:  this.bonusesParent);
        val_26 = val_13;
        this.difficultyBonusUI = val_13;
        goto label_24;
        label_18:
        var val_14 = (val_24 == 0) ? 0f : 20f;
        goto label_25;
        label_21:
        val_26 = this.difficultyBonusUI;
        label_24:
        val_25 = this.difficulty;
        string val_19 = System.String.Format(format:  Localization.Localize(key:  "", defaultValue:  "Includes {0}X from your difficulty setting", useSingularKey:  false), arg0:  MonoSingleton<GoldenMultiplierManager>.Instance.GetCurrentBonusFromDifficulty.ToString());
        val_19.SetUpBonusUI(bonusUI:  val_26, iconImage:  val_25, descText:  val_19);
        val_24 = val_24 + 1;
        val_27 = 20f;
        label_25:
        float val_23 = 150f;
        val_23 = (float)val_24 * val_23;
        val_27 = val_27 + val_23;
        UnityEngine.Vector2 val_21 = this.mainUI.sizeDelta;
        UnityEngine.Vector2 val_22 = new UnityEngine.Vector2(x:  val_21.x, y:  val_27 + 1060f);
        this.mainUI.sizeDelta = new UnityEngine.Vector2() {x = val_22.x, y = val_22.y};
    }
    private void SetUpBonusUI(UnityEngine.GameObject bonusUI, UnityEngine.Sprite iconImage, string descText)
    {
        T val_3 = bonusUI.GetComponentsInChildren<UnityEngine.UI.Image>()[1];
        val_3.sprite = iconImage;
        val_3.preserveAspect = true;
        UnityEngine.UI.Text val_2 = bonusUI.GetComponentInChildren<UnityEngine.UI.Text>();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public WGGoldenMultiplierPopup()
    {
    
    }

}
