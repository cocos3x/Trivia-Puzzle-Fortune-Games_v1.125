using UnityEngine;

namespace Spine.Unity
{
    public class WaitForSpineAnimationComplete : IEnumerator
    {
        // Fields
        private bool m_WasFired;
        
        // Properties
        private object System.Collections.IEnumerator.Current { get; }
        
        // Methods
        public WaitForSpineAnimationComplete(Spine.TrackEntry trackEntry)
        {
            this.SafeSubscribe(trackEntry:  trackEntry);
        }
        private void HandleComplete(Spine.TrackEntry trackEntry)
        {
            this.m_WasFired = true;
        }
        private void SafeSubscribe(Spine.TrackEntry trackEntry)
        {
            if(trackEntry != null)
            {
                    trackEntry.add_Complete(value:  new AnimationState.TrackEntryDelegate(object:  this, method:  System.Void Spine.Unity.WaitForSpineAnimationComplete::HandleComplete(Spine.TrackEntry trackEntry)));
                return;
            }
            
            UnityEngine.Debug.LogWarning(message:  "TrackEntry was null. Coroutine will continue immediately.");
            this.m_WasFired = true;
        }
        public Spine.Unity.WaitForSpineAnimationComplete NowWaitFor(Spine.TrackEntry trackEntry)
        {
            this.SafeSubscribe(trackEntry:  trackEntry);
            return (Spine.Unity.WaitForSpineAnimationComplete)this;
        }
        private bool System.Collections.IEnumerator.MoveNext()
        {
            var val_3;
            if(this.m_WasFired != false)
            {
                    var val_2 = 0;
                val_2 = val_2 + 1;
            }
            else
            {
                    val_3 = 1;
                return (bool)val_3;
            }
            
            this.Reset();
            val_3 = 0;
            return (bool)val_3;
        }
        private void System.Collections.IEnumerator.Reset()
        {
            this.m_WasFired = false;
        }
        private object System.Collections.IEnumerator.get_Current()
        {
            return 0;
        }
    
    }

}
