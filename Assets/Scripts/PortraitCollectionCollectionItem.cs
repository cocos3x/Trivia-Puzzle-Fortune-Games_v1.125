using UnityEngine;
public class PortraitCollectionCollectionItem : MonoBehaviour
{
    // Fields
    private const string DEFAULT_COLLECTION = "DEFAULT";
    private string thisCollection;
    private UnityEngine.UI.Text collectionTitle;
    private UnityEngine.UI.Text collectionText;
    private PortraitCollectionPortraitItem portraitPrefab;
    private PortraitCollectionPortraitItem collectionPortrait;
    private UnityEngine.UI.Button expandButton;
    private UnityEngine.UI.Image expandImage;
    private UnityEngine.GameObject collectionPortraitSection;
    private UnityEngine.GameObject collectionPortraitParent;
    private UnityEngine.UI.GridLayoutGroup allPortraitsSection;
    private System.Collections.Generic.Dictionary<string, PortraitCollectionPortraitItem> myPortraits;
    private bool hasInitCollection;
    private float defaultSize;
    private float expandToSize;
    
    // Methods
    private void OnEnable()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnAvatarChanged");
        this.myPortraits = new System.Collections.Generic.Dictionary<System.String, PortraitCollectionPortraitItem>();
    }
    public void Init(string collectionName)
    {
        float val_22;
        this.thisCollection = collectionName;
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        string val_5 = this.thisCollection.ToUpper();
        System.Collections.Generic.List<System.String> val_7 = MonoSingleton<WGPortraitDataController>.Instance.GetPortraitNamesByCollection(collection:  this.thisCollection);
        System.Collections.Generic.List<System.String> val_9 = MonoSingleton<WGPortraitDataController>.Instance.GetUnlockedPortraitsByCollection(collection:  this.thisCollection);
        this.collectionPortraitSection.SetActive(value:  true);
        int val_11 = MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionCurrentProgress(collection:  this.thisCollection);
        val_22 = 0f;
        if((val_11 >= 1) && (W25 != W26))
        {
                val_22 = (float)val_11 / ((float)MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionNextUnlockCost(collection:  this.thisCollection));
        }
        
        this.collectionPortrait.InitCollection(collectionName:  this.thisCollection, unlocked:  (W25 == W26) ? 1 : 0, inUse:  System.String.op_Equality(a:  val_2.Portrait_ID, b:  MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionRewardPotrait(collection:  this.thisCollection)), progress:  val_22);
        if(this.allPortraitsSection != 0)
        {
                this.allPortraitsSection.gameObject.SetActive(value:  false);
        }
        
        if(this.expandButton == 0)
        {
                return;
        }
        
        this.expandButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PortraitCollectionCollectionItem::<Init>b__16_0()));
    }
    public void InitDefaultCollection()
    {
        this.defaultSize = 80f;
        this.expandToSize = 2400f;
        this.thisCollection = "DEFAULT";
        UnityEngine.GameObject val_1 = this.collectionText.gameObject;
        val_1.SetActive(value:  false);
        val_1.top = 126;
        UnityEngine.Vector2 val_3 = this.GetComponent<UnityEngine.RectTransform>().sizeDelta;
        this.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2() {x = val_3.x, y = this.defaultSize};
        if(this.collectionPortraitSection != 0)
        {
                this.collectionPortraitSection.SetActive(value:  false);
        }
        
        if(this.allPortraitsSection != 0)
        {
                this.allPortraitsSection.gameObject.SetActive(value:  false);
        }
        
        if(this.expandButton == 0)
        {
                return;
        }
        
        this.expandButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PortraitCollectionCollectionItem::<InitDefaultCollection>b__17_0()));
    }
    private System.Collections.IEnumerator OnExpandClicked()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new PortraitCollectionCollectionItem.<OnExpandClicked>d__18();
    }
    private System.Collections.IEnumerator ExpandCollectionOpen()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new PortraitCollectionCollectionItem.<ExpandCollectionOpen>d__19();
    }
    private System.Collections.IEnumerator ExpandCollectionClosed()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new PortraitCollectionCollectionItem.<ExpandCollectionClosed>d__20();
    }
    private void PopulateCollection()
    {
        string val_16;
        var val_17;
        int val_36;
        float val_37;
        string val_38;
        System.Collections.Generic.Dictionary<System.String, PortraitCollectionPortraitItem> val_39;
        PortraitCollectionPortraitItem val_40;
        System.Collections.Generic.List<System.String> val_4 = MonoSingleton<WGPortraitDataController>.Instance.GetUnlockedPortraitsByCollection(collection:  this.thisCollection);
        SLC.Social.Profile val_6 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        val_36 = System.String.alignConst;
        if((MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionCurrentProgress(collection:  this.thisCollection)) < 1)
        {
            goto label_14;
        }
        
        val_37 = 0f;
        if(val_4 == (val_4 + 24))
        {
            goto label_21;
        }
        
        val_36 = MonoSingleton<FPHPortraitCollectionController>.Instance.GetNextUnlockedPortrait(collection:  this.thisCollection);
        val_37 = ((float)MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionCurrentProgress(collection:  this.thisCollection)) / ((float)MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionNextUnlockCost(collection:  this.thisCollection));
        goto label_21;
        label_14:
        val_37 = 0f;
        label_21:
        List.Enumerator<T> val_15 = MonoSingleton<WGPortraitDataController>.Instance.GetPortraitNamesByCollection(collection:  this.thisCollection).GetEnumerator();
        label_34:
        val_38 = public System.Boolean List.Enumerator<System.String>::MoveNext();
        if(val_17.MoveNext() == false)
        {
            goto label_22;
        }
        
        val_39 = this.myPortraits;
        if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
        val_38 = val_16;
        if((val_39.ContainsKey(key:  val_38)) != false)
        {
                val_39 = this.myPortraits;
            if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
            val_40 = val_39.Item[val_16];
        }
        else
        {
                val_39 = this.allPortraitsSection;
            if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
            val_38 = val_39.transform;
            val_40 = UnityEngine.Object.Instantiate<PortraitCollectionPortraitItem>(original:  this.portraitPrefab, parent:  val_38);
            val_39 = this.myPortraits;
            if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
            val_38 = val_16;
            val_39.Add(key:  val_38, value:  val_40);
            if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
            val_38 = 0;
            UnityEngine.GameObject val_23 = val_40.gameObject;
            if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
            val_23.SetActive(value:  false);
        }
        
        val_39 = val_16;
        val_38 = val_36;
        if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
        val_40.Init(portraitName:  val_16, unlocked:  val_4.Contains(item:  val_16), inUse:  System.String.op_Equality(a:  val_6.Portrait_ID, b:  val_16), progress:  ((System.String.op_Equality(a:  val_39, b:  val_38)) != true) ? (val_37) : 0f);
        goto label_34;
        label_22:
        val_17.Dispose();
        this.collectionPortrait.InitCollection(collectionName:  this.thisCollection, unlocked:  ((val_2 + 24) == (val_4 + 24)) ? 1 : 0, inUse:  System.String.op_Equality(a:  val_6.Portrait_ID, b:  MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionRewardPotrait(collection:  this.thisCollection)), progress:  val_37);
        this.hasInitCollection = true;
    }
    private void PopulateStarterSet()
    {
        PortraitCollectionPortraitItem val_18;
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        SLC.Social.Profile val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        int val_6 = SLC.Social.Leagues.LeaguesUIManager.memberAvatarHandler.AvatarSpritesCount;
        if(val_6 > 0)
        {
                do
        {
            if((this.myPortraits.ContainsKey(key:  0.ToString())) != false)
        {
                val_18 = this.myPortraits.Item[0.ToString()];
        }
        else
        {
                val_18 = UnityEngine.Object.Instantiate<PortraitCollectionPortraitItem>(original:  this.portraitPrefab, parent:  this.allPortraitsSection.transform);
            this.myPortraits.Add(key:  0.ToString(), value:  val_18);
            val_18.gameObject.SetActive(value:  false);
        }
        
            val_18.Init(Id:  0, inUse:  (System.String.op_Equality(a:  val_2.Portrait_ID, b:  System.String.alignConst)) & ((val_4.AvatarId == 0) ? 1 : 0));
        }
        while(1 < val_6);
        
        }
        
        val_18.bottom = 100;
        this.hasInitCollection = true;
    }
    private void UpdateMyAvatar()
    {
        float val_21;
        SLC.Social.Profile val_6 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        val_21 = 0f;
        if((MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionCurrentProgress(collection:  this.thisCollection)) >= 1)
        {
                string val_10 = MonoSingleton<FPHPortraitCollectionController>.Instance.GetNextUnlockedPortrait(collection:  this.thisCollection);
            val_21 = ((float)MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionCurrentProgress(collection:  this.thisCollection)) / ((float)MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionNextUnlockCost(collection:  this.thisCollection));
        }
        
        this.collectionPortrait.InitCollection(collectionName:  this.thisCollection, unlocked:  ((MonoSingleton<WGPortraitDataController>.Instance.GetPortraitNamesByCollection(collection:  this.thisCollection)) == (MonoSingleton<WGPortraitDataController>.Instance.GetUnlockedPortraitsByCollection(collection:  this.thisCollection))) ? 1 : 0, inUse:  System.String.op_Equality(a:  val_6.Portrait_ID, b:  MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionRewardPotrait(collection:  this.thisCollection)), progress:  val_21);
    }
    public void OnAvatarChanged()
    {
        if(this.hasInitCollection == false)
        {
            goto label_1;
        }
        
        if((System.String.op_Equality(a:  this.thisCollection, b:  "DEFAULT")) == false)
        {
            goto label_2;
        }
        
        this.PopulateStarterSet();
        return;
        label_1:
        this.UpdateMyAvatar();
        return;
        label_2:
        this.PopulateCollection();
    }
    private void OnDisable()
    {
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnAvatarChanged");
    }
    public PortraitCollectionCollectionItem()
    {
        this.defaultSize = 466f;
        this.expandToSize = 1250f;
    }
    private void <Init>b__16_0()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.OnExpandClicked());
    }
    private void <InitDefaultCollection>b__17_0()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.OnExpandClicked());
    }

}
