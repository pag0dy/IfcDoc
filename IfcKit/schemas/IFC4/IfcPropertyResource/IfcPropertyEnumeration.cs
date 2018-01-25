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
	[Guid("95f63d3d-7d92-449b-89e3-626dfacc0648")]
	public partial class IfcPropertyEnumeration : IfcPropertyAbstraction
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=1)] 
		[Required()]
		IList<IfcValue> _EnumerationValues = new List<IfcValue>();
	
		[DataMember(Order=2)] 
		IfcUnit _Unit;
	
	
		[Description("Name of this enumeration.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("List of values that form the enumeration.")]
		public IList<IfcValue> EnumerationValues { get { return this._EnumerationValues; } }
	
		[Description("Unit for the enumerator values, if not given, the default value for the measure t" +
	    "ype (given by the TYPE of nominal value) is used as defined by the global unit a" +
	    "ssignment at IfcProject.")]
		public IfcUnit Unit { get { return this._Unit; } set { this._Unit = value;} }
	
	
	}
	
}
