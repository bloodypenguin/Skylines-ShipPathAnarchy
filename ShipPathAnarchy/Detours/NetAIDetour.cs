using FloatThroughCanals.Redirection;
using UnityEngine;

namespace FloatThroughCanals.Detours
{
    [TargetType(typeof(NetAI))]
    public class NetAIDetour
    {
        [RedirectReverse]
        public static ToolBase.ToolErrors CheckBuildPosition(NetAI ai, bool test, bool visualize, bool overlay, bool autofix, ref NetTool.ControlPoint startPoint, ref NetTool.ControlPoint middlePoint, ref NetTool.ControlPoint endPoint, out BuildingInfo ownerBuilding, out Vector3 ownerPosition, out Vector3 ownerDirection, out int productionRate)
        {
            UnityEngine.Debug.Log("Failed to override CheckBuildPosition()");
            ownerBuilding = null;
            ownerPosition = new Vector3();
            ownerDirection = new Vector3();
            productionRate = 0;
            return ToolBase.ToolErrors.None;
        }
    }
}