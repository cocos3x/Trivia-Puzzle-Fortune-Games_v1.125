using UnityEngine;

namespace SLC.Social.Leagues
{
    public class Wait_Window : WGMessagePopup
    {
        // Fields
        private SLC.Social.Leagues.LeaguesNotifyType waitForNotificationtype;
        
        // Methods
        protected void Start()
        {
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  0.ToString());
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  3.ToString());
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  2.ToString());
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  1.ToString());
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "DisplayLeaguesErrorPopup");
        }
        public void ShowError(string message, string title, SLC.Social.Leagues.LeaguesNotifyType notificationType = 8)
        {
            int val_3;
            var val_4;
            string[] val_2 = new string[2];
            val_3 = val_2.Length;
            val_2[0] = "";
            val_3 = val_2.Length;
            val_2[1] = "";
            val_4 = null;
            val_4 = null;
            this.SetupMessage(titleTxt:  title, messageTxt:  message, shownButtons:  new bool[2], buttonTexts:  val_2, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
            this.waitForNotificationtype = notificationType;
        }
        private void HideAndReset()
        {
            this.waitForNotificationtype = 8;
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void DisplayLeaguesErrorPopup()
        {
            this.waitForNotificationtype = 8;
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void OnDataUpdate()
        {
            if(this.waitForNotificationtype != 0)
            {
                    return;
            }
            
            this.waitForNotificationtype = 8;
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void OnGuildMembersUpdate()
        {
            if(this.waitForNotificationtype != 3)
            {
                    return;
            }
            
            this.waitForNotificationtype = 8;
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void OnMyGuildUpdate()
        {
            if(this.waitForNotificationtype != 2)
            {
                    return;
            }
            
            this.waitForNotificationtype = 8;
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void OnMyProfileUpdate()
        {
            if(this.waitForNotificationtype != 1)
            {
                    return;
            }
            
            this.waitForNotificationtype = 8;
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public Wait_Window()
        {
            this.waitForNotificationtype = 8;
        }
    
    }

}
