using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Analyst3DTools;
using ESRI.ArcGIS.ConversionTools;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;
using JT.Enum.Extension;
namespace JT.ArcObject {

    //RedefineTin
    public static partial class JTGPProcess {
        public static IGPProcess RedefineTin(ITin tin, double length) {
            return new DelineateTinDataArea { in_tin = tin, max_edge_length = length, };
        }

        public static IGPProcess RedefineTin(string tin, double length) {
            return new DelineateTinDataArea { in_tin = tin, max_edge_length = length, };
        }
    }
    //MultiPartToSinglePart
    public static partial class JTGPProcess {
        public static IGPProcess MultiPartToSinglePart(IFeatureClass inFeatureClass, string outFeatureClass) {
            return new MultipartToSinglepart { in_features = inFeatureClass, out_feature_class = outFeatureClass };
        }
        public static IGPProcess MultiPartToSinglePart(string inFeatureClass, string outFeatureClass) {
            return new MultipartToSinglepart { in_features = inFeatureClass, out_feature_class = outFeatureClass, };
        }
    }
    //FeatureVerticesToPoints
    public static partial class JTGPProcess {
        public static IGPProcess FeatureVerticesToPoints(IFeatureClass inFeatureClass, string outFeatureClass) {
            return new FeatureVerticesToPoints { in_features = inFeatureClass, out_feature_class = outFeatureClass, };
        }
    }
    //TinDomain
    public static partial class JTGPProcess {
        public enum TinDomainType {
            POLYGON,
            LINE,
        }

        public static IGPProcess TinDomain(ITin tin, string outFeatureClass, TinDomainType domainType) {
            return new ESRI.ArcGIS.Analyst3DTools.TinDomain { in_tin = tin, out_feature_class = outFeatureClass, out_geometry_type = domainType.ToString(), };
        }
    }
    //Erase
    public static partial class JTGPProcess {
        public static IGPProcess Erase(IFeatureClass inFeatureClass, IFeatureClass eraseFeatureClass, string outFeatureClass) {
            return new Erase { in_features = inFeatureClass, erase_features = eraseFeatureClass, out_feature_class = outFeatureClass, };
        }
    }
    //Buffer
    public static partial class JTGPProcess {
        public enum BufferDissolveOption {
            NONE,
            ALL,
            List,
        }
        public enum BufferLineEndType {
            ROUND,
            FLAT,
        }
        public enum BufferSide {
            FULL,
            LEFT,
            RIGHT,
            OUTSIDE_ONLY,
        }

        public static IGPProcess Buffer(IFeatureClass inFeatureClass, string outFeatureClass, double distance, BufferDissolveOption dissolveOption = BufferDissolveOption.NONE, string[] dissolveFields = null, BufferSide side = BufferSide.FULL, BufferLineEndType lineEndType = BufferLineEndType.ROUND) {
            return new ESRI.ArcGIS.AnalysisTools.Buffer {
                buffer_distance_or_field = distance,
                in_features = inFeatureClass,
                out_feature_class = outFeatureClass,
                dissolve_option = dissolveOption.ToString(),
                dissolve_field = dissolveFields,
                line_end_type = lineEndType.ToString(),
                line_side = side.ToString(),
            };
        }
    }
    //CalculateField
    public static partial class JTGPProcess {
        public static IGPProcess CalculateField(ITable inTable, string field, object expression, string expressionType = "VB", string codeBlock = null, object outTable = null) {
            return new CalculateField { in_table = inTable, field = field, expression = expression, expression_type = expressionType, code_block = codeBlock, out_table = outTable };
        }

        public static IGPProcess CalculateField(IFeatureClass inFeatureClass, string field, object expression, string expressionType = "VB", string codeBlock = null, object outTable = null) {
            return new CalculateField { in_table = inFeatureClass, field = field, expression = expression, expression_type = expressionType, code_block = codeBlock, out_table = outTable };
        }
    }
    //CreateTopology
    public static partial class JTGPProcess {
        public static IGPProcess CreateTopology(string featureDataset, string topologyName) {
            return new CreateTopology { in_dataset = featureDataset, out_name = topologyName };
        }

