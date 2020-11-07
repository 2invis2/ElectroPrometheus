using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;
using static Resource;

public class ResourceManager : MonoBehaviour
{
    private List<ResourceItem> resources;

    private void Awake()
    {
        IntialResources();
    }

    private void IntialResources()
    {
        //TODO здесь должен быть вызов парсера и загрузка из XML

        int valueResource = 100;

        resources = new List<ResourceItem>();

        resources.Add(new ResourceItem(ENERGY, valueResource));
        resources.Add(new ResourceItem(OXYGEN, valueResource));
        resources.Add(new ResourceItem(PEOPLE, valueResource));
        resources.Add(new ResourceItem(HAPPINESS, valueResource));
        resources.Add(new ResourceItem(REPAIR_REACTOR_TIME, valueResource));
        resources.Add(new ResourceItem(TIME_BEFORE_LANDING, valueResource));
    }

    public void ChangeValueResource(Resource resourceName, int deltaValue)
    {
        ResourceItem changedResource = resources.Find(resourceItem => resourceItem.resource == resourceName);

        changedResource.value += deltaValue;
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

    public List<ResourceItem> GetResources()
    {
        return resources;
    }
}
