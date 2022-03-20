using UnityEngine;
public class EventPrefabsConfig : MonoBehaviour
{
    // Fields
    protected WGEventButtonV2 evtBtnAttackMadness;
    protected WGEventButtonProgress evtProgressAttackMadness;
    protected WGEventButtonV2 evtBtnRaidMadness;
    protected WGEventButtonProgress evtProgressRaidMadness;
    protected WGEventButtonV2 evtBtnForestMaster;
    protected WGEventButtonProgress evtProgressForestMaster;
    protected WGEventButtonV2 evtBtnLightningLevels;
    protected WGEventButtonProgress evtProgressLightningLevels;
    protected WGEventButtonV2 evtBtnIslandParadise;
    protected WGEventButtonProgress evtProgressIslandParadise;
    protected WGEventButtonV2 evtBtnWordHunt;
    protected WGEventButtonProgress evtProgressWordHunt;
    protected UnityEngine.Sprite evtIconWordHunt;
    protected WGEventButtonV2 evtBtnWildWordWeekend;
    protected WGEventButtonProgress evtProgressWildWordWeekend;
    protected WGEventButtonV2 evtBtnLevelChallenge;
    protected WGEventButtonProgress evtProgressLevelChallenge;
    protected WGEventButtonV2 evtBtnExtraChapter;
    protected WGEventButtonProgress evtProgressExtraChapter;
    protected WGEventButtonV2 evtBtnPuzzleCollection;
    protected WGEventButtonProgress evtProgressPuzzleCollection;
    protected WGEventButtonV2 evtBtnCrownClashClubVClub;
    protected WGEventButtonProgress evtProgressCrownClashClubVClub;
    protected WGEventButtonV2 evtBtnApplePicking;
    protected WGEventButtonProgress evtProgressApplePicking;
    protected WGEventButtonV2 evtBtnPiggyBank;
    protected WGEventButtonProgress evtProgressPiggyBank;
    protected WGEventButtonV2 evtBtnPiggyBankV2;
    protected WGEventButtonProgress evtProgressPiggyBankV2;
    protected WGEventButtonV2 evtBtnLeaderboard;
    protected WGEventButtonProgress evtProgressLeaderboard;
    protected WGEventButtonV2 evtBtnLightningWords;
    protected WGEventButtonProgress evtProgressLightningWords;
    protected WGEventButtonV2 evtBtnSuperStreak;
    protected WGEventButtonProgress evtProgressSuperStreak;
    protected WGEventButtonV2 evtBtnHotStreak;
    protected WGEventButtonProgress evtProgressHotStreak;
    protected WGEventButtonV2 evtBtnVipParty;
    protected WGEventButtonProgress evtProgressVipParty;
    protected WGEventButtonV2 evtBtnGoldenGala;
    protected WGEventButtonProgress evtProgressGoldenGala;
    protected WGEventButtonV2 evtBtnHintMania;
    protected WGEventButtonProgress evtProgressHintMania;
    protected WGEventButtonV2 evtBtnOnTheTrail;
    protected WGEventButtonProgress evtProgressOnTheTrail;
    protected WGEventButtonV2 evtBtnKeyToRiches;
    protected WGEventButtonProgress evtProgressKeyToRiches;
    protected WGEventButtonV2 evtBtnBingo;
    protected WGEventButtonProgress evtProgressBingo;
    protected WGEventButtonV2 evtBtnBuyAVowel;
    protected WGEventButtonProgress evtProgressBuyAVowel;
    protected WGEventButtonV2 evtBtnSuperBundle;
    protected WGEventButtonProgress evtProgressSuperBundle;
    protected WGEventButtonV2 evtBtnPiggyBankRaid;
    protected WGEventButtonProgress evtProgressPiggyBankRaid;
    protected WGEventButtonV2 evtBtnSeasonPass;
    protected WGEventButtonProgress evtProgressSeasonPass;
    protected WGEventButtonV2 evtBtnSnakesLadders;
    protected WGEventButtonProgress evtProgressSnakesLadders;
    protected WGEventButtonV2 evtBtnSpinKing;
    protected WGEventButtonProgress evtProgressSpinKing;
    protected WGEventButtonV2 evtBtnLetterBank;
    protected WGEventButtonProgress evtProgressLetterBank;
    protected WGEventButtonV2 evtBtnForestFrenzy;
    protected WGEventButtonProgress evtProgressForestFrenzy;
    protected WGEventButtonV2 evtBtnProgressiveIAP;
    protected WGEventButtonProgress evtProgressProgressiveIAP;
    
