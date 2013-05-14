using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.Fixture;

namespace Run00.Genesis.Test.CreatorTests.Constructor
{
	[TestClass]
	public class WithoutArguments : Run00Fixture
	{
		[TestMethod]
		public void ReturnsNewCreator()
		{
			//Act
			var result = new Creator();

			//Assert
			Assert.IsNotNull(result);
		}
	}
}
