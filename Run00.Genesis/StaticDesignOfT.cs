
namespace Run00.Genesis
{
	public abstract class StaticDesign<T> : StaticDesign
	{
		public StaticDesign() : base(typeof(T)) { }

		protected abstract T Create();

		internal override object CreateObject()
		{
			return Create();
		}
	}
}
