using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.Fixture;
using Run00.Genesis.Test.Artifacts;

namespace Run00.Genesis.Test.CreatorTests.RegisterDesign
{
	[TestClass]
	public class PasssingInDesign : Run00Fixture
	{
		[TestMethod]
		public void RegistersDesign()
		{
			//Arrange
			var creator = new Genesis.Creator();

			//Act
			creator.RegisterDesign(new EmptyDesignForSimpleClass());

			//Assert
			var design = creator.GetRegisteredDesignFor(typeof(SimpleClass));
			Assert.IsInstanceOfType(design, typeof(EmptyDesignForSimpleClass));
		}
	}
}
