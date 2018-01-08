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
		[XmlElement("BINARY")]
		[Required()]
		Byte[] _RasterCode;
	
	
		[Description("<EPM-HTML>\r\nThe format of the <em>RasterCode</em> often using a compression.\r\n</E" +
	    "PM-HTML>")]
		public IfcIdentifier RasterFormat { get { return this._RasterFormat; } set { this._RasterFormat = value;} }
	
		[Description("<EPM-HTML>\r\nBlob, given as a single binary, to capture the texture within one pop" +
	    "ular file (compression) format. The file format is provided by the <em>RasterFor" +
	    "mat</em> attribute.\r\n</EPM-HTML>")]
		public Byte[] RasterCode { get { return this._RasterCode; } set { this._RasterCode = value;} }
	
	
	}
	
}
