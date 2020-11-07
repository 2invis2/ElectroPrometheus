using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{ 
    public GameObject[] rooms = new GameObject[12];
    public GameObject eventManagerOBJ;
    public GameObject resourceManagerOBJ;
    private ResourceManager resourceManager;
    private EventManager eventManager;

    public void Awake()
    {
        resourceManager = resourceManagerOBJ.GetComponent<ResourceManager>();
        eventManager = eventManagerOBJ.GetComponent<EventManager>();

        CreateEventByType(TypeEvent.GREEN);
    }

    public void UpdateTurn()
    {
        foreach(GameObject room in rooms)
        {
            room.GetComponent<Room>().UpdateEvent();
        }

        CreateEventByType(TypeEvent.GREEN);
        CreateEventByType(TypeEvent.GREEN);
    }

    private void CreateEventByType(TypeEvent type)
    {
        eventManager.initEventByTag("GREEN");
    }
}
