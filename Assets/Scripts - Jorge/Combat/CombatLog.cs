using System.Collections.Generic;
using UnityEngine;

public class CombatLog : MonoBehaviour
{
    public Stack<string> History =
        new Stack<string>();

    public void AddEntry(string text)
    {
        History.Push(text);

        Debug.Log(text);
    }

    public string GetLastAction()
    {
        if (History.Count == 0)
            return "No actions";

        return History.Peek();
    }
}
