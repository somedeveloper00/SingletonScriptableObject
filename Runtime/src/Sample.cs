
// // This file is auto-generated. Don't edit it.
// using System;
// using System.IO;
// using UnityEditor;
// using UnityEngine;


// namespace Game.Core {


//     public partial class ItemResources {
//         private static ItemResources s_instance;
//         public static ItemResources Instance {
//             get {
//                 if (typeof(ItemResources).IsAbstract)
//                     throw new InvalidOperationException($"Cannot get instance of abstract type {typeof(ItemResources).Name}");
//                 if (s_instance) {
//                     return s_instance;
//                 }
//                 s_instance = Resources.Load<ItemResources>(ResourcesPath);
//                 if (!s_instance) {
//                     Debug.LogWarning($"created new instance of {typeof(ItemResources).Name}. singleton instance not found at location: {FullPath}");
//                     s_instance = CreateInstance<ItemResources>();
//                 }
//                 return s_instance;
//             }
//         }

//         protected const string ResourcesFolderPath = "SingletonSOs";
//         protected static readonly string ResourcesPath = Path.Combine(ResourcesFolderPath, typeof(ItemResources).Name);
//         protected static readonly string FullPath = Path.Combine("Assets", Path.Combine("Resources", ResourcesPath + ".asset"));

//         protected virtual void Awake() {
//             if (!s_instance || s_instance == this) return;
//             Debug.LogError($"{typeof(ItemResources).Name} deleted. Another instance is already available.");
// #if UNITY_EDITOR
//             if (!Application.isPlaying)
//                 DestroyImmediate(this);
//             else
// #endif
//                 Destroy(this);
//         }

//         protected virtual void OnDestroy() {
//             if (s_instance == this) {
//                 Debug.LogWarning($"{typeof(ItemResources).Name} instance destroyed. Singleton instance is no longer available.");
//             }
//         }

// #if UNITY_EDITOR
//         /// <summary>
//         /// for In-Editor use only. Don't use it.
//         /// </summary>
//         [MenuItem("Tools/Singleton Scriptable Objects/Game.Core/Select 'ItemResources'")]
//         static void Editor_SelectInstance() {
//             Selection.activeObject = Instance;
//             EditorGUIUtility.PingObject(Instance);
//         }

//         /// <summary>
//         /// For In-Editor use only. Don't use it.
//         /// </summary>
//         [InitializeOnLoadMethod]
//         static void Editor_EnsureInstanceExists() {
//             if (typeof(ItemResources).IsAbstract) return;
//             EditorApplication.delayCall += () => {
//                 s_instance = Resources.Load<ItemResources>(ResourcesPath);
//                 if (!s_instance) {
//                     // create instance
//                     s_instance = ScriptableObject.CreateInstance<ItemResources>();
//                     if (!AssetDatabase.IsValidFolder(Path.Combine("Assets/Resources", ResourcesFolderPath))) {
//                         AssetDatabase.CreateFolder("Assets/Resources", ResourcesFolderPath);
//                     }
//                     AssetDatabase.CreateAsset(s_instance, FullPath);
//                     AssetDatabase.SaveAssets();
//                 }
//             };
//         }
// #endif

//     }


// }

