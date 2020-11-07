using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public EventDatabase eventData;
	public Event ShittyEvent;
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
		eventData.gameEvents.Add(XMLParser.GetEventByID(idOfEvent));
	}
	
	public void initEventByTag(string eventTag)
	{
		eventData.gameEvents.Add(XMLParser.GetEventByTag(eventTag));
	}
}
