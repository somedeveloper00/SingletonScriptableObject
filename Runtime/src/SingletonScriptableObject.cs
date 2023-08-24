using UnityEngine;

/// <summary>
/// <para>A Singleton ScriptableObject type; it has only one instance in the project. In order for this to work, your subclass must 
/// be marked <c>partial</c>.</para>
/// <para>You can access the instance by using the <c>Instance</c> field of the type.</para>
/// 
/// <para>Example:</para>
/// <code>
/// partial class MyClass : SingletonScriptableObject {
/// // ...
/// }
/// ... 
/// // to access it
/// var myClass = MyClass.Instance;
/// </code>
/// </summary>
public abstract class SingletonScriptableObject : ScriptableObject { }