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
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("42319f70-e8d2-4b5b-8920-101a38252ebe")]
	public partial class IfcElementAssembly : IfcElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcAssemblyPlaceEnum? _AssemblyPlace;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcElementAssemblyTypeEnum _PredefinedType;
	
	
		public IfcElementAssembly()
		{
		}
	
		public IfcElementAssembly(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcAssemblyPlaceEnum? __AssemblyPlace, IfcElementAssemblyTypeEnum __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._AssemblyPlace = __AssemblyPlace;
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("A designation of where the assembly is intended to take place defined by an Enum." +
	    "")]
		public IfcAssemblyPlaceEnum? AssemblyPlace { get { return this._AssemblyPlace; } set { this._AssemblyPlace = value;} }
	
		[Description("Predefined generic types for a element assembly that are specified in an enumerat" +
	    "ion.")]
		public IfcElementAssemblyTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
