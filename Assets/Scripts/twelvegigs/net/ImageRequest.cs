using UnityEngine;

namespace twelvegigs.net
{
    public class ImageRequest : JsonRequest
    {
        // Fields
        private string pathToLocalImage;
        private static string storagePath;
        private string _url;
        private string _path;
        private string _filename;
        private bool _showErrors;
        public UnityEngine.Texture2D imageTexture;
        public bool error;
        private byte[] lnBuffer;
        private byte[] lnFile;
        private System.Action<string, UnityEngine.Texture2D> _imgOnComplete;
        private System.Action onImageError;
        private bool _cached;
        private bool _save;
        private System.Collections.Generic.List<string> ValidImageContentTypes;
        
        // Properties
        public string PathToDownloadedImage { get; }
        
        // Methods
        public string get_PathToDownloadedImage()
        {
            return (string)this.pathToLocalImage;
        }
        private static string StoragePath()
        {
            return UnityEngine.Application.persistentDataPath;
        }
        public static bool ImageInLocal(string imgPath)
        {
            return System.IO.File.Exists(path:  UnityEngine.Application.persistentDataPath + "/scrapbooks/"("/scrapbooks/") + imgPath);
        }
        public static UnityEngine.Texture2D LoadLocally(string remoteURL, string fileName)
        {
            UnityEngine.Texture2D val_1 = new UnityEngine.Texture2D(width:  256, height:  256);
            bool val_5 = UnityEngine.ImageConversion.LoadImage(tex:  val_1, data:  System.IO.File.ReadAllBytes(path:  UnityEngine.Application.persistentDataPath + "/scrapbooks/"("/scrapbooks/") + fileName));
            return val_1;
        }
        public static bool LoadFromPreCache(string filename, out UnityEngine.Texture2D textureToSet)
        {
            UnityEngine.Texture2D val_10;
            int val_11;
            textureToSet = 0;
            textureToSet = UnityEngine.Resources.Load<UnityEngine.Texture2D>(path:  "data/umbrella/precached/"("data/umbrella/precached/") + filename.Replace(oldValue:  ".png", newValue:  "")(filename.Replace(oldValue:  ".png", newValue:  "")));
            if(CompanyDevices.Instance.CompanyDevice() == false)
            {
                    return UnityEngine.Object.op_Inequality(x:  textureToSet, y:  0);
            }
            
            val_10 = textureToSet;
            if(val_10 != 0)
            {
                    return UnityEngine.Object.op_Inequality(x:  textureToSet, y:  0);
            }
            
            object[] val_7 = new object[2];
            val_10 = val_7;
            val_11 = val_7.Length;
            val_10[0] = "data/umbrella/precached/"("data/umbrella/precached/") + filename.Replace(oldValue:  ".png", newValue:  "")(filename.Replace(oldValue:  ".png", newValue:  ""));
            val_11 = val_7.Length;
            val_10[1] = "not found!";
            UnityEngine.Debug.LogErrorFormat(format:  "{0} : precached image {1}", args:  val_7);
            return UnityEngine.Object.op_Inequality(x:  textureToSet, y:  0);
        }
        public ImageRequest(string url, string filename, System.Action<string, UnityEngine.Texture2D> imgComplete, System.Action imgError, bool showErrors = True, bool destroy = False, bool cached = True, bool save = True)
        {
            System.Collections.Generic.List<System.String> val_1 = 14390;
            this._showErrors = true;
            this._cached = true;
            this._save = true;
            this.pathToLocalImage = "";
            val_1 = new System.Collections.Generic.List<System.String>();
            val_1.Add(item:  "image/jpg");
            val_1.Add(item:  "image/jpeg");
            val_1.Add(item:  "image/png");
            this.ValidImageContentTypes = val_1;
            mem[1152921520046403648] = true;
            mem[1152921520046403728] = 20;
            this = new System.Object();
            this.pathToLocalImage = UnityEngine.Application.persistentDataPath + "/scrapbooks/"("/scrapbooks/") + filename;
            this._url = url;
            this._path = UnityEngine.Application.persistentDataPath + "/scrapbooks/"("/scrapbooks/");
            this._filename = filename;
            this._imgOnComplete = imgComplete;
            this.onImageError = imgError;
            this._showErrors = showErrors;
            mem[1152921520046403732] = destroy;
            this._cached = cached;
            this._save = save;
            mem[1152921520046403720] = new System.Action(object:  this, method:  System.Void twelvegigs.net.ImageRequest::wwwExecute());
            this.loadFromServer();
        }
        private void loadFromServer()
        {
            null = null;
            if(Reachable() != false)
            {
                    UnityEngine.GameObject val_2 = new UnityEngine.GameObject();
                val_2.name = this._url;
                val_3.Request = this;
                mem[1152921520046568984] = val_2.AddComponent<NetworkThreadingHandler>();
                return;
            }
            
            this.error = true;
            if(this.onImageError == null)
            {
                    return;
            }
            
            this.onImageError.Invoke();
        }
        public override void execute()
        {
            if(this != null)
            {
                    this.Invoke();
                return;
            }
            
            throw new NullReferenceException();
        }
        protected void wwwExecute()
        {
            UnityEngine.Coroutine val_2 = X19.StartCoroutine(routine:  this.downloadRemote(url:  this._url));
        }
        private System.Collections.IEnumerator downloadRemote(string url)
        {
            .<>1__state = 0;
            .url = url;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new ImageRequest.<downloadRemote>d__25();
        }
        public override void Cleanup()
        {
            mem[1152921520047074312] = 0;
            mem[1152921520047074328] = 0;
            mem[1152921520047074272] = 0;
            mem[1152921520047074280] = 0;
            this._imgOnComplete = 0;
        }
        public override void fireCallback()
        {
            var val_8;
            if(this._cached != true)
            {
                    this.imageTexture = 0;
            }
            
            if(this.error != false)
            {
                    mem[1152921520047247632] = 1;
                this.fireOnComplete();
                if(this.onImageError == null)
            {
                    return;
            }
            
                this.onImageError.Invoke();
                return;
            }
            
            if(this._save != false)
            {
                    System.IO.DirectoryInfo val_1 = new System.IO.DirectoryInfo(path:  this._path);
                if((val_1 & 1) == 0)
            {
                    val_8 = 0;
                val_1.Create();
            }
            
                System.IO.File.WriteAllBytes(path:  this._path + this._filename, bytes:  this.lnFile);
            }
            
            this.fireOnComplete();
        }
        private void fireOnComplete()
        {
            if(this._imgOnComplete != null)
            {
                    this._imgOnComplete.Invoke(arg1:  this._filename, arg2:  this.imageTexture);
            }
            
            this._imgOnComplete = 0;
        }
        private static ImageRequest()
        {
        
        }
    
    }

}
