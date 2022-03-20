using UnityEngine;

namespace SLC.Social
{
    public class SocialManager : MonoSingleton<SLC.Social.SocialManager>
    {
        // Fields
        private static string[] _Adjectives;
        private static string[] _Nouns;
        private const int MAX_AVATARS = 25;
        
        // Properties
        public static string ProfileName { get; }
        public static int AvatarID { get; }
        public static string PortraitID { get; }
        
        // Methods
        public static string GetRandomProfileName()
        {
            null = null;
            int val_2 = SLC.Social.SocialManager.MAX_AVATARS + ((UnityEngine.Random.Range(min:  0, max:  SLC.Social.SocialManager.MAX_AVATARS + 24)) << 3);
            System.String[] val_4 = SLC.Social.SocialManager._Nouns + ((UnityEngine.Random.Range(min:  0, max:  SLC.Social.SocialManager._Nouns.Length)) << 3);
            return System.String.Format(format:  "{0} {1}", arg0:  (SLC.Social.SocialManager.MAX_AVATARS + (val_1) << 3) + 32, arg1:  (SLC.Social.SocialManager._Nouns + (val_3) << 3) + 32);
        }
        public static void ResetProfileName()
        {
            Player val_1 = App.Player;
            val_1.properties._profile_name = SLC.Social.SocialManager.GetRandomProfileName();
            Player val_3 = App.Player;
            val_3.properties.Save(writePrefs:  true);
        }
        public static string get_ProfileName()
        {
            string val_11;
            if((MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance) == 0)
            {
                goto label_5;
            }
            
            SLC.Social.Profile val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            if((val_4.Name.Equals(value:  "Player")) == false)
            {
                goto label_11;
            }
            
            label_5:
            Player val_6 = App.Player;
            if((val_6.properties._profile_name.Equals(value:  "Player")) != false)
            {
                    SLC.Social.SocialManager.ResetProfileName();
            }
            
            Player val_8 = App.Player;
            val_11 = val_8.properties._profile_name;
            return (string)mem[val_10.Name];
            label_11:
            SLC.Social.Profile val_10 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            val_11 = val_10.Name;
            return (string)mem[val_10.Name];
        }
        public static int GetRandomAvatarID()
        {
            return UnityEngine.Random.Range(min:  0, max:  25);
        }
        private static void ResetProfileAvatar()
        {
            Player val_1 = App.Player;
            val_1.properties.profile_avatar_id = UnityEngine.Random.Range(min:  0, max:  25);
            Player val_3 = App.Player;
            val_3.properties.Save(writePrefs:  true);
        }
        public static int get_AvatarID()
        {
            int val_10;
            if((MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance) != 0)
            {
                    SLC.Social.Profile val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
                if((val_4.Name.Equals(value:  "Player")) != false)
            {
                    SLC.Social.Profile val_7 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
                val_10 = val_7.AvatarId;
                return val_10;
            }
            
            }
            
            Player val_8 = App.Player;
            if(val_8.properties.profile_avatar_id == 1)
            {
                    SLC.Social.SocialManager.ResetProfileAvatar();
            }
            
            Player val_9 = App.Player;
            val_10 = val_9.properties.profile_avatar_id;
            return val_10;
        }
        public static string get_PortraitID()
        {
            string val_8;
            if((MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance) == 0)
            {
                    return (string)System.String.__il2cppRuntimeField_static_fields;
            }
            
            SLC.Social.Profile val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            if((val_4.Name.Equals(value:  "Player")) == false)
            {
                    return (string)System.String.__il2cppRuntimeField_static_fields;
            }
            
            SLC.Social.Profile val_7 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            val_8 = val_7.Portrait_ID;
            return (string)System.String.__il2cppRuntimeField_static_fields;
        }
        public SocialManager()
        {
        
        }
        private static SocialManager()
        {
            int val_3;
            int val_4;
            string[] val_1 = new string[106];
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[0] = "Clever";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 1)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[1] = "Charming";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 2)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[2] = "Lucky";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 3)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[3] = "Blessed";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 4)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[4] = "Upscale";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 5)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[5] = "Opulent";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 6)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[6] = "Likable";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 7)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[7] = "Sweet";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 8)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[8] = "Alluring";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 9)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[9] = "Magnetic";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 10)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[10] = "Golden";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 11)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[11] = "Elite";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 12)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[12] = "Brainy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 13)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[13] = "Brilliant";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 14)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[14] = "Handsome";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 15)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[15] = "Pretty";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 16)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[16] = "Foxy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 17)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[17] = "Savvy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 18)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[18] = "Pro";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 19)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[19] = "Wise";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 20)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[20] = "Witty";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 21)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[21] = "Smart";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 22)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[22] = "Sprightly";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 23)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[23] = "Slick";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 24)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[24] = "Cunning";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 25)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[25] = "Subtle";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 26)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[26] = "Bright";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 27)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[27] = "Crazy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 28)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[28] = "Cuddly";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 29)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[29] = "Racy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 30)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[30] = "Spicy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 31)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[31] = "Slinky";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 32)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[32] = "Warm";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 33)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[33] = "Cool";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 34)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[34] = "Smooth";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 35)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[35] = "Smarmy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 36)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[36] = "Wintry";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 37)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[37] = "Tranquil";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 38)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[38] = "Dreamy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 39)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[39] = "Liberal";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 40)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[40] = "Carefree";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 41)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[41] = "Sparkly";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 42)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[42] = "Exotic";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 43)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[43] = "Tender";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 44)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[44] = "Wild";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 45)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[45] = "Daring";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 46)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[46] = "Loving";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 47)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[47] = "Poetic";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 48)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[48] = "Gentle";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 49)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[49] = "Romantic";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 50)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[50] = "Ardent";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 51)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[51] = "Sultry";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 52)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[52] = "Fervent";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 53)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[53] = "Devout";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 54)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[54] = "Pious";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 55)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[55] = "Hearty";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 56)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[56] = "Eager";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 57)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[57] = "Fiery";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 58)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[58] = "Wishful";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 59)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[59] = "Heated";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 60)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[60] = "Zealous";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 61)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[61] = "Fierce";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 62)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[62] = "Strong";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 63)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[63] = "Powerful";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 64)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[64] = "Earnest";
            if(31095380 != 0)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
            if(val_1.Length <= 65)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[65] = 31095380;
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 66)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[66] = "Bold";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 67)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[67] = "Stormy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 68)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[68] = "Untamed";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 69)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[69] = "Mighty";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 70)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[70] = "Neon";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 71)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[71] = "Flying";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 72)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[72] = "Tricky";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 73)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[73] = "Sturdy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 74)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[74] = "Zen";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 75)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[75] = "Rosy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 76)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[76] = "Flowery";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 77)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[77] = "Major";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 78)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[78] = "Cosmic";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 79)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[79] = "Blazing";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 80)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[80] = "Mega";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 81)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[81] = "Delicate";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 82)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[82] = "Elegant";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 83)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[83] = "Fragile";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 84)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[84] = "Rare";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 85)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[85] = "Soft";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 86)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[86] = "Profound";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 87)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[87] = "Flawless";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 88)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[88] = "Fine";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 89)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[89] = "Great";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 90)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[90] = "Grand";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 91)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[91] = "Superior";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 92)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[92] = "Lovely";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 93)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[93] = "Ornate";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 94)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[94] = "Dapper";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 95)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[95] = "Stylish";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 96)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[96] = "Noble";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 97)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[97] = "Chic";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 98)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[98] = "Classy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length <= 99)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[99] = "Jazzy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_3 = val_1.Length;
            if(val_3 <= 100)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[100] = "Nifty";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_3 = val_1.Length;
            if(val_3 <= 101)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[101] = "Trendy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_3 = val_1.Length;
            if(val_3 <= 102)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[102] = "Dashing";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_3 = val_1.Length;
            if(val_3 <= 103)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[103] = "Ritzy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_3 = val_1.Length;
            if(val_3 <= 104)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[104] = "Sassy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_3 = val_1.Length;
            if(val_3 <= 105)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[105] = "Showy";
            SLC.Social.SocialManager.MAX_AVATARS = val_1;
            string[] val_2 = new string[100];
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_2.Length;
            if(val_4 == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[0] = "Gambler";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 1)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[1] = "Cowgirl";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 2)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[2] = "Cowboy";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 3)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[3] = "Mistress";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 4)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[4] = "Master";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 5)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[5] = "Captain";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 6)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[6] = "Momma";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 7)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[7] = "Papa";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 8)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[8] = "Alien";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 9)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[9] = "Artist";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 10)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[10] = "Guru";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 11)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[11] = "Maestro";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 12)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[12] = "Savant";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 13)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[13] = "Maven";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 14)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[14] = "Mermaid";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 15)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[15] = "Merman";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 16)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[16] = "Angel";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 17)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[17] = "Wrangler";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 18)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[18] = "Officer";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 19)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[19] = "King";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 20)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[20] = "Queen";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 21)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[21] = "Soldier";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 22)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[22] = "Winner";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 23)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[23] = "Coach";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 24)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[24] = "Viking";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 25)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[25] = "Elf";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 26)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[26] = "Lioness";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 27)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[27] = "Puma";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 28)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[28] = "Warrior";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 29)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[29] = "Ruler";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 30)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[30] = "Chief";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 31)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[31] = "Highroller";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 32)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[32] = "Biker";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 33)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[33] = "Gangster";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 34)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[34] = "Princess";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 35)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[35] = "Prince";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 36)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[36] = "Jester";
            if((public System.Boolean System.Net.WebRequest::get_UseDefaultCredentials()) != 0)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
                val_4 = val_4;
            }
            
            if(val_4 <= 37)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[37] = 1152921519632480208;
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 38)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[38] = "Pioneer";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 39)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[39] = "Goddess";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 40)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[40] = "Mayor";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            if(val_4 <= 41)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_2[41] = "Player";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_4 = val_4;
            val_2[42] = "Aardvark";
            val_4 = val_4;
            val_2[43] = "Alpaca";
            val_4 = val_4;
            val_2[44] = "Llama";
            val_4 = val_4;
            val_2[45] = "Badger";
            val_4 = val_4;
            val_2[46] = "Dolphin";
            val_4 = val_4;
            val_2[47] = "Unicorn";
            val_4 = val_4;
            val_2[48] = "Koala";
            val_4 = val_4;
            val_2[49] = "Coyote";
            val_4 = val_4;
            val_2[50] = "Falcon";
            val_4 = val_4;
            val_2[51] = "Goose";
            val_4 = val_4;
            val_2[52] = "Jackal";
            val_4 = val_4;
            val_2[53] = "Jaguar";
            val_4 = val_4;
            val_2[54] = "Magpie";
            val_4 = val_4;
            val_2[55] = "Panther";
            val_4 = val_4;
            val_2[56] = "Wizard";
            val_4 = val_4;
            val_2[57] = "Raven";
            val_4 = val_4;
            val_2[58] = "Seahorse";
            val_4 = val_4;
            val_2[59] = "Swan";
            val_4 = val_4;
            val_2[60] = "Bandit";
            val_4 = val_4;
            val_2[61] = "Heiress";
            val_4 = val_4;
            val_2[62] = "Prodigy";
            val_4 = val_4;
            val_2[63] = "Egghead";
            val_4 = val_4;
            val_2[64] = "Celeb";
            val_4 = val_4;
            val_2[65] = "Hotshot";
            val_4 = val_4;
            val_2[66] = "Superstar";
            val_4 = val_4;
            val_2[67] = "Aviator";
            val_4 = val_4;
            val_2[68] = "Magnate";
            val_4 = val_4;
            val_2[69] = "Bigwig";
            val_4 = val_4;
            val_2[70] = "Hero";
            val_4 = val_4;
            val_2[71] = "Daredevil";
            val_4 = val_4;
            val_2[72] = "Heroine";
            val_4 = val_4;
            val_2[73] = "Pirate";
            val_4 = val_4;
            val_2[74] = "Outlaw";
            val_4 = val_4;
            val_2[75] = "Pilgrim";
            val_4 = val_4;
            val_2[76] = "Settler";
            val_4 = val_4;
            val_2[77] = "Jewel";
            val_4 = val_4;
            val_2[78] = "Duke";
            val_4 = val_4;
            val_2[79] = "Baron";
            val_4 = val_4;
            val_2[80] = "Dame";
            val_4 = val_4;
            val_2[81] = "Lady";
            val_4 = val_4;
            val_2[82] = "Knight";
            val_4 = val_4;
            val_2[83] = "Admiral";
            val_4 = val_4;
            val_2[84] = "Deacon";
            val_4 = val_4;
            val_2[85] = "Diva";
            val_4 = val_4;
            val_2[86] = "Mystic";
            val_4 = val_4;
            val_2[87] = "Saint";
            val_4 = val_4;
            val_2[88] = "Sister";
            val_4 = val_4;
            val_2[89] = "Prophet";
            val_4 = val_4;
            val_2[90] = "Lotus";
            val_4 = val_4;
            val_2[91] = "Pharaoh";
            val_4 = val_4;
            val_2[92] = "Turtle";
            val_4 = val_4;
            val_2[93] = "Bunny";
            val_4 = val_4;
            val_2[94] = "Mogul";
            val_4 = val_4;
            val_2[95] = "Tycoon";
            val_4 = val_4;
            val_2[96] = "Empress";
            val_4 = val_4;
            val_2[97] = "Czar";
            val_4 = val_4;
            val_2[98] = "Butterfly";
            val_4 = val_4;
            val_2[99] = "Ladybug";
            SLC.Social.SocialManager._Nouns = val_2;
        }
    
    }

}
