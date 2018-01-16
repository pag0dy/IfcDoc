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

using BuildingSmart.IFC.IfcApprovalResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;

namespace BuildingSmart.IFC.IfcControlExtension
{
	[Guid("1498678e-05c1-4f14-8e24-50a12e670b9f")]
	public partial class IfcRelAssociatesConstraint : IfcRelAssociates
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Intent;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcConstraint _RelatingConstraint;
	
	
		[Description("The intent of the constraint usage with regard to its related IfcConstraint and I" +
	    "fcObjects, IfcPropertyDefinitions or IfcRelationships. Typical values can be e.g" +
	    ". RATIONALE or EXPECTED PERFORMANCE.")]
		public IfcLabel Intent { get { return this._Intent; } set { this._Intent = value;} }
	
		[Description("Reference to constraint that is being applied using this relationship.")]
		public IfcConstraint RelatingConstraint { get { return this._RelatingConstraint; } set { this._RelatingConstraint = value;} }
	
	
	}
	
}
