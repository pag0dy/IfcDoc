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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	public partial class IfcCovering : IfcBuildingElement
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Predefined types to define the particular type of the covering. There may be property set definitions available for each predefined type.  <blockquote class=\"note\">NOTE&nbsp; The <em>PredefinedType</em> shall only be used, if no <em>IfcCoveringType</em> is assigned, providing its own <em>IfcCoveringType.PredefinedType</em>.</blockquote>")]
		public IfcCoveringTypeEnum? PredefinedType { get; set; }
	
		[InverseProperty("RelatedCoverings")] 
		[Description("Reference to the objectified relationship that handles the relationship of the covering to the covered space.")]
		[MaxLength(1)]
		public ISet<IfcRelCoversSpaces> CoversSpaces { get; protected set; }
	
		[InverseProperty("RelatedCoverings")] 
		[Description("Reference to the objectified relationship that handles the relationship of the covering to the covered element.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  Renamed into <em>CoversElements</em> for consistency.  </blockquote>  ")]
		[MaxLength(1)]
		public ISet<IfcRelCoversBldgElements> CoversElements { get; protected set; }
	
	
		public IfcCovering(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcCoveringTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this.PredefinedType = __PredefinedType;
			this.CoversSpaces = new HashSet<IfcRelCoversSpaces>();
			this.CoversElements = new HashSet<IfcRelCoversBldgElements>();
		}
	
	
	}
	
}
