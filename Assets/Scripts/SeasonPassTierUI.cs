using UnityEngine;
public class SeasonPassTierUI : MonoBehaviour
{
    // Fields
    public UnityEngine.UI.Image tierIcon;
    public UnityEngine.UI.Text tierText;
    public UnityEngine.GameObject freeTierGO;
    public UnityEngine.GameObject chestTooltip;
    public UnityEngine.Sprite freeTierSprite;
    public System.Collections.Generic.List<UnityEngine.Sprite> tierIconTextures;
    private System.Collections.Generic.List<UnityEngine.Sprite> rewardSprites;
    public UnityEngine.UI.Button passClaimBtn;
    public UnityEngine.UI.Image passIcon;
    public UnityEngine.UI.Text passAmountTxt;
    public UnityEngine.GameObject passCollectedIcon;
    public UnityEngine.GameObject lockIcon;
    public UnityEngine.UI.Button freeClaimBtn;
    public UnityEngine.UI.Image freeIcon;
    public UnityEngine.UI.Text freeAmountTxt;
    public UnityEngine.GameObject freeCollectedIcon;
    private int tierIndex;
    private SeasonPassEcon.Tier tier;
    private UnityEngine.GameObject tooltip;
    private SeasonPassEventHandler eventHandler;
    private UnityEngine.GameObject tierHeader;
    private UnityEngine.GameObject tierDivider;
    private UnityEngine.UI.Image freeTierImage;
    private UnityEngine.UI.Button freeTooltipButton;
    private UnityEngine.UI.Button passTooltipButton;
    private SeasonPassEventPopup _seasonPopupParent;
    
    // Properties
    private SeasonPassEventPopup SeasonPopupParent { get; }
    
