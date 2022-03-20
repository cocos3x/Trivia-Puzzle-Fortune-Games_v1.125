using UnityEngine;

namespace SLC.Minigames.TwistyArrow
{
    public class WordBow : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Image bowImage;
        private UnityEngine.Sprite drawnSprite;
        private UnityEngine.Sprite releasedSprite;
        private UnityEngine.GameObject staticArrow;
        private float releaseTime;
        private float redrawTime;
        private UnityEngine.AudioSource audioSource;
        private UnityEngine.AudioClip clip;
        
        // Methods
        private void Awake()
        {
            this.bowImage = this.GetComponent<UnityEngine.UI.Image>();
            UnityEngine.AudioSource val_2 = this.GetComponent<UnityEngine.AudioSource>();
            this.audioSource = val_2;
            this.clip = val_2.clip;
            this.staticArrow.SetActive(value:  true);
        }
        public void OnFire()
        {
            this.PlaySound();
            this.staticArrow.SetActive(value:  false);
            this.StopAllCoroutines();
            this.bowImage.sprite = this.drawnSprite;
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.OnRelease());
        }
        private System.Collections.IEnumerator OnRelease()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new WordBow.<OnRelease>d__10();
        }
        private System.Collections.IEnumerator ReDraw()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new WordBow.<ReDraw>d__11();
        }
        private void PlaySound()
        {
            if((MonoSingleton<MinigameAudioController>.Instance.IsSoundMuted()) != false)
            {
                    return;
            }
            
            this.audioSource.PlayOneShot(clip:  this.clip, volumeScale:  0.5f);
        }
        public WordBow()
        {
            this.releaseTime = 0.01f;
            this.redrawTime = 0.35f;
        }
    
    }

}