        public static IGPProcess CreateTopology(IFeatureDataset featureDataset, string topologyName) {
            return new CreateTopology { in_dataset = featureDataset, out_name = topologyName };
        }
    }
    //AddRuleToTopology
    public static partial class JTGPProcess {
        public enum TopologyRuleType {
            [JTEnumExt.JTEnumStringAttribute("Must Not Have Gaps (Area)")]
            MustNotHaveGaps_Area,
            [JTEnumExt.JTEnumStringAttribute("Must Not Overlap (Area)")]
            MustNotOverlap_Area,
            [JTEnumExt.JTEnumStringAttribute("Must Be Covered By Feature Class Of (Area-Area)")]
            MustBeCoveredByFeatureClassOf_AreaArea,
            [JTEnumExt.JTEnumStringAttribute("Must Cover Each Other (Area-Area)")]
            MustCoverEachOther_AreaArea,
            [JTEnumExt.JTEnumStringAttribute("Must Be Covered By (Area-Area)")]
            MustBeCoveredBy_AreaArea,
            [JTEnumExt.JTEnumStringAttribute("Must Not Overlap With (Area-Area)")]
            MustNotOverlapWith_AreaArea,
            [JTEnumExt.JTEnumStringAttribute("Must Be Covered By Boundary Of (Line-Area)")]
            MustBeCoveredByBoundaryOf_LineArea,
            [JTEnumExt.JTEnumStringAttribute("Must Be Covered By Boundary Of (Point-Area)")]
            MustBeCoveredByBoundaryOf_PointArea,
            [JTEnumExt.JTEnumStringAttribute("Must Be Properly Inside (Point-Area)")]
            MustBeProperlyInside_PointArea,
            [JTEnumExt.JTEnumStringAttribute("Must Not Overlap (Line)")]
            MustNotOverlap_Line,
            [JTEnumExt.JTEnumStringAttribute("Must Not Intersect (Line)")]
            MustNotIntersect_Line,
            [JTEnumExt.JTEnumStringAttribute("Must Not Have Dangles (Line)")]
            MustNotHaveDangles_Line,
            [JTEnumExt.JTEnumStringAttribute("Must Not Have Pseudo-Nodes (Line)")]
            MustNotHavePseudoNodes_Line,
            [JTEnumExt.JTEnumStringAttribute("Must Be Covered By Feature Class Of (Line-Line)")]
            MustBeCoveredByFeatureClassOf_LineLine,
            [JTEnumExt.JTEnumStringAttribute("Must Not Overlap With (Line-Line)")]
            MustNotOverlapWith_LineLine,
            [JTEnumExt.JTEnumStringAttribute("Point Must Be Covered By Line (Point-Line)")]
            PointMustBeCoveredByLine_PointLine,
            [JTEnumExt.JTEnumStringAttribute("Must Be Covered By Endpoint Of (Point-Line)")]
            MustBeCoveredByEndpointOf_PointLine,
            [JTEnumExt.JTEnumStringAttribute("Boundary Must Be Covered By (Area-Line)")]
            BoundaryMustBeCoveredBy_AreaLine,
            [JTEnumExt.JTEnumStringAttribute("Area Boundary Must Be Covered By Boundary Of (Area-Area)")]
            AreaBoundaryMustBeCoveredByBoundaryOf_AreaArea,
            [JTEnumExt.JTEnumStringAttribute("Must Not Self-Overlap (Line)")]
            MustNotSelfOverlap_Line,
            [JTEnumExt.JTEnumStringAttribute("Must Not Self-Intersect (Line)")]
            MustNotSelfIntersect_Line,
            [JTEnumExt.JTEnumStringAttribute("Must Not Intersect Or Touch Interior (Line)")]
            MustNotIntersectOrTouchInterior_Line,
            [JTEnumExt.JTEnumStringAttribute("Endpoint Must Be Covered By (Line-Point)")]
            EndpointMustBeCoveredBy_LinePoint,
            [JTEnumExt.JTEnumStringAttribute("Contains Point (Area-Point)")]
            ContainsPoint_AreaPoint,
            [JTEnumExt.JTEnumStringAttribute("Must Be Single Part (Line)")]
            MustBeSinglePart_Line,
            [JTEnumExt.JTEnumStringAttribute("Must Coincide With (Point-Point)")]
            MustCoincideWith_PointPoint,
            [JTEnumExt.JTEnumStringAttribute("Must Be Disjoint (Point)")]
            MustBeDisjoint_Point,
            [JTEnumExt.JTEnumStringAttribute("Must Not Intersect With (Line-Line)")]
            MustNotIntersectWith_LineLine,
            [JTEnumExt.JTEnumStringAttribute("Must Not Intersect or Touch Interior With (Line-Line)")]
            MustNotIntersectorTouchInteriorWith_LineLine,
            [JTEnumExt.JTEnumStringAttribute("Must Be Inside (Line-Area)")]
            MustBeInside_LineArea,
            [JTEnumExt.JTEnumStringAttribute("Contains One Point (Area-Point)")]
            ContainsOnePoint_AreaPoint,
        }
        public static IGPProcess AddRuleToTopology(string inFeatureClass, string inTopology, TopologyRuleType ruleType) {
            return new AddRuleToTopology { in_featureclass = inFeatureClass, in_topology = inTopology, rule_type = ruleType.JTAttributeValue<string>(), };
        }
        public static IGPProcess AddRuleToTopology(string inFeatureClass, string inTopology, TopologyRuleType ruleType, string otherFeatureClass) {
            return new AddRuleToTopology { in_featureclass = inFeatureClass, in_topology = inTopology, rule_type = ruleType.JTAttributeValue<string>(), in_featureclass2 = otherFeatureClass, };
        }
        // Can not use IFeatureClass 
        //public static void AddRuleToTopology(IFeatureClass inFeatureClass, string inTopology, TopologyRuleType ruleType) {
        //    new Geoprocessor { OverwriteOutput = true, }.Execute(new AddRuleToTopology { in_featureclass = inFeatureClass, in_topology = inTopology, rule_type = ruleType.JTAttributeValue<string>(), }, null);
        //}
    }
    //ValidateTopology
    public static partial class JTGPProcess {
        public static IGPProcess ValidateTopology(string inTopology) {
            return new ValidateTopology { in_topology = inTopology, };
        }
    }
    //AddFeatureClassToTopology
    public static partial class JTGPProcess {
        public static IGPProcess AddFeatureClassToTopology(string inFeatureClass, string inTopology, int xyRank = 1, int zRank = 1) {
            return new AddFeatureClassToTopology { in_featureclass = inFeatureClass, in_topology = inTopology, xy_rank = xyRank, z_rank = zRank };
        }

