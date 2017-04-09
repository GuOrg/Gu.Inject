namespace Gu.Inject
{
    interface IFactory
    {
        object Create(object[] args);
    }
}