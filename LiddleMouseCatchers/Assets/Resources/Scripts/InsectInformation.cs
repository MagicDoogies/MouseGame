using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectInformation : MonoBehaviour
{
    //Attach this script to any prefab that is meant to serve as a unique insect scriptable object. 

    public Critters insectScriptableObject;// A place to put a reference to the Insect scriptable object. 
    private RheaMasterList rhea;
    
    public void Start()
    {
        rhea = GameObject.FindGameObjectWithTag("Rhea").GetComponent<RheaMasterList>();//Finds the gameobject with the tag "Rhea" and obtains it's 'Rhea MasterList' script.
    }
    public void GotCaught()
    {
        if (!rhea.insectList.Contains(insectScriptableObject))//If the scriptable object is not already in Rhea's list, add it.
        {
            rhea.insectList.Add(insectScriptableObject);//Adds the scriptable object to the to Rhea's masterlist list.
            Destroy(gameObject);//After two seconds, destroy the gameobj
        }
        
    }
    
}
