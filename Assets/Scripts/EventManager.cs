﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Event eventData;
	
	void Start()
	{
		initEventByID(0);
		Debug.Log(eventData);
	}
	
	void Update()
	{
		initEventByID(0);
		Debug.Log(eventData);
	}
	
	
	void initEventByID(int idOfEvent)
	{		
		eventData = XMLParser.ins.eventDB.gameEvents.Find(ev => ev.id == idOfEvent);
	}
}