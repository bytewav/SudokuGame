
namespace Catalyst.Core.Utility
{
    using UnityEngine;
    using System;

    [Serializable]
    public class IntObject
    {
        public event Action<int> OnValueChanged = delegate { };

        [SerializeField]
        private int value = 0;

        public int Value
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

        public IntObject() { }

        public IntObject(int value)
        {
            this.value = value;
        }
    }
}
