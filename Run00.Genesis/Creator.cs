using Run00.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

namespace Run00.Genesis
{
	public class Creator
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Creator"/> class.
		/// </summary>
		public Creator()
		{
			_designs = new Dictionary<Type, IntelligentDesign>();
		}


		/// <summary>
		/// Registers the designs with the creator for the type specified in the design.
		/// </summary>
		/// <param name="designs">The designs.</param>
		public void RegisterDesigns(IEnumerable<IntelligentDesign> designs)
		{
			Contract.Requires(designs != null);
			foreach (var design in designs.Where(d => d != null))
			{
				Contract.Assume(design != null);
				RegisterDesign(design);
			}
		}
		/// <summary>
		/// Registers the design with the creator for the type specified in the design.
		/// </summary>
		/// <param name="design">The design.</param>
		public void RegisterDesign(IntelligentDesign design)
		{
			Contract.Requires(design != null);

			if (_designs.ContainsKey(design.ForType))
				_designs[design.ForType] = design;
			else
				_designs.Add(design.ForType, design);
		}
		/// <summary>
		/// Gets the registered design for the specified type.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>Registered design. Returns null if no design has been registered.</returns>
		public IntelligentDesign GetRegisteredDesignFor(Type type)
		{
			Contract.Requires(type != null);
			return _designs.ContainsKey(type) ? _designs[type] : null;
		}


		/// <summary>
		/// Creates the plan that the Creator will use to create and populate an object of the given type.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>A Plan.</returns>
		public Plan CreatePlanFor(Type type)
		{
			Contract.Requires(type != null);
			Contract.Ensures(Contract.Result<Plan>() != null);
			return CreatePlanFor(type, _DEFAULT_LIST_SIZE);
		}
		public Plan CreatePlanFor(Type type, int size)
		{
			Contract.Requires(type != null);
			Contract.Ensures(Contract.Result<Plan>() != null);

			var result = new Plan
			{
				ForType = type,
				Generator = GetGeneratorFor(type, size),
			};

			if (type.IsEnumeration() == false)
			{
				result.PropertyPlans =
						from property in type.GetProperties()
						let planForProperty = CreatePropertyPlanFor(property, result.Generator, size)
						where property.CanWrite && property.CanRead && planForProperty != null
						select planForProperty;
			}

			return result;
		}
		private PropertyPlan CreatePropertyPlanFor(PropertyInfo property, IGenerator parentGenerator, int size)
		{
			Contract.Requires(property != null);

			var plan = CreatePlanFor(property.PropertyType, size);
			var design = parentGenerator as IntelligentDesign;
			if (design != null)
			{
				var mutation = design.FindMutationFor(property);
				if (mutation != null)
					plan.Generator = mutation;
			}

			var result = new PropertyPlan()
			{
				Property = property,
				Plan = plan
			};
			return result;
		}
		private IGenerator GetGeneratorFor(Type type, int size)
		{
			Contract.Requires(type != null);
			Contract.Ensures(Contract.Result<IGenerator>() != null);

			return GetRegisteredDesignFor(type) ?? CreateDesignFor(type, size);
		}
		private IntelligentDesign CreateDesignFor(Type type, int size)
		{
			Contract.Requires(type != null);
			Contract.Ensures(Contract.Result<IntelligentDesign>() != null);

			IntelligentDesign design = null;
			if (type.IsGenericList())
			{
				design = CreateDesignForGenericListOf(type, size);
			}
			else if (type.IsArray)
			{
				design = CreateDesignForArrayOf(type, size);
			}
			else
			{
				design = _designs.ContainsKey(type) == false ? null : _designs[type];
				design = design ?? new IntelligentDesign(type);
			}

			return design;
		}

		private IntelligentDesign CreateDesignForArrayOf(Type type, int size)
		{
			Contract.Requires(type != null);
			Contract.Ensures(Contract.Result<IntelligentDesign>() != null);

			var genericArg = type.GetElementType();
			var itemDesign = GetRegisteredDesignFor(genericArg) ?? CreateDesignFor(genericArg, size);

			var simpleType = typeof(List<>);
			var typeList = new[] { genericArg };

			if (simpleType.GetGenericArguments().Length != typeList.Length || simpleType.IsGenericTypeDefinition == false)
				return new IntelligentDesign(type);

			var listType = simpleType.MakeGenericType(typeList);

			var result = new IntelligentDesign(listType);
			result.CreateUsing(() =>
			{
				var list = Activator.CreateInstance(listType) as IList;
				for (int count = 0; count < size; count++)
				{
					var item = ((IGenerator)itemDesign).Generate();
					if (item != null)
					{
						item = Populate(item, CreatePlanFor(genericArg).PropertyPlans, _DEFAULT_RECURSION_DEPTH, _DEFAULT_RECURSION_DEPTH);
						list.Add(item);
					}
				}
				return list;
			});

			return result;
		}

