using UnityEngine;
public class WGFreeTilePopup : MonoBehaviour
{
    // Fields
    private UGUINetworkedButton Button_Entry;
    private UnityEngine.GameObject group_sorry;
    private UGUINetworkedButton Button_WatchAnother;
    private UnityEngine.UI.Button Button_Close_Sorry;
    protected UnityEngine.GameObject group_success;
    private UnityEngine.UI.Button Button_CollectHint;
    private UnityEngine.GameObject currentAlphabetTileObject;
    private HeyZapAdTag currTag;
    private bool gotVideoResponse;
    
    // Methods
    private void Awake()
    {
        this.Button_WatchAnother.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  public System.Void WGFreeTilePopup::OnFreeHintClick(bool result));
        this.Button_Close_Sorry.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGFreeTilePopup::Cancel()));
        this.Button_CollectHint.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void WGFreeTilePopup::OnCollectClicked()));
    }
    public void OnEnable()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
        this.Button_Entry.interactable = false;
        this.group_success.SetActive(value:  false);
        this.Button_CollectHint.interactable = false;
        this.group_sorry.SetActive(value:  false);
        this.OnFreeHintClick(result:  true);
    }
    public void OnFreeHintClick(bool result)
    {
        var val_16;
        string val_17;
        string val_18;
        System.Boolean[] val_19;
        string val_21;
        string val_22;
        int val_23;
        var val_24;
        if(result == false)
        {
            goto label_1;
        }
        
        if((MonoSingleton<AdsUIController>.Instance.ShowIncentivizedVideo(tag:  this.currTag, adCapExempt:  false)) == false)
        {
            goto label_5;
        }
        
        this.gotVideoResponse = false;
        return;
        label_1:
        GameBehavior val_3 = App.getBehavior;
        val_16 = val_3.<metaGameBehavior>k__BackingField;
        val_17 = Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false);
        val_18 = Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false);
        val_19 = new bool[2];
        val_19[0] = true;
        string[] val_8 = new string[2];
        val_21 = "ok_upper";
        val_22 = "OK";
        goto label_12;
        label_5:
        GameBehavior val_9 = App.getBehavior;
        val_16 = val_9.<metaGameBehavior>k__BackingField;
        val_17 = Localization.Localize(key:  "unavailable_upper", defaultValue:  "UNAVAILABLE", useSingularKey:  false);
        val_18 = Localization.Localize(key:  "no_videos_explanation", defaultValue:  "Sorry, no videos available at this time.", useSingularKey:  false);
        bool[] val_13 = new bool[2];
        val_19 = val_13;
        val_19[0] = true;
        string[] val_14 = new string[2];
        val_21 = "try_again_later_upper";
        val_22 = "TRY AGAIN LATER";
        label_12:
        val_23 = val_14.Length;
        val_14[0] = Localization.Localize(key:  val_21, defaultValue:  val_22, useSingularKey:  false);
        val_23 = val_14.Length;
        val_14[1] = "NULL";
        val_24 = null;
        val_24 = null;
        val_16.SetupMessage(titleTxt:  val_17, messageTxt:  val_18, shownButtons:  val_13, buttonTexts:  val_14, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        this.Button_Entry.interactable = true;
        this.Close();
    }
    public void OnVideoResponse(Notification notif)
    {
        bool val_2 = System.Boolean.Parse(value:  notif.data.ToString());
        bool val_3 = val_2;
        this.group_success.SetActive(value:  val_3);
        this.Button_CollectHint.interactable = val_3;
        this.group_sorry.SetActive(value:  (~val_2) & 1);
        this.gotVideoResponse = true;
    }
    public void OnCollectClicked()
    {
        this.Button_CollectHint.interactable = false;
        Alphabet2Manager val_1 = MonoSingleton<Alphabet2Manager>.Instance;
        val_1.currentAlphabetTileObject = this.currentAlphabetTileObject;
        MonoSingleton<Alphabet2Manager>.Instance.CollectCurrentVideoRewardTile();
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.CloseAfterDelay());
    }
    private System.Collections.IEnumerator CloseAfterDelay()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGFreeTilePopup.<CloseAfterDelay>d__14();
    }
    private void OnApplicationPause(bool pause)
    {
        if(pause == true)
        {
                return;
        }
        
        if(this.gotVideoResponse != false)
        {
                return;
        }
        
        this.group_success.SetActive(value:  false);
        this.Button_CollectHint.interactable = false;
        this.group_sorry.SetActive(value:  true);
    }
    private void Cancel()
    {
        this.Button_Entry.interactable = true;
        this.Close();
    }
    private void Close()
    {
        this.group_success.SetActive(value:  false);
        this.group_sorry.SetActive(value:  false);
        this.gameObject.SetActive(value:  false);
    }
    private void OnDisable()
    {
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnVideoResponse");
    }
    public WGFreeTilePopup()
    {
        this.currTag = 12;
    }

}
