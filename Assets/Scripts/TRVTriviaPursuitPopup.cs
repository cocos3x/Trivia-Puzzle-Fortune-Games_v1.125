using UnityEngine;
public class TRVTriviaPursuitPopup : MonoBehaviour
{
    // Fields
    private System.Collections.Generic.List<TRVTriviaPursuitCategoryDisplay> categories;
    private UnityEngine.UI.Text description;
    private UnityEngine.UI.Text reward;
    private UnityEngine.UI.Text rerollCost;
    private UnityEngine.GameObject regularButtonsBottom;
    private UnityEngine.UI.Button rerollButton;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Button collectButton;
    private UnityEngine.UI.Button closeButton;
    private GemsCollectAnimationInstantiator gemAnim;
    
    // Methods
    public void ShowEventPopup(TRVTriviaPursuitPopupGeneralDisplayInfo info)
    {
        System.Collections.Generic.List<TRVTriviaPursuitCategoryDisplay> val_8;
        this.rerollButton.m_OnClick.RemoveAllListeners();
        this.continueButton.m_OnClick.RemoveAllListeners();
        this.closeButton.m_OnClick.RemoveAllListeners();
        this.rerollButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVTriviaPursuitPopup::OnClick_Reroll()));
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVTriviaPursuitPopup::OnClick_Continue()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVTriviaPursuitPopup::Close()));
        this.regularButtonsBottom.SetActive(value:  true);
        this.collectButton.gameObject.SetActive(value:  false);
        string val_6 = info + 32.ToString();
        string val_7 = info.rerollCost.ToString();
        this.rerollButton.interactable = info.isEligibleToReroll;
        if(info.shouldAnimateCategories != false)
        {
                this.AnimateCategoryReroll(finalDisplayInfo:  info.isEligibleToReroll);
            return;
        }
        
        val_8 = this.categories;
        var val_9 = 4;
        do
        {
            var val_8 = val_9 - 4;
            if(val_8 >= info.shouldAnimateCategories)
        {
                return;
        }
        
            if(info.shouldAnimateCategories <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((X24 + 24) <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            info.shouldAnimateCategories + 32.Setup(info:  X24 + 16 + 32);
            val_8 = this.categories;
            val_9 = val_9 + 1;
        }
        while(val_8 != null);
        
        throw new NullReferenceException();
    }
    public void ShowRewardPopup(TRVTriviaPursuitPopupRewardDisplayInfo info)
    {
        .<>4__this = this;
        .info = info;
        this.regularButtonsBottom.SetActive(value:  false);
        this.closeButton.gameObject.SetActive(value:  false);
        var val_8 = 4;
        label_12:
        var val_3 = val_8 - 4;
        if(val_3 >= 1152921504966483968)
        {
            goto label_6;
        }
        
        if(1152921504966483968 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X24 + 24) <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.categories.Setup(info:  X24 + 16 + 32);
        val_8 = val_8 + 1;
        if(this.categories != null)
        {
            goto label_12;
        }
        
        label_6:
        this.description.resizeTextForBestFit = false;
        string val_5 = ((TRVTriviaPursuitPopup.<>c__DisplayClass11_0)[1152921517409474128].info) + 32.ToString();
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new TRVTriviaPursuitPopup.<>c__DisplayClass11_0(), method:  System.Void TRVTriviaPursuitPopup.<>c__DisplayClass11_0::<ShowRewardPopup>b__0()));
        this.collectButton.gameObject.SetActive(value:  true);
    }
    private void AnimateCategoryReroll(System.Collections.Generic.List<TRVTriviaPursuitCategoryDisplayInfo> finalDisplayInfo)
    {
        System.Collections.Generic.List<System.String> val_4;
        var val_5;
        var val_6;
        val_5 = 4;
        do
        {
            var val_1 = val_5 - 4;
            if(val_1 >= this.categories)
        {
                return;
        }
        
            val_6 = null;
            val_6 = null;
            if((TRVDataParser.categoryNames + 24) <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_4 = MonoSingleton<TRVDataParser>.Instance.getAvailableSubCategories.Item[TRVDataParser.categoryNames + 16 + 32];
            if((TRVDataParser.categoryNames + 16) <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            TRVDataParser.categoryNames + 16 + 32.AnimateCategory(incCats:  val_4, finalInfo:  TRVDataParser.categoryNames + 16 + 32);
            val_5 = val_5 + 1;
        }
        while(this.categories != null);
        
        throw new NullReferenceException();
    }
    private void OnClick_Reroll()
    {
        TRVTriviaPursuitEventHandler.<Instance>k__BackingField.RerollAnimateCategories();
    }
    private void OnClick_Continue()
    {
        this.Close();
    }
    private void OnClick_Collect(int reward)
    {
        29007.CollectReward();
        mem2[0] = new System.Action(object:  this, method:  System.Void TRVTriviaPursuitPopup::OnClick_Reroll());
        Player val_2 = App.Player;
        Player val_3 = App.Player;
        decimal val_4 = System.Decimal.op_Implicit(value:  val_3._gems);
        this.gemAnim.Play(fromValue:  val_2._gems - reward, toValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
    }
    private void Close()
    {
        this.gameObject.SetActive(value:  false);
    }
    private void OnDisable()
    {
        if((TRVTriviaPursuitEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        TRVTriviaPursuitEventHandler.<Instance>k__BackingField.OnMyEventPopupClosed();
    }
    public TRVTriviaPursuitPopup()
    {
    
    }

}
