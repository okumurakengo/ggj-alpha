using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ServiceContainer
{
    private List<IService> serviceList = new List<IService>();
    

    public void AddContaner(IService service)
    {
        serviceList.Add(service);
    }

    public void ExecuteAll(SharedStatus sharedStatus, GameManager gameObject)
    {
        foreach (var container in serviceList)
        {
            container.progress(sharedStatus, gameObject);
        }
    }
}