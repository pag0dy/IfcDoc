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
	[Guid("166fb09e-156c-46c0-ae3d-c231cb40cd96")]
	public partial class IfcPropertyListValue : IfcSimpleProperty
	{
		[DataMember(Order=0)] 
		IList<IfcValue> _ListValues = new List<IfcValue>();
	
		[DataMember(Order=1)] 
		IfcUnit _Unit;
	
	
		[Description("<EPM-HTML>\r\nList of property values.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHAN" +
	    "GE&nbsp; The attribute has been made optional with upward compatibility for file" +
	    " based exchange.</blockquote>\r\n</EPM-HTML>")]
		public IList<IfcValue> ListValues { get { return this._ListValues; } }
	
		[Description("Unit for the list values, if not given, the default value for the measure type (g" +
	    "iven by the TYPE of nominal value) is used as defined by the global unit assignm" +
	    "ent at IfcProject.")]
		public IfcUnit Unit { get { return this._Unit; } set { this._Unit = value;} }
	
	
	}
	
}
