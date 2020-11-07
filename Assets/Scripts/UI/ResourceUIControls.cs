using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUIControls : MonoBehaviour
{
	public Text energyText;
    public Text oxygenText;
    public Text peopleText;
    public Text happinessText;
    public Text repairText;
    public Text timerText;
    public ResourceManager resourceManager;

    private void Start()
    {
        ShowResourceValue();
    }

    private void Update()
	{
		ShowResourceValue();
	}

	private void ShowResourceValue()
    {
        energyText.text = resourceManager.GetValueResource(Resource.ENERGY).ToString();
        oxygenText.text = resourceManager.GetValueResource(Resource.OXYGEN).ToString();
        happinessText.text = resourceManager.GetValueResource(Resource.HAPPINESS).ToString();
        repairText.text = resourceManager.GetValueResource(Resource.REPAIR_REACTOR_TIME).ToString();
        timerText.text = resourceManager.GetValueResource(Resource.TIME_BEFORE_LANDING).ToString();
    }
}
