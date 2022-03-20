using UnityEngine;
public abstract class UIListViewController : MonoBehaviour
{
    // Fields
    private System.Collections.IEnumerator creating;
    private System.Collections.IEnumerator populating;
    protected int curr_total;
    protected UnityEngine.Transform gridRootTransform;
    protected System.Collections.Generic.List<UnityEngine.GameObject> memberGridItems;
    public System.Action<bool> OnToggleLoadingUI;
    public System.Action<bool> OnFinishedUIUpdate;
    public System.Action<bool> OnFinishedUISetup;
    
    // Methods
    protected abstract UnityEngine.GameObject GetMemberItemPrefab(); // 0
    private void UICoroutineStart(ref System.Collections.IEnumerator coroutineRef, System.Collections.IEnumerator target)
    {
        if(coroutineRef != null)
        {
                this.StopCoroutine(routine:  coroutineRef);
            coroutineRef = 0;
        }
        
        coroutineRef = target;
        UnityEngine.Coroutine val_1 = this.StartCoroutine(routine:  target);
    }
    private void UICoroutineStop(ref System.Collections.IEnumerator coroutineRef)
    {
        if(coroutineRef == null)
        {
                return;
        }
        
        this.StopCoroutine(routine:  coroutineRef);
        coroutineRef = 0;
    }
    protected void StopCoroutines()
    {
        if(this.populating != null)
        {
                this.StopCoroutine(routine:  this.populating);
            this.populating = 0;
        }
        
        if(this.creating == null)
        {
                return;
        }
        
        this.StopCoroutine(routine:  this.creating);
        this.creating = 0;
    }
    private void ToggleLoadingPopup(bool state)
    {
        if(this.OnToggleLoadingUI != null)
        {
                state = state;
            this.OnToggleLoadingUI.Invoke(obj:  state);
            return;
        }
        
        UnityEngine.Debug.LogWarning(message:  "No Loading Action", context:  this);
    }
    protected void OnDisable()
    {
        if(this.creating == null)
        {
                if(this.populating == null)
        {
                return;
        }
        
        }
        
        this.ToggleLoadingPopup(state:  false);
        if(this.populating != null)
        {
                this.StopCoroutine(routine:  this.populating);
            this.populating = 0;
        }
        
        if(this.creating == null)
        {
                return;
        }
        
        this.StopCoroutine(routine:  this.creating);
        this.creating = 0;
    }
    protected void UpdateMembersGrid()
    {
        var val_6;
        if(this.gameObject.activeInHierarchy == false)
        {
            goto label_2;
        }
        
        val_6 = this;
        if(W9 >= this.curr_total)
        {
            goto label_4;
        }
        
        if(this.creating != null)
        {
                return;
        }
        
        System.Collections.IEnumerator val_3 = this.CreateGridItems();
        goto label_6;
        label_2:
        UnityEngine.Debug.LogWarning(message:  "can\'t update members grid: not active!");
        return;
        label_4:
        if(this.creating != null)
        {
                return;
        }
        
        val_6 = this;
        System.Collections.IEnumerator val_5 = this.populating;
        if(val_5 != null)
        {
                return;
        }
        
        label_6:
        this.UICoroutineStart(coroutineRef: ref  val_5, target:  this.SetupExistingGridItems());
    }
    private System.Collections.IEnumerator CreateGridItems()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new UIListViewController.<CreateGridItems>d__15();
    }
    private System.Collections.IEnumerator SetupExistingGridItems()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new UIListViewController.<SetupExistingGridItems>d__16();
    }
    protected virtual void SetupGridItem(int i)
    {
        UnityEngine.Debug.LogError(message:  "Base SetupGridItemCalled", context:  this);
    }
    protected UIListViewController()
    {
        this.memberGridItems = new System.Collections.Generic.List<UnityEngine.GameObject>();
    }

}
