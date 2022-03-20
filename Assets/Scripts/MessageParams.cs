using UnityEngine;
[Serializable]
public class MessageParams
{
    // Fields
    public string Message;
    public PromptType Prompt;
    public bool Localize;
    
    // Methods
    public MessageParams()
    {
        this.Message = "";
    }
    public MessageParams(string message, PromptType prompt, bool localize)
    {
        this.Message = "";
        this.Message = message;
        this.Prompt = prompt;
        this.Localize = localize;
    }
    public override string ToString()
    {
        this.Prompt = this.Prompt;
        return System.String.Format(format:  "[MessageParams] Message={0}, Prompt={1}, Localize={2}", arg0:  this.Message, arg1:  this.Prompt.ToString(), arg2:  this.Localize.ToString());
    }

}
