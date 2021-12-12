using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace NrawangStudio.Assets.Editorr.Importer
{
    public class FbxPost : AssetPostprocessor
    {

        void OnPreprocessModel()
        {
            ModelImporter modelImporter = assetImporter as ModelImporter;
            modelImporter.importBlendShapes = false;
            modelImporter.importCameras = false;
            modelImporter.importLights = false;
        }

        private const string Prefab_Directory = "Assets/Prefab/";
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            foreach (var path in importedAssets)
            {
                GameObject fbxAssets = AssetDatabase.LoadAssetAtPath<GameObject>(path);

                if (!path.EndsWith(".fbx", StringComparison.OrdinalIgnoreCase))
                    continue;
                CreatePrefab(fbxAssets, path);
            }
        }

        static void CreatePrefab(GameObject fbxAssets, string path)
        {
            string fbxFileName = Path.GetFileNameWithoutExtension(path);
            string destinationPath = Prefab_Directory + fbxFileName + ".prefab";

            var go = UnityEngine.Object.Instantiate(fbxAssets);
            GameObjectUtility.SetStaticEditorFlags(fbxAssets, (StaticEditorFlags)(-1));

            PrefabUtility.SaveAsPrefabAsset(go, destinationPath);
            UnityEngine.Object.DestroyImmediate(go);
        }

    }
}
