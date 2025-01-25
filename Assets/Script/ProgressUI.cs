using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProgressUI : MonoBehaviour
{
    [SerializeField] GameInfoObj gameInfoObj;
    int currentLevel = 1;
    public Image[] lights = new Image[5];
    public Sprite[] lightStatus = new Sprite[3];
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentLevel = gameInfoObj.currentLevel;
        switch (currentLevel)
        {
            case 1:
                SetLightStatus(lightStatus[1],lightStatus[2],lightStatus[2],lightStatus[2],lightStatus[2]);
                break;
            case 2:
                SetLightStatus(lightStatus[0],lightStatus[1],lightStatus[2],lightStatus[2],lightStatus[2]);
                break;
            case 3:
                SetLightStatus(lightStatus[0],lightStatus[0],lightStatus[1],lightStatus[2],lightStatus[2]);
                break;
            case 4:
                SetLightStatus(lightStatus[0],lightStatus[0],lightStatus[0],lightStatus[1],lightStatus[2]);
                break;
            case 5:
                SetLightStatus(lightStatus[0],lightStatus[0],lightStatus[0],lightStatus[0],lightStatus[1]);
                break;
        }
    }

    void SetLightStatus(Sprite l0, Sprite l1, Sprite l2, Sprite l3, Sprite l4)
    {
        lights[0].sprite = l0;
        lights[1].sprite = l1;
        lights[2].sprite = l2;
        lights[3].sprite = l3;
        lights[4].sprite = l4;
    }
}
