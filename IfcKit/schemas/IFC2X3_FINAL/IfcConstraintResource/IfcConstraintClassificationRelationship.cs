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
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcConstraintResource
{
	[Guid("a6df2ac5-8d86-4c6d-af26-f7f14d561b17")]
	public partial class IfcConstraintClassificationRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcConstraint _ClassifiedConstraint;
	
		[DataMember(Order=1)] 
		[Required()]
		ISet<IfcClassificationNotationSelect> _RelatedClassifications = new HashSet<IfcClassificationNotationSelect>();
	
	
		[Description("Constraint being classified")]
		public IfcConstraint ClassifiedConstraint { get { return this._ClassifiedConstraint; } set { this._ClassifiedConstraint = value;} }
	
		[Description("Classifications of the constraint.")]
		public ISet<IfcClassificationNotationSelect> RelatedClassifications { get { return this._RelatedClassifications; } }
	
	
	}
	
}
