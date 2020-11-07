using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUIControls : MonoBehaviour
{
    public int roomID;
	public int eventID;
	public Sprite redSprite;
	public Sprite greenSprite;
	public Sprite purpleSprite;
	public Sprite yellowSprite;
	private string state = "OnlyAlarm";
	private List<string> results;
	private int cnt;

	
	// Start is called before the first frame update
    void Start()
    {
		cnt = 0;
		StateChange();
    }

    // Update is called once per frame
    void Update()
    {
		cnt++;
		if (cnt == 10)
		{
			//initUI(XMLParser.GetShittyEvent());
		}
    }
	
	public void initUI(Event localEvent)
	{
		eventID = localEvent.id;
		string title = localEvent.title;
		string description = localEvent.description; 
		List<string> options = new List<string>(localEvent.optionText);
		results = new List<string> (localEvent.effectsText);	
		transform.Find("Title/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>().text = title;
		transform.Find("SelectionScreen/Problem/ProblemText").gameObject.GetComponent<UnityEngine.UI.Text>().text = description;	
		
		switch (localEvent.types[0])
		{
			case "GREEN":
				this.gameObject.transform.Find("Alarm").gameObject.GetComponent<UnityEngine.UI.Image>().sprite = greenSprite;
				break;
			case "YELLOW":
				this.gameObject.transform.Find("Alarm").gameObject.GetComponent<UnityEngine.UI.Image>().sprite = yellowSprite;
				break;
			case "RED":
				this.gameObject.transform.Find("Alarm").gameObject.GetComponent<UnityEngine.UI.Image>().sprite = redSprite;
				break;
			case "PURPLE":
				this.gameObject.transform.Find("Alarm").gameObject.GetComponent<UnityEngine.UI.Image>().sprite = purpleSprite;		
				break;
		}
		
		int cnt = 0;	
		foreach (string option in options)
			{
				string searchRoot = "SelectionScreen/Solution"+cnt+"/SolutionText";
				Debug.Log(searchRoot);
				transform.Find(searchRoot).gameObject.GetComponent<UnityEngine.UI.Text>().text = option;
				cnt++;
			}
		if (cnt<5)
			for (int i = cnt; i < 5; i++)
				{
					string searchRoot = "SelectionScreen/Solution"+i;
					Destroy(transform.Find(searchRoot).gameObject);
				}
			
	}
	
	public void OnClickAlarm()
	{
		if (state == "OnlyAlarm")
			state = "Select";
		else 
			if (state == "Select")
				state = "OnlyAlarm";
		StateChange();
		GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().ClipCamera(this.gameObject.transform);
	}
	
	public void OnClickOption(int optionNum)
	{
		state = "Result";
		transform.Find("Solved/SolvedText").gameObject.GetComponent<UnityEngine.UI.Text>().text = results[optionNum];
		StateChange();
		this.gameObject.transform.parent.GetComponent<Room>().ChangeResource(optionNum);
		Debug.Log("event " + eventID + " resolved by choosing " + optionNum);
	}
	
	public void OnClickExit()
	{
		GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().UnclipCamera();
		this.gameObject.transform.parent.GetComponent<Room>().onEventSolved();
		Destroy(this.gameObject);
	}
	
	public void StateChange()
	{
		GameObject selection = transform.Find("SelectionScreen").gameObject;
		GameObject alarm = transform.Find("Alarm").gameObject;
		GameObject result = transform.Find("Solved").gameObject;
		GameObject titleName = transform.Find("Title").gameObject;
		if (state == "OnlyAlarm")
		{
			alarm.SetActive(true);
			selection.SetActive(false);
			result.SetActive(false);
			titleName.SetActive(false);
		}
		else
			if (state == "Select")
			{
				alarm.SetActive(false);
				selection.SetActive(true);
				result.SetActive(false);
				titleName.SetActive(true);
			}
			else
				if (state == "Result")
				{
					alarm.SetActive(false);
					selection.SetActive(false);
					result.SetActive(true);
					titleName.SetActive(true);
				}
	}
}
