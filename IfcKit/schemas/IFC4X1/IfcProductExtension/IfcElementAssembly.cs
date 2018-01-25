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
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcSharedComponentElements;
using BuildingSmart.IFC.IfcSharedFacilitiesElements;
using BuildingSmart.IFC.IfcStructuralElementsDomain;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("80060d73-7260-4e2d-8f9b-46819d547abe")]
	public partial class IfcElementAssembly : IfcElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcAssemblyPlaceEnum? _AssemblyPlace;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcElementAssemblyTypeEnum? _PredefinedType;
	
	
		[Description("A designation of where the assembly is intended to take place defined by an Enum." +
	    "")]
		public IfcAssemblyPlaceEnum? AssemblyPlace { get { return this._AssemblyPlace; } set { this._AssemblyPlace = value;} }
	
		[Description(@"Predefined generic types for a element assembly that are specified in an enumeration. There might be property sets defined specifically for each predefined type.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute has been changed to be optional.</blockquote>")]
		public IfcElementAssemblyTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
