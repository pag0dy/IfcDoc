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
	[Guid("a91157ae-e871-49c4-bbff-a0b9224d6a3a")]
	public partial class IfcProcedureType : IfcTypeProcess
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcProcedureTypeEnum _PredefinedType;
	
	
		[Description("<EPM-HTML>\r\n    Identifies the predefined types of a procedure from which \r\n    t" +
	    "he type required may be set.\r\n</EPM-HTML>")]
		public IfcProcedureTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
