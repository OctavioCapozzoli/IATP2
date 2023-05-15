using _Main.Scripts.Entities;
using UnityEngine;

namespace _Main.Scripts.Steering_Behaviours.Steering_Behaviours
{
    public class Pursuit : ISteeringBehaviour
    {
        private Transform _origin;
        private EntityModel _target;
        private float _time;
        
        public Pursuit(Transform origin, EntityModel target, float time)
        {
            _origin = origin;
            _target = target;
            _time = time;
        }
        public virtual Vector3 GetDir()
        {
            Vector3 point = _target.transform.position + (_target.GetFoward() * Mathf.Clamp(_target.GetSpeed() * _time, 0, 100));
            return (point - _origin.position).normalized;
        }
    }
}
