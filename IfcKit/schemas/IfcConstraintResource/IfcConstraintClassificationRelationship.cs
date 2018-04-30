// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcExternalReferenceResource;

namespace BuildingSmart.IFC.IfcConstraintResource
{
	public partial class IfcConstraintClassificationRelationship
	{
		[DataMember(Order = 0)] 
		[Description("Constraint being classified")]
		[Required()]
		public IfcConstraint ClassifiedConstraint { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Classifications of the constraint.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcClassificationNotationSelect> RelatedClassifications { get; protected set; }
	
	
		public IfcConstraintClassificationRelationship(IfcConstraint __ClassifiedConstraint, IfcClassificationNotationSelect[] __RelatedClassifications)
		{
			this.ClassifiedConstraint = __ClassifiedConstraint;
			this.RelatedClassifications = new HashSet<IfcClassificationNotationSelect>(__RelatedClassifications);
		}
	
	
	}
	
}
