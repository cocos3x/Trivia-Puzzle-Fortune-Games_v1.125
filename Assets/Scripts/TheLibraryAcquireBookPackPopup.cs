using UnityEngine;
public class TheLibraryAcquireBookPackPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text addedScoreText;
    private UnityEngine.GameObject libraryScoreStatView;
    private UnityEngine.UI.Button revealCollectButton;
    private UnityEngine.UI.Text buttonText;
    private UnityEngine.ParticleSystem starsParticles;
    private LibraryBookDisplay[] booksToDisplay;
    private int addedLibraryScore;
    private DG.Tweening.Sequence revealSequence;
    private System.Collections.Generic.List<BookInfo> _packPurchased;
    
    // Methods
    private void Awake()
    {
        this.revealCollectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryAcquireBookPackPopup::OnClick_Reveal()));
    }
    public void Setup(System.Collections.Generic.List<BookInfo> packPurchased)
    {
        var val_25;
        DG.Tweening.TweenCallback val_27;
        var val_28;
        this._packPurchased = packPurchased;
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        this.revealSequence = val_1;
        DG.Tweening.Sequence val_2 = DG.Tweening.TweenExtensions.Pause<DG.Tweening.Sequence>(t:  val_1);
        var val_32 = 4;
        label_37:
        var val_3 = val_32 - 4;
        if(val_3 >= (this.booksToDisplay.Length << ))
        {
            goto label_4;
        }
        
        if(val_3 < 30105600)
        {
                TheLibraryAcquireBookPackPopup.<>c__DisplayClass10_0 val_4 = new TheLibraryAcquireBookPackPopup.<>c__DisplayClass10_0();
            .<>4__this = this;
            if(val_3 >= this.booksToDisplay.Length)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            this.booksToDisplay[0].Setup(info:  this.booksToDisplay[0]);
            DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.revealSequence, t:  DG.Tweening.ShortcutExtensions.DOShakePosition(target:  this.booksToDisplay[0].transform, duration:  0.75f, strength:  10f, vibrato:  100, randomness:  90f, snapping:  false, fadeOut:  false));
            .book = this.booksToDisplay[0];
            DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  this.revealSequence, callback:  new DG.Tweening.TweenCallback(object:  val_4, method:  System.Void TheLibraryAcquireBookPackPopup.<>c__DisplayClass10_0::<Setup>b__2()));
            val_25 = null;
            val_25 = null;
            val_27 = TheLibraryAcquireBookPackPopup.<>c.<>9__10_3;
            if(val_27 == null)
        {
                DG.Tweening.TweenCallback val_10 = null;
            val_27 = val_10;
            val_10 = new DG.Tweening.TweenCallback(object:  TheLibraryAcquireBookPackPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TheLibraryAcquireBookPackPopup.<>c::<Setup>b__10_3());
            TheLibraryAcquireBookPackPopup.<>c.<>9__10_3 = val_27;
        }
        
            DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  this.revealSequence, callback:  val_10);
            UnityEngine.Vector3 val_13 = UnityEngine.Vector3.one;
            UnityEngine.Vector3 val_14 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, d:  0.1f);
            DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.revealSequence, t:  DG.Tweening.ShortcutExtensions.DOPunchScale(target:  this.booksToDisplay[0].transform, punch:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z}, duration:  0.5f, vibrato:  0, elasticity:  1f));
            val_28 = null;
            val_28 = null;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            BookEconInfo val_17 = TheLibraryLogic.BookEcon.Item[TheLibraryLogic.PurchasableBookRefreshTimeHours + 40];
            .value = val_17.LibraryValue;
            DG.Tweening.Sequence val_19 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  this.revealSequence, callback:  new DG.Tweening.TweenCallback(object:  val_4, method:  System.Void TheLibraryAcquireBookPackPopup.<>c__DisplayClass10_0::<Setup>b__4()));
            DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.revealSequence, interval:  0.2f);
        }
        else
        {
                this.booksToDisplay[0].gameObject.SetActive(value:  false);
        }
        
        val_32 = val_32 + 1;
        if(this.booksToDisplay != null)
        {
            goto label_37;
        }
        
        throw new NullReferenceException();
        label_4:
        DG.Tweening.Sequence val_23 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  this.revealSequence, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void TheLibraryAcquireBookPackPopup::<Setup>b__10_0()));
        DG.Tweening.Sequence val_25 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  this.revealSequence, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void TheLibraryAcquireBookPackPopup::<Setup>b__10_1()));
    }
    private void BookRevealEffect(LibraryBookDisplay bookDisplay)
    {
        bookDisplay.gameObject.transform.Find(n:  "Image_book/hidden").gameObject.SetActive(value:  false);
        bookDisplay.gameObject.transform.Find(n:  "Image_book/contents").gameObject.SetActive(value:  true);
    }
    private void UpdateAddedScoreText(int addedValue)
    {
        int val_3 = this.addedLibraryScore;
        val_3 = val_3 + addedValue;
        this.addedLibraryScore = val_3;
        string val_2 = System.String.Format(format:  "+{0}", arg0:  this.addedLibraryScore.ToString());
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void DoPostRevealEffects()
    {
        UnityEngine.GameObject val_6;
        var val_9 = 0;
        do
        {
            if(val_9 >= this.booksToDisplay.Length)
        {
                return;
        }
        
            if(this.booksToDisplay[0].gameObject.activeSelf != false)
        {
                LibraryBookDisplay val_7 = this.booksToDisplay[0];
            if((this.booksToDisplay[0x0][0].bookInfo.Rarity >= 3) && (this.booksToDisplay[0x0][0].obj_stars_rarity.Length >= 1))
        {
                var val_8 = 0;
            do
        {
            val_6 = this.booksToDisplay[0x0][0].obj_stars_rarity[val_8];
            if(val_6.activeSelf != false)
        {
                val_6 = val_6.transform;
            UnityEngine.ParticleSystem val_5 = UnityEngine.Object.Instantiate<UnityEngine.ParticleSystem>(original:  this.starsParticles, parent:  val_6);
        }
        
            val_8 = val_8 + 1;
        }
        while(val_8 < this.booksToDisplay[0x0][0].obj_stars_rarity.Length);
        
        }
        
        }
        
            val_9 = val_9 + 1;
        }
        while(this.booksToDisplay != null);
        
        throw new NullReferenceException();
    }
    private void OnClick_Reveal()
    {
        this.revealCollectButton.interactable = false;
        string val_1 = Localization.Localize(key:  "collect_upper", defaultValue:  "COLLECT", useSingularKey:  false);
        this.revealCollectButton.m_OnClick.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryAcquireBookPackPopup::OnClick_Reveal()));
        this.revealCollectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryAcquireBookPackPopup::OnClick_Collect()));
        this.libraryScoreStatView.SetActive(value:  true);
        DG.Tweening.Sequence val_4 = DG.Tweening.TweenExtensions.Play<DG.Tweening.Sequence>(t:  this.revealSequence);
    }
    private void OnClick_Collect()
    {
        LibraryWindowManager val_2 = MonoSingleton<LibraryWindowManager>.Instance.ShowUGUIMonolith<TheLibraryAcquireBooksPopup>(showNext:  false);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TheLibraryAcquireBookPackPopup()
    {
    
    }
    private void <Setup>b__10_0()
    {
        this.DoPostRevealEffects();
    }
    private void <Setup>b__10_1()
    {
        if(this.revealCollectButton != null)
        {
                this.revealCollectButton.interactable = true;
            return;
        }
        
        throw new NullReferenceException();
    }

}