    // Properties
    public UnityEngine.Sprite EventIconWordHunt { get; }
    
    // Methods
    public UnityEngine.Sprite get_EventIconWordHunt()
    {
        return (UnityEngine.Sprite)this.evtIconWordHunt;
    }
    public WGEventButtonV2 GetEventButtonPrefab(string eventId)
    {
        string val_34;
        WGEventButtonV2 val_35;
        UnityEngine.Debug.LogWarning(message:  "EVENT ID: "("EVENT ID: ") + eventId);
        uint val_2 = _PrivateImplementationDetails_.ComputeStringHash(s:  eventId);
        if(val_2 > 1592546639)
        {
            goto label_3;
        }
        
        if(val_2 > 701935430)
        {
            goto label_4;
        }
        
        if(val_2 > 264778422)
        {
            goto label_5;
        }
        
        if(val_2 > 145907821)
        {
            goto label_6;
        }
        
        if(val_2 == 54006602)
        {
            goto label_7;
        }
        
        if(val_2 != 145907821)
        {
            goto label_78;
        }
        
        val_34 = "IslandParadiseSymbol";
        goto label_9;
        label_3:
        if(val_2 > (-1129030916))
        {
            goto label_10;
        }
        
        if(val_2 > (-1630781543))
        {
            goto label_11;
        }
        
        if(val_2 > (-1957254795))
        {
            goto label_12;
        }
        
        if(val_2 == (-1957254795))
        {
            goto label_13;
        }
        
        if(val_2 != 1751534916)
        {
            goto label_78;
        }
        
        val_34 = "HotNSpicy";
        label_9:
        val_35 = 0;
        if((System.String.op_Equality(a:  eventId, b:  val_34)) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        val_35 = this.evtBtnIslandParadise;
        return (WGEventButtonV2)val_35;
        label_4:
        if(val_2 > 1188660454)
        {
            goto label_17;
        }
        
        if(val_2 > 999457290)
        {
            goto label_18;
        }
        
        if(val_2 == 958660756)
        {
            goto label_19;
        }
        
        if(val_2 != 999457290)
        {
            goto label_78;
        }
        
        val_35 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "AttackMadness")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        val_35 = this.evtBtnAttackMadness;
        return (WGEventButtonV2)val_35;
        label_10:
        if(val_2 > (-1019895860))
        {
            goto label_23;
        }
        
        if(val_2 > (-1050565114))
        {
            goto label_24;
        }
        
        if(val_2 == (-1101875113))
        {
            goto label_25;
        }
        
        if(val_2 != (-1050565114))
        {
            goto label_78;
        }
        
        val_35 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "ForestMaster")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        val_35 = this.evtBtnForestMaster;
        return (WGEventButtonV2)val_35;
        label_5:
        if(val_2 > 655166938)
        {
            goto label_29;
        }
        
        if(val_2 == 386644468)
        {
            goto label_30;
        }
        
        if(val_2 != 655166938)
        {
            goto label_78;
        }
        
