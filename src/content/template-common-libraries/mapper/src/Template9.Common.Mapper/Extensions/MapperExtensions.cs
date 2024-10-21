using System.Linq.Expressions;
using AutoMapper;

namespace Template9.Common.Mapper.Extensions;

public static class MapperExtensions
{
    /// <summary>
    /// Marks a member on the destination type as ignored.
    /// </summary>
    /// <typeparam name="TSource">The source instance type</typeparam>
    /// <typeparam name="TDestination">The destination instance type</typeparam>
    /// <param name="mapping">The current mapping expression</param>
    /// <param name="getDestinationMember">A function that returns the destination member</param>
    /// <returns>Itself</returns>
    public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>
    (
        this IMappingExpression<TSource, TDestination> mapping,
        Expression<Func<TDestination, object>> getDestinationMember
    )
    {
        if (mapping == null)
            throw new ArgumentException($"Missing required parameter {nameof(mapping)}");

        return mapping.ForMember(getDestinationMember, opt => opt.Ignore());
    }

    /// <summary>
    /// Maps a member from <typeparamref name="TSource"/> onto a member from <typeparamref name="TDestination"/> with an optional condition.
    /// </summary>
    /// <typeparam name="TSource">The source instance type</typeparam>
    /// <typeparam name="TDestination">The destination instance type</typeparam>
    /// <typeparam name="TMember">The source instance mapped member type</typeparam>
    /// <param name="mapping">The current mapping expression</param>
    /// <param name="getSourceMember">Returns the mapped member from the source type</param>
    /// <param name="getDestinationMember">Returns the mapped member from the destination type</param>
    /// <returns>Itself</returns>
    public static IMappingExpression<TSource, TDestination> AndMap<TSource, TDestination, TMember>
    (
        this IMappingExpression<TSource, TDestination> mapping,
        Expression<Func<TSource, TMember>> getSourceMember,
        Expression<Func<TDestination, object>> getDestinationMember
    )
    {
        return mapping.AndMap(getSourceMember, getDestinationMember, null);
    }

    /// <summary>
    /// Maps a member from <typeparamref name="TSource"/> onto a member from <typeparamref name="TDestination"/> with an optional condition.
    /// </summary>
    /// <typeparam name="TSource">The source instance type</typeparam>
    /// <typeparam name="TDestination">The destination instance type</typeparam>
    /// <typeparam name="TMember">The source instance mapped member type</typeparam>
    /// <param name="mapping">The current mapping expression</param>
    /// <param name="getSourceMember">Returns the mapped member from the source type</param>
    /// <param name="getDestinationMember">Returns the mapped member from the destination type</param>
    /// <param name="onlyIfCondition">Optional condition to specify for the mapping to be applicable</param>
    /// <returns>Itself</returns>
    public static IMappingExpression<TSource, TDestination> AndMap<TSource, TDestination, TMember>
    (
        this IMappingExpression<TSource, TDestination> mapping,
        Expression<Func<TSource, TMember>> getSourceMember,
        Expression<Func<TDestination, object>> getDestinationMember,
        Func<TSource, bool>? onlyIfCondition
    )
    {
        if (mapping == null)
            throw new ArgumentException($"Missing required parameter {nameof(mapping)}");

        return mapping.ForMember(getDestinationMember, opt =>
        {
            opt.MapFrom<TMember>(getSourceMember);
            if (onlyIfCondition != null) opt.Condition(onlyIfCondition);
        });
    }
}
