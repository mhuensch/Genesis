using System.IO;

namespace Run00.Genesis.Test.Artifacts
{
	public class StringDesign : IntelligentDesign<string>
	{
		public StringDesign()
		{
			CreateUsing(() => Path.GetRandomFileName().Replace(".", ""));
		}
	}
}
