using UnityEngine;

namespace _Main.Scripts.Steering_Behaviours.Steering_Behaviours
{
    public class Seek : ISteeringBehaviour
    {
        private Transform _origin;
        private Transform _target;

        public Seek(Transform origin, Transform target)
        {
            _origin = origin;
            _target = target;
        }

        public Vector3 GetDir()
        {
            return (_target.position - _origin.position).normalized;
        }

    }
}
