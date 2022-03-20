using UnityEngine;
public struct SpineAttachment.Hierarchy
{
    // Fields
    public string skin;
    public string slot;
    public string name;
    
    // Methods
    public SpineAttachment.Hierarchy(string fullPath)
    {
        char[] val_1 = new char[1];
        val_1[0] = '/';
        System.String[] val_2 = fullPath.Split(separator:  val_1, options:  1);
        if(val_2.Length != 0)
        {
                if(val_2.Length <= 1)
        {
                throw new System.Exception(message:  "Cannot generate Attachment Hierarchy from string! Not enough components! ["("Cannot generate Attachment Hierarchy from string! Not enough components! [") + ???(???) + "]");
        }
        
            this = val_2[0];
            this.slot = val_2[1];
            this.name = "";
            int val_9 = val_2.Length;
            if(val_9 < 3)
        {
                return;
        }
        
            val_9 = val_9 & 4294967295;
            var val_11 = 6;
            do
        {
            this.name = "" + val_2[2];
            val_11 = val_11 + 1;
        }
        while((val_11 - 3) < (val_2.Length << ));
        
            return;
        }
        
        this = "";
        this.slot = "";
        this.name = "";
    }

}
