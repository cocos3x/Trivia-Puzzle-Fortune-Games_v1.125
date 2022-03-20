using UnityEngine;
public class TRVExtraLifeAwarded : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Text extraLifeText;
    private UnityEngine.ParticleSystem trailParticles;
    private UnityEngine.Vector3 offSetVector;
    private float statViewDelay;
    
    // Methods
    private void OnEnable()
    {
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVExtraLifeAwarded::<OnEnable>b__5_0()));
        TRVDataParser val_2 = MonoSingleton<TRVDataParser>.Instance;
        string val_5 = (val_2.<playerPersistance>k__BackingField.TotalFreeLivesAvailable()) - 1.ToString();
    }
    private System.Collections.IEnumerator Continue()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVExtraLifeAwarded.<Continue>d__6();
    }
    public TRVExtraLifeAwarded()
    {
        UnityEngine.Vector3 val_1 = new UnityEngine.Vector3(x:  0.25f, y:  0f, z:  0f);
        this.offSetVector = val_1.x;
        mem[1152921517256230696] = val_1.z;
        this.statViewDelay = 0.65f;
    }
    private void <OnEnable>b__5_0()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.Continue());
    }

}
