using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomUtils;
using Interactable;

namespace Managers {
    public class InteractableManager : Manager<InteractableManager> {
        public List<DragSnapTo> AnchorPoints = new List<DragSnapTo>();
    }
}
