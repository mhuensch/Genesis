using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.Fixture;
using Run00.Genesis.Test.Artifacts;

namespace Run00.Genesis.Test.CreatorTests.Create
{
	[TestClass]
	public class PassingInRegisteredType : Run00Fixture
	{
		[TestMethod]
		public void ReturnsNewObjectOfRegisteredType()
		{
			//Arrange
			var creator = new Genesis.Creator();
			creator.RegisterDesign(new EmptyDesignForSimpleClass());

			//Act
			var simpleClass = creator.Create(typeof(SimpleClass));

			//Assert
			Assert.IsInstanceOfType(simpleClass, typeof(SimpleClass));
		}

		[TestMethod]
		public void ReturnsPopulatedObject()
		{
			//Arrange
			var creator = new Genesis.Creator();
			creator.RegisterDesign(new DesignForComplexClass());
			creator.RegisterDesign(new StringDesign());

			//Act
			var complexClass = creator.Create(typeof(ComplexClass)) as ComplexClass;

			//Assert
			Assert.AreEqual(DateTime.Parse("08/13/1977"), complexClass.Date);
			Assert.AreEqual(Guid.Parse("FBB49DE7-B6C3-4340-8595-45E19817147C"), complexClass.Id);
			Assert.AreEqual("My Complex Class", complexClass.Name);
			Assert.AreEqual(10, complexClass.Number);
			Assert.AreEqual("One", complexClass.Ids.ElementAt(0));
			Assert.AreEqual("Two", complexClass.Ids.ElementAt(1));
			Assert.AreEqual("Three", complexClass.Ids.ElementAt(2));

		}

		[TestMethod]
		public void ReturnsListOfPopulatedObject()
		{
			//Arrange
			var creator = new Genesis.Creator();
			creator.RegisterDesign(new DesignForComplexClass());

			//Act
			var complexClassList = creator.Create(typeof(IEnumerable<ComplexClass>)) as IEnumerable<ComplexClass>;

			foreach (var item in complexClassList)
			{
				Assert.AreEqual(DateTime.Parse("08/13/1977"), item.Date);
				Assert.AreEqual(Guid.Parse("FBB49DE7-B6C3-4340-8595-45E19817147C"), item.Id);
				Assert.AreEqual("My Complex Class", item.Name);
				Assert.AreEqual(10, item.Number);
				Assert.AreEqual("One", item.Ids.ElementAt(0));
				Assert.AreEqual("Two", item.Ids.ElementAt(1));
				Assert.AreEqual("Three", item.Ids.ElementAt(2));
			}
		}
	}
}
