using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{ 
    public GameObject[] rooms = new GameObject[12];
    public GameObject eventManagerOBJ;
    public GameObject resourceManagerOBJ;
    private ResourceManager resourceManager;
    private EventManager eventManager;

    public void Awake()
    {
        resourceManager = resourceManagerOBJ.GetComponent<ResourceManager>();
        eventManager = eventManagerOBJ.GetComponent<EventManager>();

        CreateEventByType(TypeEvent.GREEN, rooms[1]);
    }

    public void UpdateTurn()
    {
        foreach(GameObject room in rooms)
        {
            room.GetComponent<Room>().UpdateEvent();			
        }
		int randomAAAA = Random.Range(0, (freeRooms().Count-1));
		int randomFreeRoomI = freeRooms()[randomAAAA];
		CreateEventByType(TypeEvent.GREEN, rooms[randomFreeRoomI]);
		

    }

    private void CreateEventByType(TypeEvent type, GameObject roomTo)
    {
        eventManager.initEventByTag("GREEN", roomTo);
    }
	
	private List<int> freeRooms()
	{
		List<int> ans = new List<int>();
		for	(int i=0; i<12; i++)
		{
			if (!rooms[i].GetComponent<Room>().hasActiveEvent())
				ans.Add(i);
		}
		Debug.Log(ans.Count);
		return ans;
	}
}
