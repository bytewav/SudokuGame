
namespace Catalyst.Core.Utility
{
    using System;
    using UnityEngine;

    [Serializable]
    public class StringObject
    {
        public event Action<string> OnValueChanged = delegate { };

        [SerializeField]
        private string value = string.Empty;

        public string Value
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

        public StringObject() { }

        public StringObject(string value)
        {
            this.value = value;
        }
    }
}