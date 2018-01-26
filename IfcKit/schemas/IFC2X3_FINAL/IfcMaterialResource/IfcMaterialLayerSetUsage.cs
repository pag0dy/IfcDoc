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

namespace BuildingSmart.IFC.IfcMaterialResource
{
	[Guid("8576ca22-e641-4d75-abb4-a57a8b12daf6")]
	public partial class IfcMaterialLayerSetUsage :
		BuildingSmart.IFC.IfcMaterialResource.IfcMaterialSelect
	{
		[DataMember(Order=0)] 
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
	
	
		public IfcMaterialLayerSetUsage()
		{
		}
	
		public IfcMaterialLayerSetUsage(IfcMaterialLayerSet __ForLayerSet, IfcLayerSetDirectionEnum __LayerSetDirection, IfcDirectionSenseEnum __DirectionSense, IfcLengthMeasure __OffsetFromReferenceLine)
		{
			this._ForLayerSet = __ForLayerSet;
			this._LayerSetDirection = __LayerSetDirection;
			this._DirectionSense = __DirectionSense;
			this._OffsetFromReferenceLine = __OffsetFromReferenceLine;
		}
	
		[Description("<EPM-HTML>\r\nThe <i>IfcMaterialLayerSet</i> set to which the usage is applied.\r\n</" +
	    "EPM-HTML>")]
		public IfcMaterialLayerSet ForLayerSet { get { return this._ForLayerSet; } set { this._ForLayerSet = value;} }
	
		[Description(@"<EPM-HTML>
	Orientation of the layer set relative to element reference geometry. The meaning of the value of this attribute shall be specified in the geometry use section for each element. For extruded shape representation, direction can be given along the extrusion path (e.g. for slabs) or perpendicular to it (e.g. for walls).
	<blockquote><small>NOTE&nbsp; the <i>LayerSetDirection</i> for <i>IfcWallStandardCase</i> shall be AXIS2 (i.e. the y-axis) and for standard <i>IfcSlab</i> it shall be AXIS3 (i.e. the z-axis).
	</small></blockquote>
	</EPM-HTML>")]
		public IfcLayerSetDirectionEnum LayerSetDirection { get { return this._LayerSetDirection; } set { this._LayerSetDirection = value;} }
	
		[Description(@"<EPM-HTML>
	Denotion whether the layer set is oriented in positive or negative sense relative to the material layer set base. The meaning of ""positive"" and ""negative"" needs to be established in the geometry use definitions. See examples at <i>IfcMaterialLayerSetUsage</i> for a guideline as well.
	</EPM-HTML>")]
		public IfcDirectionSenseEnum DirectionSense { get { return this._DirectionSense; } set { this._DirectionSense = value;} }
	
		[Description(@"<EPM-HTML>
	Offset of the material layer set base line (MlsBase) from reference geometry (line or plane). The offset can be positive or negative, unless restricted for a particular building element type in its use definition or by implementer agreement. The reference geometry for each relevant subtype of <i>IfcElement</i> is defined in use definition for the element. Examples are given in the use definition of <i>IfcMaterialLayerSetUsage</i>.
	<EPM-HTML>")]
		public IfcLengthMeasure OffsetFromReferenceLine { get { return this._OffsetFromReferenceLine; } set { this._OffsetFromReferenceLine = value;} }
	
	
	}
	
}
