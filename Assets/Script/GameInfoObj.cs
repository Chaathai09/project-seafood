using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameInfoSObj", menuName = "ScriptableObjects/GameInfoSCriptableObjectObj")]
public class GameInfoObj : ScriptableObject
{
    public int mainScore;

    public void AddScore(int score)
    {
        mainScore += score;
    }
}
