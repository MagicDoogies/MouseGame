using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentCaughtBug : MonoBehaviour
{
    //The only purpose of this script is to store information about the current caught bug before clearing itself for the next caught bug.

    public string bugName;//reference container for the bugs name.
    public string bugBlock;//reference container for the bug's execution block.

    public void Start()
    {
        if (bugName == "" && bugBlock== "")
        {
            bugName = "Nothing";
            bugBlock = "Nothing";
        }
    }
    public void ClearValues()//When this function is activated, set values to the string "Nothing".
    {

        bugName = "Nothing";//clears the string 'bugName'.
        bugBlock = "Nothing";//clears the string 'bugBlock'.
    }
}
