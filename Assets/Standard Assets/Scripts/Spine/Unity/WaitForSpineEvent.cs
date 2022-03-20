using UnityEngine;

namespace Spine.Unity
{
    public class WaitForSpineEvent : IEnumerator
    {
        // Fields
        private Spine.EventData m_TargetEvent;
        private string m_EventName;
        private Spine.AnimationState m_AnimationState;
        private bool m_WasFired;
        private bool m_unsubscribeAfterFiring;
        
        // Properties
        public bool WillUnsubscribeAfterFiring { get; set; }
        private object System.Collections.IEnumerator.Current { get; }
        
        // Methods
        private void Subscribe(Spine.AnimationState state, Spine.EventData eventDataReference, bool unsubscribe)
        {
            object val_3;
            if(state == null)
            {
                goto label_1;
            }
            
            if(eventDataReference == null)
            {
                goto label_2;
            }
            
            this.m_AnimationState = state;
            this.m_TargetEvent = eventDataReference;
            state.add_Event(value:  new AnimationState.TrackEntryEventDelegate(object:  this, method:  System.Void Spine.Unity.WaitForSpineEvent::HandleAnimationStateEvent(Spine.TrackEntry trackEntry, Spine.Event e)));
            this.m_unsubscribeAfterFiring = unsubscribe;
            return;
            label_1:
            val_3 = "AnimationState argument was null. Coroutine will continue immediately.";
            goto label_6;
            label_2:
            val_3 = "eventDataReference argument was null. Coroutine will continue immediately.";
            label_6:
            UnityEngine.Debug.LogWarning(message:  val_3);
            this.m_WasFired = true;
        }
        private void SubscribeByName(Spine.AnimationState state, string eventName, bool unsubscribe)
        {
            object val_4;
            if(state == null)
            {
                goto label_1;
            }
            
            if((System.String.IsNullOrEmpty(value:  eventName)) == false)
            {
                goto label_2;
            }
            
            val_4 = "eventName argument was null. Coroutine will continue immediately.";
            goto label_5;
            label_1:
            val_4 = "AnimationState argument was null. Coroutine will continue immediately.";
            label_5:
            UnityEngine.Debug.LogWarning(message:  val_4);
            this.m_WasFired = true;
            return;
            label_2:
            this.m_EventName = eventName;
            this.m_AnimationState = state;
            state.add_Event(value:  new AnimationState.TrackEntryEventDelegate(object:  this, method:  System.Void Spine.Unity.WaitForSpineEvent::HandleAnimationStateEventByName(Spine.TrackEntry trackEntry, Spine.Event e)));
            this.m_unsubscribeAfterFiring = unsubscribe;
        }
        public WaitForSpineEvent(Spine.AnimationState state, Spine.EventData eventDataReference, bool unsubscribeAfterFiring = True)
        {
            val_1 = new System.Object();
            unsubscribeAfterFiring = unsubscribeAfterFiring;
            this.Subscribe(state:  state, eventDataReference:  Spine.EventData val_1 = eventDataReference, unsubscribe:  unsubscribeAfterFiring);
        }
        public WaitForSpineEvent(Spine.Unity.SkeletonAnimation skeletonAnimation, Spine.EventData eventDataReference, bool unsubscribeAfterFiring = True)
        {
            val_1 = new System.Object();
            unsubscribeAfterFiring = unsubscribeAfterFiring;
            this.Subscribe(state:  skeletonAnimation.state, eventDataReference:  Spine.EventData val_1 = eventDataReference, unsubscribe:  unsubscribeAfterFiring);
        }
        public WaitForSpineEvent(Spine.AnimationState state, string eventName, bool unsubscribeAfterFiring = True)
        {
            val_1 = new System.Object();
            unsubscribeAfterFiring = unsubscribeAfterFiring;
            this.SubscribeByName(state:  state, eventName:  string val_1 = eventName, unsubscribe:  unsubscribeAfterFiring);
        }
        public WaitForSpineEvent(Spine.Unity.SkeletonAnimation skeletonAnimation, string eventName, bool unsubscribeAfterFiring = True)
        {
            val_1 = new System.Object();
            unsubscribeAfterFiring = unsubscribeAfterFiring;
            this.SubscribeByName(state:  skeletonAnimation.state, eventName:  string val_1 = eventName, unsubscribe:  unsubscribeAfterFiring);
        }
        private void HandleAnimationStateEventByName(Spine.TrackEntry trackEntry, Spine.Event e)
        {
            bool val_5 = this.m_WasFired;
            bool val_3 = ((val_5 == true) ? 1 : 0) | (System.String.op_Equality(a:  e.data.name, b:  this.m_EventName));
            val_5 = val_3;
            this.m_WasFired = val_5;
            if(val_3 == false)
            {
                    return;
            }
            
            if(this.m_unsubscribeAfterFiring == false)
            {
                    return;
            }
            
            this.m_AnimationState.remove_Event(value:  new AnimationState.TrackEntryEventDelegate(object:  this, method:  System.Void Spine.Unity.WaitForSpineEvent::HandleAnimationStateEventByName(Spine.TrackEntry trackEntry, Spine.Event e)));
        }
        private void HandleAnimationStateEvent(Spine.TrackEntry trackEntry, Spine.Event e)
        {
            bool val_1 = (e.data == this.m_TargetEvent) ? 1 : 0;
            val_1 = this.m_WasFired | val_1;
            this.m_WasFired = val_1;
            if(this.m_WasFired != true)
            {
                    if(e.data != this.m_TargetEvent)
            {
                    return;
            }
            
            }
            
            if(this.m_unsubscribeAfterFiring == false)
            {
                    return;
            }
            
            this.m_AnimationState.remove_Event(value:  new AnimationState.TrackEntryEventDelegate(object:  this, method:  System.Void Spine.Unity.WaitForSpineEvent::HandleAnimationStateEvent(Spine.TrackEntry trackEntry, Spine.Event e)));
        }
        public bool get_WillUnsubscribeAfterFiring()
        {
            return (bool)this.m_unsubscribeAfterFiring;
        }
        public void set_WillUnsubscribeAfterFiring(bool value)
        {
            this.m_unsubscribeAfterFiring = value;
        }
        public Spine.Unity.WaitForSpineEvent NowWaitFor(Spine.AnimationState state, Spine.EventData eventDataReference, bool unsubscribeAfterFiring = True)
        {
            var val_2 = 0;
            val_2 = val_2 + 1;
            this.Reset();
            this.Clear(state:  state);
            unsubscribeAfterFiring = unsubscribeAfterFiring;
            this.Subscribe(state:  state, eventDataReference:  eventDataReference, unsubscribe:  unsubscribeAfterFiring);
            return (Spine.Unity.WaitForSpineEvent)this;
        }
        public Spine.Unity.WaitForSpineEvent NowWaitFor(Spine.AnimationState state, string eventName, bool unsubscribeAfterFiring = True)
        {
            var val_2 = 0;
            val_2 = val_2 + 1;
            this.Reset();
            this.Clear(state:  state);
            unsubscribeAfterFiring = unsubscribeAfterFiring;
            this.SubscribeByName(state:  state, eventName:  eventName, unsubscribe:  unsubscribeAfterFiring);
            return (Spine.Unity.WaitForSpineEvent)this;
        }
        private void Clear(Spine.AnimationState state)
        {
            state.remove_Event(value:  new AnimationState.TrackEntryEventDelegate(object:  this, method:  System.Void Spine.Unity.WaitForSpineEvent::HandleAnimationStateEvent(Spine.TrackEntry trackEntry, Spine.Event e)));
            state.remove_Event(value:  new AnimationState.TrackEntryEventDelegate(object:  this, method:  System.Void Spine.Unity.WaitForSpineEvent::HandleAnimationStateEventByName(Spine.TrackEntry trackEntry, Spine.Event e)));
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
