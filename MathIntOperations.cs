namespace Net_Delegates
{
    delegate int IntOperation(int i, int j);

    class MathIntOperations
    {
        internal int Sum(int x, int y)
        {
            return x + y;
        }

        internal int Minus(int x, int y)
        {
            return x - y;
        }

        internal int Multiply(int x, int y)
        {
            return x * y;
        }

        internal int Divide(int x, int y)
        {
            return x / y;
        }
    }
}