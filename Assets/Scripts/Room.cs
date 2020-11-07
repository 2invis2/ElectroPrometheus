using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public ResourceManager resourceManager;
    public EventManager eventManager;
    public EventUIControls eventUIControls;
    //public ResourceUIControls resourceUiControls;
    public Event roomEvent;
    public int eventStatus;
    public string descriptionRoom;

    private void Awake()
    {
        resourceManager = GetComponent<ResourceManager>();
        eventManager = GetComponent<EventManager>();
        eventUIControls = GetComponentInChildren<EventUIControls>();
        //resourceUiControls = GetComponentInChildren<ResourceUIControls>();
    }

    public void InitEvent(Event selectedEvent)
    {
        roomEvent = selectedEvent;
        eventStatus = roomEvent.turns;
    }

    public string ShowMasageDescription()
    {
        return roomEvent.description;
    }

    public List<string> ShowOptionText()
    {
        return roomEvent.optionText;
    }

    public string UpdateMasage(int indexOption)
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
