using NrawangStudio.Car;

using UnityEditor;
using UnityEngine;

namespace NrawangStudio.Editorr.Importer
{
    public class PrefabPost : AssetPostprocessor
    {
        void OnPostprocessPrefab(GameObject root)
        {
            SearchCarPrefab(root);
        }

        void SearchCarPrefab(GameObject obj)
        {
            if (obj.name.Contains("Car"))
            {

                var sportCar = Resources.Load<TypeCar>("Scriptable/Ferari");
                obj.AddComponent<Rigidbody>();
                obj.AddComponent<SportCar>().carEngine = sportCar;
                obj.AddComponent<CarController>();
            }
        }

    }
}
