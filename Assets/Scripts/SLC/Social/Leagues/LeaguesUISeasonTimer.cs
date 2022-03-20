using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUISeasonTimer : FrameSkipper
    {
        // Fields
        private const string timeFormat_dhms = "{0:00}:{1:00}:{2:00}:{3:00}";
        private const string timeFormat_dhm = "{0:00}:{1:00}:{2:00}";
        private UnityEngine.UI.Text timerText;
        private bool showSeconds;
        
        // Methods
        protected override void UpdateLogic()
        {
            System.Object[] val_11;
            var val_12;
            System.TimeSpan val_1 = SLC.Social.Leagues.LeaguesManager.GetSeasonTimeRemaining();
            val_11 = 1152921504622821376;
            val_12 = null;
            val_12 = null;
            if((System.TimeSpan.op_GreaterThan(t1:  new System.TimeSpan() {_ticks = val_1._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) != false)
            {
                    object[] val_4 = new object[4];
                val_11 = val_4;
                val_11[0] = val_1._ticks.Days;
                val_11[1] = val_1._ticks.Hours;
                val_11[2] = val_1._ticks.Minutes;
                val_11[3] = val_1._ticks.Seconds;
                string val_9 = System.String.Format(format:  (this.showSeconds == false) ? "{0:00}:{1:00}:{2:00}" : "{0:00}:{1:00}:{2:00}:{3:00}", args:  val_4);
                if(this.timerText != null)
            {
                    return;
            }
            
                throw new NullReferenceException();
            }
            
            string val_10 = Localization.Localize(key:  "league_calculating_rewards", defaultValue:  "CALCULATING REWARDS", useSingularKey:  false);
        }
        public LeaguesUISeasonTimer()
        {
            this.showSeconds = true;
        }
    
    }

}
