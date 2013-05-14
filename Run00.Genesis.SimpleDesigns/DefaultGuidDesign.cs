using System;

namespace Run00.Genesis.SimpleDesigns
{
	public class DefaultGuidDesign : IntelligentDesign<Guid>
	{
		public DefaultGuidDesign()
		{
			CreateUsing(() => Guid.NewGuid());
		}
	}
}
