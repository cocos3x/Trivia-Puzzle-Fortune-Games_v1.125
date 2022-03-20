using UnityEngine;
public class EditProfileFlyout : MonoBehaviour
{
    // Fields
    private EditProfileAvatarSelectionItem avatarButtonPrefab;
    private UnityEngine.RectTransform gridTransform;
    private UnityEngine.UI.InputField nameChangeInputField;
    private UnityEngine.UI.Button button_close;
    private bool saveChanges;
    private System.Collections.Generic.List<EditProfileAvatarSelectionItem> avatarSelectionItems;
    private string originalName;
    
    // Methods
    private void Awake()
    {
        UnityEngine.Events.UnityAction val_19;
        UnityEngine.RectTransform val_20;
        object val_21;
        System.Delegate val_22;
        var val_23;
        UnityEngine.Events.UnityAction val_1 = null;
        val_19 = val_1;
        val_1 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void EditProfileFlyout::Close());
        this.button_close.m_OnClick.AddListener(call:  val_1);
        this.nameChangeInputField.text = "";
        UnityEngine.UI.Text val_3 = this.nameChangeInputField.m_Placeholder.gameObject.GetComponent<UnityEngine.UI.Text>();
        SLC.Social.Profile val_5 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        SLC.Social.Profile val_7 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        this.originalName = val_7.Name;
        GameBehavior val_8 = App.getBehavior;
        if(((val_8.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_18;
        }
        
        System.Collections.Generic.List<System.String> val_10 = MonoSingleton<WGPortraitDataController>.Instance.GetAllUnlockedPortraits();
        val_20 = this.gridTransform;
        val_21 = this;
        if(1152921515854181280 < 1)
        {
            goto label_32;
        }
        
        var val_19 = 0;
        do
        {
            val_19 = UnityEngine.Object.Instantiate<EditProfileAvatarSelectionItem>(original:  mem[this.avatarButtonPrefab], parent:  mem[this.gridTransform]);
            if(val_19 >= 1152921515854190496)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_19.Setup(avatarId:  null);
            System.Action<EditProfileAvatarSelectionItem> val_12 = null;
            val_22 = val_12;
            val_12 = new System.Action<EditProfileAvatarSelectionItem>(object:  this, method:  System.Void EditProfileFlyout::OnPortraitClicked(EditProfileAvatarSelectionItem selectedItem));
            System.Delegate val_13 = System.Delegate.Combine(a:  val_11.OnAvatarSelection, b:  val_12);
            if(val_13 != null)
        {
                if(null != null)
        {
            goto label_38;
        }
        
        }
        
            val_11.OnAvatarSelection = val_13;
            this.avatarSelectionItems.SyncRoot.Add(item:  val_19);
            val_19 = val_19 + 1;
        }
        while(val_19 < 1152921515854209952);
        
        goto label_32;
        label_18:
        val_20 = this.gridTransform;
        val_21 = this;
        label_32:
        val_23 = 0;
        goto label_33;
        label_43:
        EditProfileAvatarSelectionItem val_14 = UnityEngine.Object.Instantiate<EditProfileAvatarSelectionItem>(original:  mem[this.avatarButtonPrefab], parent:  mem[this.gridTransform]);
        val_19 = val_14;
        val_14.Setup(avatarId:  0);
        System.Action<EditProfileAvatarSelectionItem> val_15 = null;
        val_22 = val_15;
        val_15 = new System.Action<EditProfileAvatarSelectionItem>(object:  this, method:  System.Void EditProfileFlyout::OnAvatarClicked(EditProfileAvatarSelectionItem selectedItem));
        System.Delegate val_16 = System.Delegate.Combine(a:  val_14.OnAvatarSelection, b:  val_15);
        if(val_16 != null)
        {
                if(null != null)
        {
            goto label_38;
        }
        
        }
        
        val_14.OnAvatarSelection = val_16;
        this.avatarSelectionItems.SyncRoot.Add(item:  val_19);
        val_23 = 1;
        label_33:
        if(val_23 < SLC.Social.Leagues.LeaguesUIManager.memberAvatarHandler.AvatarSpritesCount)
        {
            goto label_43;
        }
        
        this.RefreshAvatars();
        return;
        label_38:
    }
    private void ConfirmNameChange()
    {
        string val_17;
        string val_18;
        int val_19;
        var val_20;
        val_17 = this.nameChangeInputField.m_Text;
        val_18 = val_17.ToLower();
        if((Objectionable.Valid(words:  val_18)) != true)
        {
                string val_4 = Objectionable.FoundObjectionable(words:  val_17.ToLower());
            val_17 = this.originalName;
            this.nameChangeInputField.text = val_17;
            UnityEngine.UI.Text val_6 = this.nameChangeInputField.m_Placeholder.gameObject.GetComponent<UnityEngine.UI.Text>();
        }
        
        val_19 = this.originalName.m_stringLength;
        if(val_19 >= 1)
        {
                do
        {
            val_19 = this.originalName.m_stringLength;
            val_18 = 0 + 1;
            var val_9 = ((val_17.Chars[0] & 65535) == ' ') ? (0 + 1) : 0;
        }
        while(val_18 < val_19);
        
        }
        else
        {
                val_20 = 0;
        }
        
        if(val_20 == val_19)
        {
                return;
        }
        
        val_18 = 1152921505022660608;
        SLC.Social.Profile val_11 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        if((val_11.Name.Equals(value:  val_17)) != false)
        {
                return;
        }
        
        SLC.Social.Profile val_14 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        val_14.Name = val_17;
        this.saveChanges = true;
        Player val_15 = App.Player;
        int val_17 = val_15.properties.LifetimeProfileNameChanges;
        val_17 = val_17 + 1;
        val_15.properties.LifetimeProfileNameChanges = val_17;
        System.DateTime val_16 = ServerHandler.ServerTime;
        SLC.Social.Leagues.LeaguesTracker.LastNameChange = new System.DateTime() {dateData = val_16.dateData};
    }
    private void OnAvatarClicked(EditProfileAvatarSelectionItem selectedItem)
    {
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        val_2.Portrait_ID = System.String.alignConst;
        SLC.Social.Profile val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        if(val_4.AvatarId == selectedItem.thisAvatarId)
        {
                return;
        }
        
        SLC.Social.Profile val_6 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        val_6.AvatarId = selectedItem.thisAvatarId;
        this.saveChanges = true;
        Player val_7 = App.Player;
        int val_9 = val_7.properties.LifetimeProfileAvatarChanges;
        val_9 = val_9 + 1;
        val_7.properties.LifetimeProfileAvatarChanges = val_9;
        System.DateTime val_8 = ServerHandler.ServerTime;
        SLC.Social.Leagues.LeaguesTracker.LastAvatarChange = new System.DateTime() {dateData = val_8.dateData};
        this.RefreshAvatars();
    }
    private void OnPortraitClicked(EditProfileAvatarSelectionItem selectedItem)
    {
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        if((System.String.op_Inequality(a:  val_2.Portrait_ID, b:  selectedItem.myAvatarIdString)) == false)
        {
                return;
        }
        
        SLC.Social.Profile val_5 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        val_5.Portrait_ID = selectedItem.myAvatarIdString;
        this.saveChanges = true;
        Player val_6 = App.Player;
        int val_8 = val_6.properties.LifetimeProfileAvatarChanges;
        val_8 = val_8 + 1;
        val_6.properties.LifetimeProfileAvatarChanges = val_8;
        System.DateTime val_7 = ServerHandler.ServerTime;
        SLC.Social.Leagues.LeaguesTracker.LastAvatarChange = new System.DateTime() {dateData = val_7.dateData};
        this.RefreshAvatars();
    }
    private void RefreshAvatars()
    {
        bool val_1 = true;
        var val_2 = 0;
        do
        {
            if(val_2 >= val_1)
        {
                return;
        }
        
            if(val_1 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_1 = val_1 + 0;
            (true + 0) + 32.Refresh();
            val_2 = val_2 + 1;
        }
        while(this.avatarSelectionItems != null);
        
        throw new NullReferenceException();
    }
    private void SaveChanges()
    {
        SLC.Social.Leagues.LeaguesManager.DAO.UpdateMyProfileInfo(force:  true);
    }
    private void Close()
    {
        this.ConfirmNameChange();
        if(this.saveChanges != false)
        {
                this.SaveChanges();
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public EditProfileFlyout()
    {
        this.avatarSelectionItems = new System.Collections.Generic.List<EditProfileAvatarSelectionItem>();
    }

}
