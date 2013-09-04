using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Run00.Genesis
{
	public static class ExtensionsForType
	{
		/// <summary>
		/// Determines whether or not the given type is a .Net "system" type or not (i.e. string and date time are added to the list of Primitive and Value types.)
		/// </summary>
		/// <param name="source">Type</param>
		/// <returns>
		/// 	<c>true</c> if the type is a Primitive or Value type or if the type is a string or date time; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsSimpleType(this Type source)
		{
			Contract.Requires(source != null);

			return source.IsPrimitive ||
						 source.IsValueType ||
						 source == typeof(string) ||
						 source == typeof(DateTime);
		}


		/// <summary>
		/// Determines whether [is generic list] [the specified type].
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>
		///   <c>true</c> if [is generic list] [the specified type]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsGenericList(this Type type)
		{
			Contract.Requires(type != null);

			var genericArgs = type.GetGenericArguments();
			if (genericArgs.Count() != 1)
				return false;

			var typeOfList = typeof(List<>);
			if (typeOfList.GetGenericArguments().Length != genericArgs.Length)
				return false;

			Contract.Assume(typeOfList.IsGenericTypeDefinition);

			var typeOfGenericList = typeOfList.MakeGenericType(genericArgs);
			return type.IsAssignableFrom(typeOfGenericList);
		}
	}
}
