using UnityEngine;

namespace LitJson
{
    public class JsonException : ApplicationException
    {
        // Methods
        public JsonException()
        {
        
        }
        internal JsonException(LitJson.ParserToken token)
        {
            string val_1 = System.String.Format(format:  "Invalid token \'{0}\' in input string", arg0:  token);
        }
        internal JsonException(LitJson.ParserToken token, System.Exception inner_exception)
        {
            string val_1 = System.String.Format(format:  "Invalid token \'{0}\' in input string", arg0:  token);
        }
        internal JsonException(int c)
        {
            string val_1 = System.String.Format(format:  "Invalid character \'{0}\' in input string", arg0:  c);
        }
        internal JsonException(int c, System.Exception inner_exception)
        {
            string val_1 = System.String.Format(format:  "Invalid character \'{0}\' in input string", arg0:  c);
        }
        public JsonException(string message)
        {
        
        }
        public JsonException(string message, System.Exception inner_exception)
        {
        
        }
    
    }

}
