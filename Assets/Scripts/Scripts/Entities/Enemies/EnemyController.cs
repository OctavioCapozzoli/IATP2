using _Main.Scripts.FSM_SO_VERSION;
using _Main.Scripts.Roulette_Wheel.EnemyRouletteWheel;
using _Main.Scripts.Steering_Behaviours;
using UnityEngine;

namespace _Main.Scripts.Entities.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] StateData initState;
        [SerializeField] float sbPursuitTime;

        public SbController EnemySbController { get => _enemySbController; set => _enemySbController = value; }
        public EnemyRouletteWheel EnemyRoulette { get => _enemyRoulette; set => _enemyRoulette = value; }

        private EnemyModel _model;
        private FsmScript _enemyFsm;
        private SbController _enemySbController;
        private EnemyRouletteWheel _enemyRoulette;

        private void Awake()
        {
            _model = (EnemyModel)GetComponent<EnemyModel>().GetModel();
        }
        private void Start()
        {
            _enemyFsm = new FsmScript(_model, initState);
            _enemySbController = new SbController(_model, sbPursuitTime);
            _enemyRoulette = new EnemyRouletteWheel(_model, this);
        }
        private void Update()
        {
            _enemyFsm.UpdateState();
        }
    }
}