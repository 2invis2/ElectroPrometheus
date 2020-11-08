using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUIControls : MonoBehaviour
{
    public Resource resource;
    public GameObject mask;
    public GameObject resourceManagerOBJ;
    private List<Animator> animators = new List<Animator>();
    private ResourceManager resourceManager;

    private int resourceValue;
    private int maxResourceValue;
    private float maxScaleMask;

    private List<GameObject> listOfChildren;

    private void Awake()
    {
        resourceManager = resourceManagerOBJ.GetComponent<ResourceManager>();
        GetComponentsInChildren<Animator>(animators);

        maxScaleMask = mask.transform.localScale.x;
    }

    public void Start()
    {
        maxResourceValue = resourceManager.GetMaxValueResource(resource);
        ShowResourceValue();
    }

    private void Update()
	{
		ShowResourceValue();
	}

	private void ShowResourceValue()
    {
        resourceValue = resourceManager.GetValueResource(resource);

        float changeScaleX = (float)resourceValue / (float)maxResourceValue;

        mask.transform.localScale = new Vector3(maxScaleMask * changeScaleX,
            mask.transform.localScale.y, mask.transform.localScale.z);

        float percentValue = changeScaleX * 100;

        foreach (Animator childAnimator in animators)
        {
            if (percentValue > 70)
            {
                childAnimator.SetInteger("state", 0);
            }
            else
            {
                if (percentValue < 30)
                {
                    childAnimator.SetInteger("state", 2);
                }
                else
                {
                    childAnimator.SetInteger("state", 1);
                }

            }
        }
    }
}
