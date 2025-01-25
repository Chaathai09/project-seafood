using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMD_Database_Extension_Examples : CMD_Database_Extension
{
    new public static void Extend(CommandDatabase database)
    {
        database.AddCommand("print", new Action(PrintDefaultMessage));
        database.AddCommand("print_1p", new Action<string>(PrintUserMessage));
        database.AddCommand("print_mp", new Action<string[]>(PrintLines));

        database.AddCommand("lambda", new Action(() => { Debug.Log("Printing a default messsage to console from lambda command."); }));
        database.AddCommand("lambda_1p", new Action<string>((arg) => { Debug.Log($"Log User Message: '{arg}'"); ; }));
        database.AddCommand("lambda_mp", new Action<string[]>((args) => { Debug.Log(string.Join(", ", args)); }));

        database.AddCommand("process", new Func<IEnumerator>(SimpleProcess));
        database.AddCommand("process_1p", new Func<string, IEnumerator>(LineProcess));
        database.AddCommand("process_mp", new Func<string[], IEnumerator>(MultilineProcess));
    }

    private static void PrintDefaultMessage()
    {
        Debug.Log("Printing a default messsage to console.");
    }

    private static void PrintUserMessage(string messsage)
    {
        Debug.Log($"User Message: '{messsage}'");
    }

    private static void PrintLines(string[] lines)
    {
        int i = 1;
        foreach (string line in lines)
        {
            Debug.Log($"{i++}. '{line}'");
        }
    }

    private static IEnumerator SimpleProcess()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log($"Process Running... [{i}]");
            yield return new WaitForSeconds(1);
        }
    }

    private static IEnumerator LineProcess(string data)
    {
        if (int.TryParse(data, out int num))
        {
            for (int i = 0; i < num; i++)
            {
                Debug.Log($"Process Running... [{i}]");
                yield return new WaitForSeconds(1);
            }
        }

    }

    private static IEnumerator MultilineProcess(string[] data)
    {
       foreach (string line in data){
        Debug.Log($"Process Message: '{line}'");
        yield return new WaitForSeconds(0.5f);
       }
    }
}