		private IntelligentDesign CreateDesignForGenericListOf(Type type, int size)
		{
			Contract.Requires(type != null);
			Contract.Ensures(Contract.Result<IntelligentDesign>() != null);

			var genericArgs = type.GetGenericArguments();
			if (genericArgs.Count() != 1)
				return new IntelligentDesign(type);

			var genericArg = type.GetGenericArguments().FirstOrDefault();
			if (genericArg == null)
				return new IntelligentDesign(type);

			var itemDesign = GetRegisteredDesignFor(genericArg) ?? CreateDesignFor(genericArg, size);

			var simpleType = typeof(List<>);
			var typeList = new[] { genericArg };

			if (simpleType.GetGenericArguments().Length != typeList.Length || simpleType.IsGenericTypeDefinition == false)
				return new IntelligentDesign(type);

			var listType = simpleType.MakeGenericType(typeList);

			var result = new IntelligentDesign(listType);
			result.CreateUsing(() =>
			{
				var list = Activator.CreateInstance(listType) as IList;
				for (int count = 0; count < size; count++)
				{
					var item = ((IGenerator)itemDesign).Generate();
					if (item != null)
					{
						item = Populate(item, CreatePlanFor(genericArg).PropertyPlans, _DEFAULT_RECURSION_DEPTH, _DEFAULT_RECURSION_DEPTH);
						list.Add(item);
					}
				}
				return list;
			});

			return result;
		}

		public T Create<T>()
		{
			var result = Create(typeof(T));
			if (result == null)
				return default(T);
			return (T)result;
		}
		public T Create<T>(int recursionDepth)
		{
			var result = Create(typeof(T), recursionDepth);
			if (result == null)
				return default(T);

			return (T)result;
		}
		public object Create(Type type)
		{
			Contract.Requires(type != null);
			return Create(type, _DEFAULT_RECURSION_DEPTH);
		}
		public object Create(Type type, int count)
		{
			Contract.Requires(type != null);

			var plan = CreatePlanFor(type, count);
			if (plan.Generator == null)
				return null;

			var result = Create(plan, _DEFAULT_RECURSION_DEPTH, 0);
			return result;
		}
		private object Create(Plan plan, int recursionDepth, int depth)
		{
			Contract.Requires(plan != null);
			Contract.Requires(plan.Generator != null);

			var result = plan.Generator.Generate();
			if (result == null)
				return null;

			result = Populate(result, plan.PropertyPlans, recursionDepth, depth);

			return result;
		}
		private object Populate(object obj, IEnumerable<PropertyPlan> propertyPlans, int recursionDepth, int depth)
		{
			if (propertyPlans == null)
				return obj;

			var currentPlans =
				from plan
				in propertyPlans
				where depth <= recursionDepth || plan.Property.PropertyType.IsSimpleType()
				select plan;


			var complexPlans = new Dictionary<Plan, object>();
			foreach (var propertyPlan in currentPlans)
			{
				if (propertyPlan == null)
					continue;
				if (propertyPlan.Plan == null)
					continue;
				if (propertyPlan.Plan.Generator == null)
					continue;

				var value = propertyPlan.Plan.Generator.Generate();
				if (value == null)
					continue;

				if (propertyPlan.Property == null)
					continue;

				propertyPlan.Property.SetValue(obj, value, null);
				if (value.GetType().IsSimpleType() == false)
					complexPlans.Add(propertyPlan.Plan, value);
			}

			foreach (var keySet in complexPlans)
			{
				if (keySet.Key == null)
					continue;

				Populate(keySet.Value, keySet.Key.PropertyPlans, recursionDepth, depth + 1);
			}

			return obj;
		}


		#region private
		private const int _DEFAULT_RECURSION_DEPTH = 3;
		private const int _DEFAULT_LIST_SIZE = 3;
		private readonly Dictionary<Type, IntelligentDesign> _designs;

		[ContractInvariantMethod]
		[ExcludeFromCodeCoverage]
		[SuppressMessage("Microsoft.Performance", "CA1811:MarkMembersAsStatic", Justification = "Required for code contracts.")]
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Required for code contracts.")]
		private void ObjectInvariant()
		{
			Contract.Invariant(_designs != null);
		}
		#endregion
	}
}
