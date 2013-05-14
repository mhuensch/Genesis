using System;
using System.IO;

namespace Run00.Genesis.SimpleDesigns
{
	public class DefaultUriDesign : IntelligentDesign<Uri>
	{
		public DefaultUriDesign()
		{
			CreateUsing(() => new Uri(string.Format("http://www.{0}.com", Path.GetRandomFileName().Replace(".", ""))));
		}
	}
}
