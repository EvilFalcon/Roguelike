using UnityEditor;

namespace Downloads.Plugins.SimpleInput.Editor
{
    [CustomPropertyDrawer(typeof(Scripts.SimpleInput.MouseButtonInput))]
    public class MouseButtonInputDrawer : BaseInputDrawer
    {
        public override string ValueToString(SerializedProperty valueProperty)
        {
            return valueProperty.boolValue.ToString();
        }
    }
}