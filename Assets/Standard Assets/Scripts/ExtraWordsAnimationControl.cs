using UnityEngine;
public class ExtraWordsAnimationControl : MonoBehaviour
{
    // Fields
    public float WaveSpeed;
    public string AnimationName;
    private bool hasStart;
    private Spine.Unity.SkeletonGraphic skAnima;
    
    // Methods
    private void Awake()
    {
        if(this.skAnima != 0)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  this.AnimationName)) == true)
        {
                return;
        }
        
        this.skAnima = this.GetComponent<Spine.Unity.SkeletonGraphic>();
    }
    private void OnEnable()
    {
        if(this.hasStart == false)
        {
                return;
        }
        
        this.PlayAnimation();
    }
    private void OnDisable()
    {
        if(this.skAnima != null)
        {
                this.skAnima.Clear();
            return;
        }
        
        throw new NullReferenceException();
    }
    private void Start()
    {
        this.PlayAnimation();
        this.hasStart = true;
    }
    private void PlayAnimation()
    {
        if(this.skAnima == 0)
        {
                return;
        }
        
        Spine.TrackEntry val_2 = this.skAnima.state.SetAnimation(trackIndex:  0, animationName:  "extrawords_reward", loop:  false);
        Spine.TrackEntry val_3 = this.skAnima.state.AddAnimation(trackIndex:  0, animationName:  "extrawords_reward", loop:  true, delay:  0f);
        val_3.animationStart = 1.166f;
        val_3.timeScale = this.WaveSpeed;
        UnityEngine.Color val_4 = UnityEngine.Color.white;
        this.skAnima.color = new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a};
    }
    public void StopAnimation()
    {
        if(this.skAnima == 0)
        {
                return;
        }
        
        this.skAnima.state.ClearTracks();
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.Fadeout());
    }
    private System.Collections.IEnumerator Fadeout()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new ExtraWordsAnimationControl.<Fadeout>d__10();
    }
    public ExtraWordsAnimationControl()
    {
        this.WaveSpeed = 0.7f;
        this.AnimationName = "";
    }

}
