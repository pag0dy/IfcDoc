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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("5a72f72b-2917-406d-9209-87895d0396e1")]
	public abstract partial class IfcSectionedSolid : IfcSolidModel
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCurve _Directrix;
	
		[DataMember(Order=1)] 
		[Required()]
		IList<IfcProfileDef> _CrossSections = new List<IfcProfileDef>();
	
	
		[Description("The curve used to define the sweeping operation.")]
		public IfcCurve Directrix { get { return this._Directrix; } set { this._Directrix = value;} }
	
		[Description("List of cross sections in sequential order along the <i>Directrix</i>.")]
		public IList<IfcProfileDef> CrossSections { get { return this._CrossSections; } }
	
	
	}
	
}
