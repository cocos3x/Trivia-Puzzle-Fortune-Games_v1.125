using UnityEngine;
public class FPHMultiplerChestGameplayUI : MonoBehaviour
{
    // Fields
    private FPHMultiplierChestChestUI[] chestChestUIs;
    private UnityEngine.CanvasGroup chestUICanvasGroup;
    private UnityEngine.UI.Button chestsUIButton;
    private UnityEngine.UI.Button tooltipButton;
    private DG.Tweening.Sequence toolTipSeq;
    
    // Methods
    private void Start()
    {
        FPHEcon val_2 = App.GetGameSpecificEcon<FPHEcon>();
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  val_2.multiplierChestUnlockLevel)) != false)
        {
                this.chestUICanvasGroup.alpha = (FPHGameplayController.currentGameplayMode == 1) ? 0f : 1f;
            this.chestsUIButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHMultiplerChestGameplayUI::OnChestsUIButtonClicked()));
            this.tooltipButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHMultiplerChestGameplayUI::OnChestsUIButtonClicked()));
            return;
        }
        
        this.chestUICanvasGroup.interactable = false;
        this.chestUICanvasGroup.alpha = 0f;
    }
    public void SetChestStates(int currentChestIndex, int currentIncorrects, bool animated = False)
    {
        var val_4 = 0;
        do
        {
            if(val_4 >= this.chestChestUIs.Length)
        {
                return;
        }
        
            this.chestChestUIs[val_4].SetState(isLost:  (val_4 > currentChestIndex) ? 1 : 0, isFuture:  (val_4 < currentChestIndex) ? 1 : 0, incorrects:  currentIncorrects);
            val_4 = val_4 + 1;
        }
        while(this.chestChestUIs != null);
        
        throw new NullReferenceException();
    }
    public void ChestClicked()
    {
        this.OnChestsUIButtonClicked();
    }
    private void OnChestsUIButtonClicked()
    {
        if(this.toolTipSeq != null)
        {
                DG.Tweening.TweenExtensions.Complete(t:  this.toolTipSeq);
            return;
        }
        
        this.tooltipButton.GetComponent<UnityEngine.CanvasGroup>().blocksRaycasts = true;
        DG.Tweening.Sequence val_2 = DG.Tweening.DOTween.Sequence();
        this.toolTipSeq = val_2;
        DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_2, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.tooltipButton.GetComponent<UnityEngine.CanvasGroup>(), endValue:  1f, duration:  0.1f));
        DG.Tweening.Sequence val_6 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.toolTipSeq, interval:  3.5f);
        DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.toolTipSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.tooltipButton.GetComponent<UnityEngine.CanvasGroup>(), endValue:  0f, duration:  0.1f));
        DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  this.toolTipSeq, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void FPHMultiplerChestGameplayUI::<OnChestsUIButtonClicked>b__8_0()));
    }
    public FPHMultiplerChestGameplayUI()
    {
    
    }
    private void <OnChestsUIButtonClicked>b__8_0()
    {
        this.tooltipButton.GetComponent<UnityEngine.CanvasGroup>().blocksRaycasts = false;
        this.toolTipSeq = 0;
    }

}
