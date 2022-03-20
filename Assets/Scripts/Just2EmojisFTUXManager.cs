using UnityEngine;
public class Just2EmojisFTUXManager : MonoSingleton<Just2EmojisFTUXManager>
{
    // Fields
    private UnityEngine.UI.Text FTUXText;
    private UnityEngine.GameObject hintButton;
    private UnityEngine.UI.Text hintText;
    private UnityEngine.UI.Image hintImage;
    private UnityEngine.UI.Text coinText;
    private UnityEngine.UI.Image coinImage;
    private UnityEngine.GameObject FTUXHand;
    public bool ftux;
    public bool checkedFTUX;
    private float timer;
    public bool counting;
    
    // Methods
    private void Start()
    {
        this.checkedFTUX = false;
        this.timer = 3f;
        this.FTUXHand.SetActive(value:  false);
        this.FTUXText.enabled = false;
    }
    private void Update()
    {
        if(this.counting != false)
        {
                float val_1 = UnityEngine.Time.deltaTime;
            val_1 = this.timer + val_1;
            this.timer = val_1;
            if(val_1 < 3f)
        {
                return;
        }
        
            this.ShowHand(t:  MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance.FTUXNewLetterPosition());
            this.timer = 0f;
            this.counting = false;
            return;
        }
        
        this.timer = 0f;
    }
    public void ResetFTUXTimer()
    {
        this.timer = 0f;
    }
    public void StartFTUX()
    {
        this.FTUXHand.SetActive(value:  false);
        this.FTUXText.enabled = false;
        MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance.SetAnswersInteractable(on:  false);
        this.hintButton.GetComponent<UnityEngine.UI.Button>().interactable = false;
        this.hintButton.GetComponent<UnityEngine.UI.Image>().enabled = false;
        this.hintText.enabled = false;
        this.hintImage.enabled = false;
        this.coinText.enabled = false;
        this.coinImage.enabled = false;
        UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.ShowFTUXElements());
    }
    private System.Collections.IEnumerator ShowFTUXElements()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new Just2EmojisFTUXManager.<ShowFTUXElements>d__15();
    }
    public void HideHand()
    {
        this.FTUXHand.SetActive(value:  false);
        this.counting = true;
    }
    public void ShowHand(UnityEngine.Transform t)
    {
        UnityEngine.Object val_8;
        int val_9;
        val_8 = t;
        if(val_8 == 0)
        {
                object[] val_2 = new object[4];
            val_2[0] = "Transform is null, ftux is set to ";
            val_9 = val_2.Length;
            val_2[1] = this.ftux.ToString();
            val_9 = val_2.Length;
            val_2[2] = " with player lvl ";
            SLC.Minigames.MinigameManager val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_2[3] = val_4.currentPlayerLevel;
            val_8 = +val_2;
            UnityEngine.Debug.LogError(message:  val_8);
            return;
        }
        
        UnityEngine.Vector3 val_7 = val_8.position;
        this.FTUXHand.transform.position = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
        this.FTUXHand.SetActive(value:  true);
        this.counting = false;
    }
    public void EndFTUX()
    {
        this.ftux = true;
        this.checkedFTUX = true;
        this.FTUXText.enabled = false;
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.DelayEnablingHintButton());
        MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance.FTUXUnhighlight();
    }
    private System.Collections.IEnumerator DelayEnablingHintButton()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new Just2EmojisFTUXManager.<DelayEnablingHintButton>d__19();
    }
    public Just2EmojisFTUXManager()
    {
    
    }

}
