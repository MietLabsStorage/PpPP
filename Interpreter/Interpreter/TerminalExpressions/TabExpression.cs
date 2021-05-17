namespace Interpreter
{
    public class TabExpression: IExpression
    {
        public bool Interpret(ref string context)
        {
            if (context.Contains("\t"))
            {
                context = context.Replace("\t", " ");
                return true;
            }

            return false;
        }
    }
}