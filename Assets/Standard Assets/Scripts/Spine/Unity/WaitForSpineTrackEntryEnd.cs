using UnityEngine;

namespace Spine.Unity
{
    public class WaitForSpineTrackEntryEnd : IEnumerator
    {
        // Fields
        private bool m_WasFired;
        
        // Properties
        private object System.Collections.IEnumerator.Current { get; }
        
        // Methods
        public WaitForSpineTrackEntryEnd(Spine.TrackEntry trackEntry)
        {
            this.SafeSubscribe(trackEntry:  trackEntry);
        }
        private void HandleEnd(Spine.TrackEntry trackEntry)
        {
            this.m_WasFired = true;
        }
        private void SafeSubscribe(Spine.TrackEntry trackEntry)
        {
            if(trackEntry != null)
            {
                    trackEntry.add_End(value:  new AnimationState.TrackEntryDelegate(object:  this, method:  System.Void Spine.Unity.WaitForSpineTrackEntryEnd::HandleEnd(Spine.TrackEntry trackEntry)));
                return;
            }
            
            UnityEngine.Debug.LogWarning(message:  "TrackEntry was null. Coroutine will continue immediately.");
            this.m_WasFired = true;
        }
        public Spine.Unity.WaitForSpineTrackEntryEnd NowWaitFor(Spine.TrackEntry trackEntry)
        {
            this.SafeSubscribe(trackEntry:  trackEntry);
            return (Spine.Unity.WaitForSpineTrackEntryEnd)this;
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
