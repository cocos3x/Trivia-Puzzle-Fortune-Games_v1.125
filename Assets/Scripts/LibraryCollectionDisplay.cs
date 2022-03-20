using UnityEngine;
public class LibraryCollectionDisplay : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button button_collection;
    private UnityEngine.UI.Text text_name;
    private UnityEngine.UI.Text text_score;
    private UnityEngine.UI.Text text_books;
    private string currentCollection;
    
    // Methods
    private void Awake()
    {
        this.button_collection.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LibraryCollectionDisplay::OnCollectionClicked()));
    }
    public void Setup(string name, int score, int numBooks)
    {
        this.currentCollection = name;
        string val_1 = name.ToUpper();
        string val_2 = score.ToString();
        string val_3 = numBooks.ToString();
    }
    private void OnCollectionClicked()
    {
        TheLibraryUI.ShowTheLibraryCollection(collectionName:  this.currentCollection, trackLibraryAccessed:  false);
    }
    public LibraryCollectionDisplay()
    {
        this.currentCollection = "";
    }

}
