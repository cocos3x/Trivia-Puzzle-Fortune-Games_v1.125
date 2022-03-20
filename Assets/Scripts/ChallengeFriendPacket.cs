using UnityEngine;
public class ChallengeFriendController.ChallengeFriendPacket
{
    // Fields
    public string category;
    public string subcategory;
    public System.TimeSpan timespan;
    public int difficultyLevel;
    public System.Collections.Generic.List<string> questionIDs;
    public string challengerSupportId;
    
    // Methods
    public string Serialize()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(value:  this);
    }
    public ChallengeFriendController.ChallengeFriendPacket()
    {
        this.questionIDs = new System.Collections.Generic.List<System.String>();
    }
    public ChallengeFriendController.ChallengeFriendPacket(string serialized)
    {
        this.questionIDs = new System.Collections.Generic.List<System.String>();
        ChallengeFriendPacket val_2 = Newtonsoft.Json.JsonConvert.DeserializeObject<ChallengeFriendPacket>(value:  serialized);
        this.category = val_2.category;
        this.subcategory = val_2.subcategory;
        this.timespan = val_2.timespan;
        this.difficultyLevel = val_2.difficultyLevel;
        this.questionIDs = new System.Collections.Generic.List<System.String>(collection:  val_2.questionIDs);
        this.challengerSupportId = val_2.challengerSupportId;
    }

}
