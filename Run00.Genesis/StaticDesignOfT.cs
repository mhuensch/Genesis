
using System;
namespace Run00.Genesis
{
	public abstract class StaticDesign<T> : IStaticDesign
	{
		Type IStaticDesign.ForType { get { return typeof(T); } }

		object IStaticDesign.CreateObject()
		{
			return Create();
		}

		protected abstract T Create();
	}
}
