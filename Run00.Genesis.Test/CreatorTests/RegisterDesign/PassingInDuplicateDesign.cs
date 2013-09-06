using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.Fixture;
using Run00.Genesis.Test.Artifacts;

namespace Run00.Genesis.Test.CreatorTests.RegisterDesign
{
	[TestClass]
	public class PassingInDuplicateDesign : Run00Fixture
	{
		[TestMethod]
		public void RegistersNewerDesign()
		{
			//Arrange
			var creator = new Genesis.Creator();

			//Act
			creator.RegisterDesign(new EmptyDesignForSimpleClass());
			creator.RegisterDesign(new DuplicateDesignForSimpleClass());

			//Assert
			var design = creator.GetRegisteredDesignFor(typeof(SimpleClass));
			Assert.IsInstanceOfType(design, typeof(DuplicateDesignForSimpleClass));
		}
	}
}
