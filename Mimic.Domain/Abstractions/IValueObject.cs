namespace Mimic.Domain.Abstractions;

/// <summary>
/// IValueObject concretions wrap simple types with domain rules. It is possible to retrieve the values from these
/// concretions
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IValueObject<out T>
{
    /// <summary>
    /// Retrieve the value wrapped by the ValueObject
    /// </summary>
    /// <returns></returns>
    public T Value();
}
