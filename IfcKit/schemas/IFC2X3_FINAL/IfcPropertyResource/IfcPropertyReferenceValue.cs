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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	[Guid("8d16ca24-f432-4e59-ba7a-708ef9aca421")]
	public partial class IfcPropertyReferenceValue : IfcSimpleProperty
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _UsageName;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcObjectReferenceSelect _PropertyReference;
	
	
		public IfcPropertyReferenceValue()
		{
		}
	
		public IfcPropertyReferenceValue(IfcIdentifier __Name, IfcText? __Description, IfcLabel? __UsageName, IfcObjectReferenceSelect __PropertyReference)
			: base(__Name, __Description)
		{
			this._UsageName = __UsageName;
			this._PropertyReference = __PropertyReference;
		}
	
		[Description("Description of the use of the referenced value within the property.")]
		public IfcLabel? UsageName { get { return this._UsageName; } set { this._UsageName = value;} }
	
		[Description("Reference to another entity through one of the select types in IfcObjectReference" +
	    "Select.")]
		public IfcObjectReferenceSelect PropertyReference { get { return this._PropertyReference; } set { this._PropertyReference = value;} }
	
	
	}
	
}
