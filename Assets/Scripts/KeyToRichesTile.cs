using UnityEngine;
public class KeyToRichesTile : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject keyGroup;
    private UnityEngine.GameObject key;
    private UnityEngine.ParticleSystem particle;
    private float flyToPreDelay;
    private float flyToDuration;
    private float flyToAfterDelay;
    private DG.Tweening.Ease easeX;
    private DG.Tweening.Ease easeY;
    private UnityEngine.GameObject flyout;
    private UnityEngine.GameObject bubble;
    private UnityEngine.UI.Text info;
    private DG.Tweening.Sequence mySequence;
    
    // Methods
    public void SetupAndShowFlyout(bool isFtux)
    {
        int val_9;
        UnityEngine.UI.Text val_10;
        if(isFtux == false)
        {
            goto label_1;
        }
        
        val_10 = this.info;
        string val_1 = Localization.Localize(key:  "key_riches_ftux_tooltip", defaultValue:  "Identify words to collect Keys", useSingularKey:  false);
        if(val_10 != null)
        {
            goto label_2;
        }
        
        label_1:
        int val_4 = UnityEngine.Mathf.Max(a:  3 - KeyToRichesEventHandler._Instance.KeyCount, b:  0);
        val_9 = val_4;
        val_10 = this.info;
        string val_8 = System.String.Format(format:  Localization.Localize(key:  (val_4 < 2) ? "key_riches_next_single" : "key_riches_next_plural", defaultValue:  (val_4 < 2) ? "{0} Key until next reward!" : "{0} Keys until next reward!", useSingularKey:  false), arg0:  val_9);
        label_2:
        this.ShowFlyout();
    }
    public void HideFlyout()
    {
        if(this.flyout == 0)
        {
                return;
        }
        
        if(this.flyout.gameObject == 0)
        {
                return;
        }
        
        DG.Tweening.TweenExtensions.Kill(t:  this.mySequence, complete:  false);
        DG.Tweening.Tweener val_8 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.flyout.gameObject.GetComponent<UnityEngine.CanvasGroup>(), endValue:  0f, duration:  0.2f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void KeyToRichesTile::<HideFlyout>b__13_0()));
    }
    public void ShiftToCell(Cell newParent)
    {
        if(newParent == 0)
        {
                return;
        }
        
        this.transform.SetParent(p:  newParent.transform);
        PluginExtension.SetLocalX(transform:  this.GetComponent<UnityEngine.RectTransform>(), x:  0f);
        PluginExtension.SetLocalY(transform:  this.GetComponent<UnityEngine.RectTransform>(), y:  0f);
    }
    public void Collect()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.FlyAndHide());
    }
    public void Remove()
    {
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    private void ShowFlyout()
    {
        this.flyout.SetActive(value:  false);
        UnityEngine.Vector3 val_3 = WordRegion.instance.transform.position;
        UnityEngine.Vector3 val_6 = this.bubble.transform.position;
        UnityEngine.Vector3 val_8 = this.bubble.transform.position;
        UnityEngine.Vector3 val_9 = new UnityEngine.Vector3(x:  val_3.x, y:  val_6.y, z:  val_8.z);
        this.bubble.transform.position = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
        UnityEngine.Rect val_12 = WordRegion.instance.getSafeAreaRect;
        UnityEngine.Vector2 val_13 = val_12.m_XMin.size;
        UnityEngine.Vector3 val_16 = WordRegion.instance.transform.localScale;
        UnityEngine.Vector2 val_18 = this.bubble.GetComponent<UnityEngine.RectTransform>().sizeDelta;
        UnityEngine.Vector2 val_20 = new UnityEngine.Vector2(x:  val_13.x / val_16.x, y:  val_18.y);
        this.bubble.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2() {x = val_20.x, y = val_20.y};
        this.flyout.SetActive(value:  true);
        WGWindowManager val_22 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<UGUIClickableMask>(showNext:  false);
        mem2[0] = new System.Action(object:  this, method:  public System.Void KeyToRichesTile::HideFlyout());
        UnityEngine.CanvasGroup val_25 = this.flyout.gameObject.GetComponent<UnityEngine.CanvasGroup>();
        val_25.alpha = 0f;
        DG.Tweening.Sequence val_26 = DG.Tweening.DOTween.Sequence();
        this.mySequence = val_26;
        DG.Tweening.Sequence val_31 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  DG.Tweening.TweenSettingsExtensions.Append(s:  val_26, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  val_25, endValue:  1f, duration:  0.1f)), interval:  4f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void KeyToRichesTile::<ShowFlyout>b__17_0()));
    }
    private System.Collections.IEnumerator FlyAndHide()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new KeyToRichesTile.<FlyAndHide>d__18();
    }
    public KeyToRichesTile()
    {
        this.flyToPreDelay = 0.2f;
        this.flyToDuration = 1f;
        this.flyToAfterDelay = 0.2f;
    }
    private void <HideFlyout>b__13_0()
    {
        this.flyout.gameObject.SetActive(value:  false);
    }
    private void <ShowFlyout>b__17_0()
    {
        this.HideFlyout();
    }

}
