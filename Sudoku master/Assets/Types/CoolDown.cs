using System;

namespace Catalyst.Core.Types
{
    [Serializable]
    public class Cooldown
    {
        public float value;
        public float maxValue;

        public event Action OnReady;

        public float PercentReady
        {
            get { return value / maxValue; }
        }

        public bool IsReady
        {
            get { return value >= maxValue; }
        }

        public void Use()
        {
            value = 0;
        }

        public void Fill(float fillValue)
        {
            value += fillValue;
            if (IsReady && OnReady != null)
                OnReady();
        }

        public void SetReady()
        {
            Fill(maxValue);
        }
    }
}