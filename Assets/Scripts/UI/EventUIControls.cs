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
		List<string> dinosaurs = new List<string>();
		dinosaurs.Add("kek");
		dinosaurs.Add("kel");
		dinosaurs.Add("kem");
		initUI(1, 2, "дороу", "описанье", dinosaurs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void initUI(int rm, int ev, string title, string description, List<string> options)
	{
		roomID = rm;
		eventID = ev;
		transform.Find("Title/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>().text = title;
		transform.Find("SelectionScreen/Problem/ProblemText").gameObject.GetComponent<UnityEngine.UI.Text>().text = description;
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
	}
	
	public void OnClickOption(int optionNum)
	{
		state = "Result";
		StateChange();
		Debug.Log("event " + eventID + " resolved in room " + roomID + " by choosing " + optionNum);
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
