namespace Gu.Inject
{
    using System;
    using System.Collections.Generic;

    interface IFactory
    {
        object Create(object[] args);

        IReadOnlyList<Type> ParameterTypes { get; }
    }
}