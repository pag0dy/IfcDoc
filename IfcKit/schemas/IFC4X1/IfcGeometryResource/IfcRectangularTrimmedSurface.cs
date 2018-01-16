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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("25bb1436-242e-4954-a716-597d8e9ba615")]
	public partial class IfcRectangularTrimmedSurface : IfcBoundedSurface
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcSurface _BasisSurface;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcParameterValue _U1;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcParameterValue _V1;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcParameterValue _U2;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcParameterValue _V2;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _Usense;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _Vsense;
	
	
		[Description("Surface being trimmed.")]
		public IfcSurface BasisSurface { get { return this._BasisSurface; } set { this._BasisSurface = value;} }
	
		[Description("First u parametric value.")]
		public IfcParameterValue U1 { get { return this._U1; } set { this._U1 = value;} }
	
		[Description("First v parametric value.")]
		public IfcParameterValue V1 { get { return this._V1; } set { this._V1 = value;} }
	
		[Description("Second u parametric value.")]
		public IfcParameterValue U2 { get { return this._U2; } set { this._U2 = value;} }
	
		[Description("Second v parametric value.")]
		public IfcParameterValue V2 { get { return this._V2; } set { this._V2 = value;} }
	
		[Description("Flag to indicate whether the direction of the first parameter of the trimmed surf" +
	    "ace agrees with or opposes the sense of u in the basis surface.")]
		public IfcBoolean Usense { get { return this._Usense; } set { this._Usense = value;} }
	
		[Description("Flag to indicate whether the direction of the second parameter of the trimmed sur" +
	    "face agrees with or opposes the sense of v in the basis surface.")]
		public IfcBoolean Vsense { get { return this._Vsense; } set { this._Vsense = value;} }
	
	
	}
	
}
