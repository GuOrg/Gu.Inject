namespace Gu.Inject
{
    internal enum BindingKind
    {
        Func,
        ResolverFunc,
        Map,
        Instance,
        Uninitialized,
        Initialized,
        AutoResolved,
        Created,
        Resolved,
        Mapped,
    }
}
