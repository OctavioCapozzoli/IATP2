using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Tree;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.Roulette_Wheel.EntitiesRouletteWheel
{
    public class EnemyRouletteWheel : EntityRouletteWheel
    {
        //Sb roulette wheel
        private Roulette _sbRouletteWheel;
        private Dictionary<ActionNode, int> _sbRouletteWheelNodes = new Dictionary<ActionNode, int>();
        private EnemyModel _model;
        private EnemyController _enemyController;

        //Attack or block roulette wheel
        private Roulette _attackRouletteWheel;
        private Dictionary<ActionNode, int> _attackRouletteWheelNodes = new Dictionary<ActionNode, int>();

        public EnemyRouletteWheel(EnemyModel model, EnemyController enemyController) : base(model)
        {
            _model = model;
            _enemyController = enemyController;
        }


        public override void CreateRouletteWheel()
        {
            SbRouletteSetUp();
            AttackRouletteSetUp();
        }

        #region Steering Behaviours Enemy Roulette wheel
        void SbRouletteSetUp()
        {
            _sbRouletteWheel = new Roulette();

            ActionNode sbSeek = new ActionNode(GetSeekDir);
            ActionNode sbPursuit = new ActionNode(GetPursuitDir);
            //ActionNode transtoPatrol = new ActionNode(GetTransitionToPatrol);

            _sbRouletteWheelNodes.Add(sbSeek, 60);
            _sbRouletteWheelNodes.Add(sbPursuit, 120);
            //sbRouletteWheelNodes.Add(transtoPatrol, 10);
            //TODO agregarle algo más a esta ruleta
            ActionNode rouletteAction = new ActionNode(EnemySbRouletteAction);
        }

        void GetSeekDir()
        {
            _enemyController.EnemySbController.GetSeekDir();
        }

        void GetPursuitDir()
        {
            _enemyController.EnemySbController.GetPursuitDir();
        }


        public void EnemySbRouletteAction()
        {
            INode node = _sbRouletteWheel.Run(_sbRouletteWheelNodes);
            node.Execute();
        }

        #endregion;

        #region Attack or Block Enemy Roulette Wheel
        void AttackRouletteSetUp()
        {
            _attackRouletteWheel = new Roulette();

            ActionNode Attack1 = new ActionNode(PlayAttack1);
            ActionNode Attack2 = new ActionNode(PlayAttack2);
            ActionNode Attack3 = new ActionNode(PlayAttack3);

            _attackRouletteWheelNodes.Add(Attack1, 30);
            _attackRouletteWheelNodes.Add(Attack2, 25);
            _attackRouletteWheelNodes.Add(Attack3, 35);

            //TODO agregarle algo más a esta ruleta
            ActionNode rouletteAction = new ActionNode(EnemyAttackOrBlockRouletteAction);
        }

        void PlayAttack1()
        {
            Debug.Log("roulette attack 1");
            _model.EnemyView.PlayAttack1Animation();
        }

        void PlayAttack2()
        {
            Debug.Log("roulette attack 2");
            _model.EnemyView.PlayAttack2Animation();
        }

        void PlayAttack3()
        {
            Debug.Log("roulette attack 3");
            _model.EnemyView.PlayAttack3Animation();
        }

        public void EnemyAttackOrBlockRouletteAction()
        {
            INode node = _attackRouletteWheel.Run(_attackRouletteWheelNodes);
            node.Execute();
        }

        #endregion;

    }
}
