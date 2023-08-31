using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class AssetManagementUtils {
    const string ResourcesFolderPath = "SingletonSOs";

    static string ResourcesPath<T>() => Path.Combine(ResourcesFolderPath, typeof(T).Name);
    static string FullPath<T>() => Path.Combine("Assets", Path.Combine("Resources", ResourcesPath<T>() + ".asset"));

    /// <summary>
    /// Handles creation, movement and replacemt of singleton asset. Ensures duplicates don't exist and tries to fix renamed scripts.
    /// </summary>
    public static void UpdateResourcesForSingletonAsset<T>() where T : SingletonScriptableObject {

        EnsureDirectoriesExist<T>();

        // check if any exists
        var previous = Resources.Load(ResourcesPath<T>());
        if (previous != null) {

            if (previous is T) {
                // all good
                return;

            }

            // type has probably been renamed and another type renamed to this type,
            // we'll move previous one to a temporary location so it'll later on find and move it back to its correct location
            Debug.LogWarning($"Invalid instance type found at {FullPath<T>()}. You're probably change two type's names with each other. This is risky!");

            var tempPath = FullPath<T>().Replace(".asset", "_temp.asset");
            AssetDatabase.MoveAsset(AssetDatabase.GetAssetPath(previous), tempPath);

            // find the correct instance
            var anyInstances = Resources.LoadAll<T>(ResourcesFolderPath);
            for (int i = 1; i < anyInstances.Length; i++) {
                // delete other instances, leave only one
                if (anyInstances[i] == null) continue;
                if (AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(anyInstances[i]))) {
                    Debug.LogWarning($"Invalid repeated instance deleted at {FullPath<T>()}");
                    AssetDatabase.Refresh();
                }
            }
            // move the one instance to the correct location
            if (anyInstances.Length > 0) {
                AssetDatabase.MoveAsset(AssetDatabase.GetAssetPath(anyInstances[0]), FullPath<T>());
                AssetDatabase.Refresh();
                Debug.Log($"Moved '{typeof(T).Name}' instance to {FullPath<T>()}");
            } else {
                // probably new script. create new instance
                Debug.Log($"New instance created at {FullPath<T>()}");
                var newInstance = ScriptableObject.CreateInstance<T>();
                AssetDatabase.CreateAsset(newInstance, FullPath<T>());
                AssetDatabase.SaveAssets();
            }

        } else {

            // search to find a valid instance of same type. (Maybe the type has been renamed?)
            var anyInstances = Resources.LoadAll<T>(ResourcesFolderPath);

            // delete other instances, leave only one
            for (int i = 1; i < anyInstances.Length; i++) {
                if (anyInstances[i] == null) continue;
                if (AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(anyInstances[i]))) {
                    Debug.LogWarning($"Invalid repeated instance deleted at {FullPath<T>()}");
                    AssetDatabase.Refresh();
                }
            }

            // move the one instance to the correct location
            if (anyInstances.Length > 0) {
                AssetDatabase.MoveAsset(AssetDatabase.GetAssetPath(anyInstances[0]), FullPath<T>());
                AssetDatabase.Refresh();
                Debug.Log($"Moved '{typeof(T).Name}' instance to {FullPath<T>()}");
            } else {
                // probably new script. create new instance
                Debug.Log($"New instance created at {FullPath<T>()}");
                AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<T>(), FullPath<T>());
                AssetDatabase.SaveAssets();
            }
        }
    }

    static void EnsureDirectoriesExist<T>() {
        if (!AssetDatabase.IsValidFolder(Path.Combine("Assets", "Resources"))) {
            AssetDatabase.CreateFolder("Assets", "Resources");
            AssetDatabase.Refresh();
        }
        if (!AssetDatabase.IsValidFolder(Path.Combine("Assets", "Resources", ResourcesFolderPath))) {
            AssetDatabase.CreateFolder(Path.Combine("Assets", "Resources"), ResourcesFolderPath);
            AssetDatabase.Refresh();
        }
    }

    [MenuItem("Tools/Singleton Scriptable Objects/Reload")]
    static void ReloadEverything() {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
            foreach (var type in assembly.GetTypes()) {
                if (type.IsClass && !type.IsAbstract && typeof(SingletonScriptableObject).IsAssignableFrom(type)) {
                    // invoke the method, pass type as generic T
                    typeof(AssetManagementUtils).GetMethod(nameof(UpdateResourcesForSingletonAsset)).MakeGenericMethod(type).Invoke(null, null);
                }
            }
        }
    }
}
