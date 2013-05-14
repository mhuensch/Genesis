using System.IO;

namespace Run00.Genesis.SimpleDesigns
{
	public class DefaultStringDesign : IntelligentDesign<string>
	{
		public DefaultStringDesign()
		{
			CreateUsing(() => Path.GetRandomFileName().Replace(".", ""));
		}
	}
}
