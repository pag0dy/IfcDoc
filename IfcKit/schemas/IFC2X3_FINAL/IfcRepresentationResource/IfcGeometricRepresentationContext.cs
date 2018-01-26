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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	[Guid("7406559b-03a2-47f1-8cf1-320ead0e0fda")]
	public partial class IfcGeometricRepresentationContext : IfcRepresentationContext
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcDimensionCount _CoordinateSpaceDimension;
	
		[DataMember(Order=1)] 
		Double? _Precision;
	
		[DataMember(Order=2)] 
		[Required()]
		IfcAxis2Placement _WorldCoordinateSystem;
	
		[DataMember(Order=3)] 
		IfcDirection _TrueNorth;
	
		[InverseProperty("ParentContext")] 
		ISet<IfcGeometricRepresentationSubContext> _HasSubContexts = new HashSet<IfcGeometricRepresentationSubContext>();
	
	
		public IfcGeometricRepresentationContext()
		{
		}
	
		public IfcGeometricRepresentationContext(IfcLabel? __ContextIdentifier, IfcLabel? __ContextType, IfcDimensionCount __CoordinateSpaceDimension, Double? __Precision, IfcAxis2Placement __WorldCoordinateSystem, IfcDirection __TrueNorth)
			: base(__ContextIdentifier, __ContextType)
		{
			this._CoordinateSpaceDimension = __CoordinateSpaceDimension;
			this._Precision = __Precision;
			this._WorldCoordinateSystem = __WorldCoordinateSystem;
			this._TrueNorth = __TrueNorth;
		}
	
		[Description("<EPM-HTML>The integer dimension count of the coordinate space modeled in a geomet" +
	    "ric representation context.\r\n<br>\r\n<EPM-HTML>")]
		public IfcDimensionCount CoordinateSpaceDimension { get { return this._CoordinateSpaceDimension; } set { this._CoordinateSpaceDimension = value;} }
	
		[Description(@"<EPM-HTML>Value of the model precision for geometric models. It is a double value (REAL), typically in 1E-5 to 1E-8 range, that indicates the tolerance under which two given points are still assumed to be identical. The value can be used e.g. to sets the maximum distance from an edge curve to the underlying face surface in brep models.
	</EPM-HTML>")]
		public Double? Precision { get { return this._Precision; } set { this._Precision = value;} }
	
		[Description(@"<EPM-HTML>
	Establishment of the engineering coordinate system (often referred to as the world coordinate system in CAD) for all representation contexts used by the project. 
	<blockquote><small> 
	Note&nbsp; it can be used to provide better numeric stability if the placement of the building(s) is far away from the origin. In most cases however it would be set to origin: (0.,0.,0.) and directions x(1.,0.,0.), y(0.,1.,0.), z(0.,0.,1.).
	</small> </blockquote>
	</EPM-HTML>")]
		public IfcAxis2Placement WorldCoordinateSystem { get { return this._WorldCoordinateSystem; } set { this._WorldCoordinateSystem = value;} }
	
		[Description(@"<EPM-HTML>
	Direction of the true north relative to the underlying coordinate system as established by the attribute <i>WorldCoordinateSystem</i>. It is given by a direction within the xy-plane of the underlying coordinate system. If not given, it defaults to the positive direction of the y-axis of the <i>WorldCoordinateSystem</i>.
	<br>
	</EPM-HTML>")]
		public IfcDirection TrueNorth { get { return this._TrueNorth; } set { this._TrueNorth = value;} }
	
		[Description(@"<EPM-HTML>
	The set of <i>IfcGeometricRepresentationSubContexts</i> that refer to this <i>IfcGeometricRepresentationContext</i>.
	<blockquote><small>
	  <font color=""#FF0000"">IFC2x Edition 3 CHANGE&nbsp; New inverse attribute.</font>
	</small></blockquote>
	</EPM-HTML>")]
		public ISet<IfcGeometricRepresentationSubContext> HasSubContexts { get { return this._HasSubContexts; } }
	
	
	}
	
}
