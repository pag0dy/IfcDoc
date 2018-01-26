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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("002bda71-0a52-40b9-8ef9-82bc20f96bf3")]
	public partial class IfcRelSpaceBoundary2ndLevel : IfcRelSpaceBoundary1stLevel
	{
		[DataMember(Order=0)] 
		[XmlElement]
		IfcRelSpaceBoundary2ndLevel _CorrespondingBoundary;
	
		[InverseProperty("CorrespondingBoundary")] 
		[MaxLength(1)]
		ISet<IfcRelSpaceBoundary2ndLevel> _Corresponds = new HashSet<IfcRelSpaceBoundary2ndLevel>();
	
	
		public IfcRelSpaceBoundary2ndLevel()
		{
		}
	
		public IfcRelSpaceBoundary2ndLevel(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcSpaceBoundarySelect __RelatingSpace, IfcElement __RelatedBuildingElement, IfcConnectionGeometry __ConnectionGeometry, IfcPhysicalOrVirtualEnum __PhysicalOrVirtualBoundary, IfcInternalOrExternalEnum __InternalOrExternalBoundary, IfcRelSpaceBoundary1stLevel __ParentBoundary, IfcRelSpaceBoundary2ndLevel __CorrespondingBoundary)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatingSpace, __RelatedBuildingElement, __ConnectionGeometry, __PhysicalOrVirtualBoundary, __InternalOrExternalBoundary, __ParentBoundary)
		{
			this._CorrespondingBoundary = __CorrespondingBoundary;
		}
	
		[Description("Reference to the other space boundary of the pair of two space boundaries on eith" +
	    "er side of a space separating thermal boundary element.")]
		public IfcRelSpaceBoundary2ndLevel CorrespondingBoundary { get { return this._CorrespondingBoundary; } set { this._CorrespondingBoundary = value;} }
	
		[Description("Reference to the other space boundary of the pair of two space boundaries on eith" +
	    "er side of a space separating thermal boundary element.")]
		public ISet<IfcRelSpaceBoundary2ndLevel> Corresponds { get { return this._Corresponds; } }
	
	
	}
	
}
