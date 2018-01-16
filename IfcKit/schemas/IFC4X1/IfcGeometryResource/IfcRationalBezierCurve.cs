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
	[Guid("33d227e6-5f5f-4564-83b9-c46f7a472385")]
	public partial class IfcRationalBezierCurve : IfcBezierCurve
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<Double> _WeightsData = new List<Double>();
	
	
		[Description("The supplied values of the weights.")]
		public IList<Double> WeightsData { get { return this._WeightsData; } }
	
		public new Double Weights { get { return null; } }
	
	
	}
	
}
