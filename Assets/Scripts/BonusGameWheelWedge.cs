using UnityEngine;
public class BonusGameWheelWedge : MonoBehaviour
{
    // Fields
    private TMPro.TextMeshProUGUI label;
    private UnityEngine.UI.Image icon;
    private UnityEngine.UI.Image wedgeHighlighter;
    private UnityEngine.Color wedgeColor;
    private float fitToWidth;
    private DG.Tweening.Tween flashSeq;
    
    // Methods
    public void Init(string rewardText, UnityEngine.Sprite rewardIcon)
    {
        UnityEngine.Color val_1 = this.wedgeHighlighter.color;
        this.wedgeColor = val_1;
        mem[1152921516104034644] = val_1.g;
        mem[1152921516104034648] = val_1.b;
        mem[1152921516104034652] = val_1.a;
        this.label.text = rewardText;
        this.icon.sprite = rewardIcon;
        UnityEngine.Rect val_2 = rewardIcon.rect;
        UnityEngine.Vector2 val_3 = val_2.m_XMin.size;
        val_3.x = val_3.y / val_3.x;
        val_3.y = this.fitToWidth * val_3.x;
        this.icon.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = this.fitToWidth, y = val_3.y};
    }
    public void Flash(UnityEngine.Color flashColor, float flashDuration = 0.3, float startDelay = 0, float endDelay = 0)
    {
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_2 = DG.Tweening.TweenSettingsExtensions.PrependInterval(s:  val_1, interval:  startDelay);
        DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOColor(target:  this.wedgeHighlighter, endValue:  new UnityEngine.Color() {r = flashColor.r, g = flashColor.g, b = flashColor.b, a = flashColor.a}, duration:  flashDuration), ease:  32, amplitude:  2f, period:  0f));
        DG.Tweening.Sequence val_6 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_1, interval:  endDelay);
        DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  val_1, loops:  0, loopType:  0);
        DG.Tweening.Sequence val_8 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Sequence>(t:  val_1, ease:  1);
        this.flashSeq = val_1;
    }
    public void StopFlash()
    {
        DG.Tweening.TweenExtensions.Kill(t:  this.flashSeq, complete:  false);
        this.wedgeHighlighter.color = new UnityEngine.Color() {r = this.wedgeColor};
    }
    public BonusGameWheelWedge()
    {
        this.fitToWidth = 96f;
    }

}
