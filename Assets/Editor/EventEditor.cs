using ScriptableObjs;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(GameEvent), editorForChildClasses: true)]
    public class EventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            var e = target as GameEvent;
            if (GUILayout.Button("Raise"))
            {
                if (!(e is null)) e.Raise();
            }
                
        }
    }
}