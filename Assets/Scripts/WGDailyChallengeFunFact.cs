using UnityEngine;
public class WGDailyChallengeFunFact : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image animalIcon;
    private UnityEngine.UI.Text funFactText;
    private DailyChallengeZooTilesConfig zooTilesConfig;
    private const float FLYOUT_DURATION = 3;
    private UnityEngine.Coroutine hideFunFact;
    
    // Methods
    private void OnEnable()
    {
        var val_5;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "EnableScreenButton");
        val_5 = null;
        val_5 = null;
        WGDailyChallengeV2Popup.onMainScreenBtnClicked = new System.Action(object:  this, method:  public System.Void WGDailyChallengeFunFact::HideFunFact());
        this.hideFunFact = this.StartCoroutine(routine:  this.HideFunFactCoroutine());
    }
    private void OnDisable()
    {
        var val_2;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "DisableScreenButton");
        val_2 = null;
        val_2 = null;
        WGDailyChallengeV2Popup.onMainScreenBtnClicked = 0;
    }
    public void ShowFunFact(ZooTile info)
    {
        this.HideFunFact();
        this.animalIcon.sprite = this.zooTilesConfig.GetSprite(type:  1, name:  info.name);
        this.gameObject.SetActive(value:  true);
    }
    public void HideFunFact()
    {
        if(this.hideFunFact != null)
        {
                this.StopCoroutine(routine:  this.hideFunFact);
        }
        
        this.gameObject.SetActive(value:  false);
    }
    private System.Collections.IEnumerator HideFunFactCoroutine()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGDailyChallengeFunFact.<HideFunFactCoroutine>d__9();
    }
    public WGDailyChallengeFunFact()
    {
    
    }

}
