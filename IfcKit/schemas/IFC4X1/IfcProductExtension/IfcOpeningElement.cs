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
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("20f5b3eb-0852-4587-a1e1-bb91ca98bc61")]
	public partial class IfcOpeningElement : IfcFeatureElementSubtraction
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcOpeningElementTypeEnum? _PredefinedType;
	
		[InverseProperty("RelatingOpeningElement")] 
		[XmlElement]
		ISet<IfcRelFillsElement> _HasFillings = new HashSet<IfcRelFillsElement>();
	
	
		public IfcOpeningElement()
		{
		}
	
		public IfcOpeningElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcOpeningElementTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description(@"Predefined generic type for an opening that is specified in an enumeration. There may be a property set given specificly for the predefined types.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  The attribute has been added at the end of the entity definition.</blockquote> ")]
		public IfcOpeningElementTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("Reference to the Filling Relationship that is used to assign Elements as Fillings" +
	    " for this Opening Element. The Opening Element can be filled with zero-to-many E" +
	    "lements.\r\n")]
		public ISet<IfcRelFillsElement> HasFillings { get { return this._HasFillings; } }
	
	
	}
	
}
