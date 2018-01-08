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
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcStructuralElementsDomain;

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
