using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventDatabase
{
    public List<Event> gameEvents = new List<Event>();
}


[System.Serializable]
public class Event
{
    public int id;
    public int idNextStage;
    public List<string> types;
    public int turns;
    public string title;
    public string description;
    public List<string> optionText;
    public List<Result> resultList;
    public List<string> effectsText;
}


[System.Serializable]
public class Result
{
    public List<ResourceChange> changesOfResources;
}

[System.Serializable]
public class ResourceChange
{
    public Resource resource;
    public int deltaValue;
}

public enum Resource
{
    ENERGY,
    OXYGEN,
    FOOD,
    PEOPLE,
    MORALE,
    REACTOR,
    WATER
}