namespace Interpreter
{
    public class CloseRoundExpression: IExpression
    {
        public bool Interpret(ref string context)
        {
            if (context.Contains(" )"))
            {
                context = context.Replace(" )", ")");
                return true;
            }

            return false;
        }
    }
}