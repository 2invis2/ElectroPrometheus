using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public EventDatabase eventData;
	public Event ShittyEvent;
	
	void Start()
	{
		initEventByTag("Ulala");
		Debug.Log(XMLParser.GetShittyEvent());
	}
	
	void Update()
	{
		initEventByTag("Ulala");
		//Debug.Log(eventData);
	}
	
	
	public void initEventByID(int idOfEvent)
	{		
		eventData.gameEvents.Add(XMLParser.GetEventByID(idOfEvent));
	}
	
	public void initEventByTag(string eventTag)
	{
		eventData.gameEvents.Add(XMLParser.GetEventByTag(eventTag));
	}
}
