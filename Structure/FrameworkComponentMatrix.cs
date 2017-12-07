/*--------------------------------------
This file was generated!
The generator targets "Framework.cs" to extract an interface from
the properties between the bullets <Matrix></Matrix>. It also generates
a frameworkcomponent base class implementing the aforementioned interface
--------------------------------------*/
using System.Windows;

namespace VulkanSharpWPF {
	interface IFrameworkComponentMatrix {
		Instance Instance { get; }
		Surface Surface { get; }
		Window Window { get; }
	}

	abstract partial class FrameworkComponent : IFrameworkComponentMatrix {
		public Instance Instance => Framework.Instance;
		public Surface Surface => Framework.Surface;
		public Window Window => Framework.Window;
		public Framework Framework { get; private set; }
		public FrameworkComponent(Framework framework) => Framework = framework;
	}
}