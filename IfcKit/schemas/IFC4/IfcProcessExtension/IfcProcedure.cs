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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcProcessExtension
{
	[Guid("0cce4f12-90b1-4e02-a09b-0dab4f9a731c")]
	public partial class IfcProcedure : IfcProcess
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcProcedureTypeEnum? _PredefinedType;
	
	
		[Description("<EPM-HTML>\r\n    Identifies the predefined types of a procedure from which \r\n    t" +
	    "he type required may be set.\r\n</EPM-HTML>")]
		public IfcProcedureTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
