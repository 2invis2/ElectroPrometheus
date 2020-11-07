﻿using System.Collections;
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

        CreateEventByType(TypeEvent.GREEN, rooms[1]);
    }

    public void UpdateTurn()
    {
        foreach(GameObject room in rooms)
        {
            room.GetComponent<Room>().UpdateEvent();			
        }
		int random1 = Random.Range(0, (freeRooms().Count-1));
		int random2 = Random.Range(0, (freeRooms().Count-1));
		while (random1 == random2)
		{
			random2 = Random.Range(0, (freeRooms().Count-1));
		}
		int randomFreeRoom1 = freeRooms()[random1];
		int randomFreeRoom2 = freeRooms()[random2];
		CreateEventByType(TypeEvent.GREEN, rooms[randomFreeRoom1]);
		CreateEventByType(TypeEvent.GREEN, rooms[randomFreeRoom2]);
		

    }

    private void CreateEventByType(TypeEvent type, GameObject roomTo)
    {
        eventManager.initEventByTag(type.ToString(), roomTo);
    }
	
	private List<int> freeRooms()
	{
		List<int> ans = new List<int>();
		for	(int i=0; i<12; i++)
		{
			if (!rooms[i].GetComponent<Room>().hasActiveEvent())
				ans.Add(i);
		}
		Debug.Log(ans.Count);
		return ans;
	}
}