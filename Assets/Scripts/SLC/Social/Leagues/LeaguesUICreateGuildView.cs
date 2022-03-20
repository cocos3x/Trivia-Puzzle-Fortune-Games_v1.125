using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUICreateGuildView : MonoBehaviour
    {
        // Fields
        private bool editClubMode;
        private UnityEngine.UI.Text clubImageLabel;
        private UnityEngine.UI.Image clubImage;
        private UnityEngine.UI.Text nameInputLabel;
        private UnityEngine.UI.InputField nameInputField;
        private UnityEngine.UI.InputField mottoInputField;
        private UnityEngine.UI.Text vipReqLabel;
        private UnityEngine.UI.Dropdown vipReqDropdown;
        private UnityEngine.UI.Text inviteOnlyLabel;
        private UnityEngine.UI.Dropdown inviteOnlyDropDown;
        private UnityEngine.UI.Button createClubButton;
        private UnityEngine.UI.Text createClubCostText;
        public System.Action<string> showMessageFlyout;
        private int clubImageId;
        private string clubName;
        private string clubMotto;
        private bool clubInviteReq;
        private decimal clubReqAmount;
        
        // Methods
        private void Start()
        {
            this.PopulateVipReqOptions();
            this.PopulateInviteOnlyOptions();
            this.clubImage.sprite = SLC.Social.Leagues.LeaguesUIManager.guildAvatarHandler.GetAvatarSpriteByID(id:  0, portraitID:  0);
            if(this.editClubMode != false)
            {
                    this.PopulateCurrentClubData();
            }
            
            this.nameInputField.m_OnEndEdit.AddListener(call:  new UnityEngine.Events.UnityAction<System.String>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUICreateGuildView::OnClubNameChanged(string _nameImputString)));
            if(this.mottoInputField != 0)
            {
                    this.mottoInputField.m_OnEndEdit.AddListener(call:  new UnityEngine.Events.UnityAction<System.String>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUICreateGuildView::OnClubMottoChanged(string _mottoInputChanged)));
            }
            
            this.vipReqDropdown.m_OnValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Int32>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUICreateGuildView::OnClubReqChanged(int _valueSelected)));
            this.inviteOnlyDropDown.m_OnValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Int32>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUICreateGuildView::OnClubInviteChange(int _valueSelected)));
            this.createClubButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUICreateGuildView::CreateClubButtonPressed()));
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnDataReady");
        }
        private void OnClubNameChanged(string _nameImputString)
        {
            this.clubName = _nameImputString;
            this.SubmitClubEdit();
        }
        private void OnClubMottoChanged(string _mottoInputChanged)
        {
            this.clubMotto = _mottoInputChanged;
            this.SubmitClubEdit();
        }
        public void OnClubImageChanged()
        {
            this.clubImageId = SLC.Social.Leagues.LeaguesUIManager.guildAvatarHandler.GetIDByAvatarSprite(sprite:  this.clubImage.m_Sprite, randomIfNotFound:  false);
            this.SubmitClubEdit();
        }
        private void OnClubReqChanged(int _valueSelected)
        {
            null = null;
            System.Decimal[] val_3 = SLC.Social.Leagues.LeaguesEconomy.RequirementOptions;
            val_3 = val_3 + ((this.vipReqDropdown.m_Value) << 4);
            decimal val_2 = System.Decimal.op_Implicit(value:  System.Decimal.ToInt32(d:  new System.Decimal() {flags = (SLC.Social.Leagues.LeaguesEconomy.RequirementOptions + (this.vipReqDropdown.m_Value) << 4) + 32, hi = (SLC.Social.Leagues.LeaguesEconomy.RequirementOptions + (this.vipReqDropdown.m_Value) << 4) + 32, lo = (SLC.Social.Leagues.LeaguesEconomy.RequirementOptions + (this.vipReqDropdown.m_Value) << 4) + 32 + 8, mid = (SLC.Social.Leagues.LeaguesEconomy.RequirementOptions + (this.vipReqDropdown.m_Value) << 4) + 32 + 8}));
            this.clubReqAmount = val_2;
            mem[1152921519693246644] = val_2.lo;
            mem[1152921519693246648] = val_2.mid;
            this.SubmitClubEdit();
        }
        private void OnClubInviteChange(int _valueSelected)
        {
            this.clubInviteReq = System.Convert.ToBoolean(value:  this.inviteOnlyDropDown.m_Value);
            this.SubmitClubEdit();
        }
        private void OnEnable()
        {
            if(this.editClubMode != false)
            {
                    this.PopulateCurrentClubData();
            }
            else
            {
                    GameEcon val_1 = App.getGameEcon;
                string val_2 = ToString(format:  val_1.numberFormatInt);
                this.createClubButton.interactable = true;
            }
            
            this.OnLocalize();
        }
        private void OnLocalize()
        {
            string val_2 = System.String.Format(format:  "{0}:", arg0:  Localization.Localize(key:  "club_image", defaultValue:  "CLUB IMAGE", useSingularKey:  false));
            string val_4 = System.String.Format(format:  "{0}:", arg0:  Localization.Localize(key:  "club_name", defaultValue:  "CLUB NAME", useSingularKey:  false));
            string val_6 = System.String.Format(format:  "{0}:", arg0:  Localization.Localize(key:  "requirement_upper", defaultValue:  "REQUIREMENT", useSingularKey:  false));
            string val_8 = System.String.Format(format:  "{0}:", arg0:  Localization.Localize(key:  "invite_only", defaultValue:  "INVITE ONLY", useSingularKey:  false));
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        }
        private void PopulateCurrentClubData()
        {
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
            {
                    return;
            }
            
            SLC.Social.Leagues.Guild val_5 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            this.clubImage.sprite = SLC.Social.Leagues.LeaguesUIManager.guildAvatarHandler.GetAvatarSpriteByID(id:  val_5.AvatarId, portraitID:  0);
            SLC.Social.Leagues.Guild val_8 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            this.clubImageId = val_8.AvatarId;
            SLC.Social.Leagues.Guild val_10 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            this.clubName = val_10.Name;
            SLC.Social.Leagues.Guild val_12 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            this.nameInputField.text = val_12.Name;
            if(this.mottoInputField != 0)
            {
                    SLC.Social.Leagues.Guild val_15 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
                this.clubMotto = val_15.Motto;
                SLC.Social.Leagues.Guild val_17 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
                this.mottoInputField.text = val_17.Motto;
            }
            
            SLC.Social.Leagues.Guild val_19 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            decimal val_20 = System.Decimal.op_Implicit(value:  val_19.requiredVIPLevel);
            this.vipReqDropdown.value = SLC.Social.Leagues.LeaguesEconomy.GetIndexOfRequirementOption(req:  new System.Decimal() {flags = val_20.flags, hi = val_20.hi, lo = val_20.lo, mid = val_20.mid});
            SLC.Social.Leagues.Guild val_23 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            decimal val_24 = System.Decimal.op_Implicit(value:  val_23.requiredVIPLevel);
            this.clubReqAmount = val_24;
            mem[1152921519693994436] = val_24.lo;
            mem[1152921519693994440] = val_24.mid;
            this.vipReqDropdown.RefreshShownValue();
            SLC.Social.Leagues.Guild val_26 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            this.inviteOnlyDropDown.value = val_26.InviteRequired;
            SLC.Social.Leagues.Guild val_28 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            this.clubInviteReq = val_28.InviteRequired;
            this.inviteOnlyDropDown.RefreshShownValue();
        }
        public void SubmitClubEdit()
        {
            if(this.editClubMode == false)
            {
                    return;
            }
            
            SLC.Social.Leagues.Guild val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            if(((System.String.op_Equality(a:  this.clubName, b:  val_2.Name)) != false) && (((System.String.op_Equality(a:  this.clubMotto, b:  val_2.Motto)) != false) && (this.clubImageId == val_2.AvatarId)))
            {
                    var val_5 = (this.clubInviteReq == true) ? 1 : 0;
                val_5 = val_5 ^ ((val_2.InviteRequired == true) ? 1 : 0);
                if((val_5 & 1) == 0)
            {
                    if((System.Decimal.ToInt32(d:  new System.Decimal() {flags = this.clubReqAmount, hi = this.clubReqAmount, lo = X22, mid = X22})) == val_2.requiredVIPLevel)
            {
                    return;
            }
            
            }
            
            }
            
            this.CreateClubButtonPressed();
        }
        private void PopulateVipReqOptions()
        {
            var val_9;
            var val_10;
            var val_12;
            string val_13;
            this.vipReqDropdown.options.Clear();
            val_10 = null;
            val_10 = null;
            var val_2 = (this.vipReqDropdown == 0) ? 1 : 0;
            if(SLC.Social.Leagues.LeaguesEconomy.RequirementOptions.Length >= 1)
            {
                    var val_9 = 0;
                do
            {
                val_9 = this.vipReqDropdown.options;
                if(val_9 != 0)
            {
                    string val_4 = ToString();
                val_12 = null;
                var val_5 = (val_4 == null) ? "" : (val_4);
            }
            else
            {
                    val_12 = null;
                val_13 = Localization.Localize(key:  "none_upper", defaultValue:  "NONE", useSingularKey:  false);
            }
            
                val_9.Add(item:  new Dropdown.OptionData(text:  val_13));
                val_9 = val_9 + 1;
                var val_8 = (this.vipReqDropdown == 0) ? 1 : 0;
            }
            while(val_9 < SLC.Social.Leagues.LeaguesEconomy.RequirementOptions.Length);
            
            }
            
            this.vipReqDropdown.value = 0;
            this.vipReqDropdown.RefreshShownValue();
        }
        private void PopulateInviteOnlyOptions()
        {
            this.inviteOnlyDropDown.options.set_Item(index:  0, value:  new Dropdown.OptionData(text:  Localization.Localize(key:  "anyone_can_join", defaultValue:  "ANYONE CAN JOIN", useSingularKey:  false)));
            this.inviteOnlyDropDown.options.set_Item(index:  1, value:  new Dropdown.OptionData(text:  Localization.Localize(key:  "invite_only", defaultValue:  "INVITE ONLY", useSingularKey:  false)));
            this.inviteOnlyDropDown.RefreshShownValue();
        }
        private void CreateClubButtonPressed()
        {
            System.Action<System.String> val_27;
            var val_28;
            var val_29;
            var val_30;
            val_27 = this;
            if(this.editClubMode == false)
            {
                goto label_1;
            }
            
            if((System.String.IsNullOrEmpty(value:  this.clubName)) == false)
            {
                goto label_2;
            }
            
            val_27 = this.showMessageFlyout;
            if(val_27 == null)
            {
                    return;
            }
            
            val_27.Invoke(obj:  Localization.Localize(key:  "club_name_required", defaultValue:  "Club requires a name.", useSingularKey:  false));
            return;
            label_1:
            Player val_3 = App.Player;
            val_28 = null;
            val_28 = null;
            if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_3._credits, hi = val_3._credits, lo = 41975808}, d2:  new System.Decimal() {flags = SLC.Social.Leagues.LeaguesEconomy.CostToCreate, hi = SLC.Social.Leagues.LeaguesEconomy.CostToCreate, lo = SLC.Social.Leagues.LeaguesEconomy.CostToCreate.__il2cppRuntimeField_8, mid = SLC.Social.Leagues.LeaguesEconomy.CostToCreate.__il2cppRuntimeField_8})) == false)
            {
                goto label_11;
            }
            
            val_29 = null;
            val_29 = null;
            PurchaseProxy.currentPurchasePoint = 21;
            MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  false).Init(outOfCredits:  true, onCloseAction:  0);
            return;
            label_2:
            SLC.Social.Leagues.Guild val_8 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            val_8.AvatarId = this.clubImageId;
            SLC.Social.Leagues.Guild val_10 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            val_10.Name = this.clubName;
            SLC.Social.Leagues.Guild val_12 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            val_12.Motto = this.clubMotto;
            SLC.Social.Leagues.Guild val_14 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            val_14.InviteRequired = this.clubInviteReq;
            SLC.Social.Leagues.Guild val_16 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            val_16.requiredVIPLevel = System.Decimal.ToInt32(d:  new System.Decimal() {flags = this.clubReqAmount, hi = this.clubReqAmount, lo = X21, mid = X21});
            SLC.Social.Leagues.LeaguesManager.DAO.UpdateMyGuildInfo(resultAction:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUICreateGuildView::<CreateClubButtonPressed>b__30_0(bool result)));
            return;
            label_11:
            this.createClubButton.interactable = false;
            val_30 = null;
            val_30 = null;
            System.Decimal[] val_27 = SLC.Social.Leagues.LeaguesEconomy.RequirementOptions;
            val_27 = val_27 + ((this.vipReqDropdown.m_Value) << 4);
            if((SLC.Social.Leagues.LeaguesManager.DAO.PurchaseGuild(guildIconIndex:  SLC.Social.Leagues.LeaguesUIManager.guildAvatarHandler.GetIDByAvatarSprite(sprite:  this.clubImage.m_Sprite, randomIfNotFound:  true), guildName:  this.clubName, motto:  this.clubMotto, requiresInvite:  System.Convert.ToBoolean(value:  this.inviteOnlyDropDown.m_Value), vipLevelRequired:  System.Decimal.ToInt32(d:  new System.Decimal() {flags = (SLC.Social.Leagues.LeaguesEconomy.RequirementOptions + (this.vipReqDropdown.m_Value) << 4) + 32, hi = (SLC.Social.Leagues.LeaguesEconomy.RequirementOptions + (this.vipReqDropdown.m_Value) << 4) + 32, lo = (SLC.Social.Leagues.LeaguesEconomy.RequirementOptions + (this.vipReqDropdown.m_Value) << 4) + 32 + 8, mid = (SLC.Social.Leagues.LeaguesEconomy.RequirementOptions + (this.vipReqDropdown.m_Value) << 4) + 32 + 8}))) == null)
            {
                    return;
            }
            
            this.nameInputField.text = System.String.alignConst;
        }
        public LeaguesUICreateGuildView()
        {
            this.clubImageId = 0;
            this.clubName = "";
            this.clubMotto = "";
        }
        private void <CreateClubButtonPressed>b__30_0(bool result)
        {
            if(this.showMessageFlyout == null)
            {
                    return;
            }
            
            this.showMessageFlyout.Invoke(obj:  Localization.Localize(key:  "changes_saved", defaultValue:  "CHANGES SAVED", useSingularKey:  false));
        }
    
    }

}
