using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneByIndex : MonoBehaviour
{
    public int sceneIndexToLoad = 1; // Set the desired scene index in the Inspector
    public Button buttonToLoadScene; // Reference to the button in the Inspector

    private void Start()
    {
        buttonToLoadScene.onClick.AddListener(LoadSceneByIndexOnClick);
    }

    public void LoadSceneByIndexOnClick()
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }
}
