using UnityEngine;
public class WFLetter : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image border;
    private UnityEngine.UI.Text letter;
    private int <gridX>k__BackingField;
    private int <gridY>k__BackingField;
    private bool <IsAvailable>k__BackingField;
    private bool <IsSelected>k__BackingField;
    private bool <IsUsed>k__BackingField;
    private UnityEngine.Color borderAvl;
    private UnityEngine.Color borderSel;
    private UnityEngine.Color borderUse;
    private UnityEngine.Color letterAvl;
    private UnityEngine.Color letterSel;
    private UnityEngine.Color letterUse;
    
    // Properties
    public char Letter { get; set; }
    public int gridX { get; set; }
    public int gridY { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsSelected { get; set; }
    public bool IsUsed { get; set; }
    
    // Methods
    public char get_Letter()
    {
        return this.letter.Chars[0];
    }
    public void set_Letter(char value)
    {
        string val_1 = value.ToString();
    }
    public int get_gridX()
    {
        return (int)this.<gridX>k__BackingField;
    }
    protected void set_gridX(int value)
    {
        this.<gridX>k__BackingField = value;
    }
    public int get_gridY()
    {
        return (int)this.<gridY>k__BackingField;
    }
    protected void set_gridY(int value)
    {
        this.<gridY>k__BackingField = value;
    }
    public bool get_IsAvailable()
    {
        return (bool)this.<IsAvailable>k__BackingField;
    }
    protected void set_IsAvailable(bool value)
    {
        this.<IsAvailable>k__BackingField = value;
    }
    public bool get_IsSelected()
    {
        return (bool)this.<IsSelected>k__BackingField;
    }
    protected void set_IsSelected(bool value)
    {
        this.<IsSelected>k__BackingField = value;
    }
    public bool get_IsUsed()
    {
        return (bool)this.<IsUsed>k__BackingField;
    }
    protected void set_IsUsed(bool value)
    {
        this.<IsUsed>k__BackingField = value;
    }
    private void Start()
    {
        this.SetAvailable();
    }
    private void Update()
    {
    
    }
    public void SetGridPos(int x, int y)
    {
        this.<gridX>k__BackingField = x;
        this.<gridY>k__BackingField = y;
    }
    public bool IsAdjacent(WFLetter otherLetter)
    {
        var val_4;
        if(otherLetter != null)
        {
                int val_4 = this.<gridX>k__BackingField;
            if((otherLetter.<gridX>k__BackingField) == val_4)
        {
                val_4 = 1;
            if((otherLetter.<gridY>k__BackingField) == ((this.<gridY>k__BackingField) - 1))
        {
                return (bool)val_4;
        }
        
            if((otherLetter.<gridY>k__BackingField) == ((this.<gridY>k__BackingField) + 1))
        {
                return (bool)val_4;
        }
        
        }
        
            if((otherLetter.<gridY>k__BackingField) == (this.<gridY>k__BackingField))
        {
                val_4 = 1;
            if((otherLetter.<gridX>k__BackingField) == (val_4 - 1))
        {
                return (bool)val_4;
        }
        
            val_4 = val_4 + 1;
            if((otherLetter.<gridX>k__BackingField) == val_4)
        {
                return (bool)val_4;
        }
        
        }
        
            val_4 = 0;
            return (bool)val_4;
        }
        
        throw new NullReferenceException();
    }
    public void SetAvailable()
    {
        this.SetSize(size:  0.9f);
        this.border.color = new UnityEngine.Color() {r = this.borderAvl};
        this.letter.color = new UnityEngine.Color() {r = this.letterAvl};
        this.<IsAvailable>k__BackingField = true;
        this.<IsSelected>k__BackingField = false;
        this.<IsUsed>k__BackingField = false;
    }
    public void SetSelected()
    {
        this.SetSize(size:  1f);
        this.border.color = new UnityEngine.Color() {r = this.borderSel};
        this.letter.color = new UnityEngine.Color() {r = this.letterSel};
        this.<IsAvailable>k__BackingField = true;
        this.<IsSelected>k__BackingField = true;
        this.<IsUsed>k__BackingField = false;
    }
    public void SetUsed()
    {
        this.SetSize(size:  0.7f);
        this.border.color = new UnityEngine.Color() {r = this.borderUse};
        this.letter.color = new UnityEngine.Color() {r = this.letterUse};
        this.<IsAvailable>k__BackingField = false;
        this.<IsSelected>k__BackingField = false;
        this.<IsUsed>k__BackingField = true;
    }
    private void SetSize(float size)
    {
        PluginExtension.SetLocalScaleX(transform:  this.border.transform, x:  size);
        PluginExtension.SetLocalScaleY(transform:  this.border.transform, y:  size);
        PluginExtension.SetLocalScaleX(transform:  this.letter.transform, x:  size);
        PluginExtension.SetLocalScaleY(transform:  this.letter.transform, y:  size);
    }
    public WFLetter()
    {
        UnityEngine.Color val_1 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  0.5f);
        this.borderAvl = val_1.r;
        UnityEngine.Color val_2 = new UnityEngine.Color(r:  0.5f, g:  0.5f, b:  0.25f, a:  1f);
        this.borderSel = val_2.r;
        UnityEngine.Color val_3 = new UnityEngine.Color(r:  0.5f, g:  0.5f, b:  0.5f, a:  0.5f);
        this.borderUse = val_3.r;
        UnityEngine.Color val_4 = new UnityEngine.Color(r:  0.2f, g:  0.2f, b:  0.2f, a:  1f);
        this.letterAvl = val_4.r;
        UnityEngine.Color val_5 = new UnityEngine.Color(r:  0.6f, g:  0.5f, b:  0.2f, a:  1f);
        UnityEngine.Color val_6;
        this.letterSel = val_5.r;
        val_6 = new UnityEngine.Color(r:  0.3f, g:  0.3f, b:  0.3f, a:  1f);
        this.letterUse = val_6.r;
    }

}
