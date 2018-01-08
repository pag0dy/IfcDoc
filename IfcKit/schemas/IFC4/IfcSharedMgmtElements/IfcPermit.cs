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
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcQuantityResource;

namespace BuildingSmart.IFC.IfcSharedMgmtElements
{
	[Guid("68afab75-4967-4f29-8e43-1f456d2a85d0")]
	public partial class IfcPermit : IfcControl
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPermitTypeEnum? _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Status;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcText? _LongDescription;
	
	
		[Description("<EPM-HTML>\r\nIdentifies the predefined types of permit that can be granted.\r\n\r\n<bl" +
	    "ockquote class=\"change-ifc2x4\">IFC4 CHANGE  The attribute has been added.</block" +
	    "quote>\r\n\r\n</EPM-HTML>")]
		public IfcPermitTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("<EPM-HTML>\r\nThe status currently assigned to the permit.\r\n\r\n<blockquote class=\"ch" +
	    "ange-ifc2x4\">IFC4 CHANGE  The attribute has been added.</blockquote>\r\n\r\n</EPM-HT" +
	    "ML>")]
		public IfcLabel? Status { get { return this._Status; } set { this._Status = value;} }
	
		[Description("<EPM-HTML>\r\nDetailed description of the request.\r\n\r\n<blockquote class=\"change-ifc" +
	    "2x4\">IFC4 CHANGE  The attribute has been added.</blockquote>\r\n\r\n</EPM-HTML>")]
		public IfcText? LongDescription { get { return this._LongDescription; } set { this._LongDescription = value;} }
	
	
	}
	
}
