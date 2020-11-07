[System.Serializable]
public class ResourceItem
{
    public Resource resource;
    public int value;

    public ResourceItem()
    {
        
    }
    public ResourceItem(Resource resource, int value)
    {
        this.resource = resource;
        this.value = value;
    }
}