        public static IGPProcess AddFeatureClassToTopology(IFeatureClass inFeatureClass, string inTopology, int xyRank = 1, int zRank = 1) {
            return new AddFeatureClassToTopology { in_featureclass = inFeatureClass, in_topology = inTopology, xy_rank = xyRank, z_rank = zRank };
        }
    }
    //FeatureClassToFeatureClass
    public static partial class JTGPProcess {
        public static IGPProcess FeatureClassToFeatureClass(string inFeatureClass, string outPath, string outName) {
            return new FeatureClassToFeatureClass { in_features = inFeatureClass, out_path = outPath, out_name = outName };
        }
        public static IGPProcess FeatureClassToFeatureClass(IFeatureClass inFeatureClass, string outPath, string outName) {
            return new FeatureClassToFeatureClass { in_features = inFeatureClass, out_path = outPath, out_name = outName };
        }
    }
    //Project
    public static partial class JTGPProcess {
        public static IGPProcess Project(IDataset inDS, string outDS, ISpatialReference outSr) {
            return new Project { in_dataset = inDS, out_coor_system = outSr, out_dataset = outDS };
        }
        public static IGPProcess Project(string inDS, string outDS, ISpatialReference outSr) {
            return new Project { in_dataset = inDS, out_coor_system = outSr, out_dataset = outDS };
        }
    }
    //Dissolve
    public static partial class JTGPProcess {
        public static IGPProcess Dissolve(IFeatureClass inFeatureClass, string outFeatureClass) {
            return new Dissolve { in_features = inFeatureClass, out_feature_class = outFeatureClass, };
        }

