namespace Net_Delegates
{
    delegate int IntOperation(int i, int j);

    class MathIntOperations
    {
        internal int Sum(int x, int y)
        {
            return x + y;
        }

        internal int Min(int x, int y)
        {
            return x - y;
        }

        internal int Mul(int x, int y)
        {
            return x * y;
        }

        internal int Div(int x, int y)
        {
            return x / y;
        }
    }
}