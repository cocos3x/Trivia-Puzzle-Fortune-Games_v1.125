using UnityEngine;

namespace WordForest
{
    public class WFOForestContent : MonoBehaviour
    {
        // Fields
        private int forestId;
        private string forestName;
        private UnityEngine.UI.Image darkOverlay;
        private WordForest.WFOTree[] trees;
        private UnityEngine.UI.Image[] forestItems;
        private int currentGrowth;
        private int maxGrowth;
        private int numTreesActive;
        private int numItemsActive;
        private UnityEngine.UI.Image cloneItem;
        private WordForest.RaidXSpotButton[] raidXButtons;
        private UnityEngine.Transform shadowParent;
        private System.Collections.Generic.Queue<DG.Tweening.Sequence> animationQueue;
        private bool animationInProgress;
        
        // Properties
        public int ForestId { get; }
        public string ForestName { get; }
        public WordForest.RaidXSpotButton[] RaidXButtons { get; }
        public WordForest.WFOTree[] Trees { get; }
        
        // Methods
        public int get_ForestId()
        {
            return (int)this.forestId;
        }
        public string get_ForestName()
        {
            return (string)this.forestName;
        }
        public WordForest.RaidXSpotButton[] get_RaidXButtons()
        {
            return (WordForest.RaidXSpotButton[])this.raidXButtons;
        }
        public WordForest.WFOTree[] get_Trees()
        {
            return (WordForest.WFOTree[])this.trees;
        }
        public System.Collections.Generic.List<UnityEngine.Transform> AddGrowth(int addGrowth = 1)
        {
            WordForest.WFOTree[] val_11;
            var val_12;
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            System.Collections.Generic.List<UnityEngine.Transform> val_2 = new System.Collections.Generic.List<UnityEngine.Transform>();
            val_11 = this.trees;
            int val_3 = this.currentGrowth + addGrowth;
            float val_11 = (float)this.maxGrowth;
            val_11 = (float)val_3 / val_11;
            float val_12 = (float)this.trees.Length;
            val_12 = val_11 * val_12;
            int val_4 = UnityEngine.Mathf.FloorToInt(f:  val_12);
            if(val_4 > this.trees.Length)
            {
                    return val_2;
            }
            
            int val_14 = this.numTreesActive;
            if(val_14 < val_4)
            {
                    var val_13 = (long)val_14;
                val_13 = val_13 << 3;
                var val_5 = val_13 + 32;
                do
            {
                if(this.animationInProgress != false)
            {
                    val_12 = 0;
            }
            
                DG.Tweening.Sequence val_8 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  this.PlayGrowTreeAnimation(treeID:  val_14, delayGrowth:  (val_14 == this.numTreesActive) ? 1 : 0));
                val_2.Add(item:  typeof(WordForest.WFOTree[]).__il2cppRuntimeField_28);
                val_14 = val_14 + 1;
                val_5 = val_5 + 8;
            }
            while(val_14 < val_4);
            
            }
            
            this.AddAnimationSequence(nextSequence:  val_1);
            float val_15 = (float)this.maxGrowth;
            val_15 = (float)val_3 / val_15;
            float val_16 = (float)this.forestItems.Length;
            val_16 = val_15 * val_16;
            int val_9 = UnityEngine.Mathf.FloorToInt(f:  val_16);
            val_11 = this.numItemsActive;
            if(val_9 > val_11)
            {
                    do
            {
                this.AddAnimationSequence(nextSequence:  this.PlayNewForestItemSequence(itemID:  val_11));
                val_11 = val_11 + 1;
            }
            while(val_9 != val_11);
            
                this.numItemsActive = val_9;
            }
            
