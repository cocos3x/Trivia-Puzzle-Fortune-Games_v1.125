using UnityEngine;

namespace WordForest
{
    public class WFOShieldStatView : MonoBehaviour
    {
        // Fields
        private System.Collections.Generic.List<UnityEngine.UI.Image> shieldList;
        private System.Collections.Generic.List<UnityEngine.UI.Image> frameBgList;
        private UnityEngine.UI.Button button;
        private int visualShieldCount;
        private DG.Tweening.Sequence[] shieldAnimSeq;
        protected int artificalTargetBalance;
        
        // Properties
        public bool Interactable { get; set; }
        public UnityEngine.UI.Button Button { get; }
        
        // Methods
        public bool get_Interactable()
        {
            if(this.button != null)
            {
                    return (bool)this;
            }
            
            throw new NullReferenceException();
        }
        public void set_Interactable(bool value)
        {
            if(this.button != null)
            {
                    this.button.interactable = value;
                return;
            }
            
            throw new NullReferenceException();
        }
        public UnityEngine.UI.Button get_Button()
        {
            return (UnityEngine.UI.Button)this.button;
        }
        private void Awake()
        {
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnShieldBalanceUpdated");
            this.shieldAnimSeq = new DG.Tweening.Sequence[1926698672];
        }
        private void Start()
        {
            this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOShieldStatView::OnClicked()));
        }
        private void OnEnable()
        {
            int val_5 = this.artificalTargetBalance;
            if((val_5 & 2147483648) != 0)
            {
                    WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
                val_5 = val_1.shields;
            }
            
            this.visualShieldCount = val_5;
            var val_6 = 4;
            label_11:
            var val_2 = val_6 - 4;
            if(val_2 >= val_5)
            {
                goto label_4;
            }
            
            if(val_5 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_1.shields + 32.gameObject.SetActive(value:  (val_2 < this.visualShieldCount) ? 1 : 0);
            if(val_5 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_1.shields + 32.enabled = (val_2 >= this.visualShieldCount) ? 1 : 0;
            val_6 = val_6 + 1;
            if(this.shieldList != null)
            {
                goto label_11;
            }
            
            throw new NullReferenceException();
            label_4:
            this.artificalTargetBalance = 0;
        }
        private void OnDestroy()
        {
            NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnShieldBalanceUpdated");
        }
        public void SetTargetBalance(int targetBalance)
        {
            this.artificalTargetBalance = targetBalance;
        }
        private void OnShieldBalanceUpdated()
        {
            this.UpdateUI(instantly:  false);
        }
        public void UpdateUI(bool instantly = False)
        {
            int val_42;
            int val_43;
            float val_44;
            var val_45;
            float val_46;
            int val_47;
            int val_48;
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            if((this.artificalTargetBalance & 2147483648) == 0)
            {
                    val_42 = this.artificalTargetBalance;
                this.artificalTargetBalance = 0;
            }
            else
            {
                    val_42 = UnityEngine.Mathf.Max(a:  0, b:  val_1.shields);
            }
            
            val_43 = this.visualShieldCount;
            if(val_42 == val_43)
            {
                    return;
            }
            
            int val_3 = val_43 & 4294967295;
            if(val_42 <= val_43)
            {
                goto label_7;
            }
            
            val_44 = 0.15f;
            var val_41 = (long)val_3;
            val_41 = val_41 << 3;
            val_45 = 0;
            val_46 = 1f;
            var val_4 = val_41 + 32;
            label_58:
            val_47 = val_3 + val_45;
            if(val_47 >= (UnityEngine.Mathf.Min(a:  val_42, b:  W22)))
            {
                goto label_62;
            }
            
            if(null != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  null, complete:  false);
            }
            
            if(instantly != false)
            {
                    if(this.shieldAnimSeq[val_4] <= val_47)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_42 = null;
                UnityEngine.Vector3 val_7 = UnityEngine.Vector3.one;
                1152921508062616688.transform.localScale = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
                if(val_42 <= val_47)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_42 = val_42 + val_4;
                UnityEngine.Color val_8 = UnityEngine.Color.white;
                var val_43 = (null + (((long)(int)((this.visualShieldCount & 4294967295)) << 3) + 32)) + 0;
                if(val_43 <= val_47)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_43 = val_43 + val_4;
                ((null + (((long)(int)((this.visualShieldCount & 4294967295)) << 3) + 32)) + 0 + (((long)(int)((this.visualShieldCount & 4294967295)) << 3) + 32)) + 0.gameObject.SetActive(value:  true);
                if(val_43 <= val_47)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_43 = val_43 + val_4;
                (((null + (((long)(int)((this.visualShieldCount & 4294967295)) << 3) + 32)) + 0 + (((long)(int)((this.visualShieldCount & 4294967295)) << 3) + 32)) + (((long)(int)((this.visualShieldCount & 4294967295 + 0.enabled = false;
            }
            else
            {
                    var val_44 = 1152921505005461504;
                .<>4__this = this;
                if(val_44 <= val_47)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_44 = val_44 + val_4;
                UnityEngine.Vector3 val_12 = new UnityEngine.Vector3(x:  1.35f, y:  1.35f, z:  val_46);
                (1152921505005461504 + (((long)(int)((this.visualShieldCount & 4294967295)) << 3) + 32)) + 0.transform.localScale = new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z};
                if(val_44 <= val_47)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_44 = val_44 + val_4;
                UnityEngine.Color val_13 = new UnityEngine.Color(r:  val_46, g:  val_46, b:  val_46, a:  0f);
                var val_45 = ((1152921505005461504 + (((long)(int)((this.visualShieldCount & 4294967295)) << 3) + 32)) + (((long)(int)((this.visualShieldCount & 4294967295)) << 3) + 32)) + 0;
                if(val_45 <= val_47)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_45 = val_45 + val_4;
                (((1152921505005461504 + (((long)(int)((this.visualShieldCount & 4294967295)) << 3) + 32)) + (((long)(int)((this.visualShieldCount & 4294967295)) << 3) + 32)) + 0 + (((long)(int)((this.visualShieldCou + 0.gameObject.SetActive(value:  true);
                .currIndex = val_47;
                DG.Tweening.Sequence val_15 = DG.Tweening.DOTween.Sequence();
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                UnityEngine.Vector3 val_17 = UnityEngine.Vector3.one;
                var val_46 = 1152921509727915456;
                DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_15, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  transform, endValue:  new UnityEngine.Vector3() {x = val_17.x, y = val_17.y, z = val_17.z}, duration:  val_44), ease:  27));
                if(val_46 <= val_47)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_46 = val_46 + val_4;
                DG.Tweening.Sequence val_23 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_15, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  (1152921509727915456 + (((long)(int)((this.visualShieldCount & 4294967295)) << 3) + 32)) + 0, endValue:  val_46, duration:  0.05f), ease:  1));
                DG.Tweening.Sequence val_25 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_15, action:  new DG.Tweening.TweenCallback(object:  new WFOShieldStatView.<>c__DisplayClass17_0(), method:  System.Void WFOShieldStatView.<>c__DisplayClass17_0::<UpdateUI>b__0()));
                mem2[0] = val_15;
            }
            
            val_45 = val_45 + 1;
            if(this.shieldList != null)
            {
                goto label_58;
            }
            
            label_7:
            if(val_3 <= val_42)
            {
                goto label_62;
            }
            
            val_45 = 1152921505005514752;
            val_44 = 0.15f;
            val_47 = (long)val_42;
            int val_26 = val_43 - 1;
            val_46 = 1f;
            label_86:
            int val_28 = val_43 - 1;
            .<>4__this = this;
            if(val_3 < val_42)
            {
                goto label_62;
            }
            
            .currIndex = val_26;
            val_48 = val_26;
            if(this.shieldAnimSeq[this.visualShieldCount].Length != 0)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.shieldAnimSeq[this.visualShieldCount].Length, complete:  false);
                val_48 = (WFOShieldStatView.<>c__DisplayClass17_1)[1152921519419752640].currIndex;
            }
            
            if(this.shieldAnimSeq[val_43] <= val_48)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            this.shieldAnimSeq[val_43][val_48].enabled = true;
            if(instantly != false)
            {
                    if(this.shieldAnimSeq[val_43][val_48] <= ((WFOShieldStatView.<>c__DisplayClass17_1)[1152921519419752640].currIndex))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                this.shieldAnimSeq[val_43][val_48][(WFOShieldStatView.<>c__DisplayClass17_1)[1152921519419752640].currIndex].gameObject.SetActive(value:  false);
            }
            else
            {
                    DG.Tweening.Sequence val_30 = DG.Tweening.DOTween.Sequence();
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                UnityEngine.Vector3 val_32 = new UnityEngine.Vector3(x:  1.35f, y:  1.35f, z:  val_46);
                var val_49 = 1152921509727915456;
                DG.Tweening.Sequence val_35 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_30, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  (DG.Tweening.DOTween.__il2cppRuntimeField_cctor_finished + ((WFOShieldStatView.<>c__DisplayClass17_1)[1152921519419752640].currIndex) << 3) + 32.transform, endValue:  new UnityEngine.Vector3() {x = val_32.x, y = val_32.y, z = val_32.z}, duration:  val_44), ease:  27));
                if(val_49 <= ((WFOShieldStatView.<>c__DisplayClass17_1)[1152921519419752640].currIndex))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_49 = val_49 + (((WFOShieldStatView.<>c__DisplayClass17_1)[1152921519419752640].currIndex) << 3);
                DG.Tweening.Sequence val_38 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_30, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  (1152921509727915456 + ((WFOShieldStatView.<>c__DisplayClass17_1)[1152921519419752640].currIndex) << 3) + 32, endValue:  0f, duration:  val_44), ease:  1));
                DG.Tweening.Sequence val_40 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_30, action:  new DG.Tweening.TweenCallback(object:  new WFOShieldStatView.<>c__DisplayClass17_1(), method:  System.Void WFOShieldStatView.<>c__DisplayClass17_1::<UpdateUI>b__1()));
                val_45 = val_45;
                val_47 = val_47;
                this.shieldAnimSeq[(WFOShieldStatView.<>c__DisplayClass17_1)[1152921519419752640].currIndex] = val_30;
            }
            
            val_26 = val_26 - 1;
            val_43 = val_28;
            if(val_28 > val_47)
            {
                goto label_86;
            }
            
            label_62:
            this.visualShieldCount = val_42;
            this.artificalTargetBalance = 0;
        }
        private void OnClicked()
        {
            GameBehavior val_1 = App.getBehavior;
            goto mem[(1152921504946249728 + (public WordForest.WFORaidAttackInfoPopup MetaGameBehavior::ShowUGUIMonolith<WordForest.WFORaidAttackInfoPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
        }
        public WFOShieldStatView()
        {
            this.artificalTargetBalance = 0;
        }
    
    }

}
