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
using BuildingSmart.IFC.IfcProductExtension;

namespace BuildingSmart.IFC.IfcSharedComponentElements
{
	[Guid("be8da1db-acc3-47d4-8e94-ab610f9c3be9")]
	public partial class IfcChamferEdgeFeature : IfcEdgeFeature
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _Width;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _Height;
	
	
		[Description("The width of the feature chamfer cross section.")]
		public IfcPositiveLengthMeasure? Width { get { return this._Width; } set { this._Width = value;} }
	
		[Description("The height of the feature chamfer cross section.")]
		public IfcPositiveLengthMeasure? Height { get { return this._Height; } set { this._Height = value;} }
	
	
	}
	
}
