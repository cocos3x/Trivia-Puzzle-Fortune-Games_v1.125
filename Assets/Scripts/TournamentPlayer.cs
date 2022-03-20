using UnityEngine;
public class TournamentPlayer
{
    // Fields
    public string name;
    public int score;
    public int avatarId;
    public string portrait_ID;
    public string facebookId;
    public bool useFacebook;
    public bool isMe;
    
    // Methods
    public SLC.Social.Profile ToProfile()
    {
        .Name = this.name;
        if(this.isMe != false)
        {
                return SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        }
        
        .AvatarId = this.avatarId;
        .Portrait_ID = this.portrait_ID;
        .FacebookId = this.facebookId;
        .UseFacebook = this.useFacebook;
        return (SLC.Social.Profile)new SLC.Social.Profile();
    }
    public TournamentPlayer()
    {
        this.avatarId = 0;
        this.name = "Default Dodo";
        this.portrait_ID = "";
    }

}
