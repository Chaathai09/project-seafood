using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] GameInfoObj gameInfoObj;
    public static SceneManagerScript Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep SceneManager persistent
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
           LoadScene(0);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No more scenes in build order!");
        }
    }

    public void NewGame(){
        gameInfoObj.currentLevel = 1;
        gameInfoObj.mainScore = 0;
        gameInfoObj.isPlayIntro = false;
        LoadNextScene();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}