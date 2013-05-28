using System;
namespace Run00.Genesis
{
	public abstract class StaticDesign
	{
		internal Type ForType { get; private set; }

		internal StaticDesign(Type type) { ForType = type; }
		internal abstract object CreateObject();
	}
}
