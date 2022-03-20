using UnityEngine;
public class UGUINetworkedButton : MultiGraphicButton
{
    // Fields
    protected bool behaveAsNormalButton;
    protected UnityEngine.GameObject waitingDisplay;
    protected UnityEngine.GameObject[] hiddenWhileWaiting;
    protected UnityEngine.UI.Button[] subButtonsToControl;
    public System.Action<bool> OnConnectionClick;
    private bool awaitingPing;
    private string myName;
    
    // Methods
    protected virtual void OnStart()
    {
    
    }
    protected override void Start()
    {
        this.Start();
        if(this.behaveAsNormalButton != true)
        {
                AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void UGUINetworkedButton::CheckConnectivity()));
        }
        
        this.myName = NGUITools.GetHierarchy(obj:  this.gameObject);
    }
    public void OnOtherButtonClick()
    {
        this.CheckConnectivity();
    }
    protected override void DoStateTransition(UnityEngine.UI.Selectable.SelectionState state, bool instant)
    {
        var val_6;
        if(state == 4)
        {
                var val_1 = (W8 != 0) ? 1 : 0;
        }
        else
        {
                val_6 = 0;
        }
        
        if(this.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
        if((W8 != 0) && ((X23 + 24) >= 1))
        {
                var val_6 = 0;
            do
        {
            var val_4 = X23 + 0;
            (X23 + 0) + 32.enabled = false;
            val_6 = val_6 + 1;
        }
        while(val_6 < (X23 + 24));
        
        }
        
        this.DoStateTransition(state:  state, instant:  instant);
    }
    public void WaitingStatus(bool waiting)
    {
        bool val_1 = (~waiting) & 1;
        this.interactable = val_1;
        this.SetWaitingDisplay(visible:  waiting);
        this.SetSubButtonsInteractable(_interactable:  val_1);
        this.SetHidden(show:  val_1);
    }
    private void CheckConnectivity()
    {
        NetworkConnectivityPinger val_1 = MonoSingleton<NetworkConnectivityPinger>.Instance;
        if(val_1.OnPingDone != null)
        {
                return;
        }
        
        this.interactable = false;
        this.SetSubButtonsInteractable(_interactable:  false);
        this.SetWaitingDisplay(visible:  true);
        this.SetHidden(show:  false);
        this.awaitingPing = true;
        NetworkConnectivityPinger val_2 = MonoSingleton<NetworkConnectivityPinger>.Instance;
        val_2.OnPingDone = new System.Action<System.Boolean>(object:  this, method:  System.Void UGUINetworkedButton::<CheckConnectivity>b__12_0(bool result));
        MonoSingleton<NetworkConnectivityPinger>.Instance.PingGoogle();
    }
    private void SetWaitingDisplay(bool visible)
    {
        if(this.waitingDisplay == 0)
        {
                return;
        }
        
        this.waitingDisplay.SetActive(value:  visible);
    }
    private void SetSubButtonsInteractable(bool _interactable)
    {
        UnityEngine.UI.Button val_3;
        var val_5 = 4;
        do
        {
            if((val_5 - 4) >= (this.subButtonsToControl.Length << ))
        {
                return;
        }
        
            val_3 = this.subButtonsToControl[0];
            if(val_3 != 0)
        {
                this.subButtonsToControl[0].interactable = _interactable;
        }
        
            val_5 = val_5 + 1;
        }
        while(this.subButtonsToControl != null);
        
        throw new NullReferenceException();
    }
    private void SetHidden(bool show)
    {
        UnityEngine.GameObject val_3;
        var val_5 = 4;
        do
        {
            if((val_5 - 4) >= (this.hiddenWhileWaiting.Length << ))
        {
                return;
        }
        
            val_3 = this.hiddenWhileWaiting[0];
            if(val_3 != 0)
        {
                this.hiddenWhileWaiting[0].SetActive(value:  show);
        }
        
            val_5 = val_5 + 1;
        }
        while(this.hiddenWhileWaiting != null);
        
        throw new NullReferenceException();
    }
    protected override void OnDisable()
    {
        this.OnDisable();
        this.interactable = true;
        this.SetSubButtonsInteractable(_interactable:  true);
        this.SetWaitingDisplay(visible:  false);
        this.SetHidden(show:  true);
        if(this.awaitingPing == false)
        {
                return;
        }
        
        NetworkConnectivityPinger val_1 = MonoSingleton<NetworkConnectivityPinger>.Instance;
        val_1.OnPingDone = 0;
        this.awaitingPing = false;
    }
    public UGUINetworkedButton()
    {
        this.hiddenWhileWaiting = new UnityEngine.GameObject[0];
        this.myName = "unknown";
    }
    private void <CheckConnectivity>b__12_0(bool result)
    {
        if(this == 0)
        {
                this = this.myName + " is trying to act upon network connectivity response but is already destroyed an null. Doing nothing. Are you sure this button should be networked?"(" is trying to act upon network connectivity response but is already destroyed an null. Doing nothing. Are you sure this button should be networked?");
            UnityEngine.Debug.LogError(message:  this);
            NetworkConnectivityPinger val_3 = MonoSingleton<NetworkConnectivityPinger>.Instance;
            val_3.OnPingDone = 0;
            return;
        }
        
        this.interactable = true;
        this.SetSubButtonsInteractable(_interactable:  true);
        this.SetWaitingDisplay(visible:  false);
        this.SetHidden(show:  true);
        if(this.OnConnectionClick != null)
        {
                this.OnConnectionClick.Invoke(obj:  result);
        }
        
        NetworkConnectivityPinger val_5 = MonoSingleton<NetworkConnectivityPinger>.Instance;
        val_5.OnPingDone = 0;
        this.awaitingPing = false;
    }

}
