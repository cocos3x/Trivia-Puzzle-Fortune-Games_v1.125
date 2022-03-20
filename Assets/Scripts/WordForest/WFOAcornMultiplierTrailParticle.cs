using UnityEngine;

namespace WordForest
{
    public class WFOAcornMultiplierTrailParticle : CurrencyParticles
    {
        // Methods
        protected override string GetBalanceUpdateNotifiicationName()
        {
            return "OnAcornMultiplierTrailParticleCompleted";
        }
        public WFOAcornMultiplierTrailParticle()
        {
        
        }
    
    }

}
