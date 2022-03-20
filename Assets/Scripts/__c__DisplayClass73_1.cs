using UnityEngine;
private sealed class AttackMadnessEventHandler.<>c__DisplayClass73_1
{
    // Fields
    public UnityEngine.GameObject point;
    public AttackMadnessEventHandler.<>c__DisplayClass73_0 CS$<>8__locals1;
    
    // Methods
    public AttackMadnessEventHandler.<>c__DisplayClass73_1()
    {
    
    }
    internal void <PlayPointCollectionSequence>b__3()
    {
        UnityEngine.Object.Destroy(obj:  this.point);
        this.point.Play();
        WGAudioController val_1 = MonoSingleton<WGAudioController>.Instance;
        val_1.sound.PlayGameSpecificSound(id:  "Plop", clipIndex:  0);
    }

}
