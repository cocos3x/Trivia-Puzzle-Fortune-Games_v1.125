using UnityEngine;
public class WADMysteryGiftPopup : WGMysteryGiftPopup
{
    // Fields
    private UnityEngine.GameObject titleGroup;
    private UnityEngine.GameObject radialRays;
    private CRotate raysRotation;
    private UnityEngine.RectTransform initialPosition;
    private UnityEngine.GameObject giftGroup;
    private UnityEngine.ParticleSystem starParticle;
    private UnityEngine.ParticleSystem glowParticle;
    private UnityEngine.GameObject coinGroup;
    private UnityEngine.ParticleSystem burstParticle;
    private UnityEngine.GameObject rewardAmountGroup;
    
    // Methods
    private void OnEnable()
    {
        GameEcon val_1 = App.getGameEcon;
        string val_2 = val_1.mysteryGiftReward.ToString();
        this.InitialSetup();
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.GiftStageAnim());
    }
    protected override void OnCollect()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGSubscriptionPopup>(showNext:  true);
        mem2[0] = 0;
        WGSubscriptionManager._subEntryPoint = 108;
        WGAudioController val_3 = MonoSingleton<WGAudioController>.Instance;
        val_3.sound.PlayGameSpecificSound(id:  "MysteryGiftOpen", clipIndex:  0);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void InitialSetup()
    {
        this.titleGroup.SetActive(value:  false);
        this.radialRays.SetActive(value:  false);
        this.raysRotation.enabled = true;
        this.giftGroup.SetActive(value:  false);
        this.starParticle.Stop();
        this.glowParticle.Stop();
        this.glowParticle.gameObject.SetActive(value:  false);
        this.coinGroup.SetActive(value:  false);
        this.rewardAmountGroup.SetActive(value:  false);
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
        this.radialRays.transform.localScale = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        UnityEngine.Transform val_4 = this.titleGroup.transform;
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.zero;
        val_4.localScale = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.zero;
        val_4.transform.localScale = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
        UnityEngine.Vector3 val_9 = UnityEngine.Vector3.zero;
        this.coinGroup.transform.localScale = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
        UnityEngine.Vector3 val_11 = UnityEngine.Vector3.zero;
        this.rewardAmountGroup.transform.localScale = new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z};
    }
    private System.Collections.IEnumerator GiftStageAnim()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WADMysteryGiftPopup.<GiftStageAnim>d__13();
    }
    private System.Collections.IEnumerator CoinStageAnim()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WADMysteryGiftPopup.<CoinStageAnim>d__14();
    }
    public WADMysteryGiftPopup()
    {
    
    }

}
