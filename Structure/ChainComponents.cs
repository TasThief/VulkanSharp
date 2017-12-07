using System;
using System.Collections.Generic;
using System.Windows;

namespace VulkanSharpWPF {
	abstract class ChainComponentBase : FrameworkComponent {
		private Stack<WeakReference<ChainComponentBase>> dependencyStack;

		public virtual void Destroy() {
			while(dependencyStack.Count > 0) {
				if(dependencyStack.Pop().TryGetTarget(out ChainComponentBase auxReference))
					auxReference.Destroy();
				DestructionRoutine();
			}
		}
	
		protected abstract void DestructionRoutine();

		protected ChainComponentBase(Framework framework) : base(framework) => dependencyStack = new Stack<WeakReference<ChainComponentBase>>();

		protected void Assign(ChainComponentBase user) => dependencyStack.Push(new WeakReference<ChainComponentBase>(user));
	}

	abstract class ChainComponent<T> : ChainComponentBase where T : class {
		protected T resource = null;

		private Func<T> resourceAcquisitionRoutine = null;

		public T Get() => resourceAcquisitionRoutine();

		public T Get(ChainComponentBase user) {
			Assign(user);
			return resourceAcquisitionRoutine();
		}

		public override sealed void Destroy() {
			if(resource != null) {
				base.Destroy();
				resource = null;
			}
		}

		protected abstract T InitializationRoutine();

		private T Initialize() {
			resourceAcquisitionRoutine = () => resource;
			return InitializationRoutine();
		}

		public ChainComponent(Framework framework) : base(framework) => resourceAcquisitionRoutine = Initialize;

		~ChainComponent() => Destroy();
	}

}
