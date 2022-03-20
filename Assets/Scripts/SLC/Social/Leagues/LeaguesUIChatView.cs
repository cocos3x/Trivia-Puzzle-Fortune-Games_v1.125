using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUIChatView : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text chatTextBlock;
        private UnityEngine.UI.InputField textInput;
        private UnityEngine.UI.Button chatsButton;
        private UnityEngine.UI.Button logsButton;
        private UnityEngine.UI.Button sendButton;
        private UnityEngine.UI.Button retryButton;
        private UnityEngine.Color color_tag;
        private UnityEngine.Color color_text;
        private UnityEngine.Color color_log;
        private UnityEngine.Color color_unsent;
        private string hex_color_tag;
        private string hex_color_text;
        private string hex_color_log;
        private string hex_color_unsent;
        private bool showingChat;
        private bool blockSendMessages;
        private System.Collections.Generic.List<string> unsentMessages;
        private string reusableResult;
        private string reusableString;
        private string[] reusableSplit;
        
        // Methods
        private void Awake()
        {
            this.unsentMessages = new System.Collections.Generic.List<System.String>();
        }
        private void Start()
        {
            UnityEngine.Color32 val_1 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = this.color_tag});
            this.hex_color_tag = MetricSystem.ColorToHex(color:  new UnityEngine.Color32() {r = val_1.r & 4294967295, g = val_1.r & 4294967295, b = val_1.r & 4294967295, a = val_1.r & 4294967295});
            UnityEngine.Color32 val_4 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = this.color_text});
            val_4.r = val_4.r & 4294967295;
            this.hex_color_text = MetricSystem.ColorToHex(color:  new UnityEngine.Color32() {r = val_4.r, g = val_4.r, b = val_4.r, a = val_4.r});
            UnityEngine.Color32 val_6 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = this.color_log});
            val_6.r = val_6.r & 4294967295;
            this.hex_color_log = MetricSystem.ColorToHex(color:  new UnityEngine.Color32() {r = val_6.r, g = val_6.r, b = val_6.r, a = val_6.r});
            UnityEngine.Color32 val_8 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = this.color_unsent});
            val_8.r = val_8.r & 4294967295;
            this.hex_color_unsent = MetricSystem.ColorToHex(color:  new UnityEngine.Color32() {r = val_8.r, g = val_8.r, b = val_8.r, a = val_8.r});
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  4.ToString());
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  5.ToString());
            this.chatsButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUIChatView::ToggleChatsLogs()));
            this.logsButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUIChatView::ToggleChatsLogs()));
            this.textInput.m_OnValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.String>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUIChatView::OnChatTextEntered(string text)));
            this.sendButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUIChatView::SendChatMessage()));
            this.retryButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUIChatView::OnRetryMessage()));
            this.retryButton.interactable = false;
        }
        private void OnMyGuildChatUpdate()
        {
            this.retryButton.interactable = false;
            this.blockSendMessages = false;
            this.SetTextBlock();
        }
        private void OnMyGuildLogsUpdate()
        {
            this.SetTextBlock();
        }
        private void OnEnable()
        {
            SLC.Social.Leagues.LeaguesManager.DAO.GetGuildChat();
            this.SetTextBlock();
        }
        private void SetTextBlock()
        {
            if(this.showingChat == false)
            {
                goto label_1;
            }
            
            string val_1 = this.FormatChatMessages();
            if(this.chatTextBlock != null)
            {
                goto label_2;
            }
            
            label_1:
            string val_2 = this.FormatLogMessages();
            label_2:
            SLC.Social.Leagues.Guild val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            if(val_4.chat < 1)
            {
                    return;
            }
            
            SLC.Social.Leagues.Guild val_6 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            SLC.Social.Leagues.Guild val_8 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            SLC.Social.Leagues.Conversation val_10 = val_8.chat;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_10 = val_10 + ((val_10 - 1) << 3);
            UnityEngine.PlayerPrefs.SetString(key:  "leagues_last_message_seen", value:  0);
        }
        private string FormatChatMessages()
        {
            object val_6;
            var val_7;
            var val_27;
            string val_28;
            string val_29;
            int val_30;
            string val_31;
            int val_32;
            this.reusableResult = "";
            this.reusableString = "";
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
            {
                    return (string)this.reusableResult;
            }
            
            SLC.Social.Leagues.Guild val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            List.Enumerator<T> val_5 = val_4.chat.GetEnumerator();
            val_27 = 58;
            goto label_10;
            label_38:
            if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_6.Contains(value:  "|")) != false)
            {
                    char[] val_9 = new char[1];
                if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_9.Length == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
                val_9[0] = 124;
                System.String[] val_10 = val_6.Split(separator:  val_9, count:  2);
                this.reusableSplit = val_10;
                if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_10.Length <= 1)
            {
                    throw new IndexOutOfRangeException();
            }
            
                val_28 = val_10[1];
                if(val_28 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_29 = System.String.Format(format:  "<color=#{0}><i><b>{1}</b></i></color>\n\n", arg0:  this.hex_color_log, arg1:  val_28.Trim());
            }
            else
            {
                    char[] val_13 = new char[1];
                if(val_13 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_13.Length == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
                val_13[0] = ':';
                this.reusableSplit = val_6.Split(separator:  val_13, count:  2);
                object[] val_15 = new object[4];
                if(val_15 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_30 = val_15.Length;
                if(val_30 == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
                val_15[0] = this.hex_color_tag;
                if(this.reusableSplit == null)
            {
                    throw new NullReferenceException();
            }
            
                if(this.reusableSplit.Length == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
                string val_26 = this.reusableSplit[0];
                if(val_26 != null)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
                val_30 = val_15.Length;
            }
            
                if(val_30 <= 1)
            {
                    throw new IndexOutOfRangeException();
            }
            
                val_15[1] = val_26;
                if(this.hex_color_text != null)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
                val_30 = val_15.Length;
            }
            
                if(val_30 <= 2)
            {
                    throw new IndexOutOfRangeException();
            }
            
                val_15[2] = this.hex_color_text;
                if(this.reusableSplit == null)
            {
                    throw new NullReferenceException();
            }
            
                if(this.reusableSplit.Length <= 1)
            {
                    throw new IndexOutOfRangeException();
            }
            
                val_31 = this.reusableSplit[1];
                if(val_31 != null)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
                val_30 = val_15.Length;
            }
            
                val_15[3] = val_31;
                val_29 = System.String.Format(format:  "<color=#{0}>{1}:</color><color=#{2}>{3}</color>\n\n", args:  val_15);
            }
            
            this.reusableString = val_29;
            this.reusableResult = this.reusableResult + val_29;
            label_10:
            if(val_7.MoveNext() == true)
            {
                goto label_38;
            }
            
            val_7.Dispose();
            if(1152921513251019952 < 1)
            {
                    return (string)this.reusableResult;
            }
            
            List.Enumerator<T> val_19 = this.unsentMessages.GetEnumerator();
            val_27 = "<color=#{0}>{1}: </color><color=#{2}>{3}</color>\n\n";
            goto label_41;
            label_59:
            object[] val_20 = new object[4];
            val_31 = val_20;
            if(val_20 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.hex_color_tag != null)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
            if(val_20.Length == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_31[0] = this.hex_color_tag;
            SLC.Social.Leagues.LeaguesDataController val_21 = SLC.Social.Leagues.LeaguesManager.DAO;
            if(val_21 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_21.MyProfile == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_22.Name != null)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
            val_32 = val_20.Length;
            if(val_32 <= 1)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_31[1] = val_22.Name;
            if(this.hex_color_unsent != null)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
                val_32 = val_20.Length;
            }
            
            if(val_32 <= 2)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_31[2] = this.hex_color_unsent;
            if(val_6 != 0)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
                val_32 = val_20.Length;
            }
            
            if(val_32 <= 3)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_31[3] = val_6;
            string val_23 = System.String.Format(format:  "<color=#{0}>{1}: </color><color=#{2}>{3}</color>\n\n", args:  val_20);
            this.reusableString = val_23;
            this.reusableResult = this.reusableResult + val_23;
            label_41:
            if(val_7.MoveNext() == true)
            {
                goto label_59;
            }
            
            val_7.Dispose();
            return (string)this.reusableResult;
        }
        private string FormatLogMessages()
        {
            var val_4;
            var val_5;
            int val_13;
            this.reusableResult = "";
            this.reusableString = "";
            SLC.Social.Leagues.Guild val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            List.Enumerator<T> val_3 = val_2.log.GetEnumerator();
            goto label_6;
            label_27:
            char[] val_6 = new char[1];
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_6.Length == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_6[0] = 124;
            if(val_4 == 0)
            {
                    throw new NullReferenceException();
            }
            
            this.reusableSplit = val_4.Split(separator:  val_6, count:  2);
            object[] val_8 = new object[4];
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.hex_color_tag != null)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
            val_13 = val_8.Length;
            if(val_13 == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_8[0] = this.hex_color_tag;
            if(this.reusableSplit == null)
            {
                    throw new NullReferenceException();
            }
            
            string val_12 = this.reusableSplit[0];
            if(val_12 != null)
            {
                    val_13 = val_8.Length;
            }
            
            if(val_13 <= 1)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_8[1] = val_12;
            if(this.hex_color_text != null)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
                val_13 = val_8.Length;
            }
            
            if(val_13 <= 2)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_8[2] = this.hex_color_text;
            if(this.reusableSplit == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.reusableSplit.Length <= 1)
            {
                    throw new IndexOutOfRangeException();
            }
            
            string val_13 = this.reusableSplit[1];
            if(val_13 != null)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
                val_13 = val_8.Length;
            }
            
            if(val_13 <= 3)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_8[3] = val_13;
            string val_9 = System.String.Format(format:  "<color=#{0}>{1}</color><color=#{2}>{3}</color>\n", args:  val_8);
            this.reusableString = val_9;
            this.reusableResult = this.reusableResult + val_9;
            label_6:
            if(val_5.MoveNext() == true)
            {
                goto label_27;
            }
            
            val_5.Dispose();
            return (string)this.reusableResult;
        }
        private void ToggleChatsLogs()
        {
            bool val_4 = this.showingChat;
            val_4 = val_4 ^ 1;
            this.showingChat = val_4;
            this.logsButton.gameObject.SetActive(value:  (this.showingChat == false) ? 1 : 0);
            this.chatsButton.gameObject.SetActive(value:  this.showingChat);
            this.SetTextBlock();
        }
        private void OnChatTextEntered(string text)
        {
            var val_2;
            if((this.blockSendMessages != false) && (this.unsentMessages >= 1))
            {
                    if(this.sendButton != null)
            {
                goto label_4;
            }
            
            }
            
            if((System.String.IsNullOrEmpty(value:  text)) != false)
            {
                    label_4:
                val_2 = 0;
            }
            else
            {
                    val_2 = 1;
            }
            
            this.sendButton.interactable = true;
        }
        private void SendChatMessage()
        {
            this.textInput.text = System.Text.RegularExpressions.Regex.Replace(input:  this.textInput.m_Text, pattern:  "<.*>", replacement:  "");
            if((System.String.IsNullOrEmpty(value:  this.textInput.m_Text)) != false)
            {
                    return;
            }
            
            SLC.Social.Leagues.LeaguesManager.DAO.SendChatMessage(message:  this.textInput.m_Text, OnMessagerResponse:  new System.Action<System.Boolean, System.String>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUIChatView::OnMessageResponse(bool success, string message)));
            this.unsentMessages.Add(item:  this.textInput.m_Text);
            this.textInput.text = "";
            this.SetTextBlock();
        }
        private void OnRetryMessage()
        {
            this.retryButton.interactable = false;
            if(true < 1)
            {
                    return;
            }
            
            List.Enumerator<T> val_1 = this.unsentMessages.GetEnumerator();
            label_8:
            if(0.MoveNext() == false)
            {
                goto label_4;
            }
            
            SLC.Social.Leagues.LeaguesDataController val_3 = SLC.Social.Leagues.LeaguesManager.DAO;
            if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_3.SendChatMessage(message:  0, OnMessagerResponse:  new System.Action<System.Boolean, System.String>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUIChatView::OnMessageResponse(bool success, string message)));
            goto label_8;
            label_4:
            0.Dispose();
        }
        private void OnMessageResponse(bool success, string message)
        {
            bool val_3 = true;
            if(success != false)
            {
                    bool val_1 = this.unsentMessages.Remove(item:  message);
                return;
            }
            
            val_3 = val_3 - 1;
            if()
            {
                    return;
            }
            
            val_3 = X9 + (val_3 << 3);
            if((System.String.op_Inequality(a:  (X9 + ((true - 1)) << 3) + 32, b:  message)) != false)
            {
                    return;
            }
            
            this.retryButton.interactable = true;
            this.blockSendMessages = true;
            this.SetTextBlock();
        }
        public LeaguesUIChatView()
        {
            UnityEngine.Color val_1 = new UnityEngine.Color(r:  1f, g:  0.969f, b:  0.6f, a:  1f);
            this.color_tag = val_1.r;
            UnityEngine.Color val_2 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  1f);
            this.color_text = val_2.r;
            UnityEngine.Color val_3 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  1f);
            UnityEngine.Color val_4;
            this.color_log = val_3.r;
            val_4 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  1f);
            this.color_unsent = val_4.r;
            this.hex_color_tag = "FFF799FF";
            this.hex_color_text = "FFFFFF";
            this.showingChat = true;
            this.hex_color_log = "808080ff";
            this.hex_color_unsent = "808080ff";
            this.reusableResult = "";
            this.reusableString = "";
        }
    
    }

}
