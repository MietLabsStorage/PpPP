namespace Interpreter
{
    public class OpenRoundBracketExpression: IExpression
    {
        public bool Interpret(ref string context)
        {
            if (context.Contains("( "))
            {
                context = context.Replace("( ", "(");
                return true;
            }

            return false;
        }
    }
}