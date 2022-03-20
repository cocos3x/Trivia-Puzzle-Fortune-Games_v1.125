using UnityEngine;
public sealed class HelpshiftUser.Builder
{
    // Fields
    private string identifier;
    private string email;
    private string name;
    private string authToken;
    
    // Methods
    public HelpshiftUser.Builder(string identifier, string email)
    {
        val_1 = new System.Object();
        this.identifier = identifier;
        this.email = val_1;
    }
    public Helpshift.HelpshiftUser.Builder setName(string name)
    {
        this.name = name;
        return (HelpshiftUser.Builder)this;
    }
    public Helpshift.HelpshiftUser.Builder setAuthToken(string authToken)
    {
        this.authToken = authToken;
        return (HelpshiftUser.Builder)this;
    }
    public Helpshift.HelpshiftUser build()
    {
        .name = this.name;
        .authToken = this.authToken;
        .identifier = this.identifier;
        return (Helpshift.HelpshiftUser)new Helpshift.HelpshiftUser();
    }

}
