using System;
using UnityEngine;

namespace ScriptableObjs
{
    [CreateAssetMenu]
    public class StringVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        public string initialValue;

        [NonSerialized]
        public string RuntimeValue;

        public void OnAfterDeserialize()
        {
            RuntimeValue = initialValue;
        }

        public void OnBeforeSerialize() { }
    }
}
