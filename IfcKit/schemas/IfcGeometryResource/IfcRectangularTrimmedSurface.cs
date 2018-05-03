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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcRectangularTrimmedSurface : IfcBoundedSurface
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Surface being trimmed.")]
		[Required()]
		public IfcSurface BasisSurface { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("First u parametric value.")]
		[Required()]
		public IfcParameterValue U1 { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("First v parametric value.")]
		[Required()]
		public IfcParameterValue V1 { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Second u parametric value.")]
		[Required()]
		public IfcParameterValue U2 { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Second v parametric value.")]
		[Required()]
		public IfcParameterValue V2 { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Flag to indicate whether the direction of the first parameter of the trimmed surface agrees with or opposes the sense of u in the basis surface.")]
		[Required()]
		public IfcBoolean Usense { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Flag to indicate whether the direction of the second parameter of the trimmed surface agrees with or opposes the sense of v in the basis surface.")]
		[Required()]
		public IfcBoolean Vsense { get; set; }
	
	
		public IfcRectangularTrimmedSurface(IfcSurface __BasisSurface, IfcParameterValue __U1, IfcParameterValue __V1, IfcParameterValue __U2, IfcParameterValue __V2, IfcBoolean __Usense, IfcBoolean __Vsense)
		{
			this.BasisSurface = __BasisSurface;
			this.U1 = __U1;
			this.V1 = __V1;
			this.U2 = __U2;
			this.V2 = __V2;
			this.Usense = __Usense;
			this.Vsense = __Vsense;
		}
	
	
	}
	
}
