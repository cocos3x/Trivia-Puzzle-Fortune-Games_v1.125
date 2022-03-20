using UnityEngine;
public class WGLightningWordsFTUXFlyout : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject windowGroup;
    private UnityEngine.RectTransform windowBubble;
    private UnityEngine.Transform tooltipPick;
    private UnityEngine.UI.Image tooltipPickImg;
    private UnityEngine.Sprite tooltipPickUp;
    private UnityEngine.Sprite tooltipPickDown;
    private UnityEngine.UI.Button lightningWordsButton;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Button screenButton;
    private UnityEngine.GameObject targetButtonObject;
    
    // Methods
    private void Awake()
    {
        this.lightningWordsButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLightningWordsFTUXFlyout::OnClick_LightningWordsButton()));
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLightningWordsFTUXFlyout::Close()));
        this.screenButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLightningWordsFTUXFlyout::Close()));
    }
    private void Start()
    {
        this.targetButtonObject = this.gameObject;
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
        MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
        UnityEngine.Color val_5 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.75f);
        System.Nullable<UnityEngine.Color> val_6 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_5.r, g = val_5.g, b = val_5.b, a = val_5.a});
        MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.25f, fadeOutDuration:  0.15f);
        System.Collections.Generic.List<UnityEngine.Transform> val_7 = new System.Collections.Generic.List<UnityEngine.Transform>();
        LightningWordsUIController val_8 = MonoSingleton<LightningWordsUIController>.Instance;
        val_7.AddRange(collection:  val_8.wordEffects);
        val_7.Add(item:  this.targetButtonObject.transform);
        MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  val_7.ToArray());
    }
    private void SetupButton()
    {
        this.targetButtonObject = this.gameObject;
    }
    private void OnClick_LightningWordsButton()
    {
        LightningWordsHandler.DEFAULT_REWARD_VALUE.ShowLightningWordsPopup();
        this.Close();
    }
    private void Close()
    {
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = false;
        MonoSingleton<GameMaskOverlay>.Instance.Interactable = false;
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  0);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public void ShowFTUX(UnityEngine.Transform word, UnityEngine.Transform firstLetter, UnityEngine.Transform mainLayout, UnityEngine.Rect wordRegion)
    {
        float val_33;
        float val_34;
        float val_35;
        float val_36;
        float val_40;
        float val_41;
        this.windowGroup.SetActive(value:  false);
        this.tooltipPick.gameObject.SetActive(value:  false);
        UnityEngine.Rect val_2 = this.windowBubble.rect;
        float val_38 = val_2.m_XMin.height;
        UnityEngine.Rect val_4 = this.windowBubble.rect;
        val_33 = val_4.m_XMin.width;
        UnityEngine.Rect val_7 = firstLetter.GetComponent<UnityEngine.RectTransform>().rect;
        float val_8 = val_7.m_XMin.height;
        float val_10 = wordRegion.m_XMin.width;
        UnityEngine.Vector3 val_11 = firstLetter.position;
        UnityEngine.Vector3 val_12 = mainLayout.InverseTransformPoint(position:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z});
        float val_32 = -0.25f;
        val_32 = val_33 * val_32;
        if(val_12.x >= 0)
        {
            goto label_9;
        }
        
        val_34 = -40f;
        float val_33 = 0.5f;
        val_33 = val_33 * val_33;
        val_35 = val_33 + val_12.x;
        goto label_10;
        label_9:
        float val_34 = 0.25f;
        val_34 = val_33 * val_34;
        val_36 = 0f;
        if(val_12.x <= val_34)
        {
            goto label_11;
        }
        
        val_34 = 40f;
        float val_35 = -0.5f;
        val_35 = val_33 * val_35;
        val_35 = val_12.x + val_35;
        label_10:
        val_36 = val_35 + val_34;
        label_11:
        if((wordRegion.m_XMin.height - val_12.y) < 0)
        {
                this.tooltipPickImg.sprite = this.tooltipPickUp;
            UnityEngine.Rect val_15 = this.tooltipPick.GetComponent<UnityEngine.RectTransform>().rect;
            float val_16 = val_15.m_XMin.height;
            float val_36 = 0.5f;
            val_16 = val_16 * val_36;
            val_36 = (val_8 * val_36) + val_16;
            UnityEngine.Vector3 val_18 = new UnityEngine.Vector3(x:  0f, y:  val_36, z:  0f);
            UnityEngine.Vector3 val_19 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z}, b:  new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z});
            this.tooltipPick.localPosition = new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z};
            UnityEngine.Vector3 val_20 = this.tooltipPick.localPosition;
            val_40 = -102f;
            float val_37 = -0.5f;
            val_37 = val_38 * val_37;
            val_41 = val_20.y + val_37;
        }
        else
        {
                this.tooltipPickImg.sprite = this.tooltipPickDown;
            UnityEngine.Rect val_22 = this.tooltipPick.GetComponent<UnityEngine.RectTransform>().rect;
            float val_23 = val_22.m_XMin.height;
            val_33 = 0.5f;
            float val_24 = val_8 * val_33;
            val_23 = val_23 * val_33;
            val_24 = val_24 + val_23;
            UnityEngine.Vector3 val_25 = new UnityEngine.Vector3(x:  0f, y:  val_24, z:  0f);
            UnityEngine.Vector3 val_26 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z}, b:  new UnityEngine.Vector3() {x = val_25.x, y = val_25.y, z = val_25.z});
            this.tooltipPick.localPosition = new UnityEngine.Vector3() {x = val_26.x, y = val_26.y, z = val_26.z};
            UnityEngine.Vector3 val_27 = this.tooltipPick.localPosition;
            val_40 = -95f;
            val_41 = (val_38 * val_33) + val_27.y;
        }
        
        val_38 = val_41 + val_40;
        UnityEngine.Vector3 val_30 = new UnityEngine.Vector3(x:  val_36, y:  val_38, z:  0f);
        this.windowGroup.transform.localPosition = new UnityEngine.Vector3() {x = val_30.x, y = val_30.y, z = val_30.z};
        this.windowGroup.SetActive(value:  true);
        this.tooltipPick.gameObject.SetActive(value:  true);
    }
    public WGLightningWordsFTUXFlyout()
    {
    
    }

}
