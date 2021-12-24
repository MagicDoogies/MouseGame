using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class InsectCaught : MonoBehaviour
{
    /*public string insectName;*/
    public Flowchart overworldDialogue; //reference to the Overworld Dialogue flowchart.
    public Flowchart rheasDialogue;//reference to the Rhea Dialogue flowchart.
    public RheaMasterList rheasBugList; // reference to the Insect List in the RheaMasterList script.
    public CurrentCaughtBug bugTracker;// reference to the 'CurrentCaughtBug' script.
    public BugInstantiator bugInstantiator; //Reference to the 'bugInstantior' Gameobject;
    public bool bugacquired = false;
    

    public void Awake()
    {
       
    }
    public void OnTriggerEnter(Collider other)//When the player collides with a bug object.
    {
      if (other.tag == "Bug")
      {
            InsectInformation insect = other.gameObject.GetComponent<InsectInformation>();//local variable that references InsectInformation Script.
            bugTracker.bugName = insect.insectScriptableObject.bugName;//changes bug name in the bug tracker script to the scriptable objects name.
            bugTracker.bugBlock = insect.insectScriptableObject.caughtBlockName;//Changes the bug block name in the bug tracker script to the scriptable object name.
            rheasDialogue.SetBooleanVariable("CaughtABug", true);//Changes the 'CaughtABug' bool in 'Rheas dialogue' to true.
            BugCaughtMessage(bugTracker.bugName, bugTracker.bugBlock);//Activates the 'BugCaughtMessage' below.
            bugacquired = true;
            insect.GotCaught();//Adds bug to the list of caught bugs and destroys the game object.
           
        }

      if (other.tag == "Rhea")
      {
            BugGivenToRhea();//Activate the BugGivenToRhea function.
      }

    }
    public void BugCaughtMessage(string bugName, string bugBlock)//Only activates when a player cathces a bug.
    {
        overworldDialogue.SetStringVariable("BugName", bugName);//variable bugname in the Overworld flowchart gets changed ot the name of the bug.
        rheasDialogue.SetStringVariable("BugName", bugName);
        overworldDialogue.ExecuteBlock(bugBlock);//Executes the Fungus block that shares the same name as the insects 'caughtBlockName'
    }

    public void BugGivenToRhea()
    {
        rheasDialogue.ExecuteBlock(bugTracker.bugBlock);
        bugTracker.ClearValues();//Calls the 'ClearValues' function inside the 'CurrentCaughtBug' script.
        
        if(bugacquired == true)
        {
            bugInstantiator.InstantiateNewBug();
            bugacquired = false;

        }
        if (bugInstantiator.bugList.allBugs.Count == 0)//If insect list is at ten (complete)
        {
            rheasDialogue.SetBooleanVariable("AllBugs", true);//Set the bool 'All Bugs' to true.
            rheasDialogue.ExecuteBlock("Game Done");//Activate the block that tells you the game is over. 
        }
    }

}
