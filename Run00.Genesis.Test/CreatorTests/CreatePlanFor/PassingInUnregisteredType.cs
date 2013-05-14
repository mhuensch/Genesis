using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.Fixture;
using Run00.Genesis.Test.Artifacts;

namespace Run00.Genesis.Test.CreatorTests.CreatePlanFor
{
	[TestClass]
	public class PassingInUnregisteredType : Run00Fixture
	{
		[TestMethod]
		public void ReturnsAPlan()
		{
			//Arrange
			var creator = new Genesis.Creator();

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

			//Act
			var plan = creator.CreatePlanFor(typeof(SimpleClass));

			//Assert
			Assert.AreEqual(typeof(SimpleClass), plan.ForType);
		}

		[TestMethod]
		public void ReturnsAPlanUsingAGenericGenerator()
		{
			//Arrange
			var creator = new Genesis.Creator();

			//Act
			var plan = creator.CreatePlanFor(typeof(SimpleClass));

			//Assert
			Assert.AreEqual(typeof(IntelligentDesign), plan.GeneratorType);
		}

		[TestMethod]
		public void ReturnsPlanWiithPropertyPlans()
		{
			//Arrange
			var creator = new Genesis.Creator();

			//Act
			var plan = creator.CreatePlanFor(typeof(ComplexClass));

			//Assert
			Assert.AreEqual(5, plan.PropertyPlans.Count());
		}

		[TestMethod]
		public void ReturnsPlanWiithGenericPropertyPlans()
		{
			//Arrange
			var creator = new Genesis.Creator();

			//Act
			var plan = creator.CreatePlanFor(typeof(ComplexClass));

			//Assert
			foreach (var propPlan in plan.PropertyPlans)
				Assert.AreEqual(propPlan.Plan.GeneratorType, typeof(IntelligentDesign));
		}
	}
}
