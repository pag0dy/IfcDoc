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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	public partial class IfcTrapeziumProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The extent of the bottom line measured along the implicit x-axis.")]
		[Required()]
		public IfcPositiveLengthMeasure BottomXDim { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The extent of the top line measured along the implicit x-axis.")]
		[Required()]
		public IfcPositiveLengthMeasure TopXDim { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The extent of the distance between the parallel bottom and top lines measured along the implicit y-axis.")]
		[Required()]
		public IfcPositiveLengthMeasure YDim { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Offset from the beginning of the top line to the bottom line, measured along the implicit x-axis.")]
		[Required()]
		public IfcLengthMeasure TopXOffset { get; set; }
	
	
		public IfcTrapeziumProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __BottomXDim, IfcPositiveLengthMeasure __TopXDim, IfcPositiveLengthMeasure __YDim, IfcLengthMeasure __TopXOffset)
			: base(__ProfileType, __ProfileName, __Position)
		{
			this.BottomXDim = __BottomXDim;
			this.TopXDim = __TopXDim;
			this.YDim = __YDim;
			this.TopXOffset = __TopXOffset;
		}
	
	
	}
	
}
