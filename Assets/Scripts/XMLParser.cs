using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
//using Event;


public class XMLParser : MonoBehaviour
{
    public static XMLParser instanceParser;
	
	void Awake()
	{
		instanceParser = this;
		LoadEvents();
		LoadPunishes();
	}
	
	public EventDatabase eventDB;
	public PunishClass pnsh;
	
	public void SaveEvents()
	{
		XmlSerializer serializer = new XmlSerializer(typeof(EventDatabase));
		FileStream stream = new FileStream(Application.dataPath + "/DataXML/eventlist.xml", FileMode.Create);
		serializer.Serialize(stream, eventDB);
		stream.Close();
	}
	
	public void LoadEvents()
	{
		XmlSerializer serializer = new XmlSerializer(typeof(EventDatabase));
		FileStream stream = new FileStream(Application.dataPath + "/DataXML/eventlist.xml", FileMode.Open);
		eventDB = serializer.Deserialize(stream) as EventDatabase;
		stream.Close();
	}
	
	public void LoadPunishes()
	{
		XmlSerializer serializer = new XmlSerializer(typeof(PunishClass));
		FileStream stream = new FileStream(Application.dataPath + "/DataXML/punishes.xml", FileMode.Open);
		pnsh = serializer.Deserialize(stream) as PunishClass;
		stream.Close();
	}
	
	public void SavePunishes()
	{
		XmlSerializer serializer = new XmlSerializer(typeof(PunishClass));
		FileStream stream = new FileStream(Application.dataPath + "/DataXML/punishes.xml", FileMode.Open);
		serializer.Serialize(stream, pnsh);
		stream.Close();
	}
	
	public static Event GetShittyEvent()
	{
		return instanceParser.eventDB.gameEvents.Find(ev => ev.id == 0);
	}
	
	public static Event GetEventByID(int neededId)
	{
		return instanceParser.eventDB.gameEvents.Find(ev => ev.id == neededId);
	}
	
	public static Event GetEventByTag(string neededTag)
	{
		return instanceParser.eventDB.gameEvents.Find(ev => ev.types.Contains(neededTag));
	}
	
    
	public static Event GetEventByTagRandom(string neededTag)
	{
		 List<Event> suitable = instanceParser.eventDB.gameEvents.FindAll(ev => ev.types.Contains(neededTag));
		//foreach (Event ev in suitable)
		Event ans = suitable[Random.Range(0, suitable.Count)];
		return ans;
	}
}


