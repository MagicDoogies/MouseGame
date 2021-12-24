using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Insect", menuName = "Insect", order = 1)]

public class Critters : ScriptableObject
{
    public string bugName;//Name of the bug.
    public string caughtBlockName;
    [TextArea(4, 5)]
    public string description;//Description of the bug.
    public string temperament;//The bug's temperament.
    
    public GameObject bugModel;//The model of the bug.
    public RheaMasterList list;

    
}
