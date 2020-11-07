using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;
using static Resource;

public class ResourceManager : MonoBehaviour
{
    public int[] maxResourceValue = new int[4];


    public int startEnergyValue;
    public int startOxygenValue;
    public int startHappinessValue;
    public int startTimeValue;

    private List<ResourceItem> maxResources;
    private List<ResourceItem> resources;

    private void Awake()
    {
        IntialResources();
    }

    private void IntialResources()
    {
        //TODO здесь должен быть вызов парсера и загрузка из XML

        //int valueResource = 100;

        maxResources = new List<ResourceItem>();
        resources = new List<ResourceItem>();

        resources.Add(new ResourceItem(ENERGY, startEnergyValue));
        maxResources.Add(new ResourceItem(ENERGY, maxResourceValue[0]));

        resources.Add(new ResourceItem(OXYGEN, startOxygenValue));
        maxResources.Add(new ResourceItem(OXYGEN, maxResourceValue[1]));

        
        resources.Add(new ResourceItem(HAPPINESS, startHappinessValue));
        maxResources.Add(new ResourceItem(HAPPINESS, maxResourceValue[2]));

        resources.Add(new ResourceItem(TIME_BEFORE_LANDING, startTimeValue));
        maxResources.Add(new ResourceItem(TIME_BEFORE_LANDING, maxResourceValue[3]));

        /*resources.Add(new ResourceItem(PEOPLE, valueResource));
        resources.Add(new ResourceItem(REPAIR_REACTOR_TIME, valueResource));

        maxResources.Add(new ResourceItem(PEOPLE, valueResource));
        maxResources.Add(new ResourceItem(REPAIR_REACTOR_TIME, valueResource));*/

    }

    public void ChangeValueResource(Resource resourceName, int deltaValue)
    {
        ResourceItem changedResource = resources.Find(resourceItem => resourceItem.resource == resourceName);
        ResourceItem maxChangedResource = maxResources.Find(resourceItem => resourceItem.resource == resourceName);

        if (maxChangedResource.value > (changedResource.value + deltaValue))
            changedResource.value += deltaValue;
        else
            changedResource.value = maxChangedResource.value;
    }

    public void ChangeResources(List<ResourceItem> listChangedResources)
    {
        foreach(ResourceItem changedResource in listChangedResources)
        {
            ChangeValueResource(changedResource.resource, changedResource.value);
        }
        
    }

    public int GetValueResource(Resource resourceName)
    {
        ResourceItem changedResource = resources.Find(resourceItem => resourceItem.resource == resourceName);

        return changedResource.value;
    }

    public int GetMaxValueResource(Resource resourceName)
    {
        ResourceItem changedResource = maxResources.Find(resourceItem => resourceItem.resource == resourceName);

        return changedResource.value;
    }

    public List<ResourceItem> GetResources()
    {
        return resources;
    }
}
