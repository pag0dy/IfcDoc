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

using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcQuantityResource;

namespace BuildingSmart.IFC.IfcConstructionMgmtDomain
{
	[Guid("7036c849-da9d-45cc-b0e7-a07e7e66f2c5")]
	public partial class IfcCrewResourceType : IfcConstructionResourceType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcCrewResourceTypeEnum _PredefinedType;
	
	
		[Description("<EPM-HTML>\r\nDefines types of crew resources.\r\n<p></p>\r\n</EPM-HTML>")]
		public IfcCrewResourceTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
