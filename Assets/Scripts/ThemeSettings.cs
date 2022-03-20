using UnityEngine;
[Serializable]
public class ThemeSettings
{
    // Fields
    public UnityEngine.Color lineDragColor;
    public UnityEngine.Color tileHighlightColor;
    public Cell cellTile;
    public LetterTile LetterTile;
    
    // Methods
    public ThemeSettings()
    {
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        this.lineDragColor = val_1;
        mem[1152921517090495428] = val_1.g;
        mem[1152921517090495432] = val_1.b;
        mem[1152921517090495436] = val_1.a;
        UnityEngine.Color val_2 = UnityEngine.Color.white;
        this.tileHighlightColor = val_2;
        mem[1152921517090495444] = val_2.g;
        mem[1152921517090495448] = val_2.b;
        mem[1152921517090495452] = val_2.a;
    }

}
