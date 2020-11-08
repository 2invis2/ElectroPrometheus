using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	public GameObject resourceManagerOBJ;
    public GameObject eventManagerOBJ;
    public GameObject eventUIControlsOBJ;
	public GameObject directorOBJ;
	public Transform prefabOfEventUI;
	private ResourceManager resourceManager;
    private EventManager eventManager;
	private Director director;
	private EventUIControls eventUIControls;
	public bool inEvent;
    public Event roomEvent;
    public int eventStatus;
    public string descriptionRoom;

    private void Awake()
    {
        resourceManager = resourceManagerOBJ.GetComponent<ResourceManager>();
        eventManager = eventManagerOBJ.GetComponent<EventManager>();
		director = directorOBJ.GetComponent<Director>();
    }
	
	private void InitEventUI()
	{
		eventUIControlsOBJ = Instantiate(prefabOfEventUI, this.transform).gameObject;
		eventUIControlsOBJ.GetComponent<Canvas>().sortingOrder = 1;
		eventUIControls = eventUIControlsOBJ.GetComponent<EventUIControls>();
		eventUIControls.initUI(roomEvent);
	}

    public void InitEvent(Event selectedEvent)
    {
        roomEvent = selectedEvent;
        eventStatus = roomEvent.turns;
		InitEventUI();
		inEvent = true;
		
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
		return inEvent;
	}
	
	public void onEventSolved()
	{
		inEvent = false;
		Destroy(eventUIControlsOBJ);
		eventStatus = -1;
		director.UpdateTurn();
	}
	
	public void UpdateEvent()
	{
		if (inEvent)
		{
			eventStatus--;
			if (eventStatus <= 0)
				if (roomEvent.types[0]=="RED")
				{
					ChangeResource(0);
					Destroy(eventUIControlsOBJ);
					inEvent = false;
				}
				else
					{
						Destroy(eventUIControlsOBJ);
						inEvent = false;
						eventManager.initEventByID(roomEvent.idNextStage, this.gameObject);	
					}
			Debug.Log("event updated in room" + this.gameObject.name + " current event - " + roomEvent.description);
		}
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
