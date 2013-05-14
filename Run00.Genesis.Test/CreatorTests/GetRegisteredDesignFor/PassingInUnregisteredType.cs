using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.Fixture;
using Run00.Genesis.Test.Artifacts;

namespace Run00.Genesis.Test.CreatorTests.GetRegisteredDesignFor
{
	[TestClass]
	public class PassingInUnregisteredType : Run00Fixture
	{
		[TestMethod]
		public void ReturnsNull()
		{
			//Arrange
			var creator = new Genesis.Creator();

			//Act
			var design = creator.GetRegisteredDesignFor(typeof(SimpleClass));

			//Assert
			Assert.IsNull(design);
		}
	}
}
