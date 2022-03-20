using UnityEngine;
public class WordNutFTUXDemoWindow : WordAddictFTUXDemoWindow
{
    // Methods
    protected override UnityEngine.Vector3 GetWordRegionPosStep1(UnityEngine.Transform letterSlot1, UnityEngine.Transform letterSlot2)
    {
        UnityEngine.Vector3 val_1 = letterSlot1.position;
        UnityEngine.Vector3 val_2 = letterSlot1.position;
        UnityEngine.Vector3 val_3 = letterSlot2.position;
        UnityEngine.Vector3 val_4 = letterSlot1.position;
        float val_7 = 0.5f;
        val_7 = (val_2.y + val_3.y) * val_7;
        UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  val_1.x, y:  val_7, z:  val_4.z);
        return new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
    }
    protected override UnityEngine.Vector2 GetWordRegionSizeStep1(float cellSize)
    {
        float val_1 = cellSize + cellSize;
        cellSize = ((float)W8 << 1) + cellSize;
        val_1 = val_1 + ((float)W8 << 2);
        UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  cellSize, y:  val_1);
        return new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
    }
    protected override UnityEngine.Vector2 GetWordRegionSizeStep2(float cellSize)
    {
        float val_5 = 3f;
        val_5 = cellSize * val_5;
        var val_1 = W8 + ((W8) << 1);
        val_1 = val_1 << 1;
        float val_6 = (float)val_1;
        val_6 = val_5 + val_6;
        UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  val_6, y:  ((float)W8 << 1) + cellSize);
        return new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
    }
    public WordNutFTUXDemoWindow()
    {
    
    }

}
