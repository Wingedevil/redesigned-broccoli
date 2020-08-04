using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomUtils;
using Interactable;

namespace Managers {
    public class InteractableManager : Manager<InteractableManager> {
        public HashSet<DragSnapTo> AnchorPoints = new HashSet<DragSnapTo>();
        public HashSet<Grabbable> GrabPoints = new HashSet<Grabbable>();
    }
}
