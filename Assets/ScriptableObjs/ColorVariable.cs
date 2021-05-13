using System;
using UnityEngine;

namespace ScriptableObjs
{
    [CreateAssetMenu]
    public class ColorVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        public Color initialValue;

        [NonSerialized]
        public Color RuntimeValue;

        public void OnAfterDeserialize()
        {
            RuntimeValue = initialValue;
        }

        public void OnBeforeSerialize() { }
    }
}
