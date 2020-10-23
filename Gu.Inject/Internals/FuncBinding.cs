namespace Gu.Inject
{
    using System;

    internal struct FuncBinding
    {
        internal readonly Func<object> Func;

        internal FuncBinding(Func<object> func)
        {
            this.Func = func;
        }
    }
}