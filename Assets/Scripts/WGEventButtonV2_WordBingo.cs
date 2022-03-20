using UnityEngine;
public class WGEventButtonV2_WordBingo : WGEventButtonV2
{
    // Fields
    private UnityEngine.GameObject textBackground;
    
    // Methods
    public override void Refresh()
    {
        if(this == null)
        {
                return;
        }
        
        X20.gameObject.SetActive(value:  X20 & 1);
        this.textBackground.gameObject.SetActive(value:  (X20 != 0) ? 1 : 0);
    }
    public WGEventButtonV2_WordBingo()
    {
        mem[1152921517491608032] = 0;
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
