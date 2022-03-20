using UnityEngine;
public class LetterTile : MonoBehaviour
{
    // Fields
    public UnityEngine.UI.Text letterText;
    protected UnityEngine.UI.Image highlight;
    protected UnityEngine.RectTransform bgRect;
    public bool isHiglighted;
    
    // Properties
    public virtual string letter { get; set; }
    public UnityEngine.RectTransform CollisionRect { get; }
    
    // Methods
    public virtual string get_letter()
    {
        if(this.letterText != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public virtual void set_letter(string value)
    {
        if(this.letterText != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    protected virtual void Start()
    {
        if((MonoSingleton<ThemesHandler>.Instance) != 0)
        {
                ThemesHandler val_3 = MonoSingleton<ThemesHandler>.Instance;
            this.highlight.color = new UnityEngine.Color() {r = val_3.theme.themeSettings.tileHighlightColor};
        }
        
        this.highlight.canvasRenderer.SetAlpha(alpha:  0f);
    }
    public virtual void SetHighlight(bool state)
    {
        this.isHiglighted = state;
        if(this.highlight != null)
        {
                this.highlight.CrossFadeAlpha(alpha:  (state != true) ? 1f : 0f, duration:  0.2f, ignoreTimeScale:  true);
            return;
        }
        
        throw new NullReferenceException();
    }
    public UnityEngine.RectTransform get_CollisionRect()
    {
        return (UnityEngine.RectTransform)this.bgRect;
    }
    public virtual void SetLetter(string letterString)
    {
        if(this.letterText != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public LetterTile()
    {
    
    }

}
