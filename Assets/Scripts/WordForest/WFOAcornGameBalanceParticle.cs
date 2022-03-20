using UnityEngine;

namespace WordForest
{
    public class WFOAcornGameBalanceParticle : CurrencyParticles
    {
        // Methods
        protected override string GetBalanceUpdateNotifiicationName()
        {
            return "OnAcornLevelBalanceUpdated";
        }
        public WFOAcornGameBalanceParticle()
        {
        
        }
    
    }

}
