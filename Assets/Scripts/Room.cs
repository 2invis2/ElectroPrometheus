﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	public GameObject resourceManagerOBJ;
    public GameObject eventManagerOBJ;
    public GameObject eventUIControlsOBJ;
	public Transform prefabOfEventUI;
	private ResourceManager resourceManager;
    private EventManager eventManager;
    private EventUIControls eventUIControls;
    public Event roomEvent;
    public int eventStatus;
    public string descriptionRoom;

    private void Awake()
    {
        resourceManager = resourceManagerOBJ.GetComponent<ResourceManager>();
        eventManager = eventManagerOBJ.GetComponent<EventManager>();
    }
	
	private void InitEventUI()
	{
		eventUIControlsOBJ = Instantiate(prefabOfEventUI, this.transform).gameObject;
		eventUIControls = eventUIControlsOBJ.GetComponentInChildren<EventUIControls>();
		eventUIControls.initUI(roomEvent);
	}

    public void InitEvent(Event selectedEvent)
    {
        roomEvent = selectedEvent;
        eventStatus = roomEvent.turns;
		InitEventUI();
		
    }

    public string ShowMessageDescription()
    {
        return roomEvent.description;
    }

    public List<string> ShowOptionText()
    {
        return roomEvent.optionText;
    }

    public string UpdateMessage(int indexOption)
    {
        return roomEvent.effectsText[indexOption];
    }

    public string ShowDescriptionRoom()
    {
        return descriptionRoom;
    }

	
	public bool hasActiveEvent()
	{
		bool ans = false;
		if (transform.Find("EventUI").gameObject != null)
			ans = true;
		else
			ans = false;
		return ans;
	}
	
	public void onEventSolved()
	{
		//тут ссылка на глобальное обновление
	}
	
	public void UpdateEvent()
	{
		roomEvent.turns--;
		if (roomEvent.turns == 0)
			if (roomEvent.id == roomEvent.idNextStage)
				ChangeResource(0);
			else
				eventManager.initEventByID(roomEvent.idNextStage);
		Debug.Log("eventupdated");
	}

    public void ChangeResource(int indexOption)
    {
        List<ResourceItem> changesOfResources = roomEvent.resultList[indexOption].changesOfResources;

        foreach(ResourceItem changesResource in changesOfResources)
        {
            resourceManager.ChangeValueResource(changesResource.resource, changesResource.value);
        }
	}
}
