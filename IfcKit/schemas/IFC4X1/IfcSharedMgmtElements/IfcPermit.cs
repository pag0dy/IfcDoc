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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

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
	
	
		public IfcPermit()
		{
		}
	
		public IfcPermit(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __Identification, IfcPermitTypeEnum? __PredefinedType, IfcLabel? __Status, IfcText? __LongDescription)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __Identification)
		{
			this._PredefinedType = __PredefinedType;
			this._Status = __Status;
			this._LongDescription = __LongDescription;
		}
	
		[Description("Identifies the predefined types of permit that can be granted.\r\n\r\n<blockquote cla" +
	    "ss=\"change-ifc2x4\">IFC4 CHANGE  The attribute has been added.</blockquote>")]
		public IfcPermitTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("The status currently assigned to the permit.\r\n\r\n<blockquote class=\"change-ifc2x4\"" +
	    ">IFC4 CHANGE  The attribute has been added.</blockquote>")]
		public IfcLabel? Status { get { return this._Status; } set { this._Status = value;} }
	
		[Description("Detailed description of the request.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CH" +
	    "ANGE  The attribute has been added.</blockquote>")]
		public IfcText? LongDescription { get { return this._LongDescription; } set { this._LongDescription = value;} }
	
	
	}
	
}
