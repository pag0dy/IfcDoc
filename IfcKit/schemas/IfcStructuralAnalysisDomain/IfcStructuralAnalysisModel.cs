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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	public partial class IfcStructuralAnalysisModel : IfcSystem
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Defines the type of the structural analysis model. ")]
		[Required()]
		public IfcAnalysisModelTypeEnum PredefinedType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("If the selected model type (<em>PredefinedType</em>) describes a 2D system, the orientation defines  the analysis plane (P[1], P[2]) and the normal to the analysis plane (P[3]).  This is needed because  structural items and activities are always defined in three-dimensional space even if they are  meant to be analysed in a two-dimensional manner.    <ul>  <li>In case of predefined type IN_PLANE_LOADING_2D, the analysis is to be performed within the  projection into the P[1], P[2] plane.</li>  <li>In case of predefined type OUT_PLANE_LOADING_2D, only the P[3] component of loads and their  effects is meant to be analyzed.  This is used for beam grids and for typical slab analyses.</li>  <li>In case of predefined type LOADING_3D, <em>OrientationOf2DPlane</em> shall be omitted.</li>  </ul>")]
		public IfcAxis2Placement3D OrientationOf2DPlane { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("References to all load groups to be analyzed.")]
		[MinLength(1)]
		public ISet<IfcStructuralLoadGroup> LoadedBy { get; protected set; }
	
		[DataMember(Order = 3)] 
		[Description("References to all result groups available for this structural analysis model.")]
		[MinLength(1)]
		public ISet<IfcStructuralResultGroup> HasResults { get; protected set; }
	
		[DataMember(Order = 4)] 
		[XmlElement]
		[Description("Object placement which shall be common to all items and activities which are grouped into this instance of <em>IfcStructuralAnalysisModel</em>.  This placement establishes a coordinate system which is referred to as 'global coordinate system' in use definitions of various classes of structural items and activities.    <blockquote class=\"note\">NOTE&nbsp; Most commonly, but not necessarily, the <em>SharedPlacement</em> is an <em>IfcLocalPlacement</em> whose z axis is parallel with the z axis of the <em>IfcProject</em>'s world coordinate system and directed like the WCS z axis (i.e. pointing &quot;upwards&quot;) or directed against the WCS z axis (i.e. points &quot;downwards&quot;).</blockquote>    <blockquote class=\"note\">NOTE&nbsp; Per informal proposition, this attribute is <b>not optional</b> as soon as at least one <em>IfcStructuralItem</em> is grouped into the instance of <em>IfcStructuralAnalysisModel</em>.</blockquote>")]
		public IfcObjectPlacement SharedPlacement { get; set; }
	
	
		public IfcStructuralAnalysisModel(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcAnalysisModelTypeEnum __PredefinedType, IfcAxis2Placement3D __OrientationOf2DPlane, IfcStructuralLoadGroup[] __LoadedBy, IfcStructuralResultGroup[] __HasResults, IfcObjectPlacement __SharedPlacement)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.PredefinedType = __PredefinedType;
			this.OrientationOf2DPlane = __OrientationOf2DPlane;
			this.LoadedBy = new HashSet<IfcStructuralLoadGroup>(__LoadedBy);
			this.HasResults = new HashSet<IfcStructuralResultGroup>(__HasResults);
			this.SharedPlacement = __SharedPlacement;
		}
	
	
	}
	
}
