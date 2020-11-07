using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public EventDatabase eventData;
	
	public void initEventByID(int idOfEvent, GameObject roomTo)
	{		
		Event thisEvent = XMLParser.GetEventByID(idOfEvent);
		eventData.gameEvents.Add(thisEvent);
		roomTo.GetComponent<Room>().InitEvent(thisEvent);
	}
	
	public void initEventByTag(string eventTag, GameObject roomTo)
	{
		Event thisEvent = XMLParser.GetEventByTag(eventTag);
		eventData.gameEvents.Add(thisEvent);
		roomTo.GetComponent<Room>().InitEvent(thisEvent);
	}
	
	public void initEventByTagRandom(string eventTag, GameObject roomTo)
	{
		Event thisEvent = XMLParser.GetEventByTagRandom(eventTag);
		eventData.gameEvents.Add(thisEvent);
		roomTo.GetComponent<Room>().InitEvent(thisEvent);
	}
}
