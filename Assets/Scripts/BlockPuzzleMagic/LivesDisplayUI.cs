using UnityEngine;

namespace BlockPuzzleMagic
{
    public class LivesDisplayUI : FrameSkipper
    {
        // Fields
        protected UnityEngine.UI.Text livesCounter;
        protected UnityEngine.UI.Text livesCooldownTimer;
        protected System.TimeSpan timerCooldownInterval;
        
        // Methods
        protected virtual void Start()
        {
            BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            System.TimeSpan val_2 = System.TimeSpan.FromMinutes(value:  (double)val_1.lifeRechargeTimeMins);
            this.timerCooldownInterval = val_2;
            mem[1152921520195252880] = 10;
            goto typeof(BlockPuzzleMagic.LivesDisplayUI).__il2cppRuntimeField_170;
        }
        protected void SetupUpdateLogic()
        {
            mem[1152921520195368976] = 10;
            goto typeof(BlockPuzzleMagic.LivesDisplayUI).__il2cppRuntimeField_170;
        }
        protected override void UpdateLogic()
        {
            UnityEngine.UI.Text val_14;
            BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
            string val_2 = val_1.livesBalance.ToString();
            if(BestBlocksPlayer.Instance.IsLivesMaxed() != false)
            {
                    val_14 = this.livesCooldownTimer;
                string val_5 = Localization.Localize(key:  "max_upper", defaultValue:  "MAX", useSingularKey:  false);
                if(val_14 != null)
            {
                goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
            }
            
            }
            
            if(BestBlocksPlayer.Instance.RefreshPlayerLives() != false)
            {
                    MonoSingleton<BlockPuzzleMagic.GameProgressManager>.Instance.SaveGame();
            }
            
            System.DateTime val_9 = DateTimeCheat.UtcNow;
            BestBlocksPlayer val_10 = BestBlocksPlayer.Instance;
            System.TimeSpan val_11 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_9.dateData}, d2:  new System.DateTime() {dateData = val_10.lastLifeTopupTime});
            System.TimeSpan val_12 = System.TimeSpan.op_Subtraction(t1:  new System.TimeSpan() {_ticks = this.timerCooldownInterval}, t2:  new System.TimeSpan() {_ticks = val_11._ticks});
            val_14 = this.livesCooldownTimer;
            string val_13 = GenericStringExtentions.ToString(span:  new System.TimeSpan() {_ticks = val_12._ticks}, formatted:  true);
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        }
        public LivesDisplayUI()
        {
        
        }
    
    }

}
