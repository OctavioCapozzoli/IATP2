using System.Collections.Generic;
using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Tree;
using UnityEngine;

namespace _Main.Scripts.Roulette_Wheel.EnemyRouletteWheel
{
    public class EnemyRouletteWheel : EntityRouletteWheel
    {
        private Roulette _sbRouletteWheel;
        private Dictionary<ActionNode, int> _sbRouletteWheelNodes = new Dictionary<ActionNode, int>();
        private EntityModel _model;
        private EnemyController _enemyController;
        
        
        public EnemyRouletteWheel(EntityModel model, EnemyController enemyController) : base(model)
        {
            _model = model;
            _enemyController = enemyController;
        }

        
        public override void CreateRouletteWheel()
        {
            _sbRouletteWheel = new Roulette();

            ActionNode sbSeek = new ActionNode(GetSeekDir);
            ActionNode sbPursuit = new ActionNode(GetPursuitDir);
            //ActionNode transtoPatrol = new ActionNode(GetTransitionToPatrol);

            _sbRouletteWheelNodes.Add(sbSeek, 60);
            _sbRouletteWheelNodes.Add(sbPursuit, 120);
            //sbRouletteWheelNodes.Add(transtoPatrol, 10);

            ActionNode rouletteAction = new ActionNode(RouletteAction);
        }


        void GetSeekDir()
        {
            _enemyController.EnemySbController.GetSeekDir();
        }

        void GetPursuitDir()
        {
            _enemyController.EnemySbController.GetPursuitDir();
        }


        public void RouletteAction()
        {
            INode node = _sbRouletteWheel.Run(_sbRouletteWheelNodes);
            node.Execute();
        }


    }
}
