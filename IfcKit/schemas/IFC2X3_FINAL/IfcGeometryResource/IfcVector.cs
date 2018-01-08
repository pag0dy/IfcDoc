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
	[Guid("66413b9e-ccbb-40df-834e-cc1911608f9b")]
	public partial class IfcVector : IfcGeometricRepresentationItem,
		BuildingSmart.IFC.IfcGeometryResource.IfcVectorOrDirection
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcDirection _Orientation;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcLengthMeasure _Magnitude;
	
	
		[Description("The direction of the vector.")]
		public IfcDirection Orientation { get { return this._Orientation; } set { this._Orientation = value;} }
	
		[Description("The magnitude of the vector. All vectors of Magnitude 0.0 are regarded as equal i" +
	    "n value regardless of the orientation attribute.")]
		public IfcLengthMeasure Magnitude { get { return this._Magnitude; } set { this._Magnitude = value;} }
	
	
	}
	
}