    // Methods
    private SeasonPassEventPopup get_SeasonPopupParent()
    {
        SeasonPassEventPopup val_4;
        if(this._seasonPopupParent == 0)
        {
                this._seasonPopupParent = this.transform.GetComponentInParent<SeasonPassEventPopup>();
            return val_4;
        }
        
        val_4 = this._seasonPopupParent;
        return val_4;
    }
    public void Awake()
    {
        this.passClaimBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SeasonPassTierUI::OnClickPassClaimBtn()));
        this.freeClaimBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SeasonPassTierUI::OnClickFreeClaimBtn()));
        this.freeTooltipButton = this.freeIcon.GetComponent<UnityEngine.UI.Button>();
        this.passTooltipButton = this.passIcon.GetComponent<UnityEngine.UI.Button>();
        this.freeTooltipButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SeasonPassTierUI::<Awake>b__29_0()));
        this.passTooltipButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SeasonPassTierUI::<Awake>b__29_1()));
        this.eventHandler = SeasonPassEventHandler.<Instance>k__BackingField;
    }
    private void ScrollCellIndex(int index)
    {
        if(this.eventHandler == null)
        {
                return;
        }
        
        if(index != 0)
        {
                index = index - 1;
            TierData val_1 = this.eventHandler.GetTierData(tierIndex:  index);
            this.SetupTierAward(data:  new TierData() {lvlUnlocked = false, passActive = false, freeCollected = false, passCollected = false, currentTier = false});
            return;
        }
        
        this.SetHeaderTier();
    }
    public void SetupTierAward(SeasonPassEventHandler.TierData data)
    {
        var val_23;
        var val_24;
        this.Clear();
        this.tierIndex = data.tierIndex;
        this.tier = data.tier;
        int val_2 = UnityEngine.Mathf.Max(a:  0, b:  data.tierIndex - 1);
        var val_23 = 0;
        int val_4 = UnityEngine.Mathf.Min(a:  UnityEngine.Mathf.FloorToInt(f:  0f), b:  2);
        if(val_23 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_23 = val_23 + (val_4 << 3);
        this.tierIcon.sprite = (0 + (val_4) << 3) + 32;
        string val_5 = this.tierIndex.ToString();
        UnityEngine.GameObject val_6 = this.passClaimBtn.gameObject;
        if((data.lvlUnlocked == false) || (data.passActive == false))
        {
            goto label_9;
        }
        
        var val_7 = (data.passCollected == false) ? 1 : 0;
        if(val_6 != null)
        {
            goto label_10;
        }
        
        label_9:
        val_23 = 0;
        label_10:
        val_6.SetActive(value:  false);
        SeasonPassEcon.Tier val_24 = this.tier;
        RewardIcons val_8 = val_6.GetTierIcon(item:  this.tier.PassItem, amount:  this.tier.AwardPass, isPass:  true);
        if(val_24 <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_24 = val_24 + (val_8 << 3);
        this.passIcon.sprite = this.tier.PassItem;
        string val_9 = this.tier.AwardPass.ToString();
        this.passAmountTxt.gameObject.SetActive(value:  (data.passCollected == false) ? 1 : 0);
        this.passCollectedIcon.SetActive(value:  (data.passCollected == true) ? 1 : 0);
        this.passTooltipButton.enabled = (this.tier.PassItem == 5) ? 1 : 0;
        this.lockIcon.SetActive(value:  (data.passActive == false) ? 1 : 0);
        UnityEngine.GameObject val_15 = this.freeClaimBtn.gameObject;
        if(data.lvlUnlocked == false)
        {
            goto label_26;
        }
        
        var val_16 = (data.freeCollected == false) ? 1 : 0;
        if(val_15 != null)
        {
            goto label_27;
        }
        
        label_26:
        val_24 = 0;
        label_27:
        val_15.SetActive(value:  false);
        SeasonPassEcon.Tier val_25 = this.tier;
        RewardIcons val_17 = val_15.GetTierIcon(item:  this.tier.FreeItem, amount:  this.tier.AwardFree, isPass:  false);
        if(val_25 <= val_17)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_25 = val_25 + (val_17 << 3);
        this.freeIcon.sprite = this.tier.FreeItem;
        string val_18 = this.tier.AwardFree.ToString();
        this.freeAmountTxt.gameObject.SetActive(value:  (data.freeCollected == false) ? 1 : 0);
        this.freeCollectedIcon.SetActive(value:  (data.freeCollected == true) ? 1 : 0);
        this.freeTooltipButton.enabled = (this.tier.FreeItem == 5) ? 1 : 0;
        if(data.tierIndex == 0)
        {
                this.SetFreeTier();
        }
        
        if(data.currentTier == false)
        {
                return;
        }
        
        this.AddTierDivider();
    }
    private void Clear()
    {
        this.transform.GetChild(index:  0).gameObject.SetActive(value:  true);
        this.tierText.gameObject.SetActive(value:  true);
        this.DestroyTooltip();
        if(this.tierHeader != 0)
        {
                this.tierHeader.gameObject.SetActive(value:  false);
        }
        
        if(this.tierDivider != 0)
        {
                this.tierDivider.gameObject.SetActive(value:  false);
        }
        
        if(this.freeTierImage == 0)
        {
                return;
        }
        
        this.freeTierImage.gameObject.SetActive(value:  false);
    }
    private void SetFreeTier()
    {
        UnityEngine.UI.Image val_1 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.UI.Image>(gameObject:  this.freeTierGO);
        this.freeTierImage = val_1;
        val_1.sprite = this.freeTierSprite;
        this.freeTierImage.gameObject.SetActive(value:  true);
        this.tierText.gameObject.SetActive(value:  false);
    }
    private void AddTierDivider()
    {
        if(this.SeasonPopupParent == 0)
        {
                return;
        }
        
        if(this.tierDivider != 0)
        {
            goto label_6;
        }
        
        SeasonPassEventPopup val_4 = this.SeasonPopupParent;
        UnityEngine.GameObject val_6 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_4.tierLockDivider, parent:  this.transform);
        this.tierDivider = val_6;
        if(val_6 != null)
        {
            goto label_10;
        }
        
        label_6:
        label_10:
        this.tierDivider.gameObject.SetActive(value:  true);
    }
    private void SetHeaderTier()
    {
        if(this.SeasonPopupParent == 0)
        {
                return;
        }
        
        this.transform.GetChild(index:  0).gameObject.SetActive(value:  false);
        if(this.tierHeader != 0)
        {
            goto label_9;
        }
        
        SeasonPassEventPopup val_7 = this.SeasonPopupParent;
        UnityEngine.GameObject val_9 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_7.tierHeader, parent:  this.transform);
        this.tierHeader = val_9;
        if(val_9 != null)
        {
            goto label_13;
        }
        
        label_9:
        label_13:
        this.tierHeader.gameObject.SetActive(value:  true);
        if(this.tierDivider == 0)
        {
                return;
        }
        
        this.tierDivider.gameObject.SetActive(value:  false);
    }
    private SeasonPassTierUI.RewardIcons GetTierIcon(SeasonPassEcon.Item item, int amount, bool isPass)
    {
        if(item > 5)
        {
                return 5;
        }
        
        var val_8 = 32561680 + (item) << 2;
        val_8 = val_8 + 32561680;
        goto (32561680 + (item) << 2 + 32561680);
    }
    private void onClickImage(UnityEngine.GameObject go, bool isPass)
    {
        this.DestroyTooltip();
        UnityEngine.GameObject val_3 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.chestTooltip, parent:  go.transform.parent);
        this.tooltip = val_3;
        UnityEngine.UI.Text val_4 = val_3.GetComponentInChildren<UnityEngine.UI.Text>();
        var val_5 = (isPass != true) ? 20 : 28;
        string val_6 = SeasonPassEventHandler.<Instance>k__BackingField.GetChestContent(itemAward:  326623232);
        if(isPass != true)
        {
                UnityEngine.Vector3 val_8 = this.tooltip.transform.localPosition;
            UnityEngine.Vector3 val_9 = UnityEngine.Vector3.left;
            val_8.x.Scale(scale:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z});
            UnityEngine.Vector3 val_12 = this.tooltip.transform.GetChild(index:  1).localPosition;
            UnityEngine.Vector3 val_13 = UnityEngine.Vector3.left;
            val_12.x.Scale(scale:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z});
        }
        
        this.Invoke(methodName:  "DestroyTooltip", time:  5f);
    }
    private void OnClickPassClaimBtn()
    {
        this.passClaimBtn.gameObject.SetActive(value:  false);
        this.passAmountTxt.gameObject.SetActive(value:  false);
        this.passCollectedIcon.SetActive(value:  true);
        if(this.SeasonPopupParent == 0)
        {
                return;
        }
        
        this.SeasonPopupParent.OnRewardClaim(index:  this.tierIndex, isPassReward:  true);
    }
    private void OnClickFreeClaimBtn()
    {
        this.freeClaimBtn.gameObject.SetActive(value:  false);
        this.freeAmountTxt.gameObject.SetActive(value:  false);
        this.freeCollectedIcon.SetActive(value:  true);
        if(this.SeasonPopupParent == 0)
        {
                return;
        }
        
        this.SeasonPopupParent.OnRewardClaim(index:  this.tierIndex, isPassReward:  false);
    }
    private void DestroyTooltip()
    {
        if(this.tooltip == 0)
        {
                return;
        }
        
        UnityEngine.Object.Destroy(obj:  this.tooltip);
    }
    public SeasonPassTierUI()
    {
    
    }
    private void <Awake>b__29_0()
    {
        this.onClickImage(go:  this.freeIcon.gameObject, isPass:  false);
    }
    private void <Awake>b__29_1()
    {
        this.onClickImage(go:  this.passIcon.gameObject, isPass:  true);
    }

}
