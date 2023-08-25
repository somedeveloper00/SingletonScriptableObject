
//// This file is auto-generated. Don't edit it.
//using System;
//using System.IO;
//using UnityEngine;

//#if UNITY_EDITOR
//using UnityEditor;
//#endif

//namespace MyNamespace {
//    internal partial class Sample {
//        private static Sample s_instance;
//        public static Sample Instance {
//            get {
//                if (typeof(Sample).IsAbstract)
//                    throw new InvalidOperationException($"Cannot get instance of abstract type {typeof(Sample).Name}");
//                if (s_instance) {
//                    return s_instance;
//                }
//                s_instance = Resources.Load<Sample>(ResourcesPath);
//                if (!s_instance) {
//                    Debug.LogWarning($"created new instance of {typeof(Sample).Name}. singleton instance not found at location: {ResourcesPath}");
//                    s_instance = CreateInstance<Sample>();
//                }
//                return s_instance;
//            }
//        }

//        protected const string ResourcesFolderPath = "SingletonSOs";
//        protected static readonly string ResourcesPath = Path.Combine(ResourcesFolderPath, typeof(Sample).Name);

//        protected virtual void Awake() {
//            if (!s_instance || s_instance == this) return;
//            Debug.LogError($"{typeof(Sample).Name} deleted. Another instance is already available.");
//    #if UNITY_EDITOR
//            if (!Application.isPlaying)
//                DestroyImmediate(this);
//            else
//    #endif
//                Destroy(this);
//        }

//        protected virtual void OnDestroy() {
//            if (s_instance == this) {
//                Debug.LogWarning($"{typeof(Sample).Name} instance destroyed. Singleton instance is no longer available.");
//            }
//        }

//    #if UNITY_EDITOR
//        /// <summary>
//        /// for In-Editor use only. Don't use it.
//        /// </summary>
//        [MenuItem("Tools/Singleton Scriptable Objects/Game.Core/Select 'Sample'")]
//        static void Editor_SelectInstance() {
//            Selection.activeObject = Instance;
//            EditorGUIUtility.PingObject(Instance);
//        }

//        /// <summary>
//        /// For In-Editor use only. Don't use it.
//        /// </summary>
//        [InitializeOnLoadMethod]
//        static void Editor_EnsureInstanceExists() {
//            if (typeof(Sample).IsAbstract) return;
//            EditorApplication.delayCall += AssetManagementUtils.UpdateResourcesForSingletonAsset<Sample>;
//        }
//    #endif

//    }
//}
