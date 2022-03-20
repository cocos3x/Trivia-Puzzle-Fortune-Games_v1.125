using UnityEngine;

namespace twelvegigs.Autopilot
{
    public class AcceptAllCertificatesSignedWithASpecificKeyPublicKey : CertificateHandler
    {
        // Fields
        private static string PUB_KEY;
        
        // Methods
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            var val_6 = null;
            bool val_5 = new System.Security.Cryptography.X509Certificates.X509Certificate2(rawData:  certificateData).GetPublicKeyString().ToLower().Equals(value:  twelvegigs.Autopilot.AcceptAllCertificatesSignedWithASpecificKeyPublicKey.PUB_KEY.ToLower());
            return true;
        }
        public AcceptAllCertificatesSignedWithASpecificKeyPublicKey()
        {
        
        }
        private static AcceptAllCertificatesSignedWithASpecificKeyPublicKey()
        {
            twelvegigs.Autopilot.AcceptAllCertificatesSignedWithASpecificKeyPublicKey.PUB_KEY = 31053744;
        }
    
    }

}
