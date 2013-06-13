using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.Fixture;
using Run00.Genesis.Test.Artifacts;

namespace Run00.Genesis.Test.CreatorTests.CreatePlanFor
{
	[TestClass]
	public class PassingInRegisteredType : Run00Fixture
	{
		[TestMethod]
		public void ReturnsAPlan()
		{
			//Arrange
			var creator = new Genesis.Creator();
			creator.RegisterDesign(new EmptyDesignForSimpleClass());

			//Act
			var plan = creator.CreatePlanFor(typeof(SimpleClass));

			//Assert
			Assert.IsNotNull(plan);
		}

		[TestMethod]
		public void ReturnsAPlanForTheType()
		{
			//Arrange
			var creator = new Genesis.Creator();
			creator.RegisterDesign(new EmptyDesignForSimpleClass());

			//Act
			var plan = creator.CreatePlanFor(typeof(SimpleClass));

			//Assert
			Assert.AreEqual(typeof(SimpleClass), plan.ForType);
		}

		[TestMethod]
		public void ReturnsAPlanUsingTheSpecifiedGenerator()
		{
			//Arrange
			var creator = new Genesis.Creator();
			creator.RegisterDesign(new EmptyDesignForSimpleClass());

			//Act
			var plan = creator.CreatePlanFor(typeof(SimpleClass));

			//Assert
			Assert.AreEqual(typeof(EmptyDesignForSimpleClass), plan.GeneratorType);
		}

		[TestMethod]
		public void ReturnsPlanWiithPropertyPlans()
		{
			//Arrange
			var creator = new Genesis.Creator();
			creator.RegisterDesign(new DesignForComplexClass());

			//Act
			var plan = creator.CreatePlanFor(typeof(ComplexClass));

			//Assert
			Assert.AreEqual(5, plan.PropertyPlans.Count());
		}

		[TestMethod]
		public void ReturnsPlanWiithSpecificMutationPropertyPlans()
		{
			//Arrange
			var creator = new Genesis.Creator();
			creator.RegisterDesign(new DesignForComplexClass());
			creator.RegisterDesign(new StringDesign());

			//Act
			var plan = creator.CreatePlanFor(typeof(ComplexClass));

			//Assert
			foreach (var propPlan in plan.PropertyPlans)
			{
				var mutationType = typeof(IntelligentMutation<>).MakeGenericType(new[] { propPlan.Property.PropertyType });
				Assert.AreEqual(propPlan.Plan.GeneratorType, mutationType);
			}
		}
	}
}
