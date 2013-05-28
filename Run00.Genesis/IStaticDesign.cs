using System;
namespace Run00.Genesis
{
	public interface IStaticDesign
	{
		Type ForType { get; }
		object CreateObject();
	}
}
