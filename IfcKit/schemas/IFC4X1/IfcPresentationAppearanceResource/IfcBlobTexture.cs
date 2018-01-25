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
	[Guid("6f3625b4-6b27-4ac2-8c49-34b2079baf0c")]
	public partial class IfcBlobTexture : IfcSurfaceTexture
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _RasterFormat;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcBinary _RasterCode;
	
	
		[Description("The format of the <em>RasterCode</em> often using a compression.")]
		public IfcIdentifier RasterFormat { get { return this._RasterFormat; } set { this._RasterFormat = value;} }
	
		[Description("Blob, given as a single binary, to capture the texture within one popular file (c" +
	    "ompression) format. The file format is provided by the <em>RasterFormat</em> att" +
	    "ribute.")]
		public IfcBinary RasterCode { get { return this._RasterCode; } set { this._RasterCode = value;} }
	
	
	}
	
}
