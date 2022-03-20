using UnityEngine;
[Serializable]
public class SerializableKeyValuePair<TKey, TValue>
{
    // Fields
    public TKey Key;
    public TValue Value;
    
    // Methods
    public SerializableKeyValuePair<TKey, TValue>()
    {
        if(this != null)
        {
                return;
        }
        
        throw new NullReferenceException();
    }

}
