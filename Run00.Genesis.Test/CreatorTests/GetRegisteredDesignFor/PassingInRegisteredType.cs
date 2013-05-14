using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.Fixture;
using Run00.Genesis.Test.Artifacts;

namespace Run00.Genesis.Test.CreatorTests.GetRegisteredDesignFor
{
	[TestClass]
	public class PassingInRegisteredType : Run00Fixture
	{
		[TestMethod]
		public void ReturnsRegisteredDesign()
		{
			//Arrange
			var creator = new Genesis.Creator();
			creator.RegisterDesign(new EmptyDesignForSimpleClass());

			//Act
			var design = creator.GetRegisteredDesignFor(typeof(SimpleClass));

			//Assert
			Assert.IsInstanceOfType(design, typeof(EmptyDesignForSimpleClass));
		}
	}
}
