// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
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
	public partial class IfcMaterialLayerSetUsage :
		BuildingSmart.IFC.IfcMaterialResource.IfcMaterialSelect
	{
		[DataMember(Order = 0)] 
		[Description("<EPM-HTML>  The <i>IfcMaterialLayerSet</i> set to which the usage is applied.  </EPM-HTML>")]
		[Required()]
		public IfcMaterialLayerSet ForLayerSet { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  Orientation of the layer set relative to element reference geometry. The meaning of the value of this attribute shall be specified in the geometry use section for each element. For extruded shape representation, direction can be given along the extrusion path (e.g. for slabs) or perpendicular to it (e.g. for walls).  <blockquote><small>NOTE&nbsp; the <i>LayerSetDirection</i> for <i>IfcWallStandardCase</i> shall be AXIS2 (i.e. the y-axis) and for standard <i>IfcSlab</i> it shall be AXIS3 (i.e. the z-axis).  </small></blockquote>  </EPM-HTML>")]
		[Required()]
		public IfcLayerSetDirectionEnum LayerSetDirection { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  Denotion whether the layer set is oriented in positive or negative sense relative to the material layer set base. The meaning of \"positive\" and \"negative\" needs to be established in the geometry use definitions. See examples at <i>IfcMaterialLayerSetUsage</i> for a guideline as well.  </EPM-HTML>")]
		[Required()]
		public IfcDirectionSenseEnum DirectionSense { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  Offset of the material layer set base line (MlsBase) from reference geometry (line or plane). The offset can be positive or negative, unless restricted for a particular building element type in its use definition or by implementer agreement. The reference geometry for each relevant subtype of <i>IfcElement</i> is defined in use definition for the element. Examples are given in the use definition of <i>IfcMaterialLayerSetUsage</i>.  <EPM-HTML>")]
		[Required()]
		public IfcLengthMeasure OffsetFromReferenceLine { get; set; }
	
	
		public IfcMaterialLayerSetUsage(IfcMaterialLayerSet __ForLayerSet, IfcLayerSetDirectionEnum __LayerSetDirection, IfcDirectionSenseEnum __DirectionSense, IfcLengthMeasure __OffsetFromReferenceLine)
		{
			this.ForLayerSet = __ForLayerSet;
			this.LayerSetDirection = __LayerSetDirection;
			this.DirectionSense = __DirectionSense;
			this.OffsetFromReferenceLine = __OffsetFromReferenceLine;
		}
	
	
	}
	
}
