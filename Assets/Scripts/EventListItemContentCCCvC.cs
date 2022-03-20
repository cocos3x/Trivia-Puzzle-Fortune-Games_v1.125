using UnityEngine;
public class EventListItemContentCCCvC : EventListItemContentProgressbar
{
    // Fields
    private UnityEngine.UI.Text rightCrownText;
    private UnityEngine.UI.Image playerClubImage;
    private UnityEngine.UI.Image aiAvatarImage;
    private UnityEngine.UI.Image playerCrown;
    private UnityEngine.UI.Image aiCrown;
    public SLC.Social.AvatarConfig playerAvatarHandler;
    
    // Methods
    public override void SetupSlider(string sliderText, float sliderValue)
    {
        UnityEngine.Sprite val_36;
        SLC.Social.AvatarConfig val_37;
        SLC.Social.AvatarConfig val_38;
        this.SetupSlider(sliderText:  sliderText, sliderValue:  sliderValue);
        if(((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 88) & 2147483648) != 0)
        {
                ClubClashEvent.LAST_PROGRESS_STAMP_KEY.__unknownFiledOffset_58 = UnityEngine.Random.Range(min:  0, max:  this.playerAvatarHandler.AvatarSpritesCount);
            ClubClashEvent.LAST_PROGRESS_STAMP_KEY.__unknownFiledOffset_5C = UnityEngine.Random.Range(min:  0, max:  this.playerAvatarHandler.AvatarSpritesCount);
        }
        
        if(SLC.Social.Leagues.LeaguesManager.IsAvailableAndInGuild() == false)
        {
            goto label_10;
        }
        
        int val_7 = 0;
        if((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56) == 0)
        {
            goto label_13;
        }
        
        if((System.Int32.TryParse(s:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56.Item["crowns"], result: out  val_7)) != true)
        {
                UnityEngine.Debug.LogWarning(message:  "unable to parse opposing club crowns");
        }
        
        object val_9 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56.Item["avatar"];
        val_36 = this.playerAvatarHandler.GetAvatarSpriteByID(id:  19914752, portraitID:  0);
        goto label_22;
        label_10:
        this.playerCrown.gameObject.SetActive(value:  false);
        this.aiCrown.gameObject.SetActive(value:  false);
        UnityEngine.GameObject val_13 = this.rightCrownText.gameObject;
        val_13.SetActive(value:  false);
        val_13.gameObject.SetActive(value:  false);
        val_37 = this.playerAvatarHandler;
        this.playerClubImage.sprite = val_37.GetAvatarSpriteByID(id:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 88, portraitID:  0);
        val_38 = this.playerAvatarHandler;
        this.aiAvatarImage.sprite = val_38.GetAvatarSpriteByID(id:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 92, portraitID:  0);
        return;
        label_13:
        val_36 = this.playerAvatarHandler.GetAvatarSpriteByID(id:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 92, portraitID:  0);
        label_22:
        this.aiAvatarImage.sprite = val_36;
        if((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 44) < 1000)
        {
                string val_18 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 44.ToString();
        }
        else
        {
                decimal val_19 = System.Decimal.op_Implicit(value:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 44);
            decimal val_20 = new System.Decimal(value:  232);
            string val_21 = MetricSystem.Abbreviate(number:  new System.Decimal() {flags = val_19.flags, hi = val_19.hi, lo = val_19.lo, mid = val_19.mid}, maxSigFigs:  3, round:  true, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_20.flags, hi = val_20.flags, lo = val_20.lo, mid = val_20.lo}, useRichText:  false, withSpaces:  false);
        }
        
        int val_23 = 0;
        bool val_24 = System.Int32.TryParse(s:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56.Item["crowns"], result: out  val_23);
        if(val_23 < 1000)
        {
                string val_25 = val_23.ToString();
        }
        else
        {
                decimal val_26 = System.Decimal.op_Implicit(value:  0);
            decimal val_27 = new System.Decimal(value:  232);
            string val_28 = MetricSystem.Abbreviate(number:  new System.Decimal() {flags = val_26.flags, hi = val_26.hi, lo = val_26.lo, mid = val_26.mid}, maxSigFigs:  3, round:  true, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_27.flags, hi = val_27.flags, lo = val_27.lo, mid = val_27.lo}, useRichText:  false, withSpaces:  false);
        }
        
        val_37 = this.playerAvatarHandler;
        SLC.Social.Leagues.Guild val_30 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
        this.playerClubImage.sprite = val_37.GetAvatarSpriteByID(id:  val_30.AvatarId, portraitID:  0);
        this.playerCrown.gameObject.SetActive(value:  ((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 44) >= val_7) ? 1 : 0);
        val_38 = this.aiCrown.gameObject;
        val_38.SetActive(value:  ((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 44) < val_7) ? 1 : 0);
    }
    public EventListItemContentCCCvC()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
