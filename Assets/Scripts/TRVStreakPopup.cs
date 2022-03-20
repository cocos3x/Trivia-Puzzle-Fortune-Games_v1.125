using UnityEngine;
public class TRVStreakPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Text streakText;
    
    // Methods
    private void OnEnable()
    {
        this.closeButton.m_OnClick.RemoveAllListeners();
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVStreakPopup::Close()));
        string val_4 = MonoSingleton<TRVStreakManager>.Instance.currentStreak.ToString();
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TRVStreakPopup()
    {
    
    }

}
