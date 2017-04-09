
namespace Catalyst.Core.Utility
{
    using UnityEngine;
    using System;

    [Serializable]
    public class LongObject
    {
        public event Action<long> OnValueChanged = delegate { };

        [SerializeField]
        private long value = 0;

        public long Value
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

        public LongObject() { }

        public LongObject(long value)
        {
            this.value = value;
        }
    }
}

