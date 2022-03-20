using UnityEngine;
[Serializable]
public class CategoryColor
{
    // Fields
    public CategoryColorCode colorType;
    public UnityEngine.Color colorValue;
    public UnityEngine.Sprite tileSprite;
    
    // Methods
    public CategoryColor()
    {
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        this.colorValue = val_1;
        mem[1152921516120333640] = val_1.g;
        mem[1152921516120333644] = val_1.b;
        mem[1152921516120333648] = val_1.a;
    }

}
