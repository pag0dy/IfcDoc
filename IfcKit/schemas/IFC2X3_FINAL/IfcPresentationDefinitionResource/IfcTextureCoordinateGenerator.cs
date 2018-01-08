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
	[Guid("f74d17a0-4ce5-490b-a72b-803150ebe125")]
	public partial class IfcTextureCoordinateGenerator : IfcTextureCoordinate
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Mode;
	
		[DataMember(Order=1)] 
		[Required()]
		IList<IfcSimpleValue> _Parameter = new List<IfcSimpleValue>();
	
	
		[Description("The mode describes the algorithm used to compute texture coordinates.")]
		public IfcLabel Mode { get { return this._Mode; } set { this._Mode = value;} }
	
		[Description("The parameter used by the function as specified by Mode.")]
		public IList<IfcSimpleValue> Parameter { get { return this._Parameter; } }
	
	
	}
	
}
