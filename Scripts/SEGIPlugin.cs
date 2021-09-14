// Stationeers.Addons (c) 2018-2021 Damian 'Erdroy' Korczowski & Contributors

using Stationeers.Addons;
using UnityEngine;

namespace SEGIPlugin.Scripts
{
    public class SEGIPlugin : IPlugin
    {
        public void OnLoad()
        {
            Debug.Log("SEGI: Hello, World!");
            var gameObject = new GameObject("SEGI");
            Object.DontDestroyOnLoad(gameObject);
            gameObject.AddComponent<SEGIManager>();
        }

        public void OnUnload()
        {
        }
    }
}