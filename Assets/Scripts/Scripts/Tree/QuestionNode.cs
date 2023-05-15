namespace _Main.Scripts.Tree
{
    public class QuestionNode : INode
    {
        public delegate bool myDelegate();
        private myDelegate _question;
        private INode _trueNode;
        private INode _falseNode;
        public QuestionNode(myDelegate question, INode tN, INode fN)
        {
            _question = question;
            _trueNode = tN;
            _falseNode = fN;
        }
        public void Execute()
        {
            if (_question())
            {
                //True
                _trueNode.Execute();
            }
            else
            {
                //False
                _falseNode.Execute();
            }
        }
    }
}
