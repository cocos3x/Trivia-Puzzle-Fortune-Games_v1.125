using UnityEngine;

namespace Helpshift
{
    public static class HelpshiftJSONUtility
    {
        // Methods
        public static Helpshift.HelpshiftUser getHelpshiftUser(string serializedJSONHelpshiftUser)
        {
            object val_1 = Json.Parser.Parse(jsonString:  serializedJSONHelpshiftUser);
            .identifier = System.Convert.ToString(value:  val_1.Item["identifier"]);
            .email = System.Convert.ToString(value:  val_1.Item["email"]);
            .name = System.Convert.ToString(value:  val_1.Item["name"]);
            .authToken = System.Convert.ToString(value:  val_1.Item["authToken"]);
            return new HelpshiftUser.Builder().build();
        }
        public static Helpshift.HelpshiftAuthFailureReason getAuthFailureReason(string serializedJSONAuthFailure)
        {
            var val_6;
            string val_3 = System.Convert.ToString(value:  Json.Parser.Parse(jsonString:  serializedJSONAuthFailure).Item["authFailureReason"]);
            if((Equals(value:  val_3)) != false)
            {
                    val_6 = 0;
                return (Helpshift.HelpshiftAuthFailureReason)val_6;
            }
            
            bool val_5 = Equals(value:  val_3);
            val_6 = 1;
            return (Helpshift.HelpshiftAuthFailureReason)val_6;
        }
        public static Helpshift.HelpshiftUserAction getUserActionData(string serializedUserActionData)
        {
            object val_1 = Json.Parser.Parse(jsonString:  serializedUserActionData);
            .actionType = System.Convert.ToString(value:  val_1.Item["actionType"]);
            .actionData = System.Convert.ToString(value:  val_1.Item["actionData"]);
            return (Helpshift.HelpshiftUserAction)new Helpshift.HelpshiftUserAction();
        }
    
    }

}
