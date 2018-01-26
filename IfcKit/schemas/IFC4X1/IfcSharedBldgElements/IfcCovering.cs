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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("71cd9964-d26e-4857-81b8-de24c4651a85")]
	public partial class IfcCovering : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcCoveringTypeEnum? _PredefinedType;
	
		[InverseProperty("RelatedCoverings")] 
		[MaxLength(1)]
		ISet<IfcRelCoversSpaces> _CoversSpaces = new HashSet<IfcRelCoversSpaces>();
	
		[InverseProperty("RelatedCoverings")] 
		[MaxLength(1)]
		ISet<IfcRelCoversBldgElements> _CoversElements = new HashSet<IfcRelCoversBldgElements>();
	
	
		public IfcCovering()
		{
		}
	
		public IfcCovering(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcCoveringTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description(@"Predefined types to define the particular type of the covering. There may be property set definitions available for each predefined type.
	<blockquote class=""note"">NOTE&nbsp; The <em>PredefinedType</em> shall only be used, if no <em>IfcCoveringType</em> is assigned, providing its own <em>IfcCoveringType.PredefinedType</em>.</blockquote>")]
		public IfcCoveringTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("Reference to the objectified relationship that handles the relationship of the co" +
	    "vering to the covered space.")]
		public ISet<IfcRelCoversSpaces> CoversSpaces { get { return this._CoversSpaces; } }
	
		[Description("Reference to the objectified relationship that handles the relationship of the co" +
	    "vering to the covered element.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE  R" +
	    "enamed into <em>CoversElements</em> for consistency.\r\n</blockquote>\r\n")]
		public ISet<IfcRelCoversBldgElements> CoversElements { get { return this._CoversElements; } }
	
	
	}
	
}
