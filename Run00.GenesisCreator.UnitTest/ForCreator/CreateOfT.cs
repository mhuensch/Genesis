using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.Genesis;
using Run00.GenesisCreator.UnitTest.Artifacts;
using Moq;

namespace Run00.GenesisCreator.UnitTest.ForCreator
{
	[TestClass]
	public class CreateOfT
	{
		[TestMethod]
		public void WhenNoDesignsAreRegisteredForType_ShouldReturnNull()
		{
			//Arrange
			var moqRegistry = new Mock<IDesignRegistry>(MockBehavior.Strict);
			moqRegistry
				.Setup(r => r.FindDesign(It.IsAny<Type>(), It.IsAny<string>()))
				.Returns(default(Design));
			var creator = (ICreator)new Creator(moqRegistry.Object);

			//Act
			var result = creator.Create<PocoSimple>(string.Empty);

			//Assert
			Assert.IsNull(result);
		}

		[TestMethod]
		public void WhenDesignIsRegisteredForType_ShouldReturnConstructedObject()
		{
			//Arrange
			var moqRegistry = new Mock<IDesignRegistry>(MockBehavior.Strict);
			moqRegistry
				.Setup(r => r.FindDesign(It.IsAny<Type>(), It.IsAny<string>()))
				.Returns(new Design() { CreateUsing = () => new PocoSimple() });
			var creator = (ICreator)new Creator(moqRegistry.Object);

			//Act
			var result = creator.Create<PocoSimple>(string.Empty);

			//Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void WhenDesignIsRegisteredForTypeWithProperty_ShouldReturnConstructedObjectWithValueSet()
		{
			//Arrange
			var moqRegistry = new Mock<IDesignRegistry>(MockBehavior.Strict);
			moqRegistry
				.Setup(r => r.FindDesign(It.IsAny<Type>(), It.IsAny<string>()))
				.Returns(new Design()
				{
					CreateUsing = () => new PocoSimple(),
					PropertyDesigns = new DesignForProperty[] { 
						new DesignForProperty() { ForProperty = typeof(PocoSimple).GetProperty("Id"), SetUsing = () => Guid.NewGuid() } 
					}
				});
			var creator = (ICreator)new Creator(moqRegistry.Object);

			//Act
			var result = creator.Create<PocoSimple>(string.Empty);

			//Assert
			Assert.AreNotEqual(Guid.Empty, result.Id);
		}
	}
}
