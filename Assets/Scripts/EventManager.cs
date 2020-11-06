using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Event eventData;
	
	void Start()
	{
		Debug.Log(eventData.title);
	}
	
	void Update()
	{
		initEventByTag("Ulala");
		Debug.Log(eventData.title);
	}
	
	
	void initEventByID(int idOfEvent)
	{		
		eventData = XMLParser.ins.eventDB.gameEvents.Find(ev => ev.id == idOfEvent);
	}
	
	void initEventByTag(string eventTag)
	{
		eventData = XMLParser.ins.eventDB.gameEvents.Find(ev => ev.types.Contains(eventTag));
	}
}
