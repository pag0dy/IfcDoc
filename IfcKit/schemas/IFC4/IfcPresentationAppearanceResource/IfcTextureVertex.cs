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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("5ba3d9c4-0d1c-4b36-8793-f7b820c9de94")]
	public partial class IfcTextureVertex : IfcPresentationItem
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IList<IfcParameterValue> _Coordinates = new List<IfcParameterValue>();
	
	
		[Description("The first Coordinate[1] is the S, the second Coordinate[2] is the T parameter val" +
	    "ue.")]
		public IList<IfcParameterValue> Coordinates { get { return this._Coordinates; } }
	
	
	}
	
}
