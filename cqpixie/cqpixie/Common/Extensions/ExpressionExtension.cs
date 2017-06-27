using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace cqpixie.Common
{
    public static class ExpressionExtension
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
                action(element);
        }

        /// <summary>
        /// 如果类型是Nullable&lt;T&gt;，则返回T，否则返回自身
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type GetNonNullableType(this Type type)
        {
            if (IsNullableType(type))
            {
                return type.GetGenericArguments()[0];
            }
            return type;
        }

        /// <summary>
        /// 是否Nullable&lt;T&gt;类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullableType(this Type type)
        {
            return type != null && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        /// <summary>
        /// 是否Nullable&lt;T&gt;类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNull(this object type)
        {
            var isNull = type == null || String.IsNullOrEmpty(type.ToString().Trim()) || type == DBNull.Value;
            if (!isNull && type is ConstantExpression)
            {
                isNull = (type as ConstantExpression).Value == null;
            }
            if (!isNull && type is Guid)
            {
                isNull = (Guid)type == Guid.Empty;
            }
            return isNull;
        }

        /// <summary>
        /// 是否Nullable&lt;T&gt;类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullArray<T>(this T[] types)
        {
            var isNull = types == null || types.Length == 0;
            if (!isNull)
            {
                foreach (var type in types)
                {
                    isNull = type.IsNull();
                    if (isNull) break;
                }
            }
            return isNull;
        }

        /// <summary>
        /// 获取Lambda表达式的参数表达式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static ParameterExpression[] GetParameters<T, S>(this Expression<Func<T, S>> expr)
        {
            return expr.Parameters.ToArray();
        }

        public static bool IsEmpty<T>(this IEnumerable<T> data)
        {
            return data == null || data.Count() == 0;
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> exp_left, Expression<Func<T, bool>> exp_right)
        {
            var candidateExpr = Expression.Parameter(typeof(T), "candidate");
            var parameterReplacer = new ParameterReplacer(candidateExpr);
            var left = parameterReplacer.Replace(exp_left.Body);
            var right = parameterReplacer.Replace(exp_right.Body);
            var body = Expression.And(left, right);
            return Expression.Lambda<Func<T, bool>>(body, candidateExpr);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> exp_left, Expression<Func<T, bool>> exp_right)
        {
            var candidateExpr = Expression.Parameter(typeof(T), "candidate");
            var parameterReplacer = new ParameterReplacer(candidateExpr);
            var left = parameterReplacer.Replace(exp_left.Body);
            var right = parameterReplacer.Replace(exp_right.Body);
            var body = Expression.Or(left, right);
            return Expression.Lambda<Func<T, bool>>(body, candidateExpr);
        }
    }

    internal class ParameterReplacer : ExpressionVisitor
    {
        public ParameterReplacer(ParameterExpression paramExpr)
        {
            this.ParameterExpression = paramExpr;
        }

        public ParameterExpression ParameterExpression { get; private set; }
        public Expression Replace(Expression expr)
        {
            return this.Visit(expr);
        }
        protected override Expression VisitParameter(ParameterExpression p)
        {
            return this.ParameterExpression;
        }
    }
}