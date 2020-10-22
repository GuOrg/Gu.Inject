namespace Gu.Inject
{
    using System;
    using System.Collections.Generic;

    internal interface IFactory
    {
        IReadOnlyList<Type> ParameterTypes { get; }

        object Create(object[]? args);
    }
}