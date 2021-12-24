using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Master List", menuName = "Insect List", order = 1)]

public class BugMasterList : ScriptableObject
{
    public List<GameObject> allBugs;// Contains all the bug prefabs.

    // Start is called before the first frame update
    void Start()
    {
        allBugs = new List<GameObject>();
    }

}
