using UnityEngine;

namespace Spine
{
    public static class Json
    {
        // Methods
        public static object Deserialize(System.IO.TextReader text)
        {
            .<parseNumbersAsFloat>k__BackingField = true;
            return new SharpJson.JsonDecoder().Decode(text:  text);
        }
    
    }

}
