using UnityEngine;

namespace WordForest
{
    public class WFONewsButton : MonoBehaviour
    {
        // Fields
        private UnityEngine.GameObject rootNotifBadge;
        private UnityEngine.UI.Text labelNotifBadge;
        private UnityEngine.UI.Button button;
        
        // Methods
        private void Start()
        {
            this.button = this.gameObject.GetComponent<UnityEngine.UI.Button>();
            val_2.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFONewsButton::OnButtonClicked()));
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  5.ToString());
            this.UpdateNotificationBadge();
        }
        private void OnDestroy()
        {
            NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  5.ToString());
        }
        private void OnButtonClicked()
        {
            GameBehavior val_1 = App.getBehavior;
            goto mem[(1152921504946249728 + (public WordForest.WFONewsPopup MetaGameBehavior::ShowUGUIMonolith<WordForest.WFONewsPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
        }
        private void OnNewsStatusUpdated()
        {
            this.UpdateNotificationBadge();
        }
        private void UpdateNotificationBadge()
        {
            int val_1 = WordForest.WFONewsPopup.UnseenNewsCount;
            string val_2 = val_1.ToString();
            this.rootNotifBadge.SetActive(value:  (val_1 > 0) ? 1 : 0);
        }
        public WFONewsButton()
        {
        
        }
    
    }

}
