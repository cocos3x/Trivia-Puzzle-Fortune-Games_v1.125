using UnityEngine;
public class WGEventButtonV2_WordHunt : WGEventButtonV2
{
    // Methods
    public override void Refresh()
    {
        X20.gameObject.SetActive(value:  X20 & 1);
    }
    public WGEventButtonV2_WordHunt()
    {
        mem[1152921517491840224] = 0;
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
