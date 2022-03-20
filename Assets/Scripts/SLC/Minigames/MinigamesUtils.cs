using UnityEngine;

namespace SLC.Minigames
{
    public class MinigamesUtils
    {
        // Methods
        public static string RomanNumeralize(int num)
        {
            var val_2;
            if(num < 2)
            {
                    val_2 = "I";
                return (string)(num < 8) ? "VII" : "VIII";
            }
            
            if(num == 2)
            {
                    val_2 = "II";
                return (string)(num < 8) ? "VII" : "VIII";
            }
            
            if(num < 4)
            {
                    val_2 = "III";
                return (string)(num < 8) ? "VII" : "VIII";
            }
            
            if(num == 4)
            {
                    val_2 = "IV";
                return (string)(num < 8) ? "VII" : "VIII";
            }
            
            if(num < 6)
            {
                    val_2 = "V";
                return (string)(num < 8) ? "VII" : "VIII";
            }
            
            if(num != 6)
            {
                    return (string)(num < 8) ? "VII" : "VIII";
            }
            
            val_2 = "VI";
            return (string)(num < 8) ? "VII" : "VIII";
        }
        public static string ColorToHex(UnityEngine.Color32 color)
        {
            return (string)color.r.ToString(format:  "X2")(color.r.ToString(format:  "X2")) + color.g.ToString(format:  "X2")(color.g.ToString(format:  "X2")) + color.b.ToString(format:  "X2")(color.b.ToString(format:  "X2"));
        }
        public static UnityEngine.Color HexToColor(string hex)
        {
            UnityEngine.Color32 val_7 = new UnityEngine.Color32(r:  System.Byte.Parse(s:  hex.Substring(startIndex:  0, length:  2), style:  3), g:  System.Byte.Parse(s:  hex.Substring(startIndex:  2, length:  2), style:  3), b:  System.Byte.Parse(s:  hex.Substring(startIndex:  4, length:  2), style:  3), a:  255);
            UnityEngine.Color val_8 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_7.r, g = val_7.r, b = val_7.r, a = val_7.r});
            return new UnityEngine.Color() {r = val_8.r, g = val_8.g, b = val_8.b, a = val_8.a};
        }
        public MinigamesUtils()
        {
        
        }
    
    }

}
