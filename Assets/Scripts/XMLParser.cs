using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
//using Event;


public class XMLParser : MonoBehaviour
{
    public static XMLParser ins;
	
	void Awake(){
		ins = this;
		LoadEvents();
	}
	
	public EventDatabase eventDB;
	
	public void SaveEvents(){
		XmlSerializer serializer = new XmlSerializer(typeof(EventDatabase));
		FileStream stream = new FileStream(Application.dataPath + "/DataXML/eventlist.xml", FileMode.Create);
		serializer.Serialize(stream, eventDB);
		stream.Close();
	}
	
	public void LoadEvents(){
		XmlSerializer serializer = new XmlSerializer(typeof(EventDatabase));
		FileStream stream = new FileStream(Application.dataPath + "/DataXML/eventlist.xml", FileMode.Open);
		eventDB = serializer.Deserialize(stream) as EventDatabase;
		stream.Close();
	}
    
}


