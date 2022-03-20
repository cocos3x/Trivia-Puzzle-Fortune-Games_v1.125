using UnityEngine;
public class WGEventButtonProgressLetterBank : WGEventButtonProgress
{
    // Methods
    public override void Initialize(WGEventHandler handler)
    {
        mem[1152921517497195736] = handler;
        if((MonoSingleton<LetterBankEventGameplayUIController>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<LetterBankEventGameplayUIController>.Instance.SetEventButtonAndText(evtBtn:  this.gameObject, twnCoinsText:  this.transform.GetComponentInChildren<TweenCoinsText>());
    }
    public override void Refresh()
    {
    
    }
    public WGEventButtonProgressLetterBank()
    {
        mem[1152921517497444320] = 0;
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
