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
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcConstraintResource
{
	public partial class IfcResourceConstraintRelationship : IfcResourceLevelRelationship
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The constraint that is to be related.")]
		[Required()]
		public IfcConstraint RelatingConstraint { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The properties to which a constraint is to be related.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcResourceObjectSelect> RelatedResourceObjects { get; protected set; }
	
	
		public IfcResourceConstraintRelationship(IfcLabel? __Name, IfcText? __Description, IfcConstraint __RelatingConstraint, IfcResourceObjectSelect[] __RelatedResourceObjects)
			: base(__Name, __Description)
		{
			this.RelatingConstraint = __RelatingConstraint;
			this.RelatedResourceObjects = new HashSet<IfcResourceObjectSelect>(__RelatedResourceObjects);
		}
	
	
	}
	
}
