
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DecelarationAttribute))]
public class DecelarationPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        base.OnGUI(position, property, label);
    }
}
