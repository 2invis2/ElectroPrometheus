using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	public List<string> punishesDesc;
	public List<Result> punishesEff;
	public GameObject ParserL;
	public GameObject resourceManagerOBJ;
    public GameObject eventManagerOBJ;
    public GameObject eventUIControlsOBJ;
	public GameObject directorOBJ;
	public GameObject timeScaleOBJ;
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
		PunishLoader();	
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
			{
				if (roomEvent.types[0]=="RED")
				{
					Punish(punishesEff, punishesDesc);
					Destroy(eventUIControlsOBJ);
					inEvent = false;
				}
				else
					{
						Destroy(eventUIControlsOBJ);
						inEvent = false;
						eventManager.initEventByID(roomEvent.idNextStage, this.gameObject);	
					}
			}
		}
	}

    public void ChangeResource(int indexOption)
    {
        List<ResourceItem> changesOfResources = roomEvent.resultList[indexOption].changesOfResources;

        foreach(ResourceItem changesResource in changesOfResources)
        {
            resourceManager.ChangeValueResource(changesResource.resource, changesResource.value);

			if(changesResource.resource == Resource.TIME_BEFORE_LANDING)
            {
				int time = resourceManager.GetValueResource(Resource.TIME_BEFORE_LANDING);

				timeScaleOBJ.GetComponent<TimeScaleLine>().Move(time);
            }
        }
	}
	
	public void Punish(List<Result> res, List<string> descs)
	{
		int ln = descs.Count;
		int indx = Random.Range(0, ln);
		Result rndChange = res[indx];
		string ans = descs[indx];
		foreach (ResourceItem kek in rndChange.changesOfResources)
			resourceManager.ChangeValueResource(kek.resource, kek.value);
		GameObject.FindWithTag("Punishment").GetComponent<PunishScreen>().PunishAdd(ans);
	}
	
	public void PunishLoader()
	{
		punishesDesc = ParserL.GetComponent<XMLParser>().pnsh.Description;
		punishesEff = ParserL.GetComponent<XMLParser>().pnsh.Effect;
	}
		
}
