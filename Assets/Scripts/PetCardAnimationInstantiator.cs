using UnityEngine;
public class PetCardAnimationInstantiator : MonoBehaviour
{
    // Fields
    public int maxCardsPerRow;
    public UnityEngine.GameObject background;
    public UnityEngine.UI.HorizontalLayoutGroup rowLayout;
    public UnityEngine.UI.VerticalLayoutGroup verticalLayout;
    public UnityEngine.GameObject petCardPrefab;
    private System.Collections.Generic.List<PetCardAnimationInstantiator.PetCardReward> petCards;
    private System.Collections.Generic.List<GiftRewardUI_PetCard> petCardsUI;
    private System.Collections.Generic.List<UnityEngine.UI.HorizontalLayoutGroup> hrows;
    public System.Action OnCompleteCallback;
    private const float CardFadeDuration = 0.5;
    
    // Methods
    private void Awake()
    {
        this.hrows.Add(item:  this.rowLayout);
        this.verticalLayout.gameObject.SetActive(value:  false);
        this.background.gameObject.SetActive(value:  false);
    }
    public void AddCard(WADPets.WADPet pet, decimal startBalance, decimal endBalance)
    {
        this.petCards.Add(item:  new PetCardReward() {pet = pet, startBalance = new System.Decimal() {flags = startBalance.flags, hi = startBalance.hi, lo = startBalance.lo, mid = startBalance.mid}, endBalance = new System.Decimal() {flags = endBalance.flags, hi = endBalance.hi, lo = endBalance.lo, mid = endBalance.mid}});
    }
    public void Play(System.Collections.Generic.List<PetCardAnimationInstantiator.PetCardReward> petCards)
    {
        this.petCards = petCards;
        this.Play();
    }
    public void Play()
    {
        if(this.petCards == null)
        {
                return;
        }
        
        this.verticalLayout.gameObject.SetActive(value:  true);
        this.background.gameObject.SetActive(value:  true);
        float val_6 = 4.197171E+07f;
        val_6 = val_6 / (float)this.maxCardsPerRow;
        int val_3 = UnityEngine.Mathf.CeilToInt(f:  val_6);
        this.InstantiateRows(totalRows:  val_3);
        this.InstantiateCardUI(totalRows:  val_3);
        UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.PlayCollect());
    }
    private System.Collections.IEnumerator PlayCollect()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new PetCardAnimationInstantiator.<PlayCollect>d__15();
    }
    private void HideAndClear()
    {
        var val_11;
        this.petCards.Clear();
        this.petCardsUI.Clear();
        this.verticalLayout.gameObject.SetActive(value:  false);
        this.background.gameObject.SetActive(value:  false);
        var val_17 = 0;
        var val_13 = 0;
        label_35:
        if(val_17 >= 1152921516768331728)
        {
                return;
        }
        
        if(1152921516768331728 <= val_17)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.Collections.IEnumerator val_4 = transform.GetEnumerator();
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        label_27:
        var val_11 = 0;
        val_11 = val_11 + 1;
        if(val_4.MoveNext() == false)
        {
            goto label_17;
        }
        
        var val_12 = 0;
        val_12 = val_12 + 1;
        object val_8 = val_4.Current;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Object.Destroy(obj:  val_8.gameObject);
        goto label_27;
        label_17:
        val_13 = val_13 + 1;
        if(X0 == false)
        {
            goto label_28;
        }
        
        var val_16 = X0;
        if((X0 + 294) == 0)
        {
            goto label_32;
        }
        
        var val_14 = X0 + 176;
        var val_15 = 0;
        val_14 = val_14 + 8;
        label_31:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_30;
        }
        
        val_15 = val_15 + 1;
        val_14 = val_14 + 16;
        if(val_15 < (X0 + 294))
        {
            goto label_31;
        }
        
        goto label_32;
        label_30:
        val_16 = val_16 + (((X0 + 176 + 8)) << 4);
        val_11 = val_16 + 304;
        label_32:
        X0.Dispose();
        label_28:
        if(0 != 0)
        {
                throw ???;
        }
        
        if(val_13 != 1)
        {
                val_13 = val_13 + (0 ^ (val_13 >> 31));
        }
        
        val_17 = val_17 + 1;
        if(this.hrows != null)
        {
            goto label_35;
        }
        
        throw new NullReferenceException();
    }
    private void InstantiateRows(int totalRows)
    {
        System.Collections.Generic.List<UnityEngine.UI.HorizontalLayoutGroup> val_8;
        var val_9;
        var val_10;
        val_8 = this.hrows;
        if(W23 < totalRows)
        {
                do
        {
            this.hrows.Add(item:  UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.rowLayout.gameObject, parent:  this.verticalLayout.transform).GetComponent<UnityEngine.UI.HorizontalLayoutGroup>());
            val_9 = W23 + 1;
        }
        while(val_9 < totalRows);
        
            val_8 = this.hrows;
        }
        
        val_10 = 0;
        do
        {
            if(val_10 >= null)
        {
                return;
        }
        
            if(null <= val_10)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            UnityEngine.Object.__il2cppRuntimeField_byval_arg.gameObject.SetActive(value:  (val_10 < totalRows) ? 1 : 0);
            val_10 = val_10 + 1;
        }
        while(this.hrows != null);
        
        throw new NullReferenceException();
    }
    private void InstantiateCardUI(int totalRows)
    {
        var val_8;
        if(totalRows < 1)
        {
                return;
        }
        
        var val_9 = 0;
        do
        {
            int val_2 = UnityEngine.Mathf.Min(a:  this.maxCardsPerRow, b:  41971712 - (this.maxCardsPerRow * val_9));
            if(val_2 >= 1)
        {
                var val_8 = 0;
            do
        {
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            UnityEngine.GameObject val_5 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.petCardPrefab.gameObject, parent:  (UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 0) + 32.transform);
            val_8 = val_5;
            val_5.GetComponent<UnityEngine.CanvasGroup>().alpha = 0f;
            this.petCardsUI.Add(item:  val_8.GetComponent<GiftRewardUI_PetCard>());
            val_8 = val_8 + 1;
        }
        while(val_8 < val_2);
        
        }
        
            val_9 = val_9 + 1;
        }
        while(val_9 < (long)totalRows);
    
    }
    public PetCardAnimationInstantiator()
    {
        this.petCards = new System.Collections.Generic.List<PetCardReward>();
        this.petCardsUI = new System.Collections.Generic.List<GiftRewardUI_PetCard>();
        this.hrows = new System.Collections.Generic.List<UnityEngine.UI.HorizontalLayoutGroup>();
    }

}
