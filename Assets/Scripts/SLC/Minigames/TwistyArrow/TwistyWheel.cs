using UnityEngine;

namespace SLC.Minigames.TwistyArrow
{
    public class TwistyWheel : MonoBehaviour
    {
        // Fields
        private TMPro.TextMeshProUGUI[] WordTexts;
        private Spin WheelSpin;
        private float baseRotationSpeed;
        private float speedMultiplier;
        private const float speedMultiplierIncre = 0.25;
        private UnityEngine.AudioSource audioSource;
        private UnityEngine.AudioClip clip;
        
        // Properties
        public float SpeedMultiplier { get; }
        
        // Methods
        public float get_SpeedMultiplier()
        {
            return (float)this.speedMultiplier;
        }
        private void Awake()
        {
            SLC.Minigames.TwistyArrow.TwistyGameManager val_1 = MonoSingleton<SLC.Minigames.TwistyArrow.TwistyGameManager>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnPlayingStateChanged, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Minigames.TwistyArrow.TwistyWheel::OnPlayingStateChanged(bool playing)));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_5;
            }
            
            }
            
            val_1.OnPlayingStateChanged = val_3;
            UnityEngine.AudioSource val_4 = this.GetComponent<UnityEngine.AudioSource>();
            this.audioSource = val_4;
            this.clip = val_4.clip;
            return;
            label_5:
        }
        public void Setup(string[] words, float secondsPerRotation)
        {
            if(words.Length != this.WordTexts.Length)
            {
                    UnityEngine.Debug.LogError(message:  "Words length doesn\'t match WordTexts length.");
                this.WordTexts = this.WordTexts;
            }
            
            var val_9 = 4;
            label_11:
            if((val_9 - 4) >= this.WordTexts.Length)
            {
                goto label_7;
            }
            
            this.WordTexts[0].text = words[0];
            val_9 = val_9 + 1;
            if(this.WordTexts != null)
            {
                goto label_11;
            }
            
            label_7:
            float val_2 = (secondsPerRotation > 0f) ? 1f : -1f;
            val_2 = val_2 / secondsPerRotation;
            this.baseRotationSpeed = val_2;
            UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  -val_2);
            this.WheelSpin.rotationsPerSecond = val_3.x;
            mem2[0] = val_3.z;
            this.speedMultiplier = 1f;
            UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  UnityEngine.Random.Range(min:  0f, max:  360f));
            this.transform.localEulerAngles = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        }
        private void OnPlayingStateChanged(bool playing)
        {
            if(playing != false)
            {
                    return;
            }
            
            this.StopSpinning();
        }
        public void StopSpinning()
        {
            UnityEngine.Vector3 val_1 = UnityEngine.Vector3.zero;
            this.WheelSpin.rotationsPerSecond = val_1;
            mem2[0] = val_1.y;
            mem2[0] = val_1.z;
        }
        public void PlaySound()
        {
            if((MonoSingleton<MinigameAudioController>.Instance.IsSoundMuted()) != false)
            {
                    return;
            }
            
            this.audioSource.PlayOneShot(clip:  this.clip, volumeScale:  0.9f);
        }
        public void IncreSpeed()
        {
            float val_2 = this.speedMultiplier;
            float val_3 = 0.25f;
            val_2 = val_2 + val_3;
            this.speedMultiplier = val_2;
            val_3 = -(val_2 * this.baseRotationSpeed);
            UnityEngine.Vector3 val_1 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  val_3);
            this.WheelSpin.rotationsPerSecond = val_1.x;
            mem2[0] = val_1.z;
        }
        public TwistyWheel()
        {
            this.speedMultiplier = 1f;
        }
    
    }

}
