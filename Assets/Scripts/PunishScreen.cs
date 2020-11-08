using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunishScreen : MonoBehaviour
{
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void PunishReset()
	{
		PunishOff();
	}
	
	public void PunishAdd(string Desc)
	{
		this.gameObject.transform.Find("Text").gameObject.GetComponent<UnityEngine.UI.Text>().text=Desc;
		PunishOn();
		GameObject.FindWithTag("CC").GetComponent<CameraControl>().ClipCamera(this.gameObject.transform, 10f, false);
	}
	
	public void PunishOn()
	{
		this.gameObject.transform.Find("Text").gameObject.SetActive(true);
		this.gameObject.transform.Find("Button").gameObject.SetActive(true);
	}
	
	public void PunishOff()
	{
		this.gameObject.transform.Find("Text").gameObject.SetActive(false);
		this.gameObject.transform.Find("Button").gameObject.SetActive(false);
	}
	
	
}
