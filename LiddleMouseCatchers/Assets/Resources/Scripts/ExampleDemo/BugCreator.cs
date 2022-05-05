using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BugCreator : MonoBehaviour
{
    public Critters bug;
    public TextMeshProUGUI bugText;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bug.bugModel, new Vector3(0,0,0), Quaternion.identity);

        bugText.text = bug.bugName;
    }

    
}
