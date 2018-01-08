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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	[Guid("0eca3f63-ee99-4b79-bd1a-4602d00d24d9")]
	public partial class IfcGeometricRepresentationContext : IfcRepresentationContext,
		BuildingSmart.IFC.IfcRepresentationResource.IfcCoordinateReferenceSystemSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcDimensionCount _CoordinateSpaceDimension;
	
		[DataMember(Order=1)] 
		Double? _Precision;
	
		[DataMember(Order=2)] 
		[XmlElement]
		[Required()]
		IfcAxis2Placement _WorldCoordinateSystem;
	
		[DataMember(Order=3)] 
		[XmlElement("IfcDirection")]
		IfcDirection _TrueNorth;
	
		[InverseProperty("ParentContext")] 
		[XmlElement]
		ISet<IfcGeometricRepresentationSubContext> _HasSubContexts = new HashSet<IfcGeometricRepresentationSubContext>();
	
	
		[Description("<EPM-HTML>The integer dimension count of the coordinate space modeled in a geomet" +
	    "ric representation context.\r\n<br>\r\n<EPM-HTML>")]
		public IfcDimensionCount CoordinateSpaceDimension { get { return this._CoordinateSpaceDimension; } set { this._CoordinateSpaceDimension = value;} }
	
		[Description(@"<EPM-HTML>Value of the model precision for geometric models. It is a double value (REAL), typically in 1E-5 to 1E-8 range, that indicates the tolerance under which two given points are still assumed to be identical. The value can be used e.g. to sets the maximum distance from an edge curve to the underlying face surface in brep models.
	</EPM-HTML>")]
		public Double? Precision { get { return this._Precision; } set { this._Precision = value;} }
	
		[Description(@"<EPM-HTML>
	Establishment of the engineering coordinate system (often referred to as the world coordinate system in CAD) for all representation contexts used by the project. 
	<blockquote class=""note"">NOTE&nbsp; It can be used to provide better numeric stability if the placement of the building(s) is far away from the origin. In most cases however it would be set to origin: (0.,0.,0.) and directions x(1.,0.,0.), y(0.,1.,0.), z(0.,0.,1.).</blockquote>
	</EPM-HTML>")]
		public IfcAxis2Placement WorldCoordinateSystem { get { return this._WorldCoordinateSystem; } set { this._WorldCoordinateSystem = value;} }
	
		[Description(@"<EPM-HTML>
	Direction of the true north, or geographic northing direction, relative to the underlying project coordinate system. It is given by a 2 dimensional direction within the xy-plane of the project coordinate system. If not present, it defaults to 0. 1., meaning that the positive Y axis of the project coordinate system equals the geographic northing direction.
	<br>
	</EPM-HTML>")]
		public IfcDirection TrueNorth { get { return this._TrueNorth; } set { this._TrueNorth = value;} }
	
		[Description("<EPM-HTML>\r\nThe set of <em>IfcGeometricRepresentationSubContexts</em> that refer " +
	    "to this <em>IfcGeometricRepresentationContext</em>.\r\n<blockquote class=\"change-i" +
	    "fc2x3\">IFC2x3 CHANGE&nbsp; New inverse attribute</blockquote>\r\n</EPM-HTML>")]
		public ISet<IfcGeometricRepresentationSubContext> HasSubContexts { get { return this._HasSubContexts; } }
	
	
	}
	
}
