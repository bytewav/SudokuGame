
namespace Catalyst.Core.Utility
{
    using UnityEngine;
    using System;

    [Serializable]
    public class DoubleObject : MonoBehaviour
    {
        public event Action<double> OnValueChanged = delegate { };

        [SerializeField]
        private double value = 0;

        public double Value
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

        public DoubleObject() { }

        public DoubleObject(double value)
        {
            this.value = value;
        }
    }
}
