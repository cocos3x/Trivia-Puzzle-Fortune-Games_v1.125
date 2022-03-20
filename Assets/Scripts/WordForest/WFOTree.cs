using UnityEngine;

namespace WordForest
{
    public class WFOTree : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Image treeImage;
        private UnityEngine.UI.Image shadowImage;
        private UnityEngine.Transform growScaler;
        private UnityEngine.Color shadowColor;
        private UnityEngine.Sprite spriteChoppedTree;
        private int growthState;
        private UnityEngine.Sprite spriteFullGrownTree;
        private UnityEngine.Vector3 posFullGrownTree;
        private UnityEngine.ParticleSystem choppedTreeSmokeEfx;
        private static WordForest.WFODigAnimation _digAnimationPrefab;
        private static UnityEngine.ParticleSystem _choppedTreeSmokeEfxPrefab;
        
        // Properties
        public int GrowthState { get; }
        public UnityEngine.Transform originTransform { get; }
        private static WordForest.WFODigAnimation DigAnimationPrefab { get; }
        private static UnityEngine.ParticleSystem ChoppedTreeSmokeEfxPrefab { get; }
        
        // Methods
        public int get_GrowthState()
        {
            return (int)this.growthState;
        }
        public UnityEngine.Transform get_originTransform()
        {
            return (UnityEngine.Transform)this.growScaler;
        }
        private static WordForest.WFODigAnimation get_DigAnimationPrefab()
        {
            WordForest.WFODigAnimation val_3;
            var val_4;
            var val_5;
            val_3 = WordForest.WFOTree._digAnimationPrefab;
            if(val_3 != 0)
            {
                    return (WordForest.WFODigAnimation)WordForest.WFOTree._digAnimationPrefab;
            }
            
            val_3 = 1152921504884269056;
            val_4 = null;
            val_4 = null;
            if(App.game == 18)
            {
                    val_5 = 1152921516215922224;
            }
            else
            {
                    val_5 = 1152921516244569856;
            }
            
            ForestFrenzyManager val_2 = MonoSingleton<ForestFrenzyManager>.Instance;
            WordForest.WFOTree._digAnimationPrefab = val_2.digAnimationPrefab;
            return (WordForest.WFODigAnimation)WordForest.WFOTree._digAnimationPrefab;
        }
        private static UnityEngine.ParticleSystem get_ChoppedTreeSmokeEfxPrefab()
        {
            UnityEngine.ParticleSystem val_3;
            var val_4;
            var val_5;
            var val_6;
            val_3 = WordForest.WFOTree._choppedTreeSmokeEfxPrefab;
            if(val_3 != 0)
            {
                goto label_3;
            }
            
            val_3 = 1152921504884269056;
            val_4 = null;
            val_4 = null;
            if(App.game != 18)
            {
                goto label_9;
            }
            
            val_5 = 1152921516215922224;
            goto label_12;
            label_3:
            val_6 = 1152921505005568184;
            return (UnityEngine.ParticleSystem)WordForest.WFOTree._choppedTreeSmokeEfxPrefab;
            label_9:
            val_5 = 1152921516244569856;
            label_12:
            ForestFrenzyManager val_2 = MonoSingleton<ForestFrenzyManager>.Instance;
            val_6 = null;
            WordForest.WFOTree._choppedTreeSmokeEfxPrefab = val_2.prefabEfxTreeChoppedSmoke;
            return (UnityEngine.ParticleSystem)WordForest.WFOTree._choppedTreeSmokeEfxPrefab;
        }
        private void Awake()
        {
            this.spriteFullGrownTree = this.treeImage.m_Sprite;
            UnityEngine.Vector3 val_2 = this.treeImage.transform.localPosition;
            this.posFullGrownTree = val_2;
            mem[1152921519421228188] = val_2.y;
            mem[1152921519421228192] = val_2.z;
        }
        private void Start()
        {
            if(this.shadowImage != null)
            {
                    this.shadowImage.color = new UnityEngine.Color() {r = this.shadowColor};
                return;
            }
            
            throw new NullReferenceException();
        }
        public DG.Tweening.Sequence SetGrowthState(int state, bool instant = True, bool delayGrowth = False, UnityEngine.Transform shadowParent)
        {
            object val_43;
            WordForest.WFOTree val_44;
            float val_45;
            float val_46;
            float val_47;
            UnityEngine.Transform val_48;
            val_43 = instant;
            val_44 = this;
            .state = state;
            .shadowParent = shadowParent;
            .<>4__this = val_44;
            DG.Tweening.Sequence val_2 = DG.Tweening.DOTween.Sequence();
            this.growthState = (WFOTree.<>c__DisplayClass21_0)[1152921519421736000].state;
            if(((WFOTree.<>c__DisplayClass21_0)[1152921519421736000].state) != 2)
            {
                goto label_4;
            }
            
            this.treeImage.sprite = this.spriteChoppedTree;
            UnityEngine.Vector3 val_5 = this.treeImage.transform.localPosition;
            UnityEngine.Vector3 val_7 = this.treeImage.transform.localPosition;
            UnityEngine.Vector3 val_8 = new UnityEngine.Vector3(x:  0f, y:  val_5.y, z:  val_7.z);
            val_45 = val_8.x;
            val_46 = val_8.y;
            val_47 = val_8.z;
            this.treeImage.transform.localPosition = new UnityEngine.Vector3() {x = val_45, y = val_46, z = val_47};
            val_48 = 1152921504765632512;
            if(this.choppedTreeSmokeEfx != 0)
            {
                goto label_14;
            }
            
            val_48 = shadowParent.gameObject.transform;
            UnityEngine.ParticleSystem val_13 = UnityEngine.Object.Instantiate<UnityEngine.ParticleSystem>(original:  WordForest.WFOTree.ChoppedTreeSmokeEfxPrefab, parent:  val_48);
            this.choppedTreeSmokeEfx = val_13;
            if(val_13 != null)
            {
                goto label_18;
            }
            
            label_4:
            this.treeImage.sprite = this.spriteFullGrownTree;
            val_45 = this.posFullGrownTree;
            this.treeImage.transform.localPosition = new UnityEngine.Vector3() {x = val_45};
            val_48 = 1152921504765632512;
            if(this.choppedTreeSmokeEfx == 0)
            {
                goto label_29;
            }
            
            UnityEngine.Object.Destroy(obj:  this.choppedTreeSmokeEfx.gameObject);
            goto label_29;
            label_14:
            label_18:
            UnityEngine.Vector3 val_19 = this.shadowImage.transform.position;
            this.choppedTreeSmokeEfx.transform.position = new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z};
            this.choppedTreeSmokeEfx.Play();
            label_29:
            if(((WFOTree.<>c__DisplayClass21_0)[1152921519421736000].state) != 0)
            {
                    UnityEngine.Vector3 val_20 = UnityEngine.Vector3.one;
            }
            else
            {
                    UnityEngine.Vector3 val_21 = UnityEngine.Vector3.zero;
            }
            
