using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUIControls : MonoBehaviour
{
    public int roomID;
	public int eventID;
	private string state = "OnlyAlarm";

	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void initUI(int rm, int ev, string title, string description, List<string> options)
	{
		roomID = rm;
		eventID = ev;
		
	}
	
	public void OnClickAlarm()
	{
		if (state == "OnlyAlarm")
			state = "Select";
		else 
			if (state == "Select")
				state = "OnlyAlarm";
		StateChange();
	}
	
	public void OnClickOption(int optionNum)
	{
		state = "Result";
		StateChange();
		Debug.Log(eventID + " choice " + optionNum);
	}
	
	
	public void StateChange()
	{
		GameObject selection = transform.Find("SelectionScreen").gameObject;
		GameObject alarm = transform.Find("Alarm").gameObject;
		GameObject result = transform.Find("Solved").gameObject;
		if (state == "OnlyAlarm")
		{
			alarm.SetActive(true);
			selection.SetActive(false);
			result.SetActive(false);
		}
		else
			if (state == "Select")
			{
				alarm.SetActive(true);
				selection.SetActive(true);
				result.SetActive(false);
			}
			else
				if (state == "Result")
				{
					alarm.SetActive(false);
					selection.SetActive(false);
					result.SetActive(true);
				}
	}
}
