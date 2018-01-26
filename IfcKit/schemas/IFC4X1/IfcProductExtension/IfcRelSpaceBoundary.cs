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
	[Guid("b5068876-210f-4343-a93a-674f2a9e63ff")]
	public partial class IfcRelSpaceBoundary : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcSpaceBoundarySelect _RelatingSpace;
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcElement _RelatedBuildingElement;
	
		[DataMember(Order=2)] 
		[XmlElement]
		IfcConnectionGeometry _ConnectionGeometry;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcPhysicalOrVirtualEnum _PhysicalOrVirtualBoundary;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcInternalOrExternalEnum _InternalOrExternalBoundary;
	
	
		public IfcRelSpaceBoundary()
		{
		}
	
		public IfcRelSpaceBoundary(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcSpaceBoundarySelect __RelatingSpace, IfcElement __RelatedBuildingElement, IfcConnectionGeometry __ConnectionGeometry, IfcPhysicalOrVirtualEnum __PhysicalOrVirtualBoundary, IfcInternalOrExternalEnum __InternalOrExternalBoundary)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingSpace = __RelatingSpace;
			this._RelatedBuildingElement = __RelatedBuildingElement;
			this._ConnectionGeometry = __ConnectionGeometry;
			this._PhysicalOrVirtualBoundary = __PhysicalOrVirtualBoundary;
			this._InternalOrExternalBoundary = __InternalOrExternalBoundary;
		}
	
		[Description("Reference to one spaces that is delimited by this boundary.")]
		public IfcSpaceBoundarySelect RelatingSpace { get { return this._RelatingSpace; } set { this._RelatingSpace = value;} }
	
		[Description(@"Reference to <strike>Building</strike> Element, that defines the Space Boundaries.
	<blockquote class=""change-ifc2x"">IFC2x CHANGE&nbsp; The data type has been changed from <em>IfcBuildingElement</em> to <em>IfcElement</em> with upward compatibility for file based exchange. </blockquote>
	  <blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute has been changed to be mandatory.</blockquote>
	")]
		public IfcElement RelatedBuildingElement { get { return this._RelatedBuildingElement; } set { this._RelatedBuildingElement = value;} }
	
		[Description(@"Physical representation of the space boundary. Provided as a <u>curve or</u> surface given within the LCS of the space.
	<blockquote class=""change-ifc2x"">IFC2x CHANGE&nbsp; The data type has been changed from <em>IfcConnectionSurfaceGeometry</em> to <em>IfcConnectionGeometry</em> with upward compatibility for file based exchange.</blockquote>
	")]
		public IfcConnectionGeometry ConnectionGeometry { get { return this._ConnectionGeometry; } set { this._ConnectionGeometry = value;} }
	
		[Description("Defines, whether the Space Boundary is physical (Physical) or virtual (Virtual).\r" +
	    "\n")]
		public IfcPhysicalOrVirtualEnum PhysicalOrVirtualBoundary { get { return this._PhysicalOrVirtualBoundary; } set { this._PhysicalOrVirtualBoundary = value;} }
	
		[Description("Defines, whether the Space Boundary is internal (Internal), or external, i.e. adj" +
	    "acent to open space (that can be an partially enclosed space, such as terrace (E" +
	    "xternal).\r\n")]
		public IfcInternalOrExternalEnum InternalOrExternalBoundary { get { return this._InternalOrExternalBoundary; } set { this._InternalOrExternalBoundary = value;} }
	
	
	}
	
}
