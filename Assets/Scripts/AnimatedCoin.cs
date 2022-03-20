using UnityEngine;
public class AnimatedCoin : MonoBehaviour
{
    // Fields
    private UnityEngine.ParticleSystem particleSystem;
    private UnityEngine.ParticleSystem.MainModule particlesMainModule;
    private UnityEngine.ParticleSystem.MinMaxGradient particlesStartColor;
    private float originalLifetimeMultipler;
    private UnityEngine.Color originalParticleColor;
    private UnityEngine.Color hidingParticleColor;
    private UnityEngine.UI.Image image;
    private CollectAnimation gridCoinCollectAnimation;
    
    // Methods
    private void Awake()
    {
        var val_5;
        var val_6;
        var val_7;
        ParticleSystem.MinMaxGradient val_8;
        this.image = this.GetComponent<UnityEngine.UI.Image>();
        MainModule val_2 = this.particleSystem.main;
        this.particlesMainModule = val_2.m_ParticleSystem;
        MainModule val_3 = this.particleSystem.main;
        MinMaxGradient val_4 = val_3.m_ParticleSystem.startColor;
        mem[1152921518027869896] = val_5;
        mem[1152921518027869880] = val_6;
        mem[1152921518027869864] = val_7;
        this.particlesStartColor = val_8;
        this.originalLifetimeMultipler = this.particlesMainModule.startLifetimeMultiplier;
        UnityEngine.Color val_10 = this.particlesStartColor.color;
        this.originalParticleColor = val_10;
        mem[1152921518027869912] = val_10.g;
        mem[1152921518027869916] = val_10.b;
        mem[1152921518027869920] = val_10.a;
        UnityEngine.Color val_11 = this.particlesStartColor.color;
        UnityEngine.Color val_12 = this.particlesStartColor.color;
        UnityEngine.Color val_13 = this.particlesStartColor.color;
        UnityEngine.Color val_14 = this.particlesStartColor.color;
        val_14.a = val_14.a * 0.5f;
        UnityEngine.Color val_15 = new UnityEngine.Color(r:  val_11.r, g:  val_12.g, b:  val_13.b, a:  val_14.a);
        this.hidingParticleColor = val_15.r;
    }
    public void Reset(CollectAnimation grid)
    {
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
        this.transform.localPosition = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
        this.gridCoinCollectAnimation = grid;
        if((UnityEngine.Object.op_Implicit(exists:  this.image)) == false)
        {
                return;
        }
        
        this.image.enabled = true;
    }
    private void OnDisable()
    {
        this.StopAllCoroutines();
    }
    public void PlaySparkle(float delay)
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.PlayingSparkle(delay:  delay));
    }
    private System.Collections.IEnumerator PlayingSparkle(float delay)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .delay = delay;
        return (System.Collections.IEnumerator)new AnimatedCoin.<PlayingSparkle>d__12();
    }
    public void HideCoin()
    {
        this.image.enabled = false;
        float val_2 = this.originalLifetimeMultipler;
        val_2 = val_2 * 0.5f;
        this.particlesMainModule.startLifetimeMultiplier = val_2;
        this.particlesStartColor.color = new UnityEngine.Color() {r = this.hidingParticleColor, g = 0.5f};
        this.particlesMainModule.startColor = new MinMaxGradient() {m_Mode = this.particlesStartColor, m_GradientMin = this.particlesStartColor, m_GradientMax = 0.5f, m_ColorMin = new UnityEngine.Color() {b = this.hidingParticleColor, a = this.hidingParticleColor}, m_ColorMax = new UnityEngine.Color() {r = this.hidingParticleColor, g = this.hidingParticleColor, b = 1.401298E-45f, a = 0f}};
        this.particleSystem.Play();
        var val_3 = 0;
        val_3 = val_3 + 1;
        this.gridCoinCollectAnimation.OnCoinDeposited();
    }
    public AnimatedCoin()
    {
        this.originalLifetimeMultipler = 1f;
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        this.originalParticleColor = val_1;
        mem[1152921518028652536] = val_1.g;
        mem[1152921518028652540] = val_1.b;
        mem[1152921518028652544] = val_1.a;
        UnityEngine.Color val_2 = UnityEngine.Color.gray;
        this.hidingParticleColor = val_2;
        mem[1152921518028652552] = val_2.g;
        mem[1152921518028652556] = val_2.b;
        mem[1152921518028652560] = val_2.a;
    }

}
