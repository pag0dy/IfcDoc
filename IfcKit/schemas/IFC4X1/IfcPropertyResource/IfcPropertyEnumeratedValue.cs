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
using BuildingSmart.IFC.IfcApprovalResource;
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
	[Guid("0d3d63a5-9a73-4f49-a809-6383082c2216")]
	public partial class IfcPropertyEnumeratedValue : IfcSimpleProperty
	{
		[DataMember(Order=0)] 
		IList<IfcValue> _EnumerationValues = new List<IfcValue>();
	
		[DataMember(Order=1)] 
		[XmlElement]
		IfcPropertyEnumeration _EnumerationReference;
	
	
		[Description(@"Enumeration values, which shall be listed in the referenced <em>IfcPropertyEnumeration</em>, if such a reference is provided.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute has been made optional with upward compatibility for file based exchange.</blockquote>")]
		public IList<IfcValue> EnumerationValues { get { return this._EnumerationValues; } }
	
		[Description("Enumeration from which a enumeration value has been selected. The referenced enum" +
	    "eration also establishes the unit of the enumeration value.")]
		public IfcPropertyEnumeration EnumerationReference { get { return this._EnumerationReference; } set { this._EnumerationReference = value;} }
	
	
	}
	
}
