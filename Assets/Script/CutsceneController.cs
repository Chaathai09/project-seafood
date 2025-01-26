using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
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
        nextSceneID = Random.Range(1, 6);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(nextSceneID);
    }
}
