using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace DotEditor.Native
{
    public class NativeContext
    {
        public VisualElement rootView;

        public Stack<VisualElement> containerElements = new Stack<VisualElement>();
    }
}
