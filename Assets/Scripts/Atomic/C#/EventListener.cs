using UnityEngine;
using System.Collections;

namespace Atomic{
	public interface IEventListener  {
	
		void ListenEvent(ButtonEvent ev);
	}
}
