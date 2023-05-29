using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Entities.Player;
using _Main.Scripts.Tree;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace _Main.Scripts.Roulette_Wheel.EntitiesRouletteWheel
{
    public class PlayerRouletteWheel : EntityRouletteWheel
    {

        Roulette _regularAttacksRouletteWheel;
        Dictionary<ActionNode, int> _regularAttacksRouletteWheelNodes = new Dictionary<ActionNode, int>();
        PlayerModel _playerModel;

        public PlayerRouletteWheel(EntityModel model) : base(model)
        {
            _playerModel = model as PlayerModel;
        }

        public override void CreateRouletteWheel()
        {
            _regularAttacksRouletteWheel = new Roulette();

            ActionNode fireballAttack = new ActionNode(PlayerFireballAttack);
            ActionNode guitarSmashAttack = new ActionNode(PlayerGuitarSmashAttack);
            ActionNode firePunchesAttack = new ActionNode(PlayerFirePunchesAttack);

            _regularAttacksRouletteWheelNodes.Add(fireballAttack, 45);
            _regularAttacksRouletteWheelNodes.Add(guitarSmashAttack, 35);
            _regularAttacksRouletteWheelNodes.Add(firePunchesAttack, 15);

            ActionNode rouletteAction = new ActionNode(RouletteAction);
        }

        void PlayerFireballAttack()
        {
            _playerModel.View.FireballSpecialAttack();
        }

        void PlayerGuitarSmashAttack()
        {
            _playerModel.View.GuitarSmashSpecialAttack();
        }

        void PlayerFirePunchesAttack()
        {
            _playerModel.View.FirePunchesSpecialAttack();
        }

        public void RouletteAction()
        {
            INode node = _regularAttacksRouletteWheel.Run(_regularAttacksRouletteWheelNodes);
            node.Execute();
        }

    }
}
