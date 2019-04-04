using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Analyst3DTools;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.ConversionTools;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;
using JT.Enum.Extension;
using System;
using System.Text;
namespace JT.ArcObject {
    public static partial class JTGP {

        public static void MultiPartToSinglePart(IFeatureClass inFeatureClass, string outFeatureClass) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new MultipartToSinglepart { in_features = inFeatureClass, out_feature_class = outFeatureClass, }, null);
        }

        public static void MultiPartToSinglePart(string inFeatureClass, string outFeatureClass) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new MultipartToSinglepart { in_features = inFeatureClass, out_feature_class = outFeatureClass, }, null);
        }

    }

    public static partial class JTGP {

        public class CreateTinParameter {
            public CreateTinParameter(IFeatureClass pointFC, string heightField) { PointFeatureClass = pointFC; HeightField = heightField; }
            public IFeatureClass PointFeatureClass;
            public string HeightField;
            public string SFType = "masspoints";
            public string TagField = "<none>";
        }

        public static void CreateTin(string tinFullname, ISpatialReference sr = null, params CreateTinParameter[] para) {
            if (para == null) { throw new ArgumentNullException(); }
            var createTinToolName = new CreateTin().ToolName;
            IVariantArray va = new VarArrayClass();
            va.Add(tinFullname);
            va.Add(sr);
            foreach (var item in para) {
                var fc = item.PointFeatureClass;
                if (fc.ShapeType != esriGeometryType.esriGeometryMultipoint && fc.ShapeType != esriGeometryType.esriGeometryPoint) { throw new Exception("错误的要素类型"); }
                if (string.IsNullOrEmpty(item.HeightField)) { throw new Exception("高程字段是必须的"); }
                if (fc.FindField(item.HeightField) < 0) { throw new Exception("未找到高程字段 " + item.HeightField); }
                if (string.IsNullOrEmpty(item.TagField)) { item.TagField = "<none>"; }
                if (item.TagField.ToLower() != "<none>" && fc.FindField(item.TagField) < 0) { throw new Exception("Tag字段设置错误 " + item.TagField); }
                var ds = fc as IDataset;
                var fullname = ds.Workspace.PathName + "/" + ds.Name;
                IGpValueTableObject vt = new GpValueTableObjectClass();
                vt.SetColumns(4);
                object row = "'" + fullname + "' " + item.HeightField + " " + item.SFType + " " + item.TagField;
                vt.AddRow(ref row);
                va.Add(vt);
            }
            IGeoProcessorResult tGeoResult = null;
            try {
                tGeoResult = (IGeoProcessorResult)new Geoprocessor().Execute(createTinToolName, va, null);
            } catch {
                var msg = tGeoResult.GetMessage(0);
            }
        }

    }

    public static partial class JTGP {

        public static void RedefineTin(ITin tin, double length) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new DelineateTinDataArea { in_tin = tin, max_edge_length = length, }, null);
        }

        public static void RedefineTin(string tin, double length) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new DelineateTinDataArea { in_tin = tin, max_edge_length = length, }, null);
        }

    }

    public static partial class JTGP {

        public static void FeatureVerticesToPoints(IFeatureClass inFeatureClass, string outFeatureClass) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new FeatureVerticesToPoints { in_features = inFeatureClass, out_feature_class = outFeatureClass, }, null);
        }

    }

    public static partial class JTGP {

        public enum TinDomainType {
            POLYGON,
            LINE,
        }

        public static void TinDomain(ITin tin, string outFeatureClass, TinDomainType domainType) {
            if (tin == null) { throw new ArgumentNullException(); }
            if (tin.IsEmpty) { throw new Exception("空Tin"); }
            new Geoprocessor { OverwriteOutput = true, }.Execute(new ESRI.ArcGIS.Analyst3DTools.TinDomain { in_tin = tin, out_feature_class = outFeatureClass, out_geometry_type = domainType.ToString(), }, null);
        }

    }

    public static partial class JTGP {

        public static void Erase(IFeatureClass inFeatureClass, IFeatureClass eraseFeatureClass, string outFeatureClass) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new Erase { in_features = inFeatureClass, erase_features = eraseFeatureClass, out_feature_class = outFeatureClass, }, null);
        }

    }

    public static partial class JTGP {

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

        public static void Buffer(IFeatureClass inFeatureClass, string outFeatureClass, string distance, BufferDissolveOption dissolveOption = BufferDissolveOption.NONE, string[] dissolveFields = null, BufferSide side = BufferSide.FULL, BufferLineEndType lineEndType = BufferLineEndType.ROUND) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new ESRI.ArcGIS.AnalysisTools.Buffer {
                buffer_distance_or_field = distance,
                in_features = inFeatureClass,
                out_feature_class = outFeatureClass,
                dissolve_option = dissolveOption.ToString(),
                dissolve_field = dissolveFields,
                line_end_type = lineEndType.ToString(),
                line_side = side.ToString(),
            }, null);
        }

        public static void Buffer(string inFeatureClass, string outFeatureClass, string distance, BufferDissolveOption dissolveOption = BufferDissolveOption.NONE, string[] dissolveFields = null, BufferSide side = BufferSide.FULL, BufferLineEndType lineEndType = BufferLineEndType.ROUND) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new ESRI.ArcGIS.AnalysisTools.Buffer {
                buffer_distance_or_field = distance,
                in_features = inFeatureClass,
                out_feature_class = outFeatureClass,
                dissolve_option = dissolveOption.ToString(),
                dissolve_field = dissolveFields,
                line_end_type = lineEndType.ToString(),
                line_side = side.ToString(),
            }, null);
        }

    }

    public static partial class JTGP {

        public static void CalculateField(ITable inTable, string field, object expression, string expressionType = "VB", string codeBlock = null, object outTable = null) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new CalculateField { in_table = inTable, field = field, expression = expression, expression_type = expressionType, code_block = codeBlock, out_table = outTable }, null);
        }

        public static void CalculateField(IFeatureClass inFeatureClass, string field, object expression, string expressionType = "VB", string codeBlock = null, object outTable = null) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new CalculateField { in_table = inFeatureClass, field = field, expression = expression, expression_type = expressionType, code_block = codeBlock, out_table = outTable }, null);
        }

        public static void CalculateField(IFeatureClass inFeatureClass, string where, string field, object expression) {
            var index = inFeatureClass.FindField(field);
            if (index < 0) { throw new Exception(); }
            IQueryFilter qf = new QueryFilterClass { WhereClause = where };
            var cursor = inFeatureClass.Update(qf, true);
            IFeature feature = null;
            while ((feature = cursor.NextFeature()) != null) {
                feature.Value[index] = expression;
                cursor.UpdateFeature(feature);
            }
        }

    }

    public static partial class JTGP {

        public static string CreateTopology(string featureDataset, string topologyName) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new CreateTopology { in_dataset = featureDataset, out_name = topologyName }, null);
            return featureDataset + "/" + topologyName;
        }

        public static string CreateTopology(IFeatureDataset featureDataset, string topologyName) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new CreateTopology { in_dataset = featureDataset, out_name = topologyName }, null);
            return featureDataset.Workspace.PathName + "\\" + (featureDataset as IDataset).Name + "\\" + topologyName;
        }

    }

    public static partial class JTGP {

        public enum TopologyRuleType {
            [
            JTEnumExt.JTEnumStringAttribute("Must Not Have Gaps (Area)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTAreaNoGaps),
            ]
            MustNotHaveGaps_Area,

            [
            JTEnumExt.JTEnumStringAttribute("Must Not Overlap (Area)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTAreaNoOverlap),
            ]
            MustNotOverlap_Area,

            [
            JTEnumExt.JTEnumStringAttribute("Must Be Covered By Feature Class Of (Area-Area)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTAreaCoveredByAreaClass),
            ]
            MustBeCoveredByFeatureClassOf_AreaArea,

            [
            JTEnumExt.JTEnumStringAttribute("Must Cover Each Other (Area-Area)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTAreaAreaCoverEachOther),
            ]
            MustCoverEachOther_AreaArea,

            [
            JTEnumExt.JTEnumStringAttribute("Must Be Covered By (Area-Area)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTAreaCoveredByArea),
            ]
            MustBeCoveredBy_AreaArea,

            [
            JTEnumExt.JTEnumStringAttribute("Must Not Overlap With (Area-Area)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTAreaNoOverlapArea),
            ]
            MustNotOverlapWith_AreaArea,

            [
            JTEnumExt.JTEnumStringAttribute("Must Be Covered By Boundary Of (Line-Area)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTLineCoveredByAreaBoundary),
            ]
            MustBeCoveredByBoundaryOf_LineArea,

            [
            JTEnumExt.JTEnumStringAttribute("Must Be Covered By Boundary Of (Point-Area)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTPointCoveredByAreaBoundary),
            ]
            MustBeCoveredByBoundaryOf_PointArea,

            [
            JTEnumExt.JTEnumStringAttribute("Must Be Properly Inside (Point-Area)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTPointProperlyInsideArea),
            ]
            MustBeProperlyInside_PointArea,

            [
            JTEnumExt.JTEnumStringAttribute("Must Not Overlap (Line)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTLineNoOverlap),
            ]
            MustNotOverlap_Line,

            [
            JTEnumExt.JTEnumStringAttribute("Must Not Intersect (Line)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTLineNoIntersection),
            ]
            MustNotIntersect_Line,

            [
            JTEnumExt.JTEnumStringAttribute("Must Not Have Dangles (Line)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTLineNoDangles),
            ]
            MustNotHaveDangles_Line,

            [JTEnumExt.JTEnumStringAttribute("Must Not Have Pseudo-Nodes (Line)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTLineNoPseudos),
            ]
            MustNotHavePseudoNodes_Line,

            [JTEnumExt.JTEnumStringAttribute("Must Be Covered By Feature Class Of (Line-Line)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTLineCoveredByLineClass),
            ]
            MustBeCoveredByFeatureClassOf_LineLine,

            [JTEnumExt.JTEnumStringAttribute("Must Not Overlap With (Line-Line)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTLineNoOverlapLine),
            ]
            MustNotOverlapWith_LineLine,

            [JTEnumExt.JTEnumStringAttribute("Point Must Be Covered By Line (Point-Line)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTPointCoveredByLine),
            ]
            PointMustBeCoveredByLine_PointLine,

            [JTEnumExt.JTEnumStringAttribute("Must Be Covered By Endpoint Of (Point-Line)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTPointCoveredByLineEndpoint),
            ]
            MustBeCoveredByEndpointOf_PointLine,

            [JTEnumExt.JTEnumStringAttribute("Boundary Must Be Covered By (Area-Line)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTAreaBoundaryCoveredByLine),
            ]
            BoundaryMustBeCoveredBy_AreaLine,

            [JTEnumExt.JTEnumStringAttribute("Area Boundary Must Be Covered By Boundary Of (Area-Area)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTAreaBoundaryCoveredByAreaBoundary),
            ]
            AreaBoundaryMustBeCoveredByBoundaryOf_AreaArea,

            [JTEnumExt.JTEnumStringAttribute("Must Not Self-Overlap (Line)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTLineNoSelfOverlap),
            ]
            MustNotSelfOverlap_Line,

            [JTEnumExt.JTEnumStringAttribute("Must Not Self-Intersect (Line)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTLineNoSelfIntersect),
            ]
            MustNotSelfIntersect_Line,

            [JTEnumExt.JTEnumStringAttribute("Must Not Intersect Or Touch Interior (Line)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTLineNoIntersectOrInteriorTouch),
            ]
            MustNotIntersectOrTouchInterior_Line,

            [JTEnumExt.JTEnumStringAttribute("Endpoint Must Be Covered By (Line-Point)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTLineEndpointCoveredByPoint),
            ]
            EndpointMustBeCoveredBy_LinePoint,

            [JTEnumExt.JTEnumStringAttribute("Contains Point (Area-Point)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTAreaContainPoint),
            ]
            ContainsPoint_AreaPoint,

            [JTEnumExt.JTEnumStringAttribute("Must Be Single Part (Line)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTLineNoMultipart),
            ]
            MustBeSinglePart_Line,

            [JTEnumExt.JTEnumStringAttribute("Must Coincide With (Point-Point)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTPointCoincidePoint),
            ]
            MustCoincideWith_PointPoint,

            [JTEnumExt.JTEnumStringAttribute("Must Be Disjoint (Point)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTPointDisjoint),
            ]
            MustBeDisjoint_Point,

            [JTEnumExt.JTEnumStringAttribute("Must Not Intersect With (Line-Line)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTLineNoIntersectLine),
            ]
            MustNotIntersectWith_LineLine,

            [JTEnumExt.JTEnumStringAttribute("Must Not Intersect or Touch Interior With (Line-Line)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTLineNoIntersectOrInteriorTouchLine),
            ]
            MustNotIntersectorTouchInteriorWith_LineLine,

            [JTEnumExt.JTEnumStringAttribute("Must Be Inside (Line-Area)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTLineInsideArea),
            ]
            MustBeInside_LineArea,

            [JTEnumExt.JTEnumStringAttribute("Contains One Point (Area-Point)"),
            JTEnumExt.JTEnumObjectAttribute(esriTopologyRuleType.esriTRTAreaContainOnePoint),
            ]
            ContainsOnePoint_AreaPoint,
        }

        public static void AddRuleToTopology(string inFeatureClass, string inTopology, TopologyRuleType ruleType) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new AddRuleToTopology { in_featureclass = inFeatureClass, in_topology = inTopology, rule_type = ruleType.JTAttributeValue<string>(), }, null);
        }

        /// <summary>
        /// Can't use ( Test in ArcGIS10.2 env )
        /// </summary>
        /// <param name="inFeatureClass"></param>
        /// <param name="inTopology"></param>
        /// <param name="ruleType"></param>
        public static void AddRuleToTopology(IFeatureClass inFeatureClass, string inTopology, TopologyRuleType ruleType) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new AddRuleToTopology { in_featureclass = inFeatureClass, in_topology = inTopology, rule_type = ruleType.JTAttributeValue<string>(), }, null);
        }

        public static void AddRuleToTopology(string inFeatureClass, string inTopology, TopologyRuleType ruleType, string otherFeatureClass) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new AddRuleToTopology { in_featureclass = inFeatureClass, in_topology = inTopology, rule_type = ruleType.JTAttributeValue<string>(), in_featureclass2 = otherFeatureClass, }, null);
        }
    }

    public static partial class JTGP {

        public static void ValidateTopology(string inTopology) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new ValidateTopology { in_topology = inTopology, }, null);
        }
    }

    public static partial class JTGP {

        public static void AddFeatureClassToTopology(string inFeatureClass, string inTopology, int xyRank = 1, int zRank = 1) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new AddFeatureClassToTopology { in_featureclass = inFeatureClass, in_topology = inTopology, xy_rank = xyRank, z_rank = zRank }, null);
        }

        public static void AddFeatureClassToTopology(IFeatureClass inFeatureClass, string inTopology, int xyRank = 1, int zRank = 1) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new AddFeatureClassToTopology { in_featureclass = inFeatureClass, in_topology = inTopology, xy_rank = xyRank, z_rank = zRank }, null);
        }
    }

    public static partial class JTGP {

        public static string FeatureClassToFeatureClass(string inFeatureClass, string outPath, string outName) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new FeatureClassToFeatureClass { in_features = inFeatureClass, out_path = outPath, out_name = outName }, null);
            return outPath + "/" + outName;
        }

        public static string FeatureClassToFeatureClass(IFeatureClass inFeatureClass, string outPath, string outName) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new FeatureClassToFeatureClass { in_features = inFeatureClass, out_path = outPath, out_name = outName }, null);
            return outPath + "/" + outName;
        }

    }

    public static partial class JTGP {

        public static void Project(IDataset inDS, string outDS, ISpatialReference outSr) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new Project { in_dataset = inDS, out_coor_system = outSr, out_dataset = outDS }, null);
        }

        public static void Project(string inDS, string outDS, ISpatialReference outSr) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new Project { in_dataset = inDS, out_coor_system = outSr, out_dataset = outDS }, null);
        }

    }

    public static partial class JTGP {

        public static void Dissolve(IFeatureClass inFeatureClass, string outFeatureClass) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new Dissolve { in_features = inFeatureClass, out_feature_class = outFeatureClass, }, null);
        }

        public static void Dissolve(string inFeatureClass, string outFeatureClass) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new Dissolve { in_features = inFeatureClass, out_feature_class = outFeatureClass, }, null);
        }

    }

    public static partial class JTGP {

        public static void FeatureToLine(string inFeatureClass, string outFeatureClass) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new FeatureToLine { in_features = inFeatureClass, out_feature_class = outFeatureClass }, null);
        }

        // Call error
        //public static void FeatureToLine(IFeatureClass inFeatureClass, string outFeatureClass) {
        //    new Geoprocessor { OverwriteOutput = true, }.Execute(new FeatureToLine { in_features = inFeatureClass, out_feature_class = outFeatureClass }, null);
        //}

    }

    public static partial class JTGP {

        public static void Clip(IFeatureClass inFeatureClass, IFeatureClass clipFeatureClass, string outFeatureClass) {
            new Geoprocessor { OverwriteOutput = true, }.Execute(new ESRI.ArcGIS.AnalysisTools.Clip { in_features = inFeatureClass, clip_features = clipFeatureClass, out_feature_class = outFeatureClass }, null);
        }

    }

    public static partial class JTGP {

        public static void ExportTopologyErrors(ITopology inTopology, IWorkspace outWorkspace, string outBasename) {
            new Geoprocessor { OverwriteOutput = true }.Execute(new ExportTopologyErrors { in_topology = inTopology, out_path = outWorkspace, out_basename = outBasename, }, null);
        }

        public static void ExportTopologyErrors(ITopology inTopology, IWorkspace outWorkspace, string outBasename, out string outPointFCName, out string outPolylineFCName, out string outPolygonFCName) {
            new Geoprocessor { OverwriteOutput = true }.Execute(new ExportTopologyErrors { in_topology = inTopology, out_path = outWorkspace, out_basename = outBasename, }, null);
            outPointFCName = outBasename + "_point";
            outPolylineFCName = outBasename + "_line";
            outPolygonFCName = outBasename + "_poly";
        }

    }

    public static partial class JTGP {

        public enum AppendSchemaType {
            [JTEnumExt.JTEnumStringAttribute("TEST")]
            Test,
            [JTEnumExt.JTEnumStringAttribute("NO_TEST")]
            NoTest,
        }

        public abstract class FieldMapping {
            internal abstract string GenerateFieldMapping(ITable inTable, ITable targetTable);
        }

        public class OneToOneFieldMapping : FieldMapping {

            public string InFieldName { get; set; }
            public string TargetFieldName { get; set; }

            internal override string GenerateFieldMapping(ITable inTable, ITable targetTable) {
                StringBuilder sb = new StringBuilder();

                if (string.IsNullOrEmpty(TargetFieldName)) { return ""; }

                var targetFieldIndex = targetTable.FindField(TargetFieldName);
                if (targetFieldIndex < 0) { throw new Exception(); }
                var targetField = targetTable.Fields.Field[targetFieldIndex];

                if (string.IsNullOrEmpty(InFieldName)) { return GenerateSingleFieldMapping(targetField, null, null); }

                var inFieldIndex = inTable.FindField(InFieldName);
                if (inFieldIndex < 0) { throw new Exception(); }

                string inFeatureClassPath = "";
                if (inTable is IFeatureClass) {
                    var inFeatureClass = inTable as IFeatureClass;
                    if (inFeatureClass.FeatureDataset != null) {
                        var ds = inFeatureClass as IDataset;
                        var fds = inFeatureClass.FeatureDataset;
                        var ws = fds.Workspace;
                        inFeatureClassPath = ws.PathName + "\\" + fds.Name + "\\" + ds.Name;
                    } else {
                        var ds = inTable as IDataset;
                        var ws = ds.Workspace;
                        inFeatureClassPath = ws.PathName + "\\" + ds.Name;
                    }
                } else {
                    var ds = inTable as IDataset;
                    var ws = ds.Workspace;
                    inFeatureClassPath = ws.PathName + "\\" + ds.Name;
                }

                return GenerateSingleFieldMapping(targetField, inFeatureClassPath, InFieldName);
            }

            private string GenerateSingleFieldMapping(IField targetField, string inFieldTablePath, string inFieldName) {
                StringBuilder sb = new StringBuilder();
                if (targetField == null) { throw new Exception(); }
                var tName = targetField.Name;
                var tAlias = targetField.AliasName;
                var tEditable = targetField.Editable.ToString().ToLower();
                var tNullable = targetField.IsNullable.ToString().ToLower();
                var tRequire = targetField.Required.ToString().ToLower();
                var tLength = targetField.Length.ToString();
                var tTypeStr = "";
                switch (targetField.Type) {
                    case esriFieldType.esriFieldTypeString: tTypeStr = "Text"; break;
                    case esriFieldType.esriFieldTypeDouble: tTypeStr = "Double"; break;
                    case esriFieldType.esriFieldTypeSmallInteger: tTypeStr = "Short"; break;
                    case esriFieldType.esriFieldTypeInteger: tTypeStr = "Long"; break;
                    case esriFieldType.esriFieldTypeSingle: tTypeStr = "Float"; break;
                    case esriFieldType.esriFieldTypeDate: tTypeStr = "Date"; break;
                    default: throw new Exception();
                }
                var tScale = targetField.Scale.ToString();
                var tPrecision = targetField.Precision.ToString();

                string targetStr = tName + " \"" + tAlias + "\" " + tEditable + " " + tNullable + " " + tRequire + " " + tLength + " " + tTypeStr + " " + tScale + " " + tPrecision + " ";
                sb.Append(targetStr);
                sb.Append(",First,#");

                if (string.IsNullOrEmpty(inFieldTablePath) || string.IsNullOrEmpty(inFieldName)) {
                    sb.Append(";");
                    return sb.ToString();
                }

                if (string.IsNullOrEmpty(inFieldTablePath)) { throw new Exception(); }
                if (string.IsNullOrEmpty(inFieldName)) { throw new Exception(); }

                sb.Append(",");
                sb.Append(inFieldTablePath);
                sb.Append(",");
                sb.Append(inFieldName);
                sb.Append(",");
                sb.Append("-1");
                sb.Append(",");
                sb.Append("-1");
                sb.Append(";");
                return sb.ToString();
            }
        }

        public static void Append(IFeatureClass inFeatureClass, IFeatureClass targetFeatureClass, AppendSchemaType schemaType, FieldMapping[] fieldMapping = null, string subType = null) {
            var append = new Append { inputs = inFeatureClass, target = targetFeatureClass, schema_type = schemaType.JTAttributeValue<string>() };
            if (fieldMapping != null && fieldMapping.Length > 0) {
                StringBuilder sb = new StringBuilder();
                foreach (var fm in fieldMapping) {
                    sb.Append(fm.GenerateFieldMapping(inFeatureClass as ITable, targetFeatureClass as ITable));
                }
                append.field_mapping = sb.ToString();
            }
            if (!string.IsNullOrEmpty(subType)) { append.subtype = subType; }
            new Geoprocessor { OverwriteOutput = true }.Execute(append, null);
        }

        public static void Append(ITable inTable, ITable targetTable, AppendSchemaType schemaType, FieldMapping[] fieldMapping = null, string subType = null) {
            var append = new Append { inputs = inTable, target = targetTable, schema_type = schemaType.JTAttributeValue<string>() };
            if (fieldMapping != null && fieldMapping.Length > 0) {
                StringBuilder sb = new StringBuilder();
                foreach (var fm in fieldMapping) {
                    sb.Append(fm.GenerateFieldMapping(inTable, targetTable));
                }
                append.field_mapping = sb.ToString();
            }
            if (!string.IsNullOrEmpty(subType)) { append.subtype = subType; }
            new Geoprocessor { OverwriteOutput = true }.Execute(append, null);
        }

        public static void Append(string[] inDatasets, string targetDataset, AppendSchemaType schemaType, string fieldMapping = null, string subType = null) {
            var inDSs = "";
            foreach (var inDS in inDatasets) { inDSs += "'" + inDS + "';"; }
            var append = new Append { inputs = inDSs, target = targetDataset, schema_type = schemaType.JTAttributeValue<string>() };
            if (fieldMapping != null) { append.field_mapping = fieldMapping; }
            if (!string.IsNullOrEmpty(subType)) { append.subtype = subType; }
            new Geoprocessor { OverwriteOutput = true }.Execute(append, null);
        }

        public static void AppendAutoMatchField(IFeatureClass inFeatureClass, IFeatureClass targetFeatureClass) {
            Append(inFeatureClass, targetFeatureClass, AppendSchemaType.Test);
        }

        public static void AppendAutoMatchField(ITable inTable, ITable targetTable) {
            Append(inTable, targetTable, AppendSchemaType.Test);
        }

        public static void AppendAutoMatchField(string[] inDatasets, string targetDataset) {
            Append(inDatasets, targetDataset, AppendSchemaType.Test);
        }

    }

    public static partial class JTGP {

        public enum RasterDomainOutType {
            [JTEnumExt.JTEnumStringAttribute("Polygon")]
            Polygon,
            [JTEnumExt.JTEnumStringAttribute("Line")]
            Line,
        }

        public static void RasterDomain(IRasterDataset inRaster, string outFeatureClass, RasterDomainOutType outType) {
            new Geoprocessor { OverwriteOutput = true }.Execute(new RasterDomain {
                in_raster = inRaster,
                out_feature_class = outFeatureClass,
                out_geometry_type = outType.JTAttributeValue<string>(),
            }, null);
        }

    }

    public static partial class JTGP {
        public static void DeleteIdentical(string inDataset, string fieldname) {
            new Geoprocessor { OverwriteOutput = true }.Execute(new DeleteIdentical {
                in_dataset = inDataset,
                fields = fieldname,
            }, null);
        }
    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }

    public static partial class JTGP {

    }
}
