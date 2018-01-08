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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("3162bcee-add9-4c33-b941-380bf56723b7")]
	public partial class IfcRelAssociatesProfileProperties : IfcRelAssociates
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcProfileProperties _RelatingProfileProperties;
	
		[DataMember(Order=1)] 
		IfcShapeAspect _ProfileSectionLocation;
	
		[DataMember(Order=2)] 
		IfcOrientationSelect _ProfileOrientation;
	
	
		[Description("Profile property definition assigned to the instances.")]
		public IfcProfileProperties RelatingProfileProperties { get { return this._RelatingProfileProperties; } set { this._RelatingProfileProperties = value;} }
	
		[Description("Reference to a shape aspect with a single member of the ShapeRepresentations list" +
	    ". This member holds the location at which the profile properties apply.")]
		public IfcShapeAspect ProfileSectionLocation { get { return this._ProfileSectionLocation; } set { this._ProfileSectionLocation = value;} }
	
		[Description(@"<EPM-HTML> The provision of an plane angle or a direction as the measure to orient the profile definition within the elements coordinate system.
	<ul>
	  <li>For <i>IfcStructuralCurveMember</i> the <i>IfcPlaneAngleMeasure</i> defines the &beta; angle, for columns the derivation from the structural x axis and for beams the derivation from the structural z axis. The <i>IfcDirection</i> precisely defines the orientation of the profile's structural z axis within the structural coordinate system of the analysis model.</li>
	</ul>
	  <blockquote> <small><font color=""#ff0000"">
	IFC2x Edition 3 CHANGE&nbsp; The attribute <i>ProfileOrientation</i> is a new attribute.
	  </font></small></blockquote>
	</EPM-HTML>")]
		public IfcOrientationSelect ProfileOrientation { get { return this._ProfileOrientation; } set { this._ProfileOrientation = value;} }
	
	
	}
	
}
