// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	[Guid("2e823b55-2b4a-4eb3-ab29-2daa31a0e9d2")]
	public partial class IfcMaterialLayerSetUsage : IfcMaterialUsageDefinition
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcMaterialLayerSet _ForLayerSet;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcLayerSetDirectionEnum _LayerSetDirection;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcDirectionSenseEnum _DirectionSense;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcLengthMeasure _OffsetFromReferenceLine;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _ReferenceExtent;
	
	
		public IfcMaterialLayerSetUsage()
		{
		}
	
		public IfcMaterialLayerSetUsage(IfcMaterialLayerSet __ForLayerSet, IfcLayerSetDirectionEnum __LayerSetDirection, IfcDirectionSenseEnum __DirectionSense, IfcLengthMeasure __OffsetFromReferenceLine, IfcPositiveLengthMeasure? __ReferenceExtent)
		{
			this._ForLayerSet = __ForLayerSet;
			this._LayerSetDirection = __LayerSetDirection;
			this._DirectionSense = __DirectionSense;
			this._OffsetFromReferenceLine = __OffsetFromReferenceLine;
			this._ReferenceExtent = __ReferenceExtent;
		}
	
		[Description("The <em>IfcMaterialLayerSet</em> set to which the usage is applied.")]
		public IfcMaterialLayerSet ForLayerSet { get { return this._ForLayerSet; } set { this._ForLayerSet = value;} }
	
		[Description(@"Orientation of the material layer set relative to element reference geometry. The meaning of the value of this attribute shall be specified in the geometry use section for each element. For extruded shape representation, direction can be given along the extrusion path (e.g. for slabs) or perpendicular to it (e.g. for walls).
	
	<blockquote class=""note"">NOTE&nbsp; The <em>LayerSetDirection</em> for <em>IfcWallStandardCase</em> shall be AXIS2 (i.e. the y-axis) and for <em>IfcSlabStandardCase</em> and <em>IfcPlateStandardCase</em> it shall be AXIS3 (i.e. the z-axis).</blockquote>
	
	<blockquote class=""note"">NOTE&nbsp; Whether the material layers of the set being used shall 'grow' into the positive or negative direction of the given axis, shall be defined by <em>DirectionSense</em> attribute.</blockquote>")]
		public IfcLayerSetDirectionEnum LayerSetDirection { get { return this._LayerSetDirection; } set { this._LayerSetDirection = value;} }
	
		[Description(@"Denotes whether the material layer set is oriented in positive or negative sense along the specified axis (defined by LayerSetDirection). ""Positive"" means that the consecutive layers (the <em>IfcMaterialLayer</em> instances in the list of <em> IfcMaterialLayerSet.MaterialLayers</em>) are placed face-by-face in the direction of the positive axis as established by LayerSetDirection: for AXIS2 it would be in +y, for AXIS3 it would be +z. ""Negative"" means that the layers are placed face-by-face in the direction of the negative LayerSetDirection. In both cases,  starting at the material layer set base line.
	<blockquote class=""note"">NOTE&nbsp; the material layer set base line (MlsBase) is located by OffsetFromReferenceLine, and may be on the positive or negative side of the element reference line (or plane); positive or negative for MlsBase placement does not depend on the DirectionSense attribute, but on the relevant element axis.</blockquote>")]
		public IfcDirectionSenseEnum DirectionSense { get { return this._DirectionSense; } set { this._DirectionSense = value;} }
	
		[Description(@"Offset of the material layer set base line (MlsBase) from reference geometry (line or plane) of element. The offset can be positive or negative, unless restricted for a particular building element type in its use definition or by implementer agreement. A positive value means, that the MlsBase is placed on the positive side of the reference line or plane, on the axis established by LayerSetDirection (in case of AXIS2 into the direction of +y, or in case of AXIS2 into the direction of +z). A negative value means that the MlsBase is placed on the negative side, as established by LayerSetDirection (in case of AXIS2 into the direction of -y). <blockquote class=""note"">NOTE&nbsp; the positive or negative sign in the offset only affects the MlsBase placement, it does not have any effect on the application of DirectionSense for orientation of the material layers; also DirectionSense does not change the MlsBase placement.</small></blockquote>
	")]
		public IfcLengthMeasure OffsetFromReferenceLine { get { return this._OffsetFromReferenceLine; } set { this._OffsetFromReferenceLine = value;} }
	
		[Description(@"Extent of the extrusion of the elements body shape representation to which the <em>IfcMaterialLayerSetUsage</em> applies. It is used as the reference value for the upper <em>OffsetValues[2]</em> provided by the <em>IfcMaterialLayerSetWithOffsets</em> subtype for included material layers.
	
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; New attribute added to the end of attribute list.</blockquote>
	<blockquote class=""note"">NOTE&nbsp; The attribute <em>ReferenceExtent</em> shall be asserted, if an <em>IfcMaterialLayerSetWithOffsets</em> is included in the <em>ForLayerSet.MaterialLayers</em> list of material layers.</blockquote>
	<blockquote class=""note"">NOTE&nbsp; The <em>ReferenceExtent</em> for <em>IfcWallStandardCase</em> is the reference height starting at z=0 being the XY plane of the object coordinate system.</blockquote>")]
		public IfcPositiveLengthMeasure? ReferenceExtent { get { return this._ReferenceExtent; } set { this._ReferenceExtent = value;} }
	
	
	}
	
}
