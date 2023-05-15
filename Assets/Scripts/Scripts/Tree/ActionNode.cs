namespace _Main.Scripts.Tree
{
    public class ActionNode : INode
    {
        public delegate void myDelegate();
        myDelegate _action;

        public ActionNode(myDelegate action)
        {
            _action = action;
        }

        
        public void Execute()
        {
            _action();
        }
    }
}
