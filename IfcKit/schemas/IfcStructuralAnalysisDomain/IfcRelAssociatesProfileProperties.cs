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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	public partial class IfcRelAssociatesProfileProperties : IfcRelAssociates
	{
		[DataMember(Order = 0)] 
		[Description("Profile property definition assigned to the instances.")]
		[Required()]
		public IfcProfileProperties RelatingProfileProperties { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Reference to a shape aspect with a single member of the ShapeRepresentations list. This member holds the location at which the profile properties apply.")]
		public IfcShapeAspect ProfileSectionLocation { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("<EPM-HTML> The provision of an plane angle or a direction as the measure to orient the profile definition within the elements coordinate system.  <ul>    <li>For <i>IfcStructuralCurveMember</i> the <i>IfcPlaneAngleMeasure</i> defines the &beta; angle, for columns the derivation from the structural x axis and for beams the derivation from the structural z axis. The <i>IfcDirection</i> precisely defines the orientation of the profile's structural z axis within the structural coordinate system of the analysis model.</li>  </ul>    <blockquote> <small><font color=\"#ff0000\">  IFC2x Edition 3 CHANGE&nbsp; The attribute <i>ProfileOrientation</i> is a new attribute.    </font></small></blockquote>  </EPM-HTML>")]
		public IfcOrientationSelect ProfileOrientation { get; set; }
	
	
		public IfcRelAssociatesProfileProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcRoot[] __RelatedObjects, IfcProfileProperties __RelatingProfileProperties, IfcShapeAspect __ProfileSectionLocation, IfcOrientationSelect __ProfileOrientation)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects)
		{
			this.RelatingProfileProperties = __RelatingProfileProperties;
			this.ProfileSectionLocation = __ProfileSectionLocation;
			this.ProfileOrientation = __ProfileOrientation;
		}
	
	
	}
	
}
