namespace Gu.Inject
{
    using System;

    [Serializable]
    [Flags]
    public enum Visibility
    {
        Public = 0,
        Internal = 1 << 0,
        Private = 1 << 1,
    }
}