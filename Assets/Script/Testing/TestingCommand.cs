using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCommand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Running());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Running()
    {
        yield return CommandManager.instance.Execute("print");
        yield return CommandManager.instance.Execute("print_1p", "Hello World!");
        yield return CommandManager.instance.Execute("print_mp", "ABC", "DEF", "GHI");

        yield return CommandManager.instance.Execute("lambda");
        yield return CommandManager.instance.Execute("lambda_1p", "Hello World!");
        yield return CommandManager.instance.Execute("lambda_mp", "ABC", "DEF", "GHI");

        yield return CommandManager.instance.Execute("process");
        yield return CommandManager.instance.Execute("process_1p", "3");
        yield return CommandManager.instance.Execute("process_mp", "PABC", "PDEF", "PGHI");
    }

}
