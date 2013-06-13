using System;

namespace Run00.Genesis.SimpleDesigns
{
	public class DefaultIntDesign : IntelligentDesign<int>
	{
		public DefaultIntDesign()
		{
			CreateUsing(() => _random.Next());
		}


		private static readonly Random _random = new Random();
	}
}