        public static IGPProcess Dissolve(string inFeatureClass, string outFeatureClass) {
            return new Dissolve { in_features = inFeatureClass, out_feature_class = outFeatureClass, };
        }
    }
    //FeatureToLine
    public static partial class JTGPProcess {
        public static IGPProcess FeatureToLine(string inFeatureClass, string outFeatureClass) {
            return new FeatureToLine { in_features = inFeatureClass, out_feature_class = outFeatureClass };
        }
    }
    //Clip
    public static partial class JTGPProcess {
        public static IGPProcess Clip(IFeatureClass inFeatureClass, IFeatureClass clipFeatureClass, string outFeatureClass) {
            return new ESRI.ArcGIS.AnalysisTools.Clip { in_features = inFeatureClass, clip_features = clipFeatureClass, out_feature_class = outFeatureClass };
        }
    }
    //ExportTopologyErrors
    public static partial class JTGPProcess {
        public static IGPProcess ExportTopologyErrors(ITopology inTopology, IWorkspace outWorkspace, string outBasename) {
            return new ExportTopologyErrors { in_topology = inTopology, out_path = outWorkspace, out_basename = outBasename, };
        }
    }
    //Append
    public static partial class JTGPProcess {
        public enum AppendSchemaType {
            [JTEnumExt.JTEnumStringAttribute("TEST")]
            Test,
            [JTEnumExt.JTEnumStringAttribute("NO_TEST")]
            NoTest,
        }
        public static IGPProcess Append(IFeatureClass inFeatureClass, IFeatureClass targetFeatureClass, AppendSchemaType schemaType, object fieldMapping = null, string subType = null) {
            return new Append { inputs = inFeatureClass, target = targetFeatureClass, schema_type = schemaType.JTAttributeValue<string>() };
        }
        public static IGPProcess Append(ITable inTable, ITable targetTable, AppendSchemaType schemaType, object fieldMapping = null, string subType = null) {
            return new Append { inputs = inTable, target = targetTable, schema_type = schemaType.JTAttributeValue<string>() };
        }
        public static IGPProcess Append(string[] inDatasets, string targetDataset, AppendSchemaType schemaType, object fieldMapping = null, string subType = null) {
            var inDSs = "";
            foreach (var inDS in inDatasets) { inDSs += "'" + inDS + "';"; }
            var append = new Append { inputs = inDSs, target = targetDataset, schema_type = schemaType.JTAttributeValue<string>() };
            if (fieldMapping != null) { append.field_mapping = fieldMapping; }
            if (!string.IsNullOrEmpty(subType)) { append.subtype = subType; }
            return append;
        }

        public static IGPProcess AppendAutoMatchField(IFeatureClass inFeatureClass, IFeatureClass targetFeatureClass) {
            return Append(inFeatureClass, targetFeatureClass, AppendSchemaType.Test);
        }
        public static IGPProcess AppendAutoMatchField(ITable inTable, ITable targetTable) {
            return Append(inTable, targetTable, AppendSchemaType.Test);
        }
        public static IGPProcess AppendAutoMatchField(string[] inDatasets, string targetDataset) {
            return Append(inDatasets, targetDataset, AppendSchemaType.Test);
        }
    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }


    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }

    public static partial class JTGPProcess {

    }


}
