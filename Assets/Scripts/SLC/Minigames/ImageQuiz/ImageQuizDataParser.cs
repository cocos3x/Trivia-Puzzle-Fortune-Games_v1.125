using UnityEngine;

namespace SLC.Minigames.ImageQuiz
{
    public class ImageQuizDataParser
    {
        // Fields
        private const string RESOURCE_PATH = "minigames/ImageQuiz/";
        private const string LEVELDATA_FILENAME = "image_quiz_data";
        private const string LEVELDATA_PP_SAVED = "PP_w4yt_saved";
        private const int LEVELDATA_COLUMNS = 3;
        
        // Methods
        public void Init()
        {
            this.LoadData(filename:  "image_quiz_data", ppSaveStr:  "PP_w4yt_saved", dataColumns:  3, processDataFunction:  new System.Action<System.String[]>(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizDataParser::ProcessArrayDataToMinigame(string[] data)));
        }
        public void LoadData(string filename, string ppSaveStr, int dataColumns, System.Action<string[]> processDataFunction)
        {
            if((UnityEngine.PlayerPrefs.HasKey(key:  ppSaveStr)) != true)
            {
                    System.IO.File.WriteAllText(path:  System.String.Format(format:  "{0}/{1}", arg0:  UnityEngine.Application.persistentDataPath, arg1:  filename), contents:  UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/ImageQuiz/"("minigames/ImageQuiz/") + filename).text);
                UnityEngine.PlayerPrefs.SetInt(key:  ppSaveStr, value:  1);
                bool val_7 = PrefsSerializationManager.SavePlayerPrefs();
            }
            
            this.LoadDataInMemory(filename:  filename, ppSaveStr:  0, dataColumns:  dataColumns, processDataFunction:  processDataFunction, firstLineIsHeader:  true);
        }
        private void LoadDataInMemory(string filename, string ppSaveStr, int dataColumns, System.Action<string[]> processDataFunction, bool firstLineIsHeader = True)
        {
            bool val_10 = firstLineIsHeader;
            char[] val_4 = new char[1];
            val_4[0] = Chars[0];
            System.String[] val_6 = System.IO.File.ReadAllText(path:  System.String.Format(format:  "{0}/{1}", arg0:  UnityEngine.Application.persistentDataPath, arg1:  filename)).Split(separator:  val_4);
            if(val_10 >= val_6.Length)
            {
                    return;
            }
            
            bool val_8 = val_10;
            do
            {
                if(val_9.Length == dataColumns)
            {
                    processDataFunction.Invoke(obj:  val_6.CSVLineParser(fileData:  val_6[val_8]));
            }
            
                val_10 = val_8 + 1;
            }
            while(val_10 < val_6.Length);
        
        }
        private string[] CSVLineParser(string fileData)
        {
            System.String[] val_2 = new System.Text.RegularExpressions.Regex(pattern:  ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))").Split(input:  fileData);
            if(val_2.Length < 1)
            {
                    return val_2;
            }
            
            var val_10 = 0;
            do
            {
                char[] val_3 = new char[2];
                val_3[0] = 32;
                val_3[0] = '"';
                string val_4 = val_2[val_10].TrimStart(trimChars:  val_3);
                mem2[0] = val_4;
                char[] val_5 = new char[1];
                val_5[0] = '';
                string val_6 = val_4.TrimEnd(trimChars:  val_5);
                mem2[0] = val_6;
                char[] val_7 = new char[1];
                val_7[0] = '"';
                mem2[0] = val_6.TrimEnd(trimChars:  val_7);
                val_10 = val_10 + 1;
            }
            while(val_10 < val_2.Length);
            
            return val_2;
        }
        private void ProcessArrayDataToMinigame(string[] data)
        {
            if(data.Length != 3)
            {
                    return;
            }
            
            .word = data[0];
            .imageUrl = data[1];
            MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizDataManager>.Instance.AddLevel(level:  new SLC.Minigames.ImageQuiz.QuizLevelData());
        }
        public ImageQuizDataParser()
        {
        
        }
    
    }

}
