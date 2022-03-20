using UnityEngine;

namespace SLC.Social.Leagues
{
    public class GuildTierLoc
    {
        // Methods
        public static string GetLocalizedTier(int tier)
        {
            char[] val_2 = new char[1];
            val_2[0] = '_';
            System.String[] val_3 = tier.ToString().Split(separator:  val_2);
            return (string)System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  System.String.Format(format:  "{0}_upper", arg0:  val_3[0].ToLower()), defaultValue:  "", useSingularKey:  false), arg1:  val_3[1]);
        }
        public GuildTierLoc()
        {
        
        }
    
    }

}
