using ESRI.ArcGIS.Geodatabase;
namespace JT.ArcObject.Extension {
    public static partial class JTTopologyRuleTypeExt {

        public static string JTEsriTopologyRuleTypeCHNDescription(this esriTopologyRuleType type) {
            switch (type) {
                case esriTopologyRuleType.esriTRTAny: return "Any";
                case esriTopologyRuleType.esriTRTAreaAreaCoverEachOther: return "面面必须覆盖";
                case esriTopologyRuleType.esriTRTAreaBoundaryCoveredByAreaBoundary: return "面边界必须覆盖面边界";
                case esriTopologyRuleType.esriTRTAreaBoundaryCoveredByLine: return "面边界必须被线覆盖";
                case esriTopologyRuleType.esriTRTAreaContainOnePoint: return "面必须包含一个点";
                case esriTopologyRuleType.esriTRTAreaContainPoint: return "面包含点";
                case esriTopologyRuleType.esriTRTAreaCoveredByArea: return "面必须被面覆盖";
                case esriTopologyRuleType.esriTRTAreaCoveredByAreaClass: return "面必须被面要素类覆盖";
                case esriTopologyRuleType.esriTRTAreaNoGaps: return "面没有缝隙";
                case esriTopologyRuleType.esriTRTAreaNoOverlap: return "面不能重叠";
                case esriTopologyRuleType.esriTRTAreaNoOverlapArea: return "面不能覆盖面";
                case esriTopologyRuleType.esriTRTFeatureLargerThanClusterTolerance: return "小于容差";
                case esriTopologyRuleType.esriTRTLineCoveredByAreaBoundary: return "线必须被面边界覆盖";
                case esriTopologyRuleType.esriTRTLineCoveredByLineClass: return "线被线要素类覆盖";
                case esriTopologyRuleType.esriTRTLineEndpointCoveredByPoint: return "线端点被点覆盖";
                case esriTopologyRuleType.esriTRTLineInsideArea: return "线在面内部";
                case esriTopologyRuleType.esriTRTLineNoDangles: return "线不能有悬挂点";
                case esriTopologyRuleType.esriTRTLineNoIntersection: return "线不能相交";
                case esriTopologyRuleType.esriTRTLineNoIntersectLine: return "线与线不能相交";
                case esriTopologyRuleType.esriTRTLineNoIntersectOrInteriorTouch: return "线不能相交或内部接触";
                case esriTopologyRuleType.esriTRTLineNoIntersectOrInteriorTouchLine: return "线不能相交或内部接触线";
                case esriTopologyRuleType.esriTRTLineNoMultipart: return "线必须是单一部分";
                case esriTopologyRuleType.esriTRTLineNoOverlap: return "线不能重叠";
                case esriTopologyRuleType.esriTRTLineNoOverlapLine: return "线不能与线重叠";
                case esriTopologyRuleType.esriTRTLineNoPseudos: return "线不能有伪节点";
                case esriTopologyRuleType.esriTRTLineNoSelfIntersect: return "线不能自相交";
                case esriTopologyRuleType.esriTRTLineNoSelfOverlap: return "线不能自重叠";
                case esriTopologyRuleType.esriTRTPointCoincidePoint: return "点必须重合";
                case esriTopologyRuleType.esriTRTPointCoveredByAreaBoundary: return "点必须被面边界覆盖";
                case esriTopologyRuleType.esriTRTPointCoveredByLine: return "点必须被线覆盖";
                case esriTopologyRuleType.esriTRTPointCoveredByLineEndpoint: return "点必须被线端点覆盖";
                case esriTopologyRuleType.esriTRTPointDisjoint: return "点不相交";
                case esriTopologyRuleType.esriTRTPointProperlyInsideArea: return "点必须完全在面内部";
            }
            return null;
        }

    }

    public static partial class JTTopologyRuleTypeExt {

    }

    public static partial class JTTopologyRuleTypeExt {

    }

}
