using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Critter", menuName = "Critter", order = 1)]

public class CrittersTwo : ScriptableObject
{
    

    // Start is called before the first frame update
    public string funnyName;
    [TextArea(5, 5)]
    public string critterDescription;
    public GameObject critterModel;
    public int attackPower;

}
