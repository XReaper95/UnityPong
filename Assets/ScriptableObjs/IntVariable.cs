using System;
using UnityEngine;

namespace ScriptableObjs
{
    [CreateAssetMenu]
    public class IntVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        public int initialValue;

        [NonSerialized]
        public int RuntimeValue;

        public void OnAfterDeserialize()
        {
            RuntimeValue = initialValue;
        }

        public void OnBeforeSerialize() { }

        public override string ToString()
        {
            return RuntimeValue.ToString();
        }
    }
}
