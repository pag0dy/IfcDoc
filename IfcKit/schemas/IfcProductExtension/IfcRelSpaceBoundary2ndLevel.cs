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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	public partial class IfcRelSpaceBoundary2ndLevel : IfcRelSpaceBoundary1stLevel
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Reference to the other space boundary of the pair of two space boundaries on either side of a space separating thermal boundary element.")]
		public IfcRelSpaceBoundary2ndLevel CorrespondingBoundary { get; set; }
	
		[InverseProperty("CorrespondingBoundary")] 
		[Description("Reference to the other space boundary of the pair of two space boundaries on either side of a space separating thermal boundary element.")]
		[MaxLength(1)]
		public ISet<IfcRelSpaceBoundary2ndLevel> Corresponds { get; protected set; }
	
	
		public IfcRelSpaceBoundary2ndLevel(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcSpaceBoundarySelect __RelatingSpace, IfcElement __RelatedBuildingElement, IfcConnectionGeometry __ConnectionGeometry, IfcPhysicalOrVirtualEnum __PhysicalOrVirtualBoundary, IfcInternalOrExternalEnum __InternalOrExternalBoundary, IfcRelSpaceBoundary1stLevel __ParentBoundary, IfcRelSpaceBoundary2ndLevel __CorrespondingBoundary)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatingSpace, __RelatedBuildingElement, __ConnectionGeometry, __PhysicalOrVirtualBoundary, __InternalOrExternalBoundary, __ParentBoundary)
		{
			this.CorrespondingBoundary = __CorrespondingBoundary;
			this.Corresponds = new HashSet<IfcRelSpaceBoundary2ndLevel>();
		}
	
	
	}
	
}
