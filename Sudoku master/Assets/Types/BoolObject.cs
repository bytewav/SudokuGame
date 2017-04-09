
namespace Catalyst.Core.Utility
{
    using UnityEngine;
    using System;

    [Serializable]
    public class BoolObject
    {
        public event Action<bool> OnValueChanged = delegate { };

        [SerializeField]
        private bool value = false;

        public bool Value
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

        public BoolObject() { }

        public BoolObject(bool value)
        {
            this.value = value;
        }
    }
}

