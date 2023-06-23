using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Entities.Player;
using _Main.Scripts.Steering_Behaviours.Steering_Behaviours;
using UnityEngine;

namespace _Main.Scripts.Steering_Behaviours
{
    public class SbController
    {

        EnemyModel _enemyModel;
        PlayerModel _target;

        #region Steering Behaviours Variables
        Seek sbSeek;
        Flee sbFlee;
        Pursuit sbPursuit;
        float pursuitTime;
        ISteeringBehaviour sbRouletteSteering;

        public ISteeringBehaviour SbRouletteSteeringBh { get => sbRouletteSteering; set => sbRouletteSteering = value; }
        public Seek SbSeek { get => sbSeek; set => sbSeek = value; }
        public Flee SbFlee { get => sbFlee; set => sbFlee = value; }
        #endregion

        public SbController(EnemyModel _enemyModel, float _pursuitTime)
        {
            this._enemyModel = _enemyModel;
            _target = _enemyModel.GetTarget();
            pursuitTime = _pursuitTime;
            InitializeSB();
        }

        void InitializeSB()
        {
            sbSeek = new Seek(_enemyModel.transform, _target.transform);
            sbFlee = new Flee(_enemyModel.transform, _target.transform);
            sbPursuit = new Pursuit(_enemyModel.transform, _target, pursuitTime);

        }

        public void GetSeekDir()
        {
            sbRouletteSteering = sbSeek;

        }

        public void GetPursuitDir()
        {
            sbRouletteSteering = sbSeek;
        }

        public void GetFleeDir()
        {
            sbRouletteSteering = sbFlee;
        }

    }
}
