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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("ce48ff3e-4c67-45a7-9a8a-e3127ce53668")]
	public partial class IfcReferent : IfcPositioningElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcReferentTypeEnum? _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLengthMeasure? _RestartDistance;
	
	
		public IfcReferent()
		{
		}
	
		public IfcReferent(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcReferentTypeEnum? __PredefinedType, IfcLengthMeasure? __RestartDistance)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this._PredefinedType = __PredefinedType;
			this._RestartDistance = __RestartDistance;
		}
	
		[Description("Predefined types to define the particular type of the referent.")]
		public IfcReferentTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("Optional value in case of broken linear referencing required to keep stationing f" +
	    "urther down the alignment unchanged.")]
		public IfcLengthMeasure? RestartDistance { get { return this._RestartDistance; } set { this._RestartDistance = value;} }
	
	
	}
	
}
