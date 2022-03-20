using UnityEngine;
public class ZooTile
{
    // Fields
    public string name;
    public int requiredStars;
    public string funFact;
    
    // Methods
    public ZooTile(string name, int requiredStars, string funFact)
    {
        val_1 = new System.Object();
        this.name = name;
        this.requiredStars = requiredStars;
        this.funFact = val_1;
    }
    public override string ToString()
    {
        return (string)System.String.Format(format:  "name: {0}, requiredStars: {1}, funFact: {2}", arg0:  this.name, arg1:  this.requiredStars, arg2:  this.funFact);
    }

}
