using UnityEngine;

namespace AudienceNetwork.Utility
{
    internal class AdUtilityBridge : IAdUtilityBridge
    {
        // Fields
        public static readonly AudienceNetwork.Utility.IAdUtilityBridge Instance;
        
        // Methods
        internal AdUtilityBridge()
        {
        
        }
        private static AdUtilityBridge()
        {
            AudienceNetwork.Utility.AdUtilityBridge.Instance = AudienceNetwork.Utility.AdUtilityBridge.CreateInstance();
        }
        private static AudienceNetwork.Utility.IAdUtilityBridge CreateInstance()
        {
            var val_4;
            if(UnityEngine.Application.platform != 0)
            {
                    AudienceNetwork.Utility.AdUtilityBridgeAndroid val_2 = null;
                val_4 = val_2;
                val_2 = new AudienceNetwork.Utility.AdUtilityBridgeAndroid();
                return (AudienceNetwork.Utility.IAdUtilityBridge)val_4;
            }
            
            AudienceNetwork.Utility.AdUtilityBridge val_3 = null;
            val_4 = val_3;
            val_3 = new AudienceNetwork.Utility.AdUtilityBridge();
            return (AudienceNetwork.Utility.IAdUtilityBridge)val_4;
        }
        public virtual double DeviceWidth()
        {
            return 2208;
        }
        public virtual double DeviceHeight()
        {
            return 1242;
        }
        public virtual double Width()
        {
            return 1104;
        }
        public virtual double Height()
        {
            return 621;
        }
        public virtual double Convert(double deviceSize)
        {
            return 2;
        }
        public virtual void Prepare()
        {
        
        }
    
    }

}
