using System;
using UnityEngine;

    [Serializable]
	public class DampedVector3
    {
        public Vector3 Value;
        public Vector3 Target;
        public Vector3 Velocity;
        public float Damping;

        public void ApplyDamping()
        {
            Value = Vector3.SmoothDamp(Value, Target, ref Velocity, Damping/ Time.timeScale);
        }
    }

    [Serializable]
    public struct DampedVector2
    {
        public Vector2 Value;
        public Vector2 Target;
        public Vector2 Velocity;
        public float Damping;

        public void ApplyDamping()
        {
			Value = Vector2.SmoothDamp(Value, Target, ref Velocity, Damping/ Time.timeScale,float.MaxValue,Time.deltaTime);
        }
    }

    [Serializable]
    public struct DampedFloat
    {       
        public float Damping;
        public float Target;
        public float Velocity;
        public float Value;

        public void ApplyDamping() 
        {           
            Value = Mathf.SmoothDamp(Value, Target, ref Velocity , Damping / Time.timeScale );
        }

        public void ForceImediateValue(float target)
        {
            Velocity = 0;
            Target = target;
            Value = target;
        }
    }

	[Serializable]
	public struct DampedRect
	{
		public float Damping;
		public Vector2 TargetPos;
		public Vector2 VelocityPos;
		public Vector2 ValuePos;

		public Vector2 TargetSize;
		public Vector2 VelocitySize;
		public Vector2 ValueSize;

		public void ApplyDamping() 
		{           
			ValuePos = Vector2.SmoothDamp(ValuePos, TargetPos, ref VelocityPos, Damping/ Time.timeScale,float.MaxValue,Time.deltaTime);
			ValueSize = Vector2.SmoothDamp(ValueSize, TargetSize, ref VelocitySize, Damping/ Time.timeScale,float.MaxValue,Time.deltaTime);
		}

		public void ForceImediateValue(Rect target)
		{
			VelocityPos = Vector2.zero;
			VelocitySize = Vector2.zero;
			TargetPos = target.position;
			TargetSize = target.size;
			ValuePos = target.position;
			ValueSize = target.size;
		}

		public Rect TargetRect
		{
			get
			{
				return new Rect(TargetPos,TargetSize);
			}
			set
			{
				TargetPos = value.position;
				TargetSize = value.size;
			}
		}
	}
