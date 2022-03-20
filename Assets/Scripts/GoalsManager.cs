using UnityEngine;
public class GoalsManager : MonoSingleton<GoalsManager>
{
    // Fields
    protected System.Action<bool> OnAttackCompleted;
    protected System.Action<bool> OnRaidCompleted;
    protected System.Action OnLevelUpStructure;
    protected System.Action<int> OnEventIconCollected;
    
    // Methods
    public void AddAttackCompletedListener(System.Action<bool> listener)
    {
        System.Delegate val_1 = System.Delegate.Combine(a:  this.OnAttackCompleted, b:  listener);
        if(val_1 != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        this.OnAttackCompleted = val_1;
        return;
        label_2:
    }
    public void RemoveAttackCompletedListener(System.Action<bool> listener)
    {
        System.Delegate val_1 = System.Delegate.Remove(source:  this.OnAttackCompleted, value:  listener);
        if(val_1 != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        this.OnAttackCompleted = val_1;
        return;
        label_2:
    }
    public void NotifyAttackCompleted(bool isAttackSuccessful)
    {
        if(this.OnAttackCompleted == null)
        {
                return;
        }
        
        isAttackSuccessful = isAttackSuccessful;
        this.OnAttackCompleted.Invoke(obj:  isAttackSuccessful);
    }
    public void AddRaidCompletedListener(System.Action<bool> listener)
    {
        System.Delegate val_1 = System.Delegate.Combine(a:  this.OnRaidCompleted, b:  listener);
        if(val_1 != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        this.OnRaidCompleted = val_1;
        return;
        label_2:
    }
    public void RemoveRaidCompletedListener(System.Action<bool> listener)
    {
        System.Delegate val_1 = System.Delegate.Remove(source:  this.OnRaidCompleted, value:  listener);
        if(val_1 != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        this.OnRaidCompleted = val_1;
        return;
        label_2:
    }
    public void NotifyRaidCompleted(bool isRaidPerfect)
    {
        if(this.OnRaidCompleted == null)
        {
                return;
        }
        
        isRaidPerfect = isRaidPerfect;
        this.OnRaidCompleted.Invoke(obj:  isRaidPerfect);
    }
    public void AddLevelUpStructureListener(System.Action listener)
    {
        System.Delegate val_1 = System.Delegate.Combine(a:  this.OnLevelUpStructure, b:  listener);
        if(val_1 != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        this.OnLevelUpStructure = val_1;
        return;
        label_2:
    }
    public void RemoveLevelUpStructureListener(System.Action listener)
    {
        System.Delegate val_1 = System.Delegate.Remove(source:  this.OnLevelUpStructure, value:  listener);
        if(val_1 != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        this.OnLevelUpStructure = val_1;
        return;
        label_2:
    }
    public void NotifyLevelUpStructure()
    {
        if(this.OnLevelUpStructure == null)
        {
                return;
        }
        
        this.OnLevelUpStructure.Invoke();
    }
    public void AddEventIconCollectedListener(System.Action<int> listener)
    {
        System.Delegate val_1 = System.Delegate.Combine(a:  this.OnEventIconCollected, b:  listener);
        if(val_1 != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        this.OnEventIconCollected = val_1;
        return;
        label_2:
    }
    public void RemoveEventIconCollectedListener(System.Action<int> listener)
    {
        System.Delegate val_1 = System.Delegate.Remove(source:  this.OnEventIconCollected, value:  listener);
        if(val_1 != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        this.OnEventIconCollected = val_1;
        return;
        label_2:
    }
    public void NotifyEventIconCollected(int amtCollected)
    {
        if(this.OnEventIconCollected == null)
        {
                return;
        }
        
        this.OnEventIconCollected.Invoke(obj:  amtCollected);
    }
    public GoalsManager()
    {
    
    }

}
