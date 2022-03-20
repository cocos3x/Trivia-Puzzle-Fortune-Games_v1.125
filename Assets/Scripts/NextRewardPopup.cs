using UnityEngine;
public class NextRewardPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.Transform titleTransform;
    private UnityEngine.Transform rewardGroup;
    private UnityEngine.UI.Image rewardImage;
    private UnityEngine.UI.Text rewardAmount;
    private UnityEngine.GameObject glow;
    private UnityEngine.Sprite rewIconCoins;
    private UnityEngine.Sprite rewIconGoldenCurrency;
    private UnityEngine.Sprite rewIconFood;
    private UnityEngine.Vector3 initialPos;
    private WGEventHandler eventHandler;
    
    // Methods
    private void Start()
    {
        UnityEngine.Vector3 val_2 = this.rewardGroup.transform.localPosition;
        this.initialPos = val_2;
        mem[1152921516285523516] = val_2.y;
        mem[1152921516285523520] = val_2.z;
        this.UpdateReward();
    }
    public void SetUp(WGEventHandler handler)
    {
        this.eventHandler = handler;
    }
    public void UpdateReward()
    {
        UnityEngine.Sprite val_2;
        string val_1 = this.eventHandler.OnMyPopupWasClosed_action.ToString();
        if(this.eventHandler.myEvent == 4)
        {
            goto label_3;
        }
        
        if(this.eventHandler.myEvent == 3)
        {
            goto label_4;
        }
        
        if(this.eventHandler.myEvent != 1)
        {
                return;
        }
        
        val_2 = this.rewIconCoins;
        goto label_9;
        label_3:
        val_2 = this.rewIconFood;
        goto label_9;
        label_4:
        val_2 = this.rewIconGoldenCurrency;
        label_9:
        this.rewardImage.sprite = val_2;
    }
    public System.Collections.IEnumerator PlayNextRewardSequence(WGEventButtonV2 eventButton)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .eventButton = eventButton;
        return (System.Collections.IEnumerator)new NextRewardPopup.<PlayNextRewardSequence>d__13();
    }
    public NextRewardPopup()
    {
    
    }

}
