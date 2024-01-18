namespace Mani.Azure.Api.Common
{
    public interface IBaseValidator<T>
    {
        void Validate(T instance);
    }
}