using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleLine : MonoBehaviour
{

    public void Move(int time)
    {
        this.transform.localPosition = new Vector3(time+1, transform.localPosition.y, transform.localPosition.z);
       // this.transform.Translate(new Vector3(time - 1, transform.localPosition.y, transform.localPosition.z), Space.Self);
    }
}
