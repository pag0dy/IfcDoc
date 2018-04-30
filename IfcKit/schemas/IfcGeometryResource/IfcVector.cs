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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcVector : IfcGeometricRepresentationItem,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcHatchLineDistanceSelect,
		BuildingSmart.IFC.IfcGeometryResource.IfcVectorOrDirection
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The direction of the vector.")]
		[Required()]
		public IfcDirection Orientation { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The magnitude of the vector. All vectors of Magnitude 0.0 are regarded as equal in value regardless of the orientation attribute.")]
		[Required()]
		public IfcLengthMeasure Magnitude { get; set; }
	
	
		public IfcVector(IfcDirection __Orientation, IfcLengthMeasure __Magnitude)
		{
			this.Orientation = __Orientation;
			this.Magnitude = __Magnitude;
		}
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
