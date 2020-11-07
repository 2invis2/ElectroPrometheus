using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	public GameObject resourceManagerOBJ;
    public GameObject eventManagerOBJ;
    public GameObject eventUIControlsOBJ;
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
        eventUIControls = eventUIControlsOBJ.GetComponentInChildren<EventUIControls>();
    }

    public void InitEvent(Event selectedEvent)
    {
        roomEvent = selectedEvent;
        eventStatus = roomEvent.turns;
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

    public void GiveEventStatus()
    {

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
