using UnityEngine;

namespace SLC.Minigames.Just2Emojis
{
    public class Emoji
    {
        // Fields
        private string myName;
        
        // Properties
        public string Name { get; }
        
        // Methods
        public string get_Name()
        {
            return (string)this.myName;
        }
        public Emoji(string name)
        {
            this.myName = name;
        }
        public override string ToString()
        {
            return System.String.Format(format:  "J2E Emoji: {0}", arg0:  this.myName);
        }
    
    }

}
