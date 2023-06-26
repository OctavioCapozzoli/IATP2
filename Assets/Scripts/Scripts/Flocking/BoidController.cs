using _Main.Scripts.FSM_SO_VERSION;
using _Main.Scripts.Roulette_Wheel.EntitiesRouletteWheel;
using _Main.Scripts.Steering_Behaviours;
using UnityEngine;

namespace _Main.Scripts.Entities.Enemies
{
    public class BoidController : MonoBehaviour
    {
        [SerializeField] StateData initState;

        private EnemyMinion _model;
        private FsmScript _enemyFsm;

        private void Awake()
        {
            _model = (EnemyMinion)GetComponent<EnemyMinion>().GetModel();
        }
        private void Start()
        {
            _enemyFsm = new FsmScript(_model, initState);
        }
        private void Update()
        {
            _enemyFsm.UpdateState();
        }
    }
}