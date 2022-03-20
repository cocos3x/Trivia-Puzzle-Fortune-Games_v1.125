using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUI_MyClubDetails : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text leaguePointsText;
        private UnityEngine.UI.Text leaguePointsBonusText;
        private UnityEngine.UI.Text leaguePointsTotalText;
        private UnityEngine.UI.Text leaguePointsMultiplierText;
        private UnityEngine.UI.Text myRankText;
        private UnityEngine.UI.Text clubRankText;
        private SLC.Social.Leagues.LeaguesUIGuildTierDisplay tierDisplay;
        private UnityEngine.UI.Button increaseMultiplierButton;
        private UnityEngine.UI.Text mySeasonPoints;
        private UnityEngine.UI.Text seasonComparisonText;
        private UnityEngine.UI.Slider seasonComparisonSlider;
        private UnityEngine.GameObject clubRacer;
        private UnityEngine.RectTransform raceTrack;
        private UnityEngine.GameObject seasonRolloverInfo;
        private UnityEngine.RectTransform trackImage;
        private UnityEngine.RectTransform redZone;
        private UnityEngine.RectTransform greenZone;
        private float greenZoneFudge;
        private float redZoneFudge;
        private System.Collections.Generic.List<UnityEngine.GameObject> clubRacerList;
        private const int MAX_CLUBS = 15;
        
        // Methods
        private void Awake()
        {
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  2.ToString());
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  1.ToString());
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  7.ToString());
            this.increaseMultiplierButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUI_MyClubDetails::OnIncreaseMultiplierButtonClicked()));
        }
        private void OnEnable()
        {
            this.UpdateUI();
            this.CheckRaceTrackUpdate();
        }
        private void OnDestroy()
        {
            this.StopAllCoroutines();
        }
        public void OnMyGuildUpdate()
        {
            this.UpdateUI();
            this.CheckRaceTrackUpdate();
        }
        public void OnMyProfileUpdate()
        {
            this.UpdateUI();
            this.CheckRaceTrackUpdate();
        }
        public void OnGuildListUpdate()
        {
            this.CheckRaceTrackUpdate();
        }
        private void CheckRaceTrackUpdate()
        {
            SLC.Social.Leagues.LeaguesManager val_1 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
            if(val_1._IsInSeasonRollover != false)
            {
                    this.seasonRolloverInfo.SetActive(value:  true);
                this.raceTrack.gameObject.SetActive(value:  false);
                return;
            }
            
            this.seasonRolloverInfo.SetActive(value:  false);
            this.raceTrack.gameObject.SetActive(value:  true);
            UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.UpdateRaceTrack());
        }
        private System.Collections.IEnumerator UpdateRaceTrack()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new LeaguesUI_MyClubDetails.<UpdateRaceTrack>d__28();
        }
        private System.Collections.IEnumerator CreateClubRacerItems()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new LeaguesUI_MyClubDetails.<CreateClubRacerItems>d__29();
        }
        private System.Collections.IEnumerator SetupClubRacerItems()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new LeaguesUI_MyClubDetails.<SetupClubRacerItems>d__30();
        }
        private bool RacersOverlapping(float xPosA, float xPosB)
        {
            xPosA = xPosA ?? xPosB;
            return (bool)(xPosA < 0) ? 1 : 0;
        }
        private UnityEngine.Vector2 GetPosInTrack(decimal points)
        {
            UnityEngine.Rect val_1 = this.raceTrack.rect;
            float val_3 = val_1.m_XMin.CalculateRaceTrackBounds(points:  new System.Decimal() {flags = points.flags, hi = points.hi, lo = points.lo, mid = points.mid});
            val_3 = val_1.m_XMin.width * val_3;
            UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  val_3, y:  0f);
            return new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
        }
        private float CalculateRaceTrackBounds(decimal points)
        {
            var val_14;
            System.Collections.Generic.List<SLC.Social.Leagues.Guild> val_2 = SLC.Social.Leagues.LeaguesManager.DAO.GuildsInMyTier;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            decimal val_3 = SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + 32.LeaguePointsFinal;
            val_14 = null;
            val_14 = null;
            if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
            {
                    return 0f;
            }
            
            System.Collections.Generic.List<SLC.Social.Leagues.Guild> val_6 = SLC.Social.Leagues.LeaguesManager.DAO.GuildsInMyTier;
            System.Collections.Generic.List<SLC.Social.Leagues.Guild> val_8 = SLC.Social.Leagues.LeaguesManager.DAO.GuildsInMyTier;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            decimal val_10 = (SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + ((SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished - 1)) << 3) + 32.LeaguePointsFinal;
            return UnityEngine.Mathf.InverseLerp(a:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}), b:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}), value:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = points.flags, hi = points.hi, lo = points.lo, mid = points.mid}));
        }
        private void OnIncreaseMultiplierButtonClicked()
        {
            GameBehavior val_1 = App.getBehavior;
            goto mem[(1152921504946249728 + (public SLC.Social.Leagues.WGClubMultiplierPopup MetaGameBehavior::ShowUGUIMonolith<SLC.Social.Leagues.WGClubMultiplierPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
        }
        private void UpdateUI()
        {
            object val_80;
            var val_81;
            var val_82;
            object val_83;
            var val_84;
            System.Func<SLC.Social.Leagues.Guild, System.Int32> val_86;
            var val_87;
            float val_88;
            var val_89;
            var val_90;
            var val_91;
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
            {
                    return;
            }
            
            SLC.Social.Leagues.Guild val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            SLC.Social.Leagues.Guild val_6 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            decimal val_7 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_4.LeaguePoints, hi = val_4.LeaguePoints, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = val_6.LeaguePointsMultiplier, hi = val_6.LeaguePointsMultiplier, lo = X23, mid = X23});
            decimal val_8 = System.Decimal.Floor(d:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
            decimal val_9 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, d2:  new System.Decimal() {flags = val_4.LeaguePoints, hi = val_4.LeaguePoints, lo = X21, mid = X21});
            GameEcon val_10 = App.getGameEcon;
            string val_11 = val_4.LeaguePoints.ToString(format:  val_10.numberFormatInt);
            GameEcon val_12 = App.getGameEcon;
            string val_14 = System.String.Format(format:  "+{0}", arg0:  val_9.flags.ToString(format:  val_12.numberFormatInt));
            GameEcon val_15 = App.getGameEcon;
            string val_16 = val_8.flags.ToString(format:  val_15.numberFormatInt);
            string val_18 = System.String.Format(format:  "x {0}", arg0:  val_6.LeaguePointsMultiplier.ToString());
            SLC.Social.Leagues.Guild val_20 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            this.tierDisplay.UpdateTierUI(guildTier:  val_20.tier);
            SLC.Social.Leagues.Guild val_22 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            GameEcon val_23 = App.getGameEcon;
            string val_27 = System.String.Format(format:  "{0} - {1}<size=45>{2}</size>", arg0:  Localization.Localize(key:  "club_rank_upper", defaultValue:  "CLUB RANK", useSingularKey:  false), arg1:  val_22.rank.ToString(format:  val_23.numberFormatInt), arg2:  Ordinal.AddOrdinal(num:  val_22.rank));
            SLC.Social.Leagues.LeaguesDataController val_30 = SLC.Social.Leagues.LeaguesManager.DAO;
            int val_31 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.GetRankInGuildById(id:  val_30.MyId);
            GameEcon val_32 = App.getGameEcon;
            string val_36 = System.String.Format(format:  "<size=28>{0}{1}</size>\n{2}", arg0:  val_31.ToString(format:  val_32.numberFormatInt), arg1:  Ordinal.AddOrdinal(num:  val_31), arg2:  Localization.Localize(key:  "position_in_club", defaultValue:  "IN CLUB", useSingularKey:  false));
            SLC.Social.Profile val_39 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            GameEcon val_40 = App.getGameEcon;
            val_80 = val_39.leaguePoints.ToString(format:  val_40.numberFormatInt);
            val_81 = null;
            val_81 = null;
            if(App.game == 17)
            {
                    SLC.Social.Profile val_43 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
                val_82 = null;
                val_82 = null;
                if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_43.leaguePoints, hi = val_43.leaguePoints, lo = 41963520}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
            {
                    if((MonoSingleton<WGSubscriptionManager>.Instance.hasSubscription(subPackage:  0)) != true)
            {
                    if((MonoSingleton<WGSubscriptionManager>.Instance.hasSubscription(subPackage:  1)) == false)
            {
                goto label_55;
            }
            
            }
            
                val_80 = System.String.Format(format:  "{0} x{1}", arg0:  val_80, arg1:  MonoSingleton<WGSubscriptionManager>.Instance.pointMultiplier);
            }
            
            }
            
            label_55:
            val_83 = "</color>";
            string val_52 = System.String.Format(format:  Localization.Localize(key:  "my_season_league_pts_format", defaultValue:  "{0}{1}{2}", useSingularKey:  false), arg0:  "<color=#FFFFFFFF>", arg1:  val_80, arg2:  val_83);
            val_84 = null;
            val_84 = null;
            val_86 = LeaguesUI_MyClubDetails.<>c.<>9__35_0;
            if(val_86 == null)
            {
                    System.Func<SLC.Social.Leagues.Guild, System.Int32> val_57 = null;
                val_86 = val_57;
                val_83 = public System.Void System.Func<SLC.Social.Leagues.Guild, System.Int32>::.ctor(object object, IntPtr method);
                val_57 = new System.Func<SLC.Social.Leagues.Guild, System.Int32>(object:  LeaguesUI_MyClubDetails.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 LeaguesUI_MyClubDetails.<>c::<UpdateUI>b__35_0(SLC.Social.Leagues.Guild g));
                LeaguesUI_MyClubDetails.<>c.<>9__35_0 = val_86;
            }
            
            System.Linq.IOrderedEnumerable<TSource> val_58 = System.Linq.Enumerable.OrderBy<SLC.Social.Leagues.Guild, System.Int32>(source:  Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<SLC.Social.Leagues.Guild>>(value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  SLC.Social.Leagues.LeaguesManager.DAO.GuildsInMyTier)), keySelector:  val_57);
            SLC.Social.Leagues.Guild val_60 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            decimal val_61 = SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + 40.LeaguePointsFinal;
            val_86 = val_61.flags;
            val_87 = null;
            val_87 = null;
            if((val_60.tier != 1) && ((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_86, hi = val_61.hi, lo = val_61.lo, mid = val_61.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != true))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                decimal val_63 = System.Decimal.MinusOne.LeaguePointsFinal;
                val_86 = this.greenZone;
                val_88 = val_63.flags.CalculateRaceTrackBounds(points:  new System.Decimal() {flags = val_63.flags, hi = val_63.hi, lo = val_63.lo, mid = val_63.mid});
                UnityEngine.Vector2 val_65 = this.raceTrack.sizeDelta;
                UnityEngine.Vector2 val_66 = this.greenZone.sizeDelta;
                float val_80 = 1f;
                val_80 = val_80 - val_88;
                val_80 = val_80 * val_65.x;
                val_80 = val_80 - this.greenZoneFudge;
                UnityEngine.Vector2 val_67 = new UnityEngine.Vector2(x:  val_80, y:  val_66.y);
                val_86.sizeDelta = new UnityEngine.Vector2() {x = val_67.x, y = val_67.y};
                UnityEngine.GameObject val_68 = this.greenZone.gameObject;
                val_89 = 1;
            }
            else
            {
                    val_89 = 0;
            }
            
            this.greenZone.gameObject.SetActive(value:  false);
            decimal val_70 = SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + 120.LeaguePointsFinal;
            val_86 = val_70.flags;
            val_90 = null;
            val_90 = null;
            if((val_60.tier != 15) && ((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_86, hi = val_70.hi, lo = val_70.lo, mid = val_70.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != true))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                decimal val_72 = System.Decimal.Powers10.__il2cppRuntimeField_78.LeaguePointsFinal;
                val_88 = val_72.flags.CalculateRaceTrackBounds(points:  new System.Decimal() {flags = val_72.flags, hi = val_72.hi, lo = val_72.lo, mid = val_72.mid});
                UnityEngine.Vector2 val_74 = this.raceTrack.sizeDelta;
                UnityEngine.Vector2 val_75 = this.redZone.sizeDelta;
                float val_76 = val_88 * val_74.x;
                val_76 = val_76 - this.redZoneFudge;
                UnityEngine.Vector2 val_77 = new UnityEngine.Vector2(x:  val_76, y:  val_75.y);
                this.redZone.sizeDelta = new UnityEngine.Vector2() {x = val_77.x, y = val_77.y};
                UnityEngine.GameObject val_78 = this.redZone.gameObject;
                val_91 = 1;
            }
            else
            {
                    val_91 = 0;
            }
            
            this.redZone.gameObject.SetActive(value:  false);
        }
        public LeaguesUI_MyClubDetails()
        {
            this.greenZoneFudge = 5f;
            this.redZoneFudge = -5f;
            this.clubRacerList = new System.Collections.Generic.List<UnityEngine.GameObject>();
        }
    
    }

}
