using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Fungus;

public class BugInstantiator : MonoBehaviour
{
    // This script controls where and how bugs instantiate onto the map.
    public Transform instantiatePosition;
    public InsectCaught playerObject;
    public BugMasterList bugList;
    public Flowchart rheasDialogue;
    public List<GameObject> copyBugs;
    public List<GameObject> bugSpawnLocations;//List containing all spawn location points for bugs in the game. 
    public int bugIndex;
    public int spawnPoint;//Current spawn location of the bug.

    public void Start()
    {
        /* copyBugs = bugList.allBugs.Select(b => b).ToList();//creates a copy of the scriptable objet list bugList.*/
        
      InstantiateNewBug();
        
    }

    public void InstantiateNewBug()
    {
        bugIndex = Random.Range(0, bugList.allBugs.Count);//Takes a random index number from the duplicate list 'copyBugs'
        spawnPoint = Random.Range(0, bugSpawnLocations.Count);//Picks a gameobject from the list. 

        Instantiate(bugList.allBugs[bugIndex], bugSpawnLocations[spawnPoint].transform.position, Quaternion.identity);
        Debug.Log("I spawned at the " + bugSpawnLocations[spawnPoint].name);
        Debug.Log("I'm called " + bugList.allBugs[bugIndex].name);

        
        
        /*Instantiate(bugList.allBugs[bugIndex], Vector3.zero, Quaternion.identity, instantiatePosition);*/
        
        bugList.allBugs.RemoveAt(bugIndex);
       
    }
}