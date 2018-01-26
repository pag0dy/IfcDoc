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
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedComponentElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("ca6074f0-a8aa-4b5b-a402-931d20010f8b")]
	public abstract partial class IfcReinforcingElement : IfcElementComponent
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _SteelGrade;
	
	
		public IfcReinforcingElement()
		{
		}
	
		public IfcReinforcingElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcLabel? __SteelGrade)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._SteelGrade = __SteelGrade;
		}
	
		[Description("Deprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute depr" +
	    "ecated.\r\nUse material association at <em>IfcReinforcingElementType</em> instead." +
	    "</blockquote>")]
		public IfcLabel? SteelGrade { get { return this._SteelGrade; } set { this._SteelGrade = value;} }
	
	
	}
	
}
