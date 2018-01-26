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
	[Guid("91dc4190-4375-406b-be79-8bff1db1cc5f")]
	public partial class IfcRelSpaceBoundary : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcSpace _RelatingSpace;
	
		[DataMember(Order=1)] 
		IfcElement _RelatedBuildingElement;
	
		[DataMember(Order=2)] 
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
	
		public IfcRelSpaceBoundary(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcSpace __RelatingSpace, IfcElement __RelatedBuildingElement, IfcConnectionGeometry __ConnectionGeometry, IfcPhysicalOrVirtualEnum __PhysicalOrVirtualBoundary, IfcInternalOrExternalEnum __InternalOrExternalBoundary)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingSpace = __RelatingSpace;
			this._RelatedBuildingElement = __RelatedBuildingElement;
			this._ConnectionGeometry = __ConnectionGeometry;
			this._PhysicalOrVirtualBoundary = __PhysicalOrVirtualBoundary;
			this._InternalOrExternalBoundary = __InternalOrExternalBoundary;
		}
	
		[Description("Reference to one spaces that is delimited by this boundary.")]
		public IfcSpace RelatingSpace { get { return this._RelatingSpace; } set { this._RelatingSpace = value;} }
	
		[Description(@"<EPM-HTML>
	Reference to <strike>Building</strike> Element, that defines the Space Boundaries.
	<blockquote><small><font color=""#ff0000"">
	IFC2x PLATFORM CHANGE: The data type has been changed from <i>IfcBuildingElement</i> to <i>IfcElement</i> with upward compatibility for file based exchange.
	</font></small></blockquote>
	</EPM-HTML>
	")]
		public IfcElement RelatedBuildingElement { get { return this._RelatedBuildingElement; } set { this._RelatedBuildingElement = value;} }
	
		[Description(@"<EPM-HTML>
	Physical representation of the space boundary. Provided as a <u>curve or</u> surface given within the LCS of the space.
	<blockquote><small><font color=""#ff0000"">
	IFC2x PLATFORM CHANGE&nbsp; The data type has been changed from <i>IfcConnectionSurfaceGeometry</i> to <i>IfcConnectionGeometry</i> with upward compatibility for file based exchange.
	</font></small></blockquote>
	</EPM-HTML>
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
