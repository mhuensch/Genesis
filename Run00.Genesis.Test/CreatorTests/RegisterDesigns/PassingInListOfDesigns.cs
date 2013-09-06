using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.Fixture;
using Run00.Genesis.Test.Artifacts;

namespace Run00.Genesis.Test.CreatorTests.RegisterDesigns
{
	[TestClass]
	public class PassingInListOfDesigns : Run00Fixture
	{
		[TestMethod]
		public void RegistersEachDesign()
		{
			//Arrange
			var creator = new Genesis.Creator();
			var designs = new List<IntelligentDesign>() { new EmptyDesignForSimpleClass(), new DesignForRecursiveClass() };

			//Act
			creator.RegisterDesigns(designs);

			//Assert
			var design = creator.GetRegisteredDesignFor(typeof(SimpleClass));
			Assert.IsInstanceOfType(design, typeof(EmptyDesignForSimpleClass));
			design = creator.GetRegisteredDesignFor(typeof(RecursiveClass));
			Assert.IsInstanceOfType(design, typeof(DesignForRecursiveClass));
		}
	}
}
