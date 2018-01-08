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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	[Guid("118b09d2-c781-4701-b74a-16adaa6c69ca")]
	public partial class IfcTextureVertex
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IList<IfcParameterValue> _Coordinates = new List<IfcParameterValue>();
	
	
		[Description("The first coordinate[1] is the S, the second coordinate[2] is the T parameter val" +
	    "ue.")]
		public IList<IfcParameterValue> Coordinates { get { return this._Coordinates; } }
	
	
	}
	
}
