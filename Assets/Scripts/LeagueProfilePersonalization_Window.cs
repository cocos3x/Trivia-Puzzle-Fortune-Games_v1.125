using UnityEngine;
public class LeagueProfilePersonalization_Window : MonoBehaviour
{
    // Fields
    public System.Action onCloseAction;
    private UnityEngine.GameObject changeNameWindow;
    private UnityEngine.GameObject changeImageWindow;
    private UnityEngine.GameObject avatarButtonPrefab;
    private UnityEngine.UI.InputField nameChangeInputField;
    private UnityEngine.RectTransform gridTransform;
    private UnityEngine.UI.Button confirmNameButton;
    private UnityEngine.UI.Button randomNameButton;
    private UnityEngine.UI.Button nameCloseButton;
    private UnityEngine.UI.Button avatarCloseButton;
    private bool randomName;
    
    // Methods
    public void ShowAvatarWindow()
    {
        UnityEngine.Events.UnityAction val_16;
        var val_17;
        this.changeNameWindow.SetActive(value:  false);
        this.changeImageWindow.SetActive(value:  true);
        UnityEngine.Events.UnityAction val_1 = null;
        val_16 = val_1;
        val_1 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LeagueProfilePersonalization_Window::Close());
        this.avatarCloseButton.m_OnClick.AddListener(call:  val_1);
        val_17 = 0;
        goto label_5;
        label_27:
        .<>4__this = this;
        val_16 = 0;
        Player val_3 = App.Player;
        if(0 != val_3.properties.profile_avatar_id)
        {
                UnityEngine.GameObject val_4 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.avatarButtonPrefab, parent:  this.gridTransform);
            val_4.name = "Avatar_" + 0.ToString();
            val_16 = val_4.GetComponent<UnityEngine.UI.Button>().gameObject.GetComponent<UnityEngine.UI.Image>();
            .thisAvatar = 0;
            UnityEngine.UI.Button val_10 = val_4.GetComponent<UnityEngine.UI.Button>();
            val_10.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new LeagueProfilePersonalization_Window.<>c__DisplayClass11_0(), method:  System.Void LeagueProfilePersonalization_Window.<>c__DisplayClass11_0::<ShowAvatarWindow>b__0()));
            val_16.sprite = SLC.Social.Leagues.LeaguesUIManager.memberAvatarHandler.GetAvatarSpriteByID(id:  0, portraitID:  0);
        }
        
        val_17 = 0 + 1;
        label_5:
        if(val_17 < SLC.Social.Leagues.LeaguesUIManager.memberAvatarHandler.AvatarSpritesCount)
        {
            goto label_27;
        }
    
    }
    public void ShowNameWindow()
    {
        this.changeImageWindow.SetActive(value:  false);
        this.changeNameWindow.SetActive(value:  true);
        this.nameChangeInputField.m_OnValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.String>(object:  this, method:  System.Void LeagueProfilePersonalization_Window::OnInputUpdated(string newValue)));
        this.confirmNameButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LeagueProfilePersonalization_Window::ConfirmNameChange()));
        this.nameCloseButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LeagueProfilePersonalization_Window::Close()));
        this.randomNameButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LeagueProfilePersonalization_Window::RollRandomName()));
        this.nameChangeInputField.text = "";
        this.OnInputUpdated(newValue:  "");
    }
    private void OnInputUpdated(string newValue)
    {
        this.confirmNameButton.interactable = (newValue.m_stringLength > 0) ? 1 : 0;
        this.randomName = false;
    }
    private void RollRandomName()
    {
        this.nameChangeInputField.text = SLC.Social.SocialManager.GetRandomProfileName();
        this.randomName = true;
    }
    private void ConfirmNameChange()
    {
        int val_16;
        var val_17;
        var val_18;
        if(this.randomName == false)
        {
            goto label_2;
        }
        
        label_15:
        val_16 = this.nameChangeInputField.m_Text.m_stringLength;
        if(val_16 < 1)
        {
            goto label_4;
        }
        
        do
        {
            val_16 = this.nameChangeInputField.m_Text.m_stringLength;
            val_17 = 0 + 1;
            var val_3 = ((this.nameChangeInputField.m_Text.Chars[0] & 65535) == ' ') ? (0 + 1) : 0;
        }
        while(val_17 < val_16);
        
        goto label_6;
        label_2:
        if(((Objectionable.Valid(words:  this.nameChangeInputField.m_Text.ToLower())) == true) || ((System.Text.RegularExpressions.Regex.Replace(input:  this.nameChangeInputField.m_Text, pattern:  Objectionable.FoundObjectionable(words:  this.nameChangeInputField.m_Text.ToLower()), replacement:  "", options:  1)) != null))
        {
            goto label_15;
        }
        
        label_4:
        val_18 = 0;
        label_6:
        if(val_18 != val_16)
        {
                val_17 = 1152921505022660608;
            SLC.Social.Profile val_10 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            if((val_10.Name.Equals(value:  this.nameChangeInputField.m_Text)) != true)
        {
                val_13.Name = this.nameChangeInputField.m_Text;
            SLC.Social.Leagues.LeaguesManager.DAO.MyProfile.SaveChanges();
            Player val_14 = App.Player;
            int val_16 = val_14.properties.LifetimeProfileNameChanges;
            val_16 = val_16 + 1;
            val_14.properties.LifetimeProfileNameChanges = val_16;
            System.DateTime val_15 = ServerHandler.ServerTime;
            SLC.Social.Leagues.LeaguesTracker.LastNameChange = new System.DateTime() {dateData = val_15.dateData};
        }
        
        }
        
        this.Close();
    }
    private void OnAvatarClicked(int selectedAvatar)
    {
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        val_2.Portrait_ID = System.String.alignConst;
        SLC.Social.Profile val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        if(val_4.AvatarId != selectedAvatar)
        {
                val_6.AvatarId = selectedAvatar;
            SLC.Social.Leagues.LeaguesManager.DAO.MyProfile.SaveChanges();
            Player val_7 = App.Player;
            int val_9 = val_7.properties.LifetimeProfileAvatarChanges;
            val_9 = val_9 + 1;
            val_7.properties.LifetimeProfileAvatarChanges = val_9;
            System.DateTime val_8 = ServerHandler.ServerTime;
            SLC.Social.Leagues.LeaguesTracker.LastAvatarChange = new System.DateTime() {dateData = val_8.dateData};
        }
        
        this.Close();
    }
    private void OnAvatarClicked(string selectedPortrait)
    {
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        if((System.String.op_Inequality(a:  val_2.Portrait_ID, b:  selectedPortrait)) != false)
        {
                val_5.Portrait_ID = selectedPortrait;
            SLC.Social.Leagues.LeaguesManager.DAO.MyProfile.SaveChanges();
            Player val_6 = App.Player;
            int val_8 = val_6.properties.LifetimeProfileAvatarChanges;
            val_8 = val_8 + 1;
            val_6.properties.LifetimeProfileAvatarChanges = val_8;
            System.DateTime val_7 = ServerHandler.ServerTime;
            SLC.Social.Leagues.LeaguesTracker.LastAvatarChange = new System.DateTime() {dateData = val_7.dateData};
        }
        
        this.Close();
    }
    private void SaveChanges()
    {
        SLC.Social.Leagues.LeaguesManager.DAO.UpdateMyProfileInfo(force:  true);
    }
    private void Close()
    {
        if(this.onCloseAction != null)
        {
                this.onCloseAction.Invoke();
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public LeagueProfilePersonalization_Window()
    {
    
    }

}
