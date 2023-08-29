using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OpenDoor()
    {
        NavMesh.SetAreaCost(NavMesh.GetAreaFromName("Door"), 1f);
    }

    public void CloseDoor()
    {
        NavMesh.SetAreaCost(NavMesh.GetAreaFromName("Door"), 100f);
    }
}