            this.currentGrowth = val_3;
            this.numTreesActive = val_4;
            return val_2;
        }
        public UnityEngine.Transform FixTree(int treeIndex)
        {
            var val_5;
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            if(this.animationInProgress != false)
            {
                    val_5 = 0;
            }
            
            DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  this.PlayGrowTreeAnimation(treeID:  treeIndex, delayGrowth:  (this.numTreesActive == treeIndex) ? 1 : 0));
            WordForest.WFOTree val_5 = this.trees[treeIndex];
            this.AddAnimationSequence(nextSequence:  val_1);
            return (UnityEngine.Transform)this.trees[treeIndex][0].growScaler;
        }
        public void AddAnimationSequence(DG.Tweening.Sequence nextSequence)
        {
            DG.Tweening.Sequence val_2 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  nextSequence, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOForestContent::PlayNextSequence()));
            if(this.animationInProgress != false)
            {
                    DG.Tweening.Sequence val_3 = DG.Tweening.TweenExtensions.Pause<DG.Tweening.Sequence>(t:  nextSequence);
                this.animationQueue.Enqueue(item:  nextSequence);
                return;
            }
            
            this.animationInProgress = true;
        }
        public void Initialize(WordForest.Map forestMap)
        {
            int val_5;
            int val_16;
            WordForest.WFOTree[] val_17;
            this.shadowParent = this.transform.GetChild(index:  0);
            this.currentGrowth = forestMap.CurrentForestGrowth(includeDamagedTrees:  true);
            WordForest.WFOForestData val_4 = WordForest.WFOGameEconHelper.GetForestEconData(forestId:  this.forestId);
            val_16 = val_5;
            val_17 = this.trees;
            this.maxGrowth = val_16;
            float val_16 = (float)this.currentGrowth;
            val_16 = val_16 / (float)val_16;
            float val_17 = (float)this.trees.Length;
            val_17 = val_16 * val_17;
            this.numTreesActive = UnityEngine.Mathf.FloorToInt(f:  val_17);
            System.Collections.Generic.List<WordForest.MapItem> val_7 = forestMap.GetForestData();
            val_17 = 0;
            if(val_17 < this.trees.Length)
            {
                    val_16 = this.trees[0];
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                DG.Tweening.Sequence val_8 = val_16.SetGrowthState(state:  (UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 0) + 32 + 28, instant:  true, delayGrowth:  false, shadowParent:  this.shadowParent);
                val_17 = val_17 + 1;
            }
            else
            {
                    if(CompanyDevices.Instance.CompanyDevice() != false)
            {
                    UnityEngine.Debug.LogWarning(message:  "[Forest] Map data does not correspond to tree count.");
            }
            
            }
            
            float val_18 = (float)this.currentGrowth;
            val_18 = val_18 / (float)this.maxGrowth;
            float val_19 = (float)this.forestItems.Length;
            val_19 = val_18 * val_19;
            this.numItemsActive = UnityEngine.Mathf.FloorToInt(f:  val_19);
            var val_21 = 0;
            label_28:
            if(val_21 >= (this.forestItems.Length << ))
            {
                goto label_26;
            }
            
            PluginExtension.SetColorAlpha(graphic:  this.forestItems[val_21], a:  (val_21 < this.numItemsActive) ? 1f : 0f);
            val_21 = val_21 + 1;
            if(this.forestItems != null)
            {
                goto label_28;
            }
            
            throw new NullReferenceException();
            label_26:
            this.darkOverlay.transform.SetAsLastSibling();
            this.raidXButtons = this.gameObject.GetComponentsInChildren<WordForest.RaidXSpotButton>();
            this.ToggleRaidXSpots(isVisible:  false);
        }
        public void ToggleRaidXSpots(bool isVisible)
        {
            if(this.raidXButtons == null)
            {
                    return;
            }
            
            var val_4 = 0;
            do
            {
                if(val_4 >= this.raidXButtons.Length)
            {
                    return;
            }
            
                this.raidXButtons[val_4].gameObject.SetActive(value:  isVisible);
                val_4 = val_4 + 1;
            }
            while(this.raidXButtons != null);
            
            throw new NullReferenceException();
        }
        private void PlayNextSequence()
        {
            if(true >= 1)
            {
                    DG.Tweening.Sequence val_2 = DG.Tweening.TweenExtensions.Play<DG.Tweening.Sequence>(t:  this.animationQueue.Dequeue());
                return;
            }
            
            this.animationInProgress = false;
        }
        private DG.Tweening.Sequence PlayGrowTreeAnimation(int treeID, bool delayGrowth = False)
        {
            return this.trees[treeID].SetGrowthState(state:  1, instant:  false, delayGrowth:  delayGrowth, shadowParent:  this.shadowParent);
        }
        private DG.Tweening.Sequence PlayNewForestItemSequence(int itemID)
        {
            WFOForestContent.<>c__DisplayClass29_0 val_1 = new WFOForestContent.<>c__DisplayClass29_0();
            .<>4__this = this;
            .itemID = itemID;
            DG.Tweening.Sequence val_2 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_2, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.darkOverlay, endValue:  0.5f, duration:  0.25f));
            DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_2, interval:  0.15f);
            DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_2, callback:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WFOForestContent.<>c__DisplayClass29_0::<PlayNewForestItemSequence>b__0()));
            DG.Tweening.Sequence val_8 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_2, interval:  1.15f);
            DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_2, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.darkOverlay, endValue:  0f, duration:  0.25f));
            DG.Tweening.Sequence val_12 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_2, callback:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WFOForestContent.<>c__DisplayClass29_0::<PlayNewForestItemSequence>b__1()));
            DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_2, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.forestItems[(WFOForestContent.<>c__DisplayClass29_0)[1152921518119586704].itemID], endValue:  1f, duration:  0f));
            return val_2;
        }
        public WFOForestContent()
        {
            this.animationQueue = new System.Collections.Generic.Queue<DG.Tweening.Sequence>();
        }
    
    }

}