        val_35 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "SpinKing")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        val_35 = this.evtBtnSpinKing;
        return (WGEventButtonV2)val_35;
        label_11:
        if(val_2 > (-1449662652))
        {
            goto label_34;
        }
        
        if(val_2 == (-1531801635))
        {
            goto label_35;
        }
        
        if(val_2 != (-1449662652))
        {
            goto label_78;
        }
        
        val_35 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "SuperBundle")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        val_35 = this.evtBtnSuperBundle;
        return (WGEventButtonV2)val_35;
        label_17:
        if(val_2 > 1399814793)
        {
            goto label_39;
        }
        
        if(val_2 == 1314484049)
        {
            goto label_40;
        }
        
        if(val_2 != 1399814793)
        {
            goto label_78;
        }
        
        val_35 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "PiggyBank")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        val_35 = this.evtBtnPiggyBank;
        return (WGEventButtonV2)val_35;
        label_23:
        if(val_2 > (-623396922))
        {
            goto label_44;
        }
        
        if(val_2 == (-763592254))
        {
            goto label_45;
        }
        
        if(val_2 != (-623396922))
        {
            goto label_78;
        }
        
        val_35 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "RaidMadness")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        val_35 = this.evtBtnRaidMadness;
        return (WGEventButtonV2)val_35;
        label_6:
        if(val_2 == 231953039)
        {
            goto label_49;
        }
        
        if(val_2 != 264778422)
        {
            goto label_78;
        }
        
        val_35 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "ExtraChapterRewards")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        val_35 = this.evtBtnExtraChapter;
        return (WGEventButtonV2)val_35;
        label_12:
        if(val_2 == (-1694107091))
        {
            goto label_53;
        }
        
        if(val_2 != (-1630781543))
        {
            goto label_78;
        }
        
        val_35 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "PuzzleCollection")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        val_35 = this.evtBtnPuzzleCollection;
        return (WGEventButtonV2)val_35;
        label_18:
        if(val_2 == 1054264077)
        {
            goto label_57;
        }
        
        if(val_2 != 1188660454)
        {
            goto label_78;
        }
        
        val_35 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "HotStreak")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        val_35 = this.evtBtnHotStreak;
        return (WGEventButtonV2)val_35;
        label_24:
        if(val_2 == (-1043654426))
        {
            goto label_61;
        }
        
        if(val_2 != (-1019895860))
        {
            goto label_78;
        }
        
        val_35 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "Leaderboard")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        val_35 = this.evtBtnLeaderboard;
        return (WGEventButtonV2)val_35;
        label_29:
        if(val_2 == 697097638)
        {
            goto label_65;
        }
        
        if(val_2 != 701935430)
        {
            goto label_78;
        }
        
        val_35 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "LevelChallenge")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        val_35 = this.evtBtnLevelChallenge;
        return (WGEventButtonV2)val_35;
        label_34:
        if(val_2 == (-1392364358))
        {
            goto label_69;
        }
        
        if(val_2 != (-1129030916))
        {
            goto label_78;
        }
        
        val_35 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "WordHunt")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        val_35 = this.evtBtnWordHunt;
        return (WGEventButtonV2)val_35;
        label_39:
        if(val_2 == 1537055809)
        {
            goto label_73;
        }
        
        if(val_2 != 1592546639)
        {
            goto label_78;
        }
        
        val_35 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "BuyAVowel")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        val_35 = this.evtBtnBuyAVowel;
        return (WGEventButtonV2)val_35;
        label_44:
        if(val_2 == (-530341297))
        {
            goto label_77;
        }
        
        if(val_2 == (-84738646))
        {
                val_35 = 0;
            if((System.String.op_Equality(a:  eventId, b:  "LightningLevels")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
            val_35 = this.evtBtnLightningLevels;
            return (WGEventButtonV2)val_35;
        }
        
        label_78:
        val_35 = 0;
        return (WGEventButtonV2)val_35;
        label_7:
        if((System.String.op_Equality(a:  eventId, b:  "LightningWords")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        return (WGEventButtonV2)val_35;
        label_13:
        if((System.String.op_Equality(a:  eventId, b:  "CrownClashPvP")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        return (WGEventButtonV2)val_35;
        label_19:
        if((System.String.op_Equality(a:  eventId, b:  "VipParty")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        return (WGEventButtonV2)val_35;
        label_25:
        if((System.String.op_Equality(a:  eventId, b:  "GoldenGala")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        return (WGEventButtonV2)val_35;
        label_30:
        if((System.String.op_Equality(a:  eventId, b:  "WordBingo")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        return (WGEventButtonV2)val_35;
        label_35:
        if((System.String.op_Equality(a:  eventId, b:  "PiggyBankRaid")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        return (WGEventButtonV2)val_35;
        label_40:
        if((System.String.op_Equality(a:  eventId, b:  "SeasonPass")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        return (WGEventButtonV2)val_35;
        label_45:
        if((System.String.op_Equality(a:  eventId, b:  "SnakesAndLadders")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        return (WGEventButtonV2)val_35;
        label_49:
        if((System.String.op_Equality(a:  eventId, b:  "LetterBank")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        return (WGEventButtonV2)val_35;
        label_53:
        if((System.String.op_Equality(a:  eventId, b:  "PiggyBankV2")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        return (WGEventButtonV2)val_35;
        label_57:
        if((System.String.op_Equality(a:  eventId, b:  "ProgressiveIapSale")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        return (WGEventButtonV2)val_35;
        label_61:
        if((System.String.op_Equality(a:  eventId, b:  "SuperStreak")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        return (WGEventButtonV2)val_35;
        label_65:
        if((System.String.op_Equality(a:  eventId, b:  "ForestFrenzy")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        return (WGEventButtonV2)val_35;
        label_69:
        if((System.String.op_Equality(a:  eventId, b:  "WildWordWeekend")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        return (WGEventButtonV2)val_35;
        label_73:
        if((System.String.op_Equality(a:  eventId, b:  "OnTheTrail")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        return (WGEventButtonV2)val_35;
        label_77:
        if((System.String.op_Equality(a:  eventId, b:  "KeyToRiches")) == false)
        {
                return (WGEventButtonV2)val_35;
        }
        
        return (WGEventButtonV2)val_35;
    }
    public WGEventButtonProgress GetEventProgressPrefab(string eventId)
    {
        string val_33;
        WGEventButtonProgress val_34;
        uint val_1 = _PrivateImplementationDetails_.ComputeStringHash(s:  eventId);
        if(val_1 > 1592546639)
        {
            goto label_1;
        }
        
        if(val_1 > 701935430)
        {
            goto label_2;
        }
        
        if(val_1 > 264778422)
        {
            goto label_3;
        }
        
        if(val_1 > 145907821)
        {
            goto label_4;
        }
        
        if(val_1 == 54006602)
        {
            goto label_5;
        }
        
        if(val_1 != 145907821)
        {
            goto label_76;
        }
        
        val_33 = "IslandParadiseSymbol";
        goto label_7;
        label_1:
        if(val_1 > (-1129030916))
        {
            goto label_8;
        }
        
        if(val_1 > (-1630781543))
        {
            goto label_9;
        }
        
        if(val_1 > (-1957254795))
        {
            goto label_10;
        }
        
        if(val_1 == (-1957254795))
        {
            goto label_11;
        }
        
        if(val_1 != 1751534916)
        {
            goto label_76;
        }
        
        val_33 = "HotNSpicy";
        label_7:
        val_34 = 0;
        if((System.String.op_Equality(a:  eventId, b:  val_33)) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        val_34 = this.evtProgressIslandParadise;
        return (WGEventButtonProgress)val_34;
        label_2:
        if(val_1 > 1188660454)
        {
            goto label_15;
        }
        
        if(val_1 > 999457290)
        {
            goto label_16;
        }
        
        if(val_1 == 958660756)
        {
            goto label_17;
        }
        
        if(val_1 != 999457290)
        {
            goto label_76;
        }
        
        val_34 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "AttackMadness")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        val_34 = this.evtProgressAttackMadness;
        return (WGEventButtonProgress)val_34;
        label_8:
        if(val_1 > (-1019895860))
        {
            goto label_21;
        }
        
        if(val_1 > (-1050565114))
        {
            goto label_22;
        }
        
        if(val_1 == (-1101875113))
        {
            goto label_23;
        }
        
        if(val_1 != (-1050565114))
        {
            goto label_76;
        }
        
        val_34 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "ForestMaster")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        val_34 = this.evtProgressForestMaster;
        return (WGEventButtonProgress)val_34;
        label_3:
        if(val_1 > 655166938)
        {
            goto label_27;
        }
        
        if(val_1 == 386644468)
        {
            goto label_28;
        }
        
        if(val_1 != 655166938)
        {
            goto label_76;
        }
        
        val_34 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "SpinKing")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        val_34 = this.evtProgressSpinKing;
        return (WGEventButtonProgress)val_34;
        label_9:
        if(val_1 > (-1449662652))
        {
            goto label_32;
        }
        
        if(val_1 == (-1531801635))
        {
            goto label_33;
        }
        
        if(val_1 != (-1449662652))
        {
            goto label_76;
        }
        
        val_34 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "SuperBundle")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        val_34 = this.evtProgressSuperBundle;
        return (WGEventButtonProgress)val_34;
        label_15:
        if(val_1 > 1399814793)
        {
            goto label_37;
        }
        
        if(val_1 == 1314484049)
        {
            goto label_38;
        }
        
        if(val_1 != 1399814793)
        {
            goto label_76;
        }
        
        val_34 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "PiggyBank")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        val_34 = this.evtProgressPiggyBank;
        return (WGEventButtonProgress)val_34;
        label_21:
        if(val_1 > (-623396922))
        {
            goto label_42;
        }
        
        if(val_1 == (-763592254))
        {
            goto label_43;
        }
        
        if(val_1 != (-623396922))
        {
            goto label_76;
        }
        
        val_34 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "RaidMadness")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        val_34 = this.evtProgressRaidMadness;
        return (WGEventButtonProgress)val_34;
        label_4:
        if(val_1 == 231953039)
        {
            goto label_47;
        }
        
        if(val_1 != 264778422)
        {
            goto label_76;
        }
        
        val_34 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "ExtraChapterRewards")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        val_34 = this.evtProgressExtraChapter;
        return (WGEventButtonProgress)val_34;
        label_10:
        if(val_1 == (-1694107091))
        {
            goto label_51;
        }
        
        if(val_1 != (-1630781543))
        {
            goto label_76;
        }
        
        val_34 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "PuzzleCollection")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        val_34 = this.evtProgressPuzzleCollection;
        return (WGEventButtonProgress)val_34;
        label_16:
        if(val_1 == 1054264077)
        {
            goto label_55;
        }
        
        if(val_1 != 1188660454)
        {
            goto label_76;
        }
        
        val_34 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "HotStreak")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        val_34 = this.evtProgressHotStreak;
        return (WGEventButtonProgress)val_34;
        label_22:
        if(val_1 == (-1043654426))
        {
            goto label_59;
        }
        
        if(val_1 != (-1019895860))
        {
            goto label_76;
        }
        
        val_34 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "Leaderboard")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        val_34 = this.evtProgressLeaderboard;
        return (WGEventButtonProgress)val_34;
        label_27:
        if(val_1 == 697097638)
        {
            goto label_63;
        }
        
        if(val_1 != 701935430)
        {
            goto label_76;
        }
        
        val_34 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "LevelChallenge")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        val_34 = this.evtProgressLevelChallenge;
        return (WGEventButtonProgress)val_34;
        label_32:
        if(val_1 == (-1392364358))
        {
            goto label_67;
        }
        
        if(val_1 != (-1129030916))
        {
            goto label_76;
        }
        
        val_34 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "WordHunt")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        val_34 = this.evtProgressWordHunt;
        return (WGEventButtonProgress)val_34;
        label_37:
        if(val_1 == 1537055809)
        {
            goto label_71;
        }
        
        if(val_1 != 1592546639)
        {
            goto label_76;
        }
        
        val_34 = 0;
        if((System.String.op_Equality(a:  eventId, b:  "BuyAVowel")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        val_34 = this.evtProgressBuyAVowel;
        return (WGEventButtonProgress)val_34;
        label_42:
        if(val_1 == (-530341297))
        {
            goto label_75;
        }
        
        if(val_1 == (-84738646))
        {
                val_34 = 0;
            if((System.String.op_Equality(a:  eventId, b:  "LightningLevels")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
            val_34 = this.evtProgressLightningLevels;
            return (WGEventButtonProgress)val_34;
        }
        
        label_76:
        val_34 = 0;
        return (WGEventButtonProgress)val_34;
        label_5:
        if((System.String.op_Equality(a:  eventId, b:  "LightningWords")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        return (WGEventButtonProgress)val_34;
        label_11:
        if((System.String.op_Equality(a:  eventId, b:  "CrownClashPvP")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        return (WGEventButtonProgress)val_34;
        label_17:
        if((System.String.op_Equality(a:  eventId, b:  "VipParty")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        return (WGEventButtonProgress)val_34;
        label_23:
        if((System.String.op_Equality(a:  eventId, b:  "GoldenGala")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        return (WGEventButtonProgress)val_34;
        label_28:
        if((System.String.op_Equality(a:  eventId, b:  "WordBingo")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        return (WGEventButtonProgress)val_34;
        label_33:
        if((System.String.op_Equality(a:  eventId, b:  "PiggyBankRaid")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        return (WGEventButtonProgress)val_34;
        label_38:
        if((System.String.op_Equality(a:  eventId, b:  "SeasonPass")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        return (WGEventButtonProgress)val_34;
        label_43:
        if((System.String.op_Equality(a:  eventId, b:  "SnakesAndLadders")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        return (WGEventButtonProgress)val_34;
        label_47:
        if((System.String.op_Equality(a:  eventId, b:  "LetterBank")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        return (WGEventButtonProgress)val_34;
        label_51:
        if((System.String.op_Equality(a:  eventId, b:  "PiggyBankV2")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        return (WGEventButtonProgress)val_34;
        label_55:
        if((System.String.op_Equality(a:  eventId, b:  "ProgressiveIapSale")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        return (WGEventButtonProgress)val_34;
        label_59:
        if((System.String.op_Equality(a:  eventId, b:  "SuperStreak")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        return (WGEventButtonProgress)val_34;
        label_63:
        if((System.String.op_Equality(a:  eventId, b:  "ForestFrenzy")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        return (WGEventButtonProgress)val_34;
        label_67:
        if((System.String.op_Equality(a:  eventId, b:  "WildWordWeekend")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        return (WGEventButtonProgress)val_34;
        label_71:
        if((System.String.op_Equality(a:  eventId, b:  "OnTheTrail")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        return (WGEventButtonProgress)val_34;
        label_75:
        if((System.String.op_Equality(a:  eventId, b:  "KeyToRiches")) == false)
        {
                return (WGEventButtonProgress)val_34;
        }
        
        return (WGEventButtonProgress)val_34;
    }
    public EventPrefabsConfig()
    {
    
    }

}
