using UnityEngine;
public class KeyToRichesChest : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject glowingKeyGO;
    private UnityEngine.UI.Image glowingKey;
    private UnityEngine.UI.Image rewardImage;
    private UnityEngine.UI.Text rewardText;
    private UnityEngine.UI.Button chestButton;
    private UnityEngine.Animator animator;
    private float keyMoveDuration;
    private float rewardParticleDelay;
    private UnityEngine.UI.Text hackText;
    private KeyToRichesEventHandler.Reward currentReward;
    private KeyToRichesPopup popup;
    private UnityEngine.Transform keyPosOrigin;
    private int index;
    
    // Methods
    private void OnCollect()
    {
        if(this.currentReward == null)
        {
                return;
        }
        
        if((KeyToRichesEventHandler._Instance.OpenChest(reward:  this.currentReward)) == false)
        {
                return;
        }
        
        this.chestButton.interactable = false;
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.RewardSequence());
        this.popup.OnCollect(index:  this.index);
    }
    private void Awake()
    {
        this.chestButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void KeyToRichesChest::OnCollect()));
    }
    private void OnEnable()
    {
        this.hackText.gameObject.SetActive(value:  false);
    }
    public void SetupDefault()
    {
        this.chestButton.interactable = false;
        this.glowingKeyGO.SetActive(value:  false);
        this.ToggleChestContent(show:  KeyToRichesEventHandler._Instance.showChestContent);
    }
    public void SetupReward(KeyToRichesPopup keyToRichesPopup, int i, KeyToRichesEventHandler.Reward reward, UnityEngine.Sprite rewardSprite, int rewardAmount, UnityEngine.Transform keyPos)
    {
        this.currentReward = reward;
        this.popup = keyToRichesPopup;
        this.index = i;
        this.rewardImage.sprite = rewardSprite;
        string val_1 = rewardAmount.ToString();
        this.keyPosOrigin = keyPos;
        this.chestButton.interactable = true;
        this.glowingKeyGO.SetActive(value:  false);
        this.ToggleChestContent(show:  KeyToRichesEventHandler._Instance.showChestContent);
    }
    public void RevealReward()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.RevealSequence());
    }
    private System.Collections.IEnumerator RewardSequence()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new KeyToRichesChest.<RewardSequence>d__19();
    }
    private System.Collections.IEnumerator RevealSequence()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new KeyToRichesChest.<RevealSequence>d__20();
    }
    public void ToggleChestContent(bool show)
    {
        this.hackText.gameObject.SetActive(value:  show);
        if(show == false)
        {
                return;
        }
        
        if(this.currentReward == null)
        {
            goto label_4;
        }
        
        label_6:
        this = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        label_4:
        if(this.hackText != null)
        {
            goto label_6;
        }
        
        throw new NullReferenceException();
    }
    public KeyToRichesChest()
    {
        this.keyMoveDuration = 0.8f;
        this.rewardParticleDelay = 1.2f;
    }

}
