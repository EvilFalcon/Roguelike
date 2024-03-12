using UnityEditor;

namespace Downloads.Plugins.SimpleInput.Editor
{
    [CustomPropertyDrawer(typeof(Scripts.SimpleInput.ButtonInput))]
    public class ButtonInputDrawer : BaseInputDrawer
    {
        public override string ValueToString(SerializedProperty valueProperty)
        {
            return valueProperty.boolValue.ToString();
        }
    }
}