using UnityEngine;
public class ShareFacebookAchievementPopup : MonoBehaviour
{
    // Fields
    private bool fbTriggered;
    
    // Methods
    private void Awake()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnFacebookPluginUpdate");
    }
    private void OnDestroy()
    {
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnFacebookPluginUpdate");
    }
    private void ShareClicked()
    {
        if((FacebookPlugin.TaskComplete(taskToCheck:  4)) != false)
        {
                this.ResetAndClose();
            return;
        }
        
        this.fbTriggered = true;
        if((FacebookPlugin.TaskComplete(taskToCheck:  1)) != false)
        {
                FacebookPlugin.PerformTask(task:  4);
            return;
        }
        
        FacebookPlugin.PerformFirstAvailableTask();
    }
    private void OnFacebookPluginUpdate(Notification n)
    {
        if(this.fbTriggered == false)
        {
                return;
        }
        
        if(null != 4)
        {
                if(null != null)
        {
                return;
        }
        
            if(null != null)
        {
                FacebookPlugin.PerformTask(task:  4);
            return;
        }
        
        }
        
        this.ResetAndClose();
    }
    private void ResetAndClose()
    {
        this.fbTriggered = false;
        NGUITools.SetActive(go:  this.gameObject, state:  false);
    }
    public ShareFacebookAchievementPopup()
    {
    
    }

}
