using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Tree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.Roulette_Wheel.EntitiesRouletteWheel
{
    public class BossRouletteWheel : EntityRouletteWheel
    {
        BossEnemyModel model;
        BossEnemyController controller;

        //Regular Attack roulette wheel
        private Roulette _regularAttacksRouletteWheel;
        private Dictionary<ActionNode, int> _regularAttacksRouletteWheelNodes = new Dictionary<ActionNode, int>();

        //Enhanced Attack roulette wheel
        private Roulette _enhancedAttacksRouletteWheel;
        private Dictionary<ActionNode, int> _enhancedAttacksRouletteWheelNodes = new Dictionary<ActionNode, int>();

        //Desperate Attack roulette wheel
        private Roulette _desperateAttacksRouletteWheel;
        private Dictionary<ActionNode, int> _desperateAttacksRouletteWheelNodes = new Dictionary<ActionNode, int>();

        public BossRouletteWheel(BossEnemyModel _model, BossEnemyController _controller) : base(_model)
        {
            model = _model;
            controller = _controller;
        }

        public override void CreateRouletteWheel()
        {
            RegularAttacksRouletteSetUp();
            EnhancedAttacksRouletteSetUp();
            DesperateAttackRouletteSetUp();
        }

        #region Regular Attacks Roulette Wheel
        void RegularAttacksRouletteSetUp()
        {
            _regularAttacksRouletteWheel = new Roulette();

            ActionNode Attack1 = new ActionNode(PlayAttack1);
            ActionNode Attack2 = new ActionNode(PlayAttack2);
            ActionNode Attack3 = new ActionNode(PlayAttack3);

            _regularAttacksRouletteWheelNodes.Add(Attack1, 30);
            _regularAttacksRouletteWheelNodes.Add(Attack2, 25);
            _regularAttacksRouletteWheelNodes.Add(Attack3, 35);

            ActionNode rouletteAction = new ActionNode(EnemyRegularAttacksRouletteAction);
        }

        void PlayAttack1()
        {
            model.EnemyView.PlayAttack1Animation();
        }

        void PlayAttack2()
        {
            model.EnemyView.PlayAttack2Animation();
        }

        void PlayAttack3()
        {
            model.EnemyView.PlayAttack3Animation();
        }

        public void EnemyRegularAttacksRouletteAction()
        {
            INode node = _regularAttacksRouletteWheel.Run(_regularAttacksRouletteWheelNodes);
            node.Execute();
        }

        #endregion

        #region Enhanced Attacks Roulette Wheel
        void EnhancedAttacksRouletteSetUp()
        {
            _enhancedAttacksRouletteWheel = new Roulette();

            ActionNode EnhancedAttack1 = new ActionNode(PlayEnhancedAttack1);
            ActionNode EnhancedAttack2 = new ActionNode(PlayEnhancedAttack2);
            ActionNode EnhancedAttack3 = new ActionNode(PlayEnhancedAttack3);

            _enhancedAttacksRouletteWheelNodes.Add(EnhancedAttack1, 30);
            _enhancedAttacksRouletteWheelNodes.Add(EnhancedAttack2, 25);
            _enhancedAttacksRouletteWheelNodes.Add(EnhancedAttack3, 35);

            ActionNode rouletteAction = new ActionNode(EnemyEnhancedAttacksRouletteAction);
        }

        void PlayEnhancedAttack1()
        {
            model.EnemyView.PlayEnhancedAttack1Animation();
        }

        void PlayEnhancedAttack2()
        {
            model.EnemyView.PlayEnhancedAttack2Animation();
        }

        void PlayEnhancedAttack3()
        {
            model.EnemyView.PlayEnhancedAttack3Animation();
        }

        public void EnemyEnhancedAttacksRouletteAction()
        {
            INode node = _enhancedAttacksRouletteWheel.Run(_enhancedAttacksRouletteWheelNodes);
            node.Execute();
        }

        #endregion

        #region Desperate Attacks Roulette Wheel
        void DesperateAttackRouletteSetUp()
        {
            _enhancedAttacksRouletteWheel = new Roulette();

            ActionNode DesperateAttack1 = new ActionNode(PlayDesperateAttack1);
            ActionNode DesperateAttack2 = new ActionNode(PlayDesperateAttack2);
            ActionNode DesperateAttack3 = new ActionNode(PlayDesperateAttack3);

            _desperateAttacksRouletteWheelNodes.Add(DesperateAttack1, 30);
            _desperateAttacksRouletteWheelNodes.Add(DesperateAttack2, 25);
            _desperateAttacksRouletteWheelNodes.Add(DesperateAttack3, 35);

            ActionNode rouletteAction = new ActionNode(EnemyDesperateAttacksRouletteAction);
        }

        void PlayDesperateAttack1()
        {
            model.EnemyView.PlayDesperateAttack1Animation();
        }

        void PlayDesperateAttack2()
        {
            model.EnemyView.PlayDesperateAttack2Animation();
        }

        void PlayDesperateAttack3()
        {
            model.EnemyView.PlayDesperateAttack3Animation();
        }

        public void EnemyDesperateAttacksRouletteAction()
        {
            INode node = _desperateAttacksRouletteWheel.Run(_desperateAttacksRouletteWheelNodes);
            node.Execute();
        }

        #endregion
    }
}
