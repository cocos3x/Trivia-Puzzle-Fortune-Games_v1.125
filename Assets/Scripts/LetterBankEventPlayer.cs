using UnityEngine;
public class LetterBankEventPlayer
{
    // Fields
    public int guildMemberId;
    public string name;
    public int score;
    public int avatarId;
    public string facebookId;
    public bool useFacebook;
    public bool isMe;
    
    // Methods
    public SLC.Social.Profile ToProfile()
    {
        .ServerId = this.guildMemberId;
        .Name = this.name;
        if(this.isMe != false)
        {
                return SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        }
        
        .AvatarId = this.avatarId;
        .FacebookId = this.facebookId;
        .UseFacebook = this.useFacebook;
        return (SLC.Social.Profile)new SLC.Social.Profile();
    }
    public LetterBankEventPlayer()
    {
        this.guildMemberId = 0;
        this.avatarId = 0;
        this.name = "Default Dodo";
    }

}
