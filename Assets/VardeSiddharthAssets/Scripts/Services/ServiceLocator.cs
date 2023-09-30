using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : GenericSingleton<ServiceLocator>
{
    Dictionary<TypesOfServices, IGameService> services;// = new Dictionary<TypesOfServices, IGameService>();

    protected override void Awake()
    {
        base.Awake();
        services = new Dictionary<TypesOfServices, IGameService>();
    }

    public void Register<T>(TypesOfServices type, T service) where T : IGameService
    {
        if(!services.ContainsKey(type))
        {
            services.Add(type, service);
        }
    }

    public T GetService<T>(TypesOfServices type) where T : class ,IGameService
    {
        if (!services.ContainsKey(type))
        {
            Debug.LogError("Service Does not Exists");
            return null;
        }

        return (T)services[type];
    }
}
