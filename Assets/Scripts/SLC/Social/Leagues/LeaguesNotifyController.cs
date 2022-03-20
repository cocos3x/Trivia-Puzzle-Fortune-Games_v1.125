using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesNotifyController : LeaguesServerController
    {
        // Methods
        public void Notify(SLC.Social.Leagues.LeaguesNotifyType note)
        {
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  note.ToString());
        }
        public LeaguesNotifyController()
        {
            this = new UnityEngine.MonoBehaviour();
        }
    
    }

}
