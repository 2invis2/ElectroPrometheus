using UnityEngine;

public class CameraControl : MonoBehaviour
{

	public int speed = 50;

	void Update()
	{
		// лево
		if ((int)Input.mousePosition.x < 2 || Input.GetAxis("Horizontal") < 0)
			transform.position -= transform.right * Time.deltaTime * speed;
		// право
		if ((int)Input.mousePosition.x > Screen.width - 2 || Input.GetAxis("Horizontal") > 0)
			transform.position += transform.right * Time.deltaTime * speed;
		// верх 
		if ((int)Input.mousePosition.y > Screen.height - 2 || Input.GetAxis("Vertical") > 0)
			transform.position += transform.up * Time.deltaTime * speed;
		// низ
		if ((int)Input.mousePosition.y < 2 || Input.GetAxis("Vertical") < 0)
			transform.position -= transform.up * Time.deltaTime * speed;
	}
}
