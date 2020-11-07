using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public EventDatabase eventData;
	public Event ShittyEvent;
	public GameObject sampleRoom;
	private int cnt;
	
	void Start()
	{
		cnt = 0;
	}
	
	void Update()
	{
		cnt++;
		if (cnt == 5)
		{
			initEventByTag("Ulala");
		}
	}
	
	
	public void initEventByID(int idOfEvent)
	{		
		Event thisEvent = XMLParser.GetEventByID(idOfEvent);
		eventData.gameEvents.Add(thisEvent);
		sampleRoom.GetComponent<Room>().InitEvent(thisEvent);
	}
	
	public void initEventByTag(string eventTag)
	{
		Event thisEvent = XMLParser.GetEventByTag(eventTag);
		eventData.gameEvents.Add(thisEvent);
		sampleRoom.GetComponent<Room>().InitEvent(thisEvent);
	}
}
