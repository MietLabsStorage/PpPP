namespace Interpreter
{
    public class NewlinesExpression: IExpression
    {
        public bool Interpret(ref string context)
        {
            if (context.Contains("\n\n"))
            {
                context = context.Replace("\n\n", "\n");
                return true;
            }

            return false;
        }
    }
}