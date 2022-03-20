using UnityEngine;
public class TheLibraryBookProgressElement : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image image_background;
    private UnityEngine.GameObject obj_background_highlight;
    private UnityEngine.GameObject obj_darken_overlay;
    private UnityEngine.GameObject obj_progress;
    private UnityEngine.UI.Text text_progress;
    private UnityEngine.UI.Text text_chapter_numeral;
    private UnityEngine.GameObject obj_checkmark;
    private UnityEngine.UI.Button button_chapter_click;
    private UnityEngine.UI.Graphic[] graphics_to_darken;
    private UnityEngine.UI.Outline[] outlines_to_darken;
    private System.Collections.Generic.List<UnityEngine.Color> colors_graphics;
    private System.Collections.Generic.List<UnityEngine.Color> colors_texts;
    private System.Collections.Generic.List<UnityEngine.Color> colors_outlines;
    private int chapterDisplayed;
    private System.Action<int> ChapterClickAction;
    
    // Methods
    private void Awake()
    {
        this.button_chapter_click.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryBookProgressElement::OnElementClickAction()));
        this.colors_graphics = new System.Collections.Generic.List<UnityEngine.Color>();
        var val_5 = 0;
        label_8:
        if(val_5 >= this.graphics_to_darken.Length)
        {
            goto label_4;
        }
        
        UnityEngine.UI.Graphic val_4 = this.graphics_to_darken[val_5];
        this.colors_graphics.Add(item:  new UnityEngine.Color());
        val_5 = val_5 + 1;
        if(this.graphics_to_darken != null)
        {
            goto label_8;
        }
        
        label_4:
        this.colors_outlines = new System.Collections.Generic.List<UnityEngine.Color>();
        var val_7 = 0;
        do
        {
            if(val_7 >= this.outlines_to_darken.Length)
        {
                return;
        }
        
            UnityEngine.UI.Outline val_6 = this.outlines_to_darken[val_7];
            this.colors_outlines.Add(item:  new UnityEngine.Color());
            val_7 = val_7 + 1;
        }
        while(this.outlines_to_darken != null);
        
        throw new NullReferenceException();
    }
    public void Setup(int chapter, float completeProgress, int lastChapterInBook, TheLibrary.ProgressState state, bool interactable, System.Action<int> chapterClickAction)
    {
        this.chapterDisplayed = chapter;
        this.ChapterClickAction = chapterClickAction;
        this.button_chapter_click.interactable = interactable;
        if((UnityEngine.Object.op_Implicit(exists:  this.obj_darken_overlay)) != false)
        {
                this.obj_darken_overlay.SetActive(value:  (state == 2) ? 1 : 0);
        }
        
        string val_4 = this.obj_darken_overlay.RomanNumeralize(num:  chapter);
        this.obj_checkmark.SetActive(value:  (state == 0) ? 1 : 0);
        this.obj_progress.SetActive(value:  (state == 1) ? 1 : 0);
        string val_7 = completeProgress.ToString(format:  "#0%");
        this.ToggleChapterSelected(isOn:  (state == 1) ? 1 : 0, dimOthers:  false);
    }
    public void ToggleChapterSelected(bool isOn, bool dimOthers = False)
    {
        if(this.obj_background_highlight != 0)
        {
                this.obj_background_highlight.SetActive(value:  isOn);
        }
        
        if(dimOthers == false)
        {
                return;
        }
        
        if(this.obj_darken_overlay != 0)
        {
                this.obj_darken_overlay.SetActive(value:  (~isOn) & 1);
        }
        
        if(isOn != false)
        {
                this.LightenEverything();
            return;
        }
        
        this.DarkenEverything();
    }
    private void OnElementClickAction()
    {
        if(this.ChapterClickAction == null)
        {
                return;
        }
        
        this.ChapterClickAction.Invoke(obj:  this.chapterDisplayed);
    }
    private string RomanNumeralize(int num)
    {
        if((num - 1) <= 4)
        {
                var val_3 = 32561592 + ((num - 1)) << 2;
            val_3 = val_3 + 32561592;
        }
        else
        {
                string val_2 = num.ToString();
            return (string);
        }
    
    }
    private void DarkenEverything()
    {
        var val_3;
        var val_9 = 0;
        var val_8 = 0;
        label_7:
        if(val_8 >= this.graphics_to_darken.Length)
        {
            goto label_2;
        }
        
        UnityEngine.UI.Graphic val_3 = this.graphics_to_darken[val_8];
        if(this.graphics_to_darken.Length <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.Color val_1 = this.DarkenColor(originalColor:  new UnityEngine.Color() {r = this.graphics_to_darken[val_8][val_9], g = this.graphics_to_darken[val_8][val_9], b = this.graphics_to_darken[val_8][val_9], a = this.graphics_to_darken[val_8][val_9]}, normalizedPercent:  0.65f);
        val_8 = val_8 + 1;
        val_9 = val_9 + 16;
        if(this.graphics_to_darken != null)
        {
            goto label_7;
        }
        
        label_2:
        val_3 = 0;
        var val_15 = 0;
        do
        {
            if(val_15 >= this.outlines_to_darken.Length)
        {
                return;
        }
        
            if(this.outlines_to_darken.Length <= val_15)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            UnityEngine.Color val_2 = this.DarkenColor(originalColor:  new UnityEngine.Color() {r = this.outlines_to_darken[val_15][val_3], g = this.outlines_to_darken[val_15][val_3], b = this.outlines_to_darken[val_15][val_3], a = this.outlines_to_darken[val_15][val_3]}, normalizedPercent:  0.65f);
            this.outlines_to_darken[val_15].effectColor = new UnityEngine.Color() {r = val_2.r, g = val_2.g, b = val_2.b, a = val_2.a};
            val_15 = val_15 + 1;
            val_3 = val_3 + 16;
        }
        while(this.outlines_to_darken != null);
        
        throw new NullReferenceException();
    }
    private void LightenEverything()
    {
        var val_1;
        var val_7 = 0;
        var val_6 = 0;
        label_7:
        if(val_6 >= this.graphics_to_darken.Length)
        {
            goto label_2;
        }
        
        UnityEngine.UI.Graphic val_1 = this.graphics_to_darken[val_6];
        if(this.graphics_to_darken.Length <= val_6)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.UI.Graphic val_2 = this.graphics_to_darken[val_6][val_7];
        UnityEngine.UI.Graphic val_3 = this.graphics_to_darken[val_6][val_7];
        UnityEngine.UI.Graphic val_4 = this.graphics_to_darken[val_6][val_7];
        UnityEngine.UI.Graphic val_5 = this.graphics_to_darken[val_6][val_7];
        val_6 = val_6 + 1;
        val_7 = val_7 + 16;
        if(this.graphics_to_darken != null)
        {
            goto label_7;
        }
        
        label_2:
        val_1 = 0;
        var val_13 = 0;
        do
        {
            if(val_13 >= this.outlines_to_darken.Length)
        {
                return;
        }
        
            if(this.outlines_to_darken.Length <= val_13)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            this.outlines_to_darken[val_13].effectColor = new UnityEngine.Color() {r = this.outlines_to_darken[val_13][val_1], g = this.outlines_to_darken[val_13][val_1], b = this.outlines_to_darken[val_13][val_1], a = this.outlines_to_darken[val_13][val_1]};
            val_13 = val_13 + 1;
            val_1 = val_1 + 16;
        }
        while(this.outlines_to_darken != null);
        
        throw new NullReferenceException();
    }
    private UnityEngine.Color DarkenColor(UnityEngine.Color originalColor, float normalizedPercent)
    {
        UnityEngine.Color.RGBToHSV(rgbColor:  new UnityEngine.Color() {r = originalColor.r, g = originalColor.g, b = originalColor.b, a = originalColor.a}, H: out  float val_1 = -8.426975E-19f, S: out  float val_2 = -8.426973E-19f, V: out  float val_3 = -8.426967E-19f);
        float val_5 = 0f;
        val_5 = val_5 * normalizedPercent;
        UnityEngine.Color val_4 = UnityEngine.Color.HSVToRGB(H:  0f, S:  0f, V:  val_5);
        return new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a};
    }
    public TheLibraryBookProgressElement()
    {
    
    }

}
