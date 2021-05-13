using System;
using UnityEngine;

namespace ScriptableObjs
{
    [CreateAssetMenu]
    public class BooleanVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        public bool initialValue;

        [NonSerialized]
        public bool RuntimeValue;

        public void OnAfterDeserialize()
        {
            RuntimeValue = initialValue;
        }

        public void OnBeforeSerialize() { }
    }
}