            if(val_43 != false)
            {
                    this.growScaler.localScale = new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_21.z};
                if(((WFOTree.<>c__DisplayClass21_0)[1152921519421736000].state) == 0)
            {
                    return val_2;
            }
            
                if(((WFOTree.<>c__DisplayClass21_0)[1152921519421736000].shadowParent) == 0)
            {
                    return val_2;
            }
            
                this.shadowImage.transform.SetParent(parent:  (WFOTree.<>c__DisplayClass21_0)[1152921519421736000].shadowParent, worldPositionStays:  true);
                return val_2;
            }
            
            WFOTree.<>c__DisplayClass21_1 val_24 = null;
            val_43 = val_24;
            val_24 = new WFOTree.<>c__DisplayClass21_1();
            val_48 = shadowParent.transform;
            WordForest.WFODigAnimation val_27 = UnityEngine.Object.Instantiate<WordForest.WFODigAnimation>(original:  WordForest.WFOTree.DigAnimationPrefab, parent:  val_48);
            .digAnimation = val_27;
            val_27.transform.SetAsFirstSibling();
            UnityEngine.Vector3 val_30 = this.growScaler.localPosition;
            (WFOTree.<>c__DisplayClass21_1)[1152921519421867072].digAnimation.transform.localPosition = new UnityEngine.Vector3() {x = val_30.x, y = val_30.y, z = val_30.z};
            (WFOTree.<>c__DisplayClass21_1)[1152921519421867072].digAnimation.StartDigAnimation();
            if(delayGrowth != false)
            {
                    DG.Tweening.Sequence val_31 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_2, interval:  0.9f);
            }
            
            DG.Tweening.Sequence val_33 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_2, callback:  new DG.Tweening.TweenCallback(object:  val_24, method:  System.Void WFOTree.<>c__DisplayClass21_1::<SetGrowthState>b__0()));
            UnityEngine.Vector3 val_34 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_21.z}, d:  0.9f);
            DG.Tweening.Sequence val_37 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_2, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.growScaler, endValue:  new UnityEngine.Vector3() {x = val_34.x, y = val_34.y, z = val_34.z}, duration:  0.4f), ease:  6));
            val_44 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.growScaler, endValue:  new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_21.z}, duration:  0.25f), ease:  30);
            DG.Tweening.Sequence val_42 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_2, t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  val_44, action:  new DG.Tweening.TweenCallback(object:  new WFOTree.<>c__DisplayClass21_0(), method:  System.Void WFOTree.<>c__DisplayClass21_0::<SetGrowthState>b__1())));
            return val_2;
        }
        public WFOTree()
        {
        
        }
    
    }

}
