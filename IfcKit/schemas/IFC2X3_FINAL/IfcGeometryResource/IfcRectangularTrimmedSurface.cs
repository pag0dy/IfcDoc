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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("a15c5ebd-7a08-41d4-ac69-184ee254821c")]
	public partial class IfcRectangularTrimmedSurface : IfcBoundedSurface
	{
		[DataMember(Order=0)] 
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
		[Required()]
		Boolean _Usense;
	
		[DataMember(Order=6)] 
		[Required()]
		Boolean _Vsense;
	
	
		public IfcRectangularTrimmedSurface()
		{
		}
	
		public IfcRectangularTrimmedSurface(IfcSurface __BasisSurface, IfcParameterValue __U1, IfcParameterValue __V1, IfcParameterValue __U2, IfcParameterValue __V2, Boolean __Usense, Boolean __Vsense)
		{
			this._BasisSurface = __BasisSurface;
			this._U1 = __U1;
			this._V1 = __V1;
			this._U2 = __U2;
			this._V2 = __V2;
			this._Usense = __Usense;
			this._Vsense = __Vsense;
		}
	
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
		public Boolean Usense { get { return this._Usense; } set { this._Usense = value;} }
	
		[Description("Flag to indicate whether the direction of the second parameter of the trimmed sur" +
	    "face agrees with or opposes the sense of v in the basis surface.")]
		public Boolean Vsense { get { return this._Vsense; } set { this._Vsense = value;} }
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
