using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : EditorWindow
{
    // Start is called before the first frame update
    void Start()
    {

    }
        

    // Update is called once per frame
    public void OnEnable()
    {
        // Each editor window contains a root VisualElement object
        var root = rootVisualElement;
 
        var tree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Ui/test.uxml");
        var treeElement = tree.CloneTree();
 
        // Do not use .Query() for a single element.
        //Button button = treeElement.Query<Button>();
        // Use .Q():
        var button = treeElement.Q<Button>();
 
        button.clickable.clicked += () => Debug.Log("Clicked");
 
        root.Add(button);
    }
}
