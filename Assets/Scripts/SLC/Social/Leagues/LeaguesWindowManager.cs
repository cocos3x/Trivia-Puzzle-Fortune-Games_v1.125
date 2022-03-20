using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesWindowManager : SLCWindowManager<SLC.Social.Leagues.LeaguesWindowManager>
    {
        // Properties
        protected override System.Type myWindowType { get; }
        
        // Methods
        protected override System.Type get_myWindowType()
        {
            return System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
        }
        public LeaguesWindowManager()
        {
        
        }
    
    }

}
