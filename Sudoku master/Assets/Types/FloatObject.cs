
namespace Catalyst.Core.Utility
{
    using System;
    using UnityEngine;

    [Serializable]
    public class FloatObject
    {
        public event Action<float> OnValueChanged = delegate { };

        [SerializeField]
        private float value = 0f;

        public float Value
        {
            get { return value; }
            set
            {
                this.value = value;
                
                if (OnValueChanged != null)
                {
                    OnValueChanged(this.value);
                }
            }
        }

        public FloatObject() { }

        public FloatObject(float value)
        {
            this.value = value;
        }
    }
}