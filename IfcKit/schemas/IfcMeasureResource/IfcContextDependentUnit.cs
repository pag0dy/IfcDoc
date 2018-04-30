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

namespace BuildingSmart.IFC.IfcMeasureResource
{
	public partial class IfcContextDependentUnit : IfcNamedUnit,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The word, or group of words, by which the context dependent unit is referred to.")]
		[Required()]
		public IfcLabel Name { get; set; }
	
		[InverseProperty("RelatedResourceObjects")] 
		[Description("Reference to external information, e.g. library, classification, or document information, which is associated with the context dependent unit.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE New inverse attribute</blockquote>")]
		public ISet<IfcExternalReferenceRelationship> HasExternalReference { get; protected set; }
	
	
		public IfcContextDependentUnit(IfcDimensionalExponents __Dimensions, IfcUnitEnum __UnitType, IfcLabel __Name)
			: base(__Dimensions, __UnitType)
		{
			this.Name = __Name;
			this.HasExternalReference = new HashSet<IfcExternalReferenceRelationship>();
		}
	
	
	}
	
}
