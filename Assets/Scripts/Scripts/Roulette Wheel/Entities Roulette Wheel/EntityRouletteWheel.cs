using _Main.Scripts.Entities;

namespace _Main.Scripts.Roulette_Wheel.EntitiesRouletteWheel
{
    public abstract class EntityRouletteWheel
    {
        public EntityRouletteWheel(EntityModel _model)
        {

            CreateRouletteWheel();
        }

        public abstract void CreateRouletteWheel();
    }
}
