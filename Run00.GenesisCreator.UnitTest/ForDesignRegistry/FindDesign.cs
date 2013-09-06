//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Run00.Genesis;
//using Run00.GenesisCreator.UnitTest.Artifacts;

//namespace Run00.GenesisCreator.UnitTest.ForDesignRegistry
//{
//	[TestClass]
//	public class FindDesign
//	{
//		[TestMethod]
//		public void WhenDesignMatchesType_ShouldReturnConstructedObject()
//		{
//			//Arrange
//			var designs = new IIntelligentDesign[] { new DesignForPocoSimple() };
//			var registry = (IDesignRegistry)new DesignRegistry(designs);

//			//Act
//			var result = registry.FindDesign(typeof(PocoSimple), string.Empty);

//			//Assert
//			Assert.IsNotNull(result);
//		}

//		[TestMethod]
//		public void WhenDesignDoesntMatchType_ShouldReturnNull()
//		{
//			//Arrange
//			var designs = new IIntelligentDesign[] { new DesignForPocoSimple() };
//			var registry = (IDesignRegistry)new DesignRegistry(designs);

//			//Act
//			var result = registry.FindDesign(typeof(PocoSimple), string.Empty);

//			//Assert
//			Assert.IsNull(result);
//		}

//		[TestMethod]
//		public void WhenMoreThanOneDesignMatchesTheType_ShouldReturnConstructedObject()
//		{
//			//Arrange
//			var designs = new IIntelligentDesign[] { new DesignForPocoSimple() };
//			var registry = (IDesignRegistry)new DesignRegistry(designs);

//			//Act
//			var result = registry.FindDesign(typeof(PocoSimple), string.Empty);

//			//Assert
//			Assert.IsNotNull(result);
//		}

//		[TestMethod]
//		public void WhenDesignMatchesAproximateType_ShouldReturnConstructedObject()
//		{
//			//Arrange
//			var designs = new IIntelligentDesign[] { new DesignForPocoSimple() };
//			var registry = (IDesignRegistry)new DesignRegistry(designs);

//			//Act
//			var result = registry.FindDesign(typeof(PocoConcrete), string.Empty);

//			//Assert
//			Assert.IsNotNull(result);
//		}

//		//[TestMethod]
//		//public void WhenDesignMatchesName_ShouldReturnNamedPatternObject()
//		//{
//		//	//Arrange
//		//	var name = Guid.NewGuid().ToString();
//		//	var designs = new IIntelligentDesign[] { new DesignForPocoSimple() };
//		//	var registry = (IDesignRegistry)new DesignRegistry(designs);

//		//	//Act
//		//	var result = registry.FindDesign(typeof(PocoSimple), name);

//		//	//Assert
//		//	Assert.AreEqual(design1, result);
//		//	Assert.AreNotEqual(design2, result);
//		//}

//		//[TestMethod]
//		//public void WhenDesignMatchesAproximateTypeOrConcreteType_ShouldReturnExactMatch()
//		//{
//		//	//Arrange
//		//	var name = Guid.NewGuid().ToString();
//		//	var designs = new IIntelligentDesign[] { new DesignForPocoSimple() };
//		//	var registry = (IDesignRegistry)new DesignRegistry(designs);

//		//	//Act
//		//	var result = registry.FindDesign(typeof(PocoConcrete), name);

//		//	//Assert
//		//	Assert.AreEqual(design1, result);
//		//	Assert.AreNotEqual(design2, result);
//		//}
//	}
//}
