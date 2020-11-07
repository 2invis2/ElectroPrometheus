using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUIControls : MonoBehaviour
{
    public int roomID;
	public int eventID;

	
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
		
	}
}
