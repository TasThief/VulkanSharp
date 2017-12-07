using System.Windows;

namespace VulkanSharpWPF {
	class Framework : IFrameworkComponentMatrix {
		//<Matrix>
		public Instance Instance { get; set; }
		public Surface Surface { get; set; }
		public Window Window { get; set; }
		//</Matrix>

	}
	abstract partial class FrameworkComponent : IFrameworkComponentMatrix {

	}
}
