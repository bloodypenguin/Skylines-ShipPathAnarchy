using ColossalFramework.Math;
using FloatThroughCanals.Redirection;
using UnityEngine;

namespace FloatThroughCanals.Detours
{
    [TargetType(typeof(ShipPathAI))]
    public class ShipPathAIDetour : NetAI
    {
        [RedirectMethod]
        public override ToolBase.ToolErrors CheckBuildPosition(bool test, bool visualize, bool overlay, bool autofix, ref NetTool.ControlPoint startPoint, ref NetTool.ControlPoint middlePoint, ref NetTool.ControlPoint endPoint, out BuildingInfo ownerBuilding, out Vector3 ownerPosition, out Vector3 ownerDirection, out int productionRate)
        {
            ToolBase.ToolErrors toolErrors = NetAIDetour.CheckBuildPosition(this, test, visualize, overlay, autofix, ref startPoint, ref middlePoint, ref endPoint, out ownerBuilding, out ownerPosition, out ownerDirection, out productionRate);
            Vector3 middlePos1;
            Vector3 middlePos2;
            NetSegment.CalculateMiddlePoints(startPoint.m_position, middlePoint.m_direction, endPoint.m_position, -endPoint.m_direction, true, true, out middlePos1, out middlePos2);
            Bezier2 bezier2;
            bezier2.a = VectorUtils.XZ(startPoint.m_position);
            bezier2.b = VectorUtils.XZ(middlePos1);
            bezier2.c = VectorUtils.XZ(middlePos2);
            bezier2.d = VectorUtils.XZ(endPoint.m_position);
            int @int = Mathf.CeilToInt(Vector2.Distance(bezier2.a, bezier2.d) * 0.005f);
            Segment2 segment;
            segment.a = bezier2.a;
            for (int index = 1; index <= @int; ++index)
            {
                segment.b = bezier2.Position((float)index / (float)@int);
                //begin mod
                //end mod
                segment.a = segment.b;
            }
            return toolErrors;
        }
    }
}