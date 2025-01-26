using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] GameInfoObj gameInfoObj;

    public PlayableDirector director;
    public int nextSceneID;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneID = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseTimeline()
    {
        director.Pause();
    }

    public void ResumeTimeline()
    {
        if (director.state == PlayState.Paused)
        {
            director.Play();
        }
    }

    public void SetNextSceneID(int sceneID)
    {
        nextSceneID = sceneID;
    }
    public void SetNextSceneIDRandom()
    {
        if (gameInfoObj.currentLevel == 5)
            nextSceneID = Random.Range(2, 6);
        else
            nextSceneID = gameInfoObj.currentLevel + 1;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(nextSceneID);
    }
}
