using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

	public int speed = 10;
	private int currentSpeed;
	public int edgeScreen = 50;
    public List<int> borderCord = new List<int>(); //лево,право,вверх,низ

    void Start()
	{
		currentSpeed = speed;
	}
	
	void Update()
	{
		// лево
		if (((int)Input.mousePosition.x < edgeScreen || Input.GetAxis("Horizontal") < 0) &&
            ((transform.position - transform.right * Time.deltaTime * currentSpeed).x >borderCord[0]))
			transform.position -= transform.right * Time.deltaTime * currentSpeed;
		// право
		if (((int)Input.mousePosition.x > Screen.width - edgeScreen || Input.GetAxis("Horizontal") > 0) &&
            ((transform.position+transform.right * Time.deltaTime * currentSpeed).x < borderCord[1]))
            transform.position += transform.right * Time.deltaTime * currentSpeed;
		// верх 
		if (((int)Input.mousePosition.y > Screen.height - edgeScreen || Input.GetAxis("Vertical") > 0) &&
            ((transform.position + transform.up * Time.deltaTime * currentSpeed).y < borderCord[2]))
			transform.position += transform.up * Time.deltaTime * currentSpeed;
		// низ
		if (((int)Input.mousePosition.y < edgeScreen || Input.GetAxis("Vertical") < 0)&&
            ((transform.position - transform.up * Time.deltaTime * currentSpeed).y > borderCord[3]))
			transform.position -= transform.up * Time.deltaTime * currentSpeed;
	}
	
	public void ClipCamera(Transform obj, float sizeC, bool stopif)
	{
		transform.position = new Vector3(obj.position.x, obj.position.y, transform.position.z);
		transform.Find("Main Camera").gameObject.GetComponent<Camera>().orthographicSize = sizeC;
		if (stopif)
			currentSpeed = 0;
	}
	
	public void UnclipCamera()
	{
		currentSpeed = speed;
		transform.Find("Main Camera").gameObject.GetComponent<Camera>().orthographicSize = 10f;	
	}	
}
