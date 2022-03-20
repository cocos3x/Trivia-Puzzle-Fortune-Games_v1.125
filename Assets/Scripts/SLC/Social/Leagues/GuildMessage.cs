using UnityEngine;

namespace SLC.Social.Leagues
{
    public class GuildMessage
    {
        // Fields
        public string message;
        public System.DateTime sentAt;
        public SLC.Social.Profile sender;
        
        // Methods
        public GuildMessage(string message, System.DateTime sentAt)
        {
            null = null;
            this.sentAt = System.DateTime.MinValue;
            this.message = message;
            this.sentAt = sentAt;
        }
        public GuildMessage(string message, System.DateTime sentAt, SLC.Social.Profile sender)
        {
            null = null;
            this.sentAt = System.DateTime.MinValue;
            val_1 = new System.Object();
            this.message = message;
            this.sentAt = sentAt;
            this.sender = val_1;
        }
    
    }

}
