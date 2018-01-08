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
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	[Guid("7c1a56a5-26cf-4e5b-932f-55d94501a267")]
	public partial class IfcPropertyReferenceValue : IfcSimpleProperty
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcText? _UsageName;
	
		[DataMember(Order=1)] 
		IfcObjectReferenceSelect _PropertyReference;
	
	
		[Description("<EPM-HTML>\r\nDescription of the use of the referenced value within the property. I" +
	    "t is a descriptive text that may hold an expression or other additional informat" +
	    "ion.\r\n</EPM-HTML>")]
		public IfcText? UsageName { get { return this._UsageName; } set { this._UsageName = value;} }
	
		[Description(@"<EPM-HTML>
	Reference to another property entity through one of the select types in the <em>IfcObjectReferenceSelect</em>.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute has been made optional with upward compatibility for file based exchange.</blockquote>
	</EPM-HTML>")]
		public IfcObjectReferenceSelect PropertyReference { get { return this._PropertyReference; } set { this._PropertyReference = value;} }
	
	
	}
	
}
