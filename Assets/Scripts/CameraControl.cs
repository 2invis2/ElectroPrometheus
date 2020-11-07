using UnityEngine;

public class CameraControl : MonoBehaviour
{

	public int speed = 50;
	private int currentSpeed;

	void Start()
	{
		currentSpeed = speed;
	}
	
	void Update()
	{
		// лево
		if ((int)Input.mousePosition.x < 2 || Input.GetAxis("Horizontal") < 0)
			transform.position -= transform.right * Time.deltaTime * currentSpeed;
		// право
		if ((int)Input.mousePosition.x > Screen.width - 2 || Input.GetAxis("Horizontal") > 0)
			transform.position += transform.right * Time.deltaTime * currentSpeed;
		// верх 
		if ((int)Input.mousePosition.y > Screen.height - 2 || Input.GetAxis("Vertical") > 0)
			transform.position += transform.up * Time.deltaTime * currentSpeed;
		// низ
		if ((int)Input.mousePosition.y < 2 || Input.GetAxis("Vertical") < 0)
			transform.position -= transform.up * Time.deltaTime * currentSpeed;
	}
	
	public void ClipCamera(Transform obj)
	{
		transform.position = obj.position;
		transform.Find("Main Camera").gameObject.GetComponent<Camera>().orthographicSize = 2.5f;
		currentSpeed = 0;
	}
	
	public void UnclipCamera()
	{
		currentSpeed = speed;	
		transform.Find("Main Camera").gameObject.GetComponent<Camera>().orthographicSize = 10f;		
	}
}
