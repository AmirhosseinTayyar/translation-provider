using Core.Domain.Common.Consts;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;

namespace Core.Domain.Common.Guards;

public static class EntityGuard
{
    public static void ThrowIfNull<TEntity, TId>(TEntity? entity, params string[] parameters)
        where TEntity : Entity<TId>
        where TId : struct, IComparable, IComparable<TId>, IConvertible, IEquatable<TId>, IFormattable
    {
        if (entity is null)
        {
            throw new InvalidEntityStateException(ProjectValidationErrors.VALIDATION_ERROR_NOT_EXIST, parameters);
        }
    }
}