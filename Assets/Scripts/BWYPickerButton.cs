using UnityEngine;
public class BWYPickerButton : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject ChooseCellGroup;
    private UnityEngine.GameObject ChooseShapeGroup;
    private UnityEngine.Transform chosenCell;
    
    // Methods
    public void Click()
    {
        this.OpenCellGroup();
        this.ChooseShapeGroup.SetActive(value:  false);
    }
    private void OpenCellGroup()
    {
        this.ChooseCellGroup.SetActive(value:  true);
        BlockPuzzleMagic.BlockShapeSpawner val_1 = MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance;
        if(val_1.ShapeContainers.Length < 1)
        {
                return;
        }
        
        var val_10 = 0;
        do
        {
            .<>4__this = this;
            UnityEngine.Transform val_9 = val_1.ShapeContainers[val_10];
            .cellContainer = val_9;
            UnityEngine.Debug.LogError(message:  "working on cell " + val_9.name);
            UnityEngine.UI.Button val_5 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.UI.Button>(child:  (BWYPickerButton.<>c__DisplayClass4_0)[1152921513413169520].cellContainer);
            val_5.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new BWYPickerButton.<>c__DisplayClass4_0(), method:  System.Void BWYPickerButton.<>c__DisplayClass4_0::<OpenCellGroup>b__0()));
            UnityEngine.Canvas val_8 = (BWYPickerButton.<>c__DisplayClass4_0)[1152921513413169520].cellContainer.gameObject.AddComponent<UnityEngine.Canvas>();
            val_8.overrideSorting = true;
            val_8.sortingLayerName = "Foreground";
            val_8.sortingOrder = 2;
            val_10 = val_10 + 1;
        }
        while(val_10 < val_1.ShapeContainers.Length);
    
    }
    private void OpenShapeGroup()
    {
        BlockPuzzleMagic.ShapeBlockSpawn val_5;
        var val_6;
        UnityEngine.GameObject val_14;
        UnityEngine.Transform val_15;
        this.ChooseCellGroup.SetActive(value:  false);
        this.ChooseShapeGroup.SetActive(value:  true);
        BlockPuzzleMagic.GameReferenceData val_1 = BlockPuzzleMagic.GameReferenceData.Instance;
        if(this.ChooseShapeGroup.transform.childCount != 0)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = val_1.shapeBlockList.ShapeBlocks.GetEnumerator();
        label_18:
        if(val_6.MoveNext() == false)
        {
            goto label_9;
        }
        
        BWYPickerButton.<>c__DisplayClass5_0 val_8 = null;
        val_15 = 0;
        val_8 = new BWYPickerButton.<>c__DisplayClass5_0();
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        .shape = val_5;
        .<>4__this = this;
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_14 = this.ChooseShapeGroup;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15 = val_14.transform;
        UnityEngine.GameObject val_10 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_5 + 24, parent:  val_15);
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15 = public UnityEngine.UI.Button UnityEngine.GameObject::AddComponent<UnityEngine.UI.Button>();
        if((val_10.AddComponent<UnityEngine.UI.Button>()) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Events.UnityAction val_12 = null;
        val_15 = val_8;
        val_12 = new UnityEngine.Events.UnityAction(object:  val_8, method:  System.Void BWYPickerButton.<>c__DisplayClass5_0::<OpenShapeGroup>b__0());
        if(val_11.m_OnClick == null)
        {
                throw new NullReferenceException();
        }
        
        val_11.m_OnClick.AddListener(call:  val_12);
        goto label_18;
        label_9:
        val_6.Dispose();
    }
    public void PickShape(BlockPuzzleMagic.ShapeBlockSpawn shape)
    {
        if(this.chosenCell.childCount >= 1)
        {
                MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.chosenCell);
        }
        
        this.ChooseShapeGroup.gameObject.SetActive(value:  false);
    }
    public void PickCell(UnityEngine.Transform cell)
    {
        UnityEngine.Transform val_9;
        BlockPuzzleMagic.BlockShapeSpawner val_1 = MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance;
        if(val_1.ShapeContainers.Length >= 1)
        {
                var val_9 = 0;
            do
        {
            val_9 = val_1.ShapeContainers[val_9];
            UnityEngine.Object.Destroy(obj:  val_9.gameObject.GetComponent<UnityEngine.UI.Button>());
            if((val_9.gameObject.GetComponent<UnityEngine.Canvas>()) != 0)
        {
                val_9 = val_9.gameObject.GetComponent<UnityEngine.Canvas>();
            UnityEngine.Object.Destroy(obj:  val_9);
        }
        
            val_9 = val_9 + 1;
        }
        while(val_9 < val_1.ShapeContainers.Length);
        
        }
        
        this.chosenCell = cell;
        this.OpenShapeGroup();
    }
    public BWYPickerButton()
    {
    
    }

}
