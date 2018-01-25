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
	[Guid("893d5903-b4b9-47a6-b246-30c5ec310142")]
	public partial class IfcProjectOrder : IfcControl
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcProjectOrderTypeEnum? _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Status;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcText? _LongDescription;
	
	
		[Description("Predefined generic type for a project order that is specified in an enumeration. " +
	    "There may be a property set given specificly for the predefined types.\r\n\r\n<block" +
	    "quote class=\"change-ifc2x4\">IFC4 CHANGE  The attribute has been made optional.</" +
	    "blockquote>\r\n")]
		public IfcProjectOrderTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description(@"The current status of a project order.Examples of status values that might be used for a project order status include:
	<ul>
	<li>PLANNED</li>
	<li>REQUESTED</li>
	<li>APPROVED</li>
	<li>ISSUED</li>
	<li>STARTED</li>
	<li>DELAYED</li>
	<li>DONE</li>
	</ul>")]
		public IfcLabel? Status { get { return this._Status; } set { this._Status = value;} }
	
		[Description("A detailed description of the project order describing the work to be completed.")]
		public IfcText? LongDescription { get { return this._LongDescription; } set { this._LongDescription = value;} }
	
	
	}
	
}
