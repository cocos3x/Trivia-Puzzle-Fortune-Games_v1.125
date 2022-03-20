using UnityEngine;
public class WGBonusRewardsPopup : MonoBehaviour
{
    // Fields
    private WGBonusRewardsRow rowObject;
    private UnityEngine.UI.VerticalLayoutGroup rowParent;
    private UnityEngine.UI.Button infoButton;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button infoPopupCloseButton;
    private UnityEngine.GameObject infoPopup;
    private UnityEngine.GameObject primaryPopup;
    private UnityEngine.UI.Text bonusLevelText;
    private UnityEngine.UI.Text bonusPointsText;
    
    // Methods
    private void OnEnable()
    {
        this.SetupRequirements();
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGBonusRewardsPopup::Close()));
        this.infoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGBonusRewardsPopup::ToggleInfo()));
        this.infoPopupCloseButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGBonusRewardsPopup::ToggleInfo()));
        this.primaryPopup.SetActive(value:  true);
        this.infoPopup.SetActive(value:  false);
        this.SetupText();
    }
    private void SetupRequirements()
    {
        BonusRewardsContainer val_3;
        var val_4;
        UnityEngine.Transform val_8;
        UnityEngine.UI.VerticalLayoutGroup val_9;
        WGBonusRewardsRow val_10;
        List.Enumerator<T> val_2 = App.getGameEcon.GetEnumerator();
        label_13:
        val_8 = public System.Boolean List.Enumerator<BonusRewardsContainer>::MoveNext();
        if(val_4.MoveNext() == false)
        {
            goto label_5;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_3 + 16) == 0)
        {
            goto label_13;
        }
        
        val_10 = this.rowObject;
        if((val_3 + 16) != 1)
        {
                val_9 = this.rowParent;
            if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
            val_8 = val_9.transform;
            val_10 = UnityEngine.Object.Instantiate<WGBonusRewardsRow>(original:  val_10, parent:  val_8);
        }
        
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10.Setup(myData:  val_3);
        goto label_13;
        label_5:
        val_4.Dispose();
    }
    private void SetupText()
    {
        UnityEngine.UI.Text val_15;
        var val_16;
        int val_17;
        BonusRewardsContainer val_2 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetNextRewards();
        if(val_2 != null)
        {
                val_15 = this.bonusLevelText;
            val_16 = val_2;
            val_17 = (val_2.<level>k__BackingField) - 1;
        }
        else
        {
                val_17 = val_4.<level>k__BackingField;
            val_15 = this.bonusLevelText;
            val_16 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetCurrentRewards();
        }
        
        string val_5 = val_17.ToString();
        GameEcon val_8 = App.getGameEcon;
        GameEcon val_10 = App.getGameEcon;
        string val_12 = System.String.Format(format:  "{0} / {1}", arg0:  DefaultHandler<WGBonusRewardsHandler>.Instance.GetProgressThroughCurrentTier().ToString(format:  val_8.numberFormatInt), arg1:  val_4.<pointReq>k__BackingField.ToString(format:  val_10.numberFormatInt));
        if((DefaultHandler<WGBonusRewardsHandler>.Instance.MaxPointsGained()) == false)
        {
                return;
        }
    
    }
    private void ToggleInfo()
    {
        this.primaryPopup.gameObject.SetActive(value:  this.infoPopup.gameObject.activeSelf);
        this.infoPopup.gameObject.SetActive(value:  (~this.infoPopup.gameObject.activeSelf) & 1);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGBonusRewardsPopup()
    {
    
    }

}
