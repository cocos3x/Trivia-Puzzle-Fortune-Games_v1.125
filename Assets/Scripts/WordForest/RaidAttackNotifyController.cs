using UnityEngine;

namespace WordForest
{
    public class RaidAttackNotifyController : MonoBehaviour
    {
        // Methods
        public void Notify(WordForest.RaidAttackNotifyType note, System.Collections.Hashtable data)
        {
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  note.ToString(), aData:  data);
        }
        public RaidAttackNotifyController()
        {
        
        }
    
    }

}